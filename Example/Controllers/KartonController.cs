using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Models;

namespace Example.Controllers
{
    public class KartonController : Controller
    {

        private StomatologContext context = new StomatologContext();

        //
        // GET: /Karton/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Karton/DodajKarton
        [Authorize(Roles = "user")]
        public ActionResult DodajKarton()
        {
            return View(new NoviKarton());
        }

        // POST: /Karton/DodajKarton
        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult DodajKarton(NoviKarton model)
        {
            if (ModelState.IsValid)
            {
                Pacijent o = new Pacijent()
                {
                    StomatologIDClanaKomore = model.StomatologIDClanaKomore,
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    GodinaRodjenja = model.GodinaRodjenja,
                    JMBG = model.JMBG,
                    KontaktTelefon = model.KontaktTelefon,
                    ImeRoditelja = model.ImeRoditelja,
                    Napomena = model.Napomena,
                    Pol = model.Pol
                };

                context.Pacijenti.Add(o);
                context.SaveChanges();
                return RedirectToAction("Index", "Karton");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        // GET: /Ordinacija/Pretraga
        public ActionResult Pretraga()
        {
            return View(new KartonViewModel());
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
        public ActionResult RefreshList(KartonViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_ListaKartona", model);
        }

    }
}