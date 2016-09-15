using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Example.Controllers
{
    public class ObavljenaPosetaController : Controller
    {

        private StomatologContext context = new StomatologContext();

        //
        // GET: /Stomatolog/
        [Authorize(Roles = "user")]

        public ActionResult Index()
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

        public ActionResult DodajObavljeniPregled(int? IDKartona, int Dan, int Mesec, int Godina, int Sat, int Minut)
        {
            if (IDKartona == null)
                throw new Exception("nije izabran ID kartona");

            Pacijent novi = context.Pacijenti.Where(m => m.IDKartona == (int)IDKartona).First();
            ObavljeniPregled novaPoseta = new ObavljeniPregled();
            novaPoseta.Dan = Dan;
            novaPoseta.Mesec = Mesec;
            novaPoseta.Godina = Godina;
            novaPoseta.Sat = Sat;
            novaPoseta.Minut = Minut;
            novaPoseta.IDStomatologa = novi.StomatologIDClanaKomore;
            novaPoseta.IDPacijenta = (int)IDKartona;
            novaPoseta.ImePacijenta = novi.Ime;
            novaPoseta.PrezimePacijenta = novi.Prezime;
            novaPoseta.JMBG = novi.JMBG;
            novaPoseta.JedinicaDoleLevo = "";
            novaPoseta.JedinicaGoreDesno = "";
            novaPoseta.JedinicaDoleDesno = "";
            novaPoseta.JedinicaGoreLevo = "";
            novaPoseta.DvojkaDoleLevo = "";
            novaPoseta.DvojkaGoreDesno = "";
            novaPoseta.DvojkaDoleDesno = "";
            novaPoseta.DvojkaGoreLevo = "";

            novaPoseta.TrojkaDoleLevo = "";
            novaPoseta.TrojkaGoreDesno = "";
            novaPoseta.TrojkaDoleDesno = "";
            novaPoseta.TrojkaGoreLevo = "";


            novaPoseta.CetvorkaDoleLevo = "";
            novaPoseta.CetvorkaGoreDesno = "";
            novaPoseta.CetvorkaDoleDesno = "";
            novaPoseta.CetvorkaGoreLevo = "";

            novaPoseta.PeticaDoleLevo = "";
            novaPoseta.PeticaGoreDesno = "";
            novaPoseta.PeticaDoleDesno = "";
            novaPoseta.PeticaGoreLevo = "";

            novaPoseta.SesticaDoleLevo = "";
            novaPoseta.SesticaGoreDesno = "";
            novaPoseta.SesticaDoleDesno = "";
            novaPoseta.SesticaGoreLevo = "";

            novaPoseta.SedmicaDoleLevo = "";
            novaPoseta.SedmicaGoreDesno = "";
            novaPoseta.SedmicaDoleDesno = "";
            novaPoseta.SedmicaGoreLevo = "";


            novaPoseta.OsmicaDoleLevo = "";
            novaPoseta.OsmicaGoreDesno = "";
            novaPoseta.OsmicaDoleDesno = "";
            novaPoseta.OsmicaGoreLevo = "";

            return View(novaPoseta);

        }

        [HttpPost]
        public ActionResult DodajObavljeniPregled(ObavljeniPregled model)
        {

            if (ModelState.IsValid)
            {
                string IDStomatologa = User.Identity.GetUserName();
                Stomatolog trenutni = context.Stomatolozi.Where(m => m.IDClanaKomore == IDStomatologa).First();
                Pacijent novaPoseta = context.Pacijenti.Where(m => m.IDKartona == model.IDPacijenta).First();

                ObavljenaPoseta z = new ObavljenaPoseta()
                {
                    StomatologIDClanaKomore = IDStomatologa,
                    IzabraniStomatolog = trenutni,
                    PregledaniPacijent = novaPoseta,
                    PacijentIDKartona = novaPoseta.IDKartona,
                    DatumVreme = new DateTime(model.Godina, model.Mesec, model.Dan, model.Sat, model.Minut, 0),
                    OpisIntervencije = "pregled",
                    Terapija = ""
                };

                context.ObavljenePosete.Add(z);
                context.SaveChanges();
                Pregled p = new Pregled()
                {
                    Poseta = z,
                    IDPregleda = z.IDPosete,

                    JedinicaDoleLevo = model.JedinicaDoleLevo,
                    JedinicaGoreDesno = model.JedinicaGoreDesno,
                    JedinicaDoleDesno = model.JedinicaDoleDesno,
                    JedinicaGoreLevo = model.JedinicaGoreLevo,


                    DvojkaDoleLevo = model.DvojkaDoleLevo,
                    DvojkaGoreDesno = model.DvojkaGoreDesno,
                    DvojkaDoleDesno = model.DvojkaDoleDesno,
                    DvojkaGoreLevo = model.DvojkaGoreLevo,

                    TrojkaDoleLevo = model.TrojkaDoleLevo,
                    TrojkaGoreDesno = model.TrojkaGoreDesno,
                    TrojkaDoleDesno = model.TrojkaDoleDesno,
                    TrojkaGoreLevo = model.TrojkaGoreLevo,

                    CetvorkaDoleLevo = model.CetvorkaDoleLevo,
                    CetvorkaGoreDesno = model.CetvorkaGoreDesno,
                    CetvorkaDoleDesno = model.CetvorkaDoleDesno,
                    CetvorkaGoreLevo = model.CetvorkaGoreLevo,


                    PeticaDoleLevo = model.PeticaDoleLevo,
                    PeticaGoreDesno = model.PeticaGoreDesno,
                    PeticaDoleDesno = model.PeticaDoleDesno,
                    PeticaGoreLevo = model.PeticaGoreLevo,

                    SesticaDoleLevo = model.SesticaDoleLevo,
                    SesticaGoreDesno = model.SesticaGoreDesno,
                    SesticaDoleDesno = model.SesticaDoleDesno,
                    SesticaGoreLevo = model.SesticaGoreLevo,

                    SedmicaDoleLevo = model.SedmicaDoleLevo,
                    SedmicaGoreDesno = model.SedmicaGoreDesno,
                    SedmicaDoleDesno = model.SedmicaDoleDesno,
                    SedmicaGoreLevo = model.SedmicaGoreLevo,

                    OsmicaDoleLevo = model.OsmicaDoleLevo,
                    OsmicaGoreDesno = model.OsmicaGoreDesno,
                    OsmicaDoleDesno = model.OsmicaDoleDesno,
                    OsmicaGoreLevo = model.OsmicaGoreLevo

                };





                context.Pregledi.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index", "ObavljenaPoseta");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }



        public ActionResult DodajNovuObavljenuPosetu(int? IDKartona, int Dan, int Mesec, int Godina, int Sat, int Minut)
        {
            if (IDKartona == null)
                throw new Exception("nije izabran ID kartona");

            Pacijent novi = context.Pacijenti.Where(m => m.IDKartona == (int)IDKartona).First();
            NovaObavljenaPoseta novaPoseta = new NovaObavljenaPoseta();
            novaPoseta.Dan = Dan;
            novaPoseta.Mesec = Mesec;
            novaPoseta.Godina = Godina;
            novaPoseta.Sat = Sat;
            novaPoseta.Minut = Minut;
            novaPoseta.StomatologIDClanaKomore = novi.StomatologIDClanaKomore;
            novaPoseta.PacijentIDKartona = (int)IDKartona;
            novaPoseta.ImePacijenta = novi.Ime;
            novaPoseta.PrezimePacijenta = novi.Prezime;
            novaPoseta.JMBG = novi.JMBG;
            novaPoseta.OpisIntervencije = "";
            novaPoseta.Terapija = "";
            return View(novaPoseta);

        }



        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult DodajNovuObavljenuPosetu(NovaObavljenaPoseta model)
        {
            if (ModelState.IsValid)
            {
                string IDStomatologa = User.Identity.GetUserName();
                Stomatolog trenutni = context.Stomatolozi.Where(m => m.IDClanaKomore == IDStomatologa).First();
                Pacijent novaPoseta = context.Pacijenti.Where(m => m.IDKartona == model.PacijentIDKartona).First();
                ObavljenaPoseta z = new ObavljenaPoseta()
                {
                    StomatologIDClanaKomore = IDStomatologa,
                    IzabraniStomatolog = trenutni,
                    PregledaniPacijent = novaPoseta,
                    PacijentIDKartona = novaPoseta.IDKartona,
                    DatumVreme = new DateTime(model.Godina, model.Mesec, model.Dan, model.Sat, model.Minut, 0),
                    OpisIntervencije = model.OpisIntervencije,
                    Terapija = model.Terapija
                };

                context.ObavljenePosete.Add(z);
                context.SaveChanges();
                return RedirectToAction("Index", "ObavljenaPoseta");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }




        [Authorize(Roles = "user")]

        // GET: /ObavljenaPoseta/Pretraga
        public ActionResult Pretraga()
        {
            string IDStomatologa = User.Identity.GetUserName();
            DateTime dt = DateTime.Now;
            ObavljenaPosetaViewModel nova = new ObavljenaPosetaViewModel
            {
                Dan1 = dt.Day,
                Mesec1 = dt.Month,
                Godina1 = dt.Year,
                Dan2 = dt.AddDays(7).Day,
                Mesec2 = dt.AddDays(7).Month,
                Godina2 = dt.AddDays(7).Year,
                IDStomatologa = IDStomatologa,
                ListaObavljenihPoseta = context.ObavljenePosete.Where(m => m.StomatologIDClanaKomore == IDStomatologa).ToList().OrderByDescending(m => m.DatumVreme)
            };
            return View(nova);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult RefreshList(ObavljenaPosetaViewModel model)
        {
            string IDStomatologa = User.Identity.GetUserName();
            model.IDStomatologa = IDStomatologa;
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_ListaObavljenihPoseta", model);
        }


        [Authorize(Roles = "user")]

        public ActionResult DetaljiObavljenePosete(int? IDPosete)
        {
            if (IDPosete == null)
                throw new Exception("");

            DetaljiObavljenaPosetaViewModel model = new DetaljiObavljenaPosetaViewModel();
            model.IDPosete = (int)IDPosete;

            return View(model);
        }



        public ActionResult DetaljiObavljenogPregleda(int? IDPregleda)
        {
            if (IDPregleda == null)
                throw new Exception("");
            ObavljeniPregled model = new ObavljeniPregled();

            model.IDPosete = (int)IDPregleda;
            Pregled p = context.Pregledi.Where(m => m.IDPregleda == IDPregleda).First();
            model.IDPosete = p.IDPregleda;
            model.Dan = p.Poseta.DatumVreme.Day;
            model.Mesec = p.Poseta.DatumVreme.Month;
            model.Godina = p.Poseta.DatumVreme.Year;
            model.Sat = p.Poseta.DatumVreme.Hour;
            model.Minut = p.Poseta.DatumVreme.Minute;
            model.JMBG = p.Poseta.PregledaniPacijent.JMBG;
            model.ImePacijenta = p.Poseta.PregledaniPacijent.Ime;
            model.PrezimePacijenta = p.Poseta.PregledaniPacijent.Prezime;
            model.JedinicaDoleLevo = p.JedinicaDoleLevo;
            model.JedinicaGoreDesno = p.JedinicaGoreDesno;
            model.JedinicaDoleDesno = p.JedinicaDoleDesno;
            model.JedinicaGoreLevo = p.JedinicaGoreLevo;


            model.DvojkaDoleLevo = p.DvojkaDoleLevo;
            model.DvojkaGoreDesno = p.DvojkaGoreDesno;
            model.DvojkaDoleDesno = p.DvojkaDoleDesno;
            model.DvojkaGoreLevo = p.DvojkaGoreLevo;

            model.TrojkaDoleLevo = p.TrojkaDoleLevo;
            model.TrojkaGoreDesno = p.TrojkaGoreDesno;
            model.TrojkaDoleDesno = p.TrojkaDoleDesno;
            model.TrojkaGoreLevo = p.TrojkaGoreLevo;

            model.CetvorkaDoleLevo = p.CetvorkaDoleLevo;
            model.CetvorkaGoreDesno = p.CetvorkaGoreDesno;
            model.CetvorkaDoleDesno = p.CetvorkaDoleDesno;
            model.CetvorkaGoreLevo = p.CetvorkaGoreLevo;


            model.PeticaDoleLevo = p.PeticaDoleLevo;
            model.PeticaGoreDesno = p.PeticaGoreDesno;
            model.PeticaDoleDesno = p.PeticaDoleDesno;
            model.PeticaGoreLevo = p.PeticaGoreLevo;

            model.SesticaDoleLevo = p.SesticaDoleLevo;
            model.SesticaGoreDesno = p.SesticaGoreDesno;
            model.SesticaDoleDesno = p.SesticaDoleDesno;
            model.SesticaGoreLevo = p.SesticaGoreLevo;

            model.SedmicaDoleLevo = p.SedmicaDoleLevo;
            model.SedmicaGoreDesno = p.SedmicaGoreDesno;
            model.SedmicaDoleDesno = p.SedmicaDoleDesno;
            model.SedmicaGoreLevo = p.SedmicaGoreLevo;

            model.OsmicaDoleLevo = p.OsmicaDoleLevo;
            model.OsmicaGoreDesno = p.OsmicaGoreDesno;
            model.OsmicaDoleDesno = p.OsmicaDoleDesno;
            model.OsmicaGoreLevo = p.OsmicaGoreLevo;



            return View(model);


        }



        [Authorize(Roles = "user")]

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
        [Authorize(Roles = "user")]

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

        [Authorize(Roles = "user")]

        public ActionResult ObrisiObavljenuPosetu(int IDPosete)
        {

            ObavljenaPoseta o = (from m in context.ObavljenePosete where m.IDPosete == IDPosete select m).ToList().First();
            context.ObavljenePosete.Remove(o);
            context.SaveChanges();

            return RedirectToAction("Pretraga", "ObavljenaPoseta");
        }
    }
}