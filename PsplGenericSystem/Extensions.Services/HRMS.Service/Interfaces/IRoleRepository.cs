using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IRoleRepository
    {
        [Logger]
        [ExceptionLogger]
        bool CreateRole(RoleMaster roleMasterobj);

        [Logger]
        [ExceptionLogger]
        bool UpdateRole(RoleMaster roleMasterobj);

        [Logger]
        [ExceptionLogger]
        List<RoleMaster> SelectAllRoles(int companyId);

        [Logger]
        [ExceptionLogger]
        RoleMaster SelectRoleByRoleId(int roleId);

        [Logger]
        [ExceptionLogger]
        bool DeleteRoleById(int roleId);

        [Logger]
        [ExceptionLogger]
        bool ManageUserRoleById(int userId, int roleId);

        [Logger]
        [ExceptionLogger]
        bool IsTitleExists(RoleMaster roleMasterobj);


    }
}
