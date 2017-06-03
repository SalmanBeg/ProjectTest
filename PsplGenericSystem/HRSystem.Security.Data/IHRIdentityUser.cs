using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Security.Authentication
{
    public class IHRIdentityUser : IUser<int>
    {
        public IHRIdentityUser() {
           }
        public IHRIdentityUser(string userName)
        {
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        // can also define optional properties such as:
        //    PasswordHash
        //    SecurityStamp
        //    Claims
        //    Logins
        //    Roles
    }
}
