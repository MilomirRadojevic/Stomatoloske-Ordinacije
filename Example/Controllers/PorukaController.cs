using Example.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Example.Controllers
{
    public class PorukaController : Controller
    {
        private ApplicationUser AppUser
        {
            get
            {
                UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                return manager.FindById(User.Identity.GetUserId());
            }
        }

        private Stomatolog MessageUser
        {
            get
            {
                UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                StomatologContext context = new StomatologContext();
                var user = manager.FindById(User.Identity.GetUserId());
                var result = (from e in context.Stomatolozi
                              where e.IDClanaKomore == user.UserName
                              select e).First();
                return result;
            }


        }

        //
        // GET: /Poruka/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NovaPoruka(string PrimalacIDClanaKomore)
        {
            string ID;

            ID = PrimalacIDClanaKomore;
            NovaPorukaViewModel model = new NovaPorukaViewModel();
            model.PrimalacIDClanaKomore = ID;
            return View(model);
        }

        [HttpPost]
        public ActionResult NovaPoruka(NovaPorukaViewModel model)
        {
            if (ModelState.IsValid)
            {


                model.sacuvajPoruku(MessageUser.IDClanaKomore);
                return RedirectToAction("Index");


            }
            return View(model);
        }


        [HttpPost]
        public ActionResult NovaPoruka2(Poruka model)
        {
            if (ModelState.IsValid)
            {
                Console.Write("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                model.Salje = MessageUser;
                model.StomatologSaljeIDClanaKomore = MessageUser.IDClanaKomore;
                model.sacuvajPoruku();
                return RedirectToAction("Index");


            }
            return View(model);
        }

        public ActionResult ListaPoruka()
        {
            ListaPorukaViewModel model = new ListaPorukaViewModel();
            model.azurirajListuPoruka(MessageUser.IDClanaKomore);
            return View(model);
        }

        [HttpPost]
        public ActionResult RefreshList(ListaPorukaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.azurirajListuPoruka(MessageUser.IDClanaKomore);
            }
            return PartialView("_ListaPoruka", model);
        }


        public ActionResult ProcitajPoruku(string IDClanaKomore)
        {

            StomatologContext context = new StomatologContext();
            ICollection<Poruka> lista_poruka_primljene = context.Poruke.Where(m => m.Salje.IDClanaKomore == IDClanaKomore).ToList();
            ICollection<Poruka> lista_poruka_poslate = context.Poruke.Where(m => m.Primalac.IDClanaKomore == IDClanaKomore).ToList();

            Poruka novaPoruka = new Poruka();
            novaPoruka.Primalac = context.Stomatolozi.Where(m => m.IDClanaKomore == IDClanaKomore).ToList().First();
            novaPoruka.StomatologPrimalacIDClanaKomore = novaPoruka.Primalac.IDClanaKomore;

            lista_poruka_poslate.Add(novaPoruka);
            var pom = lista_poruka_poslate.Concat(lista_poruka_primljene);

            return View(pom.OrderBy(m => m.DatumVreme).ToList());
        }

    }
}