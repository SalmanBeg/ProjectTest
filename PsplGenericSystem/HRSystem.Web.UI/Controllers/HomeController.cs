using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HRSystem.Web.UI.Models;
using System.Web.Mvc;
using HRSystem.Security.Authentication;
using System.Web.Security;
using System.Net;
using System.Collections.Generic;

namespace HRSystem.Web.UI.Controllers
{
    public class HomeController : Controller
    {


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public HomeController()
        {
        }

        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // POST: /Account/Login
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);

//            var identity = new ClaimsIdentity(new[] {
//                new Claim(ClaimTypes.Email, model.Email)
//            },
//"ApplicationCookie");
//            AuthenticationManager.SignIn(identity);


            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal("Index");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }





        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Index()
        {
            dashboard userDashboard = new dashboard();
            userDashboard.Title = "Your Applications";
            userDashboard.Description = " Browse your applications";
            userDashboard.UserApplications= new List<Application>();
            userDashboard.UserApplications.Add(new Application
            {
                Id = "1",
                Description = "Benifit",
                Name = "Benifit"
            });
            userDashboard.UserApplications.Add(new Application
            {
                Id = "1",
                Description = "Employee",
                Name = "Employee"
            });

            return View("Dashboard", userDashboard);
        }

        public ActionResult About()
        {
           if(User.Identity.IsAuthenticated)
           {
               ViewBag.Message = "Your application description page.";

               return View();
           }
           else
           {
               return View("Login");
           }

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        //// GET: /Account/Login
        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View("Login");
        //}
    }
}