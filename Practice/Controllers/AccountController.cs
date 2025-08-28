using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Practice.App_Start;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager aum;

        public AccountController()
        {

        }

        public AccountController(ApplicationUserManager userManager)
        {
            UserManagers = userManager;
        }

        public ApplicationUserManager UserManagers
        {
            get
            {
                return aum ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                aum = value;
            }
        }

        public ActionResult LoginInicial(string usser, string pass)
        {
            
            var user = UserManagers.Find(usser, pass);

            if (user != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Login));
        }

        public ActionResult Index() 
        {
            return View();
        }


        public ActionResult Login(string usser, string pass)
        {
            //var user = UserManagers.Find(usser, pass);

            //if (user != null)
            //{
            //  //  return RedirectToAction
            //}
            //var user = new ApplicationUser { UserName = "testuser", Email = "test@test.com" };
            //var hasher = new PasswordHasher();
            //string hash = hasher.HashPassword("Prueba123");
            //Console.WriteLine(hash);
            //ViewBag.message = hash;
            return View();

        }
    }
}