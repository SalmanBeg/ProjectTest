using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
  public  interface IRoleRepository
    {
      bool CreateRole(RoleMaster roleMasterobj);

      bool UpdateRole(RoleMaster roleMasterobj);

      List<RoleMaster> SelectAllRoles(int companyId);

      RoleMaster SelectRoleByRoleId(int roleId);

      bool DeleteRoleById(int roleId, int companyId);

      bool ManageUserRoleById(int userId, int roleId);
    }
}
