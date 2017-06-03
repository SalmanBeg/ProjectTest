using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRSystem.Security.Authentication
{
    /// <summary>
    /// Class that implements the key ASP.NET Identity role store iterfaces
    /// </summary>
    public class PsplRoleStore<TRole> : IQueryableRoleStore<TRole>
    where TRole : PsplIdentityRole
    {
        public IQueryable<TRole> Roles
        {
            get { throw new NotImplementedException(); }
        }

        public Task CreateAsync(TRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TRole role)
        {
            throw new NotImplementedException();
        }

        public Task<TRole> FindByIdAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<TRole> FindByNameAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TRole role)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}