using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtendedModels;
using HRMS.Service.Repositories;
using HRMS.Web.ViewModels;
using HRMS.Web.Helper;

namespace HRMS.Web.Controllers
{
    public class EmployeeSnapshotController : Controller
    {
        #region Class Level Variables and constructor


        private readonly IEmployeeSnapshotRepository _employeesnapshotRepository ;
        private readonly ITaxRepository _taxRepository ;
        private readonly IEmergencyContanctRepository _emergencycontanctRepository;
        public EmployeeSnapshotController(IEmployeeSnapshotRepository employeeSnapshotRepository,ITaxRepository taxRepository,IEmergencyContanctRepository emergencyContanctRepository)
        {
            this._employeesnapshotRepository = employeeSnapshotRepository;
            this._taxRepository = taxRepository;
            this._emergencycontanctRepository = emergencyContanctRepository;
        }
        #endregion
        /// <summary>
        /// View to show various details related to an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult EmployeeSnapshot()
        {
            int UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            EmployeeSnapshotFormModel employeesnapshotFormModelObj = new EmployeeSnapshotFormModel();
            EmployeeTax employeetaxObj = _taxRepository.SelectEmployeeTax(UserId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (employeetaxObj == null)
                employeetaxObj = new EmployeeTax();
            EmployeeSnapshot employeesnapshotObj = _employeesnapshotRepository.SelectEmployeeSnapshotById(UserId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (employeesnapshotObj == null)
                employeesnapshotObj = new EmployeeSnapshot();
            EmployeeEmergencyContact emergencycontactObj = _emergencycontanctRepository.SelectAllEmergencyContact(UserId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).FirstOrDefault();
            if (emergencycontactObj == null)
                emergencycontactObj = new EmployeeEmergencyContact();
            employeesnapshotFormModelObj.EmployeeSnapshot = employeesnapshotObj;
            employeesnapshotFormModelObj.EmployeeTax = employeetaxObj;
            employeesnapshotFormModelObj.EmployeeEmergencyContact = emergencycontactObj;
            return View(employeesnapshotFormModelObj);
        }
    }
}