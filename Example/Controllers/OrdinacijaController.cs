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

        public ActionResult DetailjiOrdinacije(int? MaticniBrojFirme)
        {
            if (MaticniBrojFirme == null)
                throw new Exception("Matični broj firme nije zadat!");

            DetaljiOrdinacijeViewModel model = new DetaljiOrdinacijeViewModel();
            model.MaticniBrojFirme = (int)MaticniBrojFirme;

            return View(model);
        }


        public ActionResult IzmeniOrdinaciju(int? MaticniBrojFirme)
        {
            if (MaticniBrojFirme == null)
                throw new Exception("Maticni broj firme nije zadat!");
            IzmeniOrdinacijuViewModel model = new IzmeniOrdinacijuViewModel();
            model.MaticniBrojFirme = (int)MaticniBrojFirme;
            model.loadData();

            return View(model);
        }

        [HttpPost]
        public ActionResult IzmeniOrdinaciju(IzmeniOrdinacijuViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.editOrdinacija();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", new { Message = e.Message });
                }

            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ObrisiOrdinaciju(int? MaticniBrojFirme)
        {

            Ordinacija o = context.Ordinacije.Where(m => m.MaticniBrojFirme == MaticniBrojFirme).SingleOrDefault();
            context.Ordinacije.Remove(o);
            context.SaveChanges();

            return RedirectToAction("Pretraga", "Ordinacija");
        }
    }
}