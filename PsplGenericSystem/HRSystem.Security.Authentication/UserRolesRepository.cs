using System.Collections.Generic;
using System.Linq;

namespace HRSystem.Security.Authentication
{
    internal class UserRolesRepository
    {
        private readonly IdentityHREntities _databaseContext;

        public UserRolesRepository(IdentityHREntities database)
        {
            _databaseContext = database;
        }

        /// <summary>
        /// Returns a list of user's roles
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public IList<string> FindByUserId(string userId)
        {
            var roles = _databaseContext.Users.
                Where(u => u.Id == userId).SelectMany(r => r.UserRoles);
            return roles.Select(r => r.RoleId).ToList();
        }
    }
}