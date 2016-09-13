using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Example.Controllers
{
    public class ObjavaController : Controller
    {
        StomatologContext context = new StomatologContext();
        //
        // GET: /Objava/
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "user")]

        public ActionResult SveObjave()
        {
            return View(new SveObjaveViewModel());
        }


        [Authorize(Roles = "user")]

        public ActionResult PrikaziObjavu(int? IDObjave)
        {
            if (IDObjave == null)
                throw new Exception("Nije izabrana objava");

            ObjavaViewModel model = new ObjavaViewModel();
            model.IDObjave = (int)IDObjave;

            return View(model);
        }


        [Authorize(Roles = "user")]

        public ActionResult NovaObjava()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult NovaObjava(NovaObjava model)
        {
            string IDkorisnika = User.Identity.GetUserName();
            Stomatolog ulogovani = context.Stomatolozi.Where(m => m.IDClanaKomore == IDkorisnika).First();
            DateTime trenutnoVreme = DateTime.Now;
            Objava novaObjava = new Objava
            {
                DatumVreme = trenutnoVreme,
                KomentariNaObjavu = new List<KomentarNaObjavu>(),
                Objavio = ulogovani,
                StomatologIDClanaKomore = ulogovani.IDClanaKomore,
                Tekst = model.Tekst,
                Vrsta = model.Vrsta
            };

            context.Objave.Add(novaObjava);
            context.SaveChanges();

            return RedirectToAction("Index", "Objava");
        }

        [Authorize(Roles = "user")]

        public ActionResult DodajKomentar(int? IDObjave)
        {
            if (IDObjave == null)
                throw new Exception("Nepoznata objava");
            NoviKomentar model = new NoviKomentar();
            model.IDObjave = (int)IDObjave;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "user")]

        public ActionResult DodajKomentar(NoviKomentar model)
        {
            string IDkorisnika = User.Identity.GetUserName();

            Stomatolog ulogovani = context.Stomatolozi.Where(m => m.IDClanaKomore == IDkorisnika).First();
            DateTime trenutnoVreme = DateTime.Now;
            Objava originalnaObjava = context.Objave.Where(m => m.IDObjave == model.IDObjave).First();
            KomentarNaObjavu noviKomentar = new KomentarNaObjavu
            {
                DatumVreme = trenutnoVreme,
                ObjavaIDObjave = model.IDObjave,
                Tekst = ulogovani.Ime + " " + ulogovani.Prezime + ":\n" + model.Tekst,
                OriginalnaObjava = originalnaObjava
            };

            context.KomentariNaObjave.Add(noviKomentar);
            context.SaveChanges();

            return RedirectToAction("Index", "Objava");
        }

    }
}