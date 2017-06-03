namespace HRSystem.Security.Authentication
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    /// <summary>
    /// Class that implements the ASP.NET Identity
    /// IUser interface
    /// </summary>
    public class PsplIdentityUser : IdentityUser<string,
                                IdentityUserLogin,
                                IdentityUserRole,
                                IdentityUserClaim>, IUser
    {
        public PsplIdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}