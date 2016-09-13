using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Example.Controllers
{
    public class ZakazanaPosetaController : Controller
    {

        private StomatologContext context = new StomatologContext();

        // SREDJENO
        //
        // GET: /Stomatolog/
        [Authorize(Roles = "user")]

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


        [Authorize(Roles = "user")]

        public ActionResult PretragaKartona()
        {
            string trenutni = User.Identity.GetUserName();
            KartonViewModel pretragaKartona = new KartonViewModel
            {
                IDStomatologa = trenutni,
                Ime = "",
                Prezime = "",
                ListaKartona = (from m in context.Pacijenti
                                where m.StomatologIDClanaKomore == trenutni
                                select m).ToList(),
                JMBG = ""
            };
            return View(pretragaKartona);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult RefreshListZaKartone(KartonViewModel model)
        {
            string IDStomatologa = User.Identity.GetUserName();
            model.IDStomatologa = IDStomatologa;
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_ListaKartona", model);
        }

        // GET: /ZakazanaPoseta/PacijentSaKartonom
        [Authorize(Roles = "user")]
        public ActionResult PacijentSaKartonom(int ? IDKartona)
        {
            if (IDKartona == null)
                throw new Exception("nije izabran ID kartona");
            Pacijent novi = context.Pacijenti.Where(m => m.IDKartona == (int)IDKartona).First();
            NovaZakazanaPosetaSaKartonom novaPoseta = new NovaZakazanaPosetaSaKartonom();
            DateTime now = DateTime.Now;
            novaPoseta.Dan = now.Day;
            novaPoseta.Mesec = now.Month;
            novaPoseta.Godina = now.Year;
            novaPoseta.Sat = now.Hour;
            novaPoseta.Minut = now.Minute;
            novaPoseta.StomatologIDClanaKomore = novi.StomatologIDClanaKomore;
            novaPoseta.IDKartona = (int)IDKartona;
            novaPoseta.ImePacijenta = novi.Ime;
            novaPoseta.PrezimePacijenta = novi.Prezime;
            novaPoseta.JMBG = novi.JMBG;
            novaPoseta.Napomena = "";
            return View(novaPoseta);
        }

        // POST: /ZakazanaPoseta/PacijentSaKartonom
        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult PacijentSaKartonom(NovaZakazanaPosetaSaKartonom model)
        {
            if (ModelState.IsValid)
            {
                string IDStomatologa = User.Identity.GetUserName();
                Stomatolog trenutni = context.Stomatolozi.Where(m => m.IDClanaKomore == IDStomatologa).First();
                Pacijent novaPoseta = context.Pacijenti.Where(m => m.IDKartona == model.IDKartona).First();
                ZakazanaPoseta z = new ZakazanaPoseta()
                {
                    StomatologIDClanaKomore =IDStomatologa,
                    Zakazao = trenutni,
                    ZakazanPacijent = novaPoseta,
                    PacijentIDKartona = novaPoseta.IDKartona,
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
            string IDStomatologa = User.Identity.GetUserName();
            NovaZakazanaPosetaBezKartona novaPoseta = new NovaZakazanaPosetaBezKartona();
            DateTime now = DateTime.Now;
            novaPoseta.Dan = now.Day;
            novaPoseta.Mesec = now.Month;
            novaPoseta.Godina = now.Year;
            novaPoseta.Sat = now.Hour;
            novaPoseta.Minut = now.Minute;
            novaPoseta.StomatologIDClanaKomore = IDStomatologa;
            return View(novaPoseta);
        }

        // POST: /ZakazanaPoseta/PacijentBezKartona
        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult PacijentBezKartona(NovaZakazanaPosetaBezKartona model)
        {
            if (ModelState.IsValid)
            {
                string IDStomatologa = User.Identity.GetUserName();
                Stomatolog trenutni = context.Stomatolozi.Where(m => m.IDClanaKomore == IDStomatologa).First();
                ZakazanaPoseta z = new ZakazanaPoseta()
                {
                    StomatologIDClanaKomore = IDStomatologa,
                    PacijentIDKartona = null,
                    Zakazao = trenutni,
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
        [Authorize(Roles = "user")]

        public ActionResult Pretraga()
        {
            string IDStomatologa = User.Identity.GetUserName();
            DateTime dt = DateTime.Now;
            ZakazanaPosetaViewModel nova = new ZakazanaPosetaViewModel
            {
                Dan1 = dt.Day,
                Mesec1 = dt.Month,
                Godina1 = dt.Year,
                Dan2 = dt.AddDays(7).Day,
                Mesec2 = dt.AddDays(7).Month,
                Godina2 = dt.AddDays(7).Year,
                IDStomatologa = IDStomatologa,
                ListaZakazanihPoseta = context.ZakazanePosete.Where(m => m.StomatologIDClanaKomore == IDStomatologa).ToList()
            };
            return View(nova);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult RefreshList(ZakazanaPosetaViewModel model)
        {
            string IDStomatologa = User.Identity.GetUserName();
            model.IDStomatologa = IDStomatologa;
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_ListaZakazanihPoseta", model);
        }

        [Authorize(Roles = "user")]

        public ActionResult DetaljiZakazanePosete(int ? IDZakazanePosete)
        {
            if (IDZakazanePosete == null)
                throw new Exception("nije izabran ID zakazane posete");

            DetaljiZakazanaPosetaViewModel model = new DetaljiZakazanaPosetaViewModel();
            model.IDZakazanePosete = (int)IDZakazanePosete;

            return View(model);
        }


        [Authorize(Roles = "user")]

        public ActionResult IzmeniZakazanuPosetu(int ? IDZakazanePosete)
        {
            if (IDZakazanePosete == null)
                throw new Exception("nije izabran ID zakazane posete");
            IzmeniZakazanuPosetuViewModel model = new IzmeniZakazanuPosetuViewModel();
            model.IDZakazanePosete = (int)IDZakazanePosete;
            model.loadData();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

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

        [Authorize(Roles = "user")]

        public ActionResult ObrisiZakazanuPosetu(int IDZakazanePosete)
        {

            ZakazanaPoseta z = (from m in context.ZakazanePosete where m.IDZakazanePosete == IDZakazanePosete select m).ToList().First();
            context.ZakazanePosete.Remove(z);
            context.SaveChanges();

            return RedirectToAction("Pretraga", "ZakazanaPoseta");
        }
    }
}