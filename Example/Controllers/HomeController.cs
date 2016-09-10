using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Example;

namespace Example.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("admin"))
                    return RedirectToAction("Admin", "Home");
                else if (User.IsInRole("user"))
                    return RedirectToAction("IndexForUsers", "Home");
            }
            IzborGradaViewModel model = new IzborGradaViewModel();
            model.Grad = "Svi gradovi";
            return View(model);
        }

        [HttpPost]
        public ActionResult RefreshList(IzborGradaViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.RefreshList();
            }
            return PartialView("_PrikazOrdinacija", model);
        }

        public ActionResult DetaljiOrdinacijeJavno(int? MaticniBrojFirme)
        {
            if (MaticniBrojFirme == null)
                throw new Exception("Matični broj firme nije zadat!");

            DetaljiOrdinacijeJavnoViewModel model = new DetaljiOrdinacijeJavnoViewModel();
            model.MaticniBrojFirme = (int)MaticniBrojFirme;

            return View(model);
        }

        public ActionResult ProfilStomatologaJavno(string IDClanaKomore)
        {
            if (IDClanaKomore == null)
                throw new Exception("Nije pravilno izabran stomatolog!");

            ProfilStomatologaJavnoModelView model = new ProfilStomatologaJavnoModelView();
            model.IDClanaKomore = IDClanaKomore;

            return View(model);
        }

        [Authorize(Roles = "user")]
        public ActionResult IndexForUsers()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            StomatologContext context = new StomatologContext();
            var user = manager.FindById(User.Identity.GetUserId());
            var result = from e in context.Stomatolozi
                         where e.IDClanaKomore == user.UserName
                         select e.Ime + " " + e.Prezime;
            if (result.Any())
                ViewBag.Ime = result.First();
            else
                ViewBag.Ime = "unknown";

            return View();
        }


        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {

            return View();
        }

        [AllowAnonymous]
        public ActionResult Error(string Message)
        {
            ViewBag.Message = Message;
            return View("~/Views/Shared/Error.cshtml");
        }

    }
}