using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class ZakazanaPosetaController : Controller
    {

        private StomatologContext context = new StomatologContext();

        //
        // GET: /Stomatolog/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /ZakazanaPoseta/ZakaziPosetu
        [Authorize(Roles = "user")]
        public ActionResult ZakaziPosetu()
        {
            return View();
        }

        // GET: /ZakazanaPoseta/PacijentSaKartonom
        [Authorize(Roles = "user")]
        public ActionResult PacijentSaKartonom()
        {
            return View(new NovaZakazanaPosetaSaKartonom());
        }

        // POST: /ZakazanaPoseta/PacijentSaKartonom
        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult PacijentSaKartonom(NovaZakazanaPosetaSaKartonom model)
        {
            if (ModelState.IsValid)
            {
                ZakazanaPoseta z = new ZakazanaPoseta()
                {
                    StomatologIDClanaKomore = model.StomatologIDClanaKomore,
                    PacijentIDKartona = (from m in context.Pacijenti
                                         where m.Ime == model.ImePacijenta &&
                                         m.Prezime == model.PrezimePacijenta &&
                                         m.JMBG == model.JMBG
                                         select m.IDKartona).ToList().First(),
                    DatumVreme = new DateTime(model.Godina, model.Mesec, model.Dan, model.Sat, model.Minut, 0),
                    ImePacijenta = model.ImePacijenta,
                    PrezimePacijenta = model.PrezimePacijenta,
                    Napomena = model.Napomena,
                    ImaKarton = true
                };

                context.ZakazanePosete.Add(z);
                context.SaveChanges();
                return RedirectToAction("Index", "ZakazanaPoseta");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /ZakazanaPoseta/PacijentBezKartona
        [Authorize(Roles = "user")]
        public ActionResult PacijentBezKartona()
        {
            return View(new NovaZakazanaPosetaBezKartona());
        }

        // POST: /ZakazanaPoseta/PacijentBezKartona
        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult PacijentBezKartona(NovaZakazanaPosetaBezKartona model)
        {
            if (ModelState.IsValid)
            {
                ZakazanaPoseta z = new ZakazanaPoseta()
                {
                    StomatologIDClanaKomore = model.StomatologIDClanaKomore,
                    PacijentIDKartona = null,
                    DatumVreme = new DateTime(model.Godina, model.Mesec, model.Dan, model.Sat, model.Minut, 0),
                    ImePacijenta = model.ImePacijenta,
                    PrezimePacijenta = model.PrezimePacijenta,
                    Napomena = model.Napomena,
                    ImaKarton = false
                };

                context.ZakazanePosete.Add(z);
                context.SaveChanges();
                return RedirectToAction("Index", "ZakazanaPoseta");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Stomatolog/Pretraga
        public ActionResult Pretraga()
        {
            return View(new ZakazanaPosetaViewModel());
        }

        [HttpPost]
        public ActionResult RefreshList(ZakazanaPosetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_ListaZakazanihPoseta", model);
        }

        public ActionResult DetaljiZakazanePosete(int IDZakazanePosete)
        {
            if (IDZakazanePosete == null)
                throw new Exception("");

            DetaljiZakazanaPosetaViewModel model = new DetaljiZakazanaPosetaViewModel();
            model.IDZakazanePosete = IDZakazanePosete;

            return View(model);
        }

        public ActionResult IzmeniZakazanuPosetu(int IDZakazanePosete)
        {
            if (IDZakazanePosete == null)
                throw new Exception("");
            IzmeniZakazanuPosetuViewModel model = new IzmeniZakazanuPosetuViewModel();
            model.IDZakazanePosete = IDZakazanePosete;
            model.loadData();

            return View(model);
        }

        [HttpPost]
        public ActionResult IzmeniZakazanuPosetu(IzmeniZakazanuPosetuViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.editZakazanuPosetu();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", new { Message = e.Message });
                }

            }
            return View(model);
        }

        public ActionResult ObrisiZakazanuPosetu(int IDZakazanePosete)
        {

            ZakazanaPoseta z = (from m in context.ZakazanePosete where m.IDZakazanePosete == IDZakazanePosete select m).ToList().First();
            context.ZakazanePosete.Remove(z);
            context.SaveChanges();

            return RedirectToAction("Pretraga", "ZakazanaPoseta");
        }
    }
}