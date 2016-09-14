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

        StomatologContext context = new StomatologContext();
        //
        [Authorize(Roles = "user")]

        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "user")]

        public ActionResult NovaPoruka(string PrimalacIDClanaKomore)
        {
            string ID;

            ID = PrimalacIDClanaKomore;
            NovaPorukaViewModel model = new NovaPorukaViewModel();
            model.PrimalacIDClanaKomore = ID;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult NovaPoruka(NovaPorukaViewModel model)
        {
            if (ModelState.IsValid)
            {


                model.sacuvajPoruku(MessageUser.IDClanaKomore);
                return RedirectToAction("Index");


            }
            return View(model);
        }


        [Authorize(Roles = "user")]

        public ActionResult NovaPoruka2(string IDClanaKomore1 , string IDClanaKomore2)
        {
            string ulogovani = User.Identity.GetUserName();
            
            string ID;
            if (IDClanaKomore1 == ulogovani)
                ID = IDClanaKomore2;
            else
                ID = IDClanaKomore1;
            
            NovaPorukaViewModel model = new NovaPorukaViewModel();
            model.PrimalacIDClanaKomore = ID;

            model.ImePrimaoca = context.Stomatolozi.Where(m => m.IDClanaKomore == ID).First().Ime;
            model.PrezimePrimaoca = context.Stomatolozi.Where(m => m.IDClanaKomore == ID).First().Prezime;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult NovaPoruka2(NovaPorukaViewModel model)
        {
            if (ModelState.IsValid)
            {

                model.sacuvajPoruku(MessageUser.IDClanaKomore);
                return RedirectToAction("Index");
            }
            return View(model);
        }



        [Authorize(Roles = "user")]

        public ActionResult ListaPoruka()
        {
            string ulogovani = User.Identity.GetUserName();
            ListaPorukaViewModel model = new ListaPorukaViewModel();
            model.azurirajListuPoruka(ulogovani);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult RefreshList(ListaPorukaViewModel model)
        {
            string ulogovani = User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                model.azurirajListuPoruka(ulogovani);
            }
            return PartialView("_ListaPoruka", model);
        }


        [Authorize(Roles = "user")]
        public ActionResult ProcitajPoruku(string IDClanaKomore1,string IDClanaKomore2)
        {
            string trenutni = User.Identity.GetUserName();
            string ID = IDClanaKomore1 == trenutni ? IDClanaKomore2 : IDClanaKomore1;
            StomatologContext context = new StomatologContext();
            string ulogovani = User.Identity.GetUserName();
            ICollection<Poruka> lista_poruka_primljene = context.Poruke.Where(m => m.Salje.IDClanaKomore == ID).Where(m => m.Primalac.IDClanaKomore == ulogovani).ToList();
            ICollection<Poruka> lista_poruka_poslate = context.Poruke.Where(m => m.Primalac.IDClanaKomore == ID).Where(m => m.Salje.IDClanaKomore == ulogovani).ToList();

          
            var pom = lista_poruka_poslate.Concat(lista_poruka_primljene);
            ViewBag.IDClana = trenutni;
            return View(pom.OrderBy(m => m.DatumVreme).ToList());
        }

    }
}