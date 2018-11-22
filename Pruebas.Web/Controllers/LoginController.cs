using Microsoft.Owin.Security;
using Pruebas.Web.Models;
using Pruebas.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Pruebas.Web.Startup;

namespace Pruebas.Web.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public virtual ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Index(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //ToDo: usually this will be injected via DI. but creating this manually now for brevity
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            var authService = new AdAuthenticationService(authenticationManager);

            var authenticationResult = authService.SignIn(model.Username, model.Password);

            if (authenticationResult.IsSuccess)
            {
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", authenticationResult.ErrorMessage);
            return View(model);
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        [ValidateAntiForgeryToken]
        public virtual ActionResult Logoff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(PruebasAuthentication.ApplicationCookie);

            return RedirectToAction("Index");
        }
    }
}