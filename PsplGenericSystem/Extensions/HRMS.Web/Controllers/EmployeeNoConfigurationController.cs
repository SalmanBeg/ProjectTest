using HRMS.Service.Interfaces;
using HRMS.Service.Repositories;
using HRMS.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.Controllers
{
    public class EmployeeNoConfigurationController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IEmployeeNoConfigurationRepository _employeeNoConfigurationRepository = null;
        public const string EmpNoConfigSuccess = "Configured Employee Number Succesfully ";
        public const string EmpNoConfigFail = "Please provide appropriate data.";
        public EmployeeNoConfigurationController()
        {
            this._employeeNoConfigurationRepository = new EmployeeNoConfigurationRepository();
        }
        #endregion
        /// <summary>
        /// View to setup employe number wit prefix,start value and increment value 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateEmployeeNoConfiguration()
        {
            var employeeNoConfigurationObj = _employeeNoConfigurationRepository.SelectEmployeeNoConfigurationbyCompanyId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(employeeNoConfigurationObj);
        }
        /// <summary>
        /// View to setup employe number wit prefix,start value and increment value
        /// </summary>
        /// <param name="employeeNoConfigurationObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult CreateEmployeeNoConfiguration(EmployeeNoConfiguration employeeNoConfigurationObj)
        {
            ModelState.Remove("EmployeeNoId");
            if (ModelState.IsValid)
            {
                employeeNoConfigurationObj.CompanyId = Int32.Parse(GlobalsVariables.CurrentCompanyId);
                var result = 0;
                if (employeeNoConfigurationObj.EmployeeNoId.Equals(0))
                {
                    employeeNoConfigurationObj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                    result = _employeeNoConfigurationRepository.CreateEmployeeNoConfiguration(employeeNoConfigurationObj);
                }
                else
                {
                    employeeNoConfigurationObj.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                    result = _employeeNoConfigurationRepository.UpdateEmployeeNoConfiguration(employeeNoConfigurationObj);
                }
                if (result > 0)
                {
                    return RedirectToAction("EmployeeDashboard", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, EmpNoConfigFail);
                }
            }
            return View(employeeNoConfigurationObj);
        }

    }
}