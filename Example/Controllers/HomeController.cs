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
        [Authorize(Roles = "user")]
        public ActionResult Index()
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