using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Models;

namespace Example.Controllers
{
    public class OrdinacijaController : Controller
    {

        private StomatologContext context = new StomatologContext();

        //
        // GET: /Ordinacija/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Ordinacija/DodajOrdinaciju
        [Authorize(Roles = "admin")]
        public ActionResult DodajOrdinaciju()
        {
            return View(new NovaOrdinacija());
        }

        // POST: /Ordinacija/DodajOrdinaciju
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DodajOrdinaciju(NovaOrdinacija model)
        {
            if (ModelState.IsValid)
            {
                Ordinacija o = new Ordinacija()
                {
                    Naziv = model.Naziv,
                    PIB = model.PIB,
                    MaticniBrojFirme = model.MaticniBrojFirme,
                    ImeVlasnika = model.ImeVlasnika,
                    PrezimeVlasnika = model.PrezimeVlasnika,
                    JMBG = model.JMBGVlasnika,
                    Adresa = model.Adresa,
                    Grad = model.Grad,
                    KontaktTelefon = model.KontaktTelefon
                };

                context.Ordinacije.Add(o);
                context.SaveChanges();
                return RedirectToAction("Index", "Ordinacija");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        // GET: /Ordinacija/Pretraga
        public ActionResult Pretraga()
        {
            return View(new OrdinacijaViewModel());
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
        public ActionResult RefreshList(OrdinacijaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_ListaOrdinacija", model);
        }

    }
}