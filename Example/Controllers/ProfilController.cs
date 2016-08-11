using Example.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Controllers
{
    public class ProfilController : Controller
    {
        //
        // GET: /Profil/
        public ActionResult Index()
        {
            UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            StomatologContext context = new StomatologContext();
            var user = manager.FindById(User.Identity.GetUserId());
            var result = (from e in context.Stomatolozi
                         where e.IDClanaKomore == user.UserName
                         select e.IDClanaKomore).First();
            UrediProfilViewModel model = new UrediProfilViewModel();
            model.IDClanaKomore = result;
            model.UcitajImeIPrezime();
            return View(model);
        }



        [HttpPost]
        public ActionResult Index(UrediProfilViewModel model)
        {
            if (ModelState.IsValid)
            {
                /*try
                {*/
                    model.IzmeniProfil();
                    return RedirectToAction("IndexForUsers","Home");
                /*}
                catch (Exception e)
                {
                    return RedirectToAction("Error", new { Message = e.Message });
                }*/

            }
            return View(model);
        }
	}
}