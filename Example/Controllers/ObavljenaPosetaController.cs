using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class ObavljenaPosetaController : Controller
    {

        private StomatologContext context = new StomatologContext();

        //
        // GET: /Stomatolog/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /ObavljenaPoseta/DodajNovuObavljenuPosetu
        [Authorize(Roles = "user")]
        public ActionResult DodajNovuObavljenuPosetu()
        {
            return View(new NovaObavljenaPoseta());
        }

        // POST: /ObavljenaPoseta/DodajNovuObavljenuPosetu
        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult DodajNovuObavljenuPosetu(NovaObavljenaPoseta model)
        {
            if (ModelState.IsValid)
            {
                ObavljenaPoseta o = new ObavljenaPoseta()
                {
                    StomatologIDClanaKomore = model.StomatologIDClanaKomore,
                    PacijentIDKartona = model.PacijentIDKartona,
                    DatumVreme = new DateTime(model.Godina, model.Mesec, model.Dan, model.Sat, model.Minut, 0),
                    OpisIntervencije = model.OpisIntervencije,
                    Terapija = model.Terapija,
                    PregledaniPacijent = context.Pacijenti.Where(m => m.IDKartona == model.PacijentIDKartona).ToList().First()
                };

                context.ObavljenePosete.Add(o);
                context.SaveChanges();
                return RedirectToAction("Index", "ObavljenaPoseta");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /ObavljenaPoseta/Pretraga
        public ActionResult Pretraga()
        {
            return View(new ObavljenaPosetaViewModel());
        }

        [HttpPost]
        public ActionResult RefreshList(ObavljenaPosetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_ListaObavljenihPoseta", model);
        }

        public ActionResult DetaljiObavljenePosete(int IDPosete)
        {
            if (IDPosete == null)
                throw new Exception("");

            DetaljiObavljenaPosetaViewModel model = new DetaljiObavljenaPosetaViewModel();
            model.IDPosete = IDPosete;

            return View(model);
        }

        public ActionResult IzmeniObavljenuPosetu(int IDPosete)
        {
            if (IDPosete == null)
                throw new Exception("");
            IzmeniObavljenuPosetuViewModel model = new IzmeniObavljenuPosetuViewModel();
            model.IDPosete = IDPosete;
            model.loadData();

            return View(model);
        }

        [HttpPost]
        public ActionResult IzmeniObavljenuPosetu(IzmeniObavljenuPosetuViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.editObavljenuPosetu();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", new { Message = e.Message });
                }

            }
            return View(model);
        }

        public ActionResult ObrisiObavljenuPosetu(int IDPosete)
        {

            ObavljenaPoseta o = (from m in context.ObavljenePosete where m.IDPosete == IDPosete select m).ToList().First();
            context.ObavljenePosete.Remove(o);
            context.SaveChanges();

            return RedirectToAction("Pretraga", "ObavljenaPoseta");
        }
    }
}