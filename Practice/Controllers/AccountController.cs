using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            aum = userManager;
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

        [HttpPost]
        public ActionResult LoginInicial(LoginModel lgm)
        {
            string usser = lgm.Email;
            string pass = lgm.Password;

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            // Obtiene todos los usuarios
            var usuarios = userManager.Users.ToList();

            var user = UserManagers.Find("testuser", "MiClaveDePrueba123!");
                
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


        public ActionResult Login()
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
            ViewBag.Message = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            return View();

        }
    }
}