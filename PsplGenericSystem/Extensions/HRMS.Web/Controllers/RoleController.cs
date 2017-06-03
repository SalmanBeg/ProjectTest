using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Common.Enums;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;

namespace HRMS.Web.Controllers
{
    public class RoleController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        #endregion
        /// <summary>
        /// View to show all the roles in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllRoles()
        {
            var manageRolesList = new List<ManageRolesFormModel>();
            var roleList = _roleRepository.SelectAllRoles(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            foreach (var rolelistobj in roleList)
            {
                //loading roles other than superadministrator
                if (!String.Equals(rolelistobj.RoleName, GeneralEnum.RoleName.Superadministrator.ToString(),
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    var manageRolesFormModelobj = new ManageRolesFormModel();
                    manageRolesFormModelobj.RoleMaster = new RoleMaster();
                    manageRolesFormModelobj.RoleMasterId = rolelistobj.RoleMasterId;
                    manageRolesFormModelobj.CompanyId = rolelistobj.CompanyId;
                    manageRolesFormModelobj.RoleName = rolelistobj.RoleName;
                    manageRolesFormModelobj.Description = rolelistobj.Description;
                    manageRolesFormModelobj.IsDefault = rolelistobj.IsDefault;
                    manageRolesFormModelobj.Status = rolelistobj.Status;
                    manageRolesList.Add(manageRolesFormModelobj);
                }
            }
            return View(manageRolesList);
        }
        /// <summary>
        /// View to add a new role in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateRole()
        {
            var roleobj = new RoleMaster();
            return View(roleobj);
        }
        /// <summary>
        /// View to add a new role in a company
        /// </summary>
        /// <param name="roleobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult CreateRole(RoleMaster roleobj)
        {
            roleobj.IsDefault = false;
            roleobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            bool success = _roleRepository.CreateRole(roleobj);
            return RedirectToAction("SelectAllRoles", "Role");
        }
        /// <summary>
        /// Method to remove a role based on record Id
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteRole(string roleIds)
        {
            if (roleIds != null)
            {
                foreach (var roleId in roleIds.Split(','))
                {
                    bool success = _roleRepository.DeleteRoleById(Convert.ToInt32(roleId));
                }
            }
            return true;
        }

        [HttpGet]
        [ActionName("IsTitleExists")]
        public JsonResult IsTitleExists(RoleMaster roleMasterobj)
        {
            roleMasterobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _roleRepository.IsTitleExists(roleMasterobj);
            if (roleMasterobj.RoleMasterId.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
