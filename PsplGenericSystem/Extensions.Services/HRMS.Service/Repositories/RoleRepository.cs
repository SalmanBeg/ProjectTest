using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public bool CreateRole(RoleMaster roleMasterobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_RoleMasterInsert(roleMasterobj.RoleName, roleMasterobj.Description, roleMasterobj.CompanyId, roleMasterobj.Status
                        , roleMasterobj.IsDefault, output);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool UpdateRole(RoleMaster roleMasterobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_RoleMasterUpdate(roleMasterobj.RoleMasterId, roleMasterobj.RoleName, roleMasterobj.Description, roleMasterobj.CompanyId
                        , roleMasterobj.Status, roleMasterobj.IsDefault, output).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<RoleMaster> SelectAllRoles(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_RoleMasterSelectAll_Result> lstResult = hrmsEntity.usp_RoleMasterSelectAll(companyId).ToList();
                    var roleMasterList = lstResult.Select(rolemasterobj => new RoleMaster
                    {
                        RoleMasterId = rolemasterobj.RoleMasterID,
                        RoleId = rolemasterobj.RoleID,
                        RoleName = rolemasterobj.RoleName,
                        Description = rolemasterobj.Description,
                        Status = rolemasterobj.Status,
                        IsDefault = rolemasterobj.IsDefault,
                        CompanyId = rolemasterobj.CompanyID
                    }).ToList();
                    return roleMasterList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public RoleMaster SelectRoleByRoleId(int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_RoleMasterSelect_Result> lstResult = hrmsEntity.usp_RoleMasterSelect(roleId).ToList();

                    var RoleMasterList = lstResult.Select(RoleMasterobj => new RoleMaster
                    {
                        RoleMasterId = RoleMasterobj.RoleMasterID,
                        RoleId = RoleMasterobj.RoleID,
                        RoleName = RoleMasterobj.RoleName,
                        Description = RoleMasterobj.Description,
                        Status = RoleMasterobj.Status,
                        IsDefault = RoleMasterobj.IsDefault,
                        CompanyId = RoleMasterobj.CompanyID
                    }).ToList();
                    return RoleMasterList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteRoleById(int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_RoleMasterDelete(roleId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ManageUserRoleById(int userId, int roleId)
        {
            var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_UserRoleUpdate_Result> lstResult = hrmsEntity.usp_UserRoleUpdate(roleId, userId, output).ToList();
                    return lstResult.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTitleExists(RoleMaster roleMasterobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var roleMastersList = hrmsEntity.RoleMasters.ToList();
                    var roleMastersList1 = roleMastersList.Where(m => m.CompanyId == roleMasterobj.CompanyId && m.RoleName.ToLower() == roleMasterobj.RoleName.ToLower() && m.RoleId != roleMasterobj.RoleId).FirstOrDefault();
                    if (roleMastersList1 != null)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}