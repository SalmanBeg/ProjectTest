using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using HRSystem.Web.Models;
using System.Security.Claims;
using HRSystem.Security.Authentication;
using Newtonsoft.Json.Linq;
using System.Web.Http;

namespace HRSystem.Web.Controllers.Api
{
    [Authorize]
    public class AccountController : ApiController
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private IAuthenticationManager Authentication
        {
            get { return HttpContext.Current.Request.GetOwinContext().Authentication; }
        }

        // GET api/Me
        public string Get()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            return  "";
        }

        [HttpPost]
        [ActionName("Authenticate")]
        [AllowAnonymous]
        public String Authenticate(string user, string password)
        {

            //if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            //    return "failed";
            //var userIdentity = UserManager.FindAsync(user, password).Result;
            //if (userIdentity != null)
            //{
            //    var identity = new ClaimsIdentity(Startup.OAuthBearerOptions.AuthenticationType);
            //    identity.AddClaim(new Claim(ClaimTypes.Name, user));
            //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userIdentity.Id));
            //    AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            //    var currentUtc = new SystemClock().UtcNow;
            //    ticket.Properties.IssuedUtc = currentUtc;
            //    ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromMinutes(30));
            //    string AccessToken = Startup.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);
            //    return AccessToken;
            //}
            return "failed";
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
   
            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

 
    }
}