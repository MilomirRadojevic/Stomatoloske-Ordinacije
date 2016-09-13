using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Models;
using Microsoft.AspNet.Identity;

namespace Example.Controllers
{
    public class KartonController : Controller
    {

        private StomatologContext context = new StomatologContext();

        //
        // GET: /Karton/
        [Authorize(Roles = "user")]

        public ActionResult Index()
        {
            return View();
        }

        // GET: /Karton/DodajKarton
        [Authorize(Roles = "user")]
        public ActionResult DodajKarton()
        {
            return View();
        }

        // POST: /Karton/DodajKarton
        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult DodajKarton(NoviKarton model)
        {
            if (ModelState.IsValid)
            {
                string IDStomatologa = User.Identity.GetUserName();
                Stomatolog izabrani = context.Stomatolozi.Where(m => m.IDClanaKomore == IDStomatologa).First();
                Pacijent o = new Pacijent()
                {
                    StomatologIDClanaKomore = IDStomatologa,
                    IzabraniStomatolog = izabrani,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    GodinaRodjenja = model.GodinaRodjenja,
                    JMBG = model.JMBG,
                    KontaktTelefon = model.KontaktTelefon,
                    ImeRoditelja = model.ImeRoditelja,
                    Napomena = model.Napomena,
                    Pol = model.Pol,
                    ObavljenePosete = new List<ObavljenaPoseta>(),
                    ZakazanePosete = new List<ZakazanaPoseta>()
                };

                context.Pacijenti.Add(o);
                context.SaveChanges();
                return RedirectToAction("Index", "Karton");
            }


            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [Authorize(Roles = "user")]

        // GET: /Ordinacija/Pretraga
        public ActionResult Pretraga()
        {
            string IDStomatologa = User.Identity.GetUserName();
            KartonViewModel pretragaKartona = new KartonViewModel
            {   
                IDStomatologa = IDStomatologa,
                Ime = "",
                Prezime = "",
                ListaKartona = (from m in context.Pacijenti
                                 where m.StomatologIDClanaKomore == IDStomatologa
                                 select m).ToList(),
                JMBG = ""
            };
            return View(pretragaKartona);
        }

        /*[HttpPost]
        public ActionResult Index(MovieListViewModel model)
        {
            if(ModelState.IsValid)
            {
              
                model.RefreshList();
            }
            return View(model);
        }*/

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult RefreshList(KartonViewModel model)
        {
            string IDStomatologa = User.Identity.GetUserName();
            model.IDStomatologa = IDStomatologa;
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_NovaListaKartona", model);
        }

        [Authorize(Roles = "user")]

        public ActionResult DetaljiKartona(int? IDKartona)
        {
            if (IDKartona == null)
                throw new Exception("ID kartona nije zadat!");

            DetaljiKartonaViewModel model = new DetaljiKartonaViewModel();
            model.IDKartona = (int)IDKartona;

            return View(model);
        }


        [Authorize(Roles = "user")]

        public ActionResult IzmeniKarton(int? IDKartona)
        {
            if (IDKartona == null)
                throw new Exception("ID kartona nije zadat!");
            IzmeniKartonViewModel model = new IzmeniKartonViewModel();
            model.IDKartona = (int)IDKartona;
            model.loadData();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult IzmeniKarton(IzmeniKartonViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.editKarton();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", new { Message = e.Message });
                }

            }
            return View(model);
        }


        [Authorize(Roles = "user")]

        public ActionResult ObrisiKarton(int? IDKartona)
        {

            Pacijent o = context.Pacijenti.Where(m => m.IDKartona == IDKartona).SingleOrDefault();
            context.Pacijenti.Remove(o);
            context.SaveChanges();

            return RedirectToAction("Pretraga", "Karton");
        }
    }
}