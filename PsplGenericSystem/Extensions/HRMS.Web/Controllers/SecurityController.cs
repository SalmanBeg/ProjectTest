using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;

namespace HRMS.Web.Controllers
{
    public class SecurityController : Controller
    {
        #region class level variables and constructors
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IRoleRepository _roleRepository;
        public SecurityController(IRegisteredUsersRepository registeredUsersepository, IRoleRepository roleRepository)
        {
            _registeredUsersRepository = registeredUsersepository;
            _roleRepository = roleRepository;
        }

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageRoles()
        {
            return View();
        }
        /// <summary>
        /// View to list users in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ManageUsers()
        {
            var lstlookup = new List<RoleMaster>();
            List<UserLoginModel> manageUsersList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var manageRolesList = new List<ManageRolesFormModel>();

            foreach (var manageuser in manageUsersList)
            {
                var manageRolesModelobj = new ManageRolesFormModel();
                manageRolesModelobj.UserName = manageuser.UserName;
                manageRolesModelobj.RoleMasterId = manageuser.RoleId;
                manageRolesModelobj.RoleName = manageuser.RoleName;
                manageRolesModelobj.Status = manageuser.IsApproved;
                manageRolesModelobj.Email = manageuser.Email;
                manageRolesModelobj.RoleList = _roleRepository.SelectAllRoles(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));        
                manageRolesModelobj.CompanyId = manageuser.CompanyId;
                manageRolesModelobj.UserId = manageuser.UserId;
                manageRolesList.Add(manageRolesModelobj);
            }
            ViewBag.RoleList = _roleRepository.SelectAllRoles(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(manageRolesList);
        }
        public ActionResult ManagePasswords()
        {
            return View();
        }
        /// <summary>
        /// View to update roles to a user 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool ManageUserRoleById(int userId, int roleId)
        {
            bool success = _roleRepository.ManageUserRoleById(userId, roleId);
            return success;
        }
    }
}
