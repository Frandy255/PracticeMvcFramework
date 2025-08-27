using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager usA;
        public ActionResult Login(string usser, string pass)
        {
           return View();
        }
    }
}