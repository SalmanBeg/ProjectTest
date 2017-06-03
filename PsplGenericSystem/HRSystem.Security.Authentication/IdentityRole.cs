namespace HRSystem.Security.Authentication
{
    using Microsoft.AspNet.Identity;
    using System;

    /// <summary>
    /// Class that implements the ASP.NET Identity
    /// IRole interface
    /// </summary>
    public class PsplIdentityRole : IRole
    {
        public PsplIdentityRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public PsplIdentityRole(string name)
            : this()
        {
            Name = name;
        }

        public PsplIdentityRole(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}