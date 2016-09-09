using Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class StomatologController : Controller
    {

        private StomatologContext context = new StomatologContext();

        //
        // GET: /Stomatolog/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Stomatolog/Pretraga
        public ActionResult Pretraga()
        {
            return View(new StomatologViewModel());
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
        public ActionResult RefreshList(StomatologViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_ListaStomatologa", model);
        }

        public ActionResult DetaljiStomatologa(string IDClanaKomore)
        {
            if (IDClanaKomore == null)
                throw new Exception("ID clana komore nije zadat!");

            DetaljiStomatologViewModel model = new DetaljiStomatologViewModel();
            model.IDClanaKomore = IDClanaKomore;

            return View(model);
        }

        public ActionResult IzmeniStomatologa(string IDClanaKomore)
        {
            if (IDClanaKomore == null)
                throw new Exception("ID clana komore nije zadat!");
            IzmeniStomatologaViewModel model = new IzmeniStomatologaViewModel();
            model.IDClanaKomore = IDClanaKomore;
            model.loadData();

            return View(model);
        }

        [HttpPost]
        public ActionResult IzmeniStomatologa(IzmeniStomatologaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.editStomatologa();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", new { Message = e.Message });
                }

            }
            return View(model);
        }

        public ActionResult ObrisiStomatologa(string IDClanaKomore)
        {

            Stomatolog s = (from m in context.Stomatolozi where m.IDClanaKomore == IDClanaKomore select m).ToList().First();
            context.Stomatolozi.Remove(s);
            context.SaveChanges();

            return RedirectToAction("Pretraga", "Stomatolog");
        }
    }
}