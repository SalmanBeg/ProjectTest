using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public class RoleRepository:IRoleRepository
    {
       private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();

       public class RoleFields
       {
           public const string RoleMasterId = "RoleMasterId";
           public const string RoleId = "RoleId";
           public const string RoleName = "RoleName";
           public const string Description = "Description";
           public const string CompanyId = "CompanyId";
           public const string Status = "Status";
           public const string IsDefault = "IsDefault";
       }

       public bool CreateRole(RoleMaster roleMasterobj)
       {
           bool executionState = false;
           _oDatabaseHelper = new DatabaseHelper();
           _oDatabaseHelper.AddParameter("@RoleName", roleMasterobj.RoleName);
           _oDatabaseHelper.AddParameter("@Description", roleMasterobj.Description);
           _oDatabaseHelper.AddParameter("@CompanyID", roleMasterobj.CompanyId);
           _oDatabaseHelper.AddParameter("@Status", roleMasterobj.Status);
           _oDatabaseHelper.AddParameter("@IsDefault", roleMasterobj.IsDefault);
           _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
           _oDatabaseHelper.ExecuteScalar("OrganizationLevel.usp_RoleMasterInsert", ref executionState);
           _oDatabaseHelper.Dispose();
           return executionState;
       }

       public bool UpdateRole(RoleMaster roleMasterobj)
       {
           bool executionState = false;
           _oDatabaseHelper = new DatabaseHelper();
           _oDatabaseHelper.AddParameter("@RoleName", roleMasterobj.RoleName);
           _oDatabaseHelper.AddParameter("@Description", roleMasterobj.Description);
           _oDatabaseHelper.AddParameter("@CompanyID", roleMasterobj.CompanyId);
           _oDatabaseHelper.AddParameter("@Status", roleMasterobj.Status);
           _oDatabaseHelper.AddParameter("@IsDefault", roleMasterobj.IsDefault);
           _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
           _oDatabaseHelper.ExecuteScalar("OrganizationLevel.usp_RoleMasterUpdate", ref executionState);
           _oDatabaseHelper.Dispose();
           return executionState;
       }

       public List<RoleMaster> SelectAllRoles(int companyId)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();

               List<RoleMaster> roleList = new List<RoleMaster>();
               _oDatabaseHelper.AddParameter("@CompanyId", companyId);
               IDataReader rdr = _oDatabaseHelper.ExecuteReader("OrganizationLevel.usp_RoleMasterSelectAll", ref executionState);
               while (rdr.Read())
               {
                   var roleobj = new RoleMaster();
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.RoleMasterId)))
                       roleobj.RoleMasterId = rdr.GetInt32(rdr.GetOrdinal(RoleFields.RoleMasterId));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.RoleId)))
                       roleobj.RoleId = rdr.GetGuid(rdr.GetOrdinal(RoleFields.RoleId)).ToString();
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.RoleName)))
                       roleobj.RoleName = rdr.GetString(rdr.GetOrdinal(RoleFields.RoleName));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.Description)))
                       roleobj.Description = rdr.GetString(rdr.GetOrdinal(RoleFields.Description));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.Status)))
                       roleobj.Status = rdr.GetBoolean(rdr.GetOrdinal(RoleFields.Status));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.IsDefault)))
                       roleobj.IsDefault = rdr.GetBoolean(rdr.GetOrdinal(RoleFields.IsDefault));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.CompanyId)))
                       roleobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(RoleFields.CompanyId));
                   roleList.Add(roleobj);
               }
               rdr.Close();
               return roleList;
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               _oDatabaseHelper.Dispose();
           }
       }

       public RoleMaster SelectRoleByRoleId(int roleId)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@RoleMasterID", roleId);
               var roleobj = new RoleMaster();
               IDataReader rdr = _oDatabaseHelper.ExecuteReader("OrganizationLevel.usp_RoleMasterSelect", ref executionState);
               while (rdr.Read())
               {                  
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.RoleMasterId)))
                       roleobj.RoleMasterId = rdr.GetInt32(rdr.GetOrdinal(RoleFields.RoleMasterId));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.RoleId)))
                       roleobj.RoleId = rdr.GetGuid(rdr.GetOrdinal(RoleFields.RoleId)).ToString();
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.RoleName)))
                       roleobj.RoleName = rdr.GetString(rdr.GetOrdinal(RoleFields.RoleName));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.Description)))
                       roleobj.Description = rdr.GetString(rdr.GetOrdinal(RoleFields.Description));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.Status)))
                       roleobj.Status = rdr.GetBoolean(rdr.GetOrdinal(RoleFields.Status));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.IsDefault)))
                       roleobj.IsDefault = rdr.GetBoolean(rdr.GetOrdinal(RoleFields.IsDefault));
                   if (!rdr.IsDBNull(rdr.GetOrdinal(RoleFields.CompanyId)))
                       roleobj.CompanyId = rdr.GetInt32(rdr.GetOrdinal(RoleFields.CompanyId));                  
               }
               rdr.Close();
               return roleobj;
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               _oDatabaseHelper.Dispose();
           }
       }

       public bool DeleteRoleById(int roleId, int companyId)
       {
           try
           {
               bool executionState = false;
               _oDatabaseHelper = new DatabaseHelper();
               _oDatabaseHelper.AddParameter("@RoleMasterID", roleId);
               _oDatabaseHelper.AddParameter("@CompanyID", companyId);
               _oDatabaseHelper.ExecuteScalar("OrganizationLevel.usp_RoleMasterDelete", ref executionState);
               _oDatabaseHelper.Dispose();

               return executionState;
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               _oDatabaseHelper.Dispose();
           }
       }

       public bool ManageUserRoleById(int userId, int roleId)
       {
           bool executionState = false;
           _oDatabaseHelper = new DatabaseHelper();
           _oDatabaseHelper.AddParameter("@UserId", userId);
           _oDatabaseHelper.AddParameter("@RoleId", roleId);
           _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
           _oDatabaseHelper.ExecuteScalar("Security.usp_UserRoleUpdate", ref executionState);
           _oDatabaseHelper.Dispose();
           return executionState;
       }
    }
}
