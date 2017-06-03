using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;

namespace HRMS.Web.Controllers
{
    public class EmployeeOSHAController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IOSHARepository _oSHARepository;
        private readonly IUtilityRepository _UtilityRepo;
        public EmployeeOSHAController(IOSHARepository oSHARepository, IUtilityRepository utilityRepo)
        {
            _oSHARepository = oSHARepository;
            _UtilityRepo = utilityRepo;
        }

        protected IOSHARepository OSHARepository
        {
            get { return _oSHARepository; }
        }
        protected IUtilityRepository UtilityRepository
        {
            get { return _UtilityRepo; }
        }
        #endregion
        /// <summary>
        /// View to add a new OSHA record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateEmployeeOSHA()
        {
            var oshaformModelobj = new OshaFormModel();
            var employeeOSHAId = Request.QueryString["employeeOSHAId"];
            oshaformModelobj.EmployeeOSHA = _oSHARepository.SelectEmployeeOSHAById(Convert.ToInt32(employeeOSHAId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (oshaformModelobj.EmployeeOSHA == null)
                oshaformModelobj.EmployeeOSHA = new EmployeeOSHA();
            oshaformModelobj.CountryList = _UtilityRepo.GetCountry();
            if (oshaformModelobj.EmployeeOSHA != null && oshaformModelobj.EmployeeOSHA.EmployeeOSHAId != 0)
            {
                if (oshaformModelobj.EmployeeOSHA.CountryId != 0)
                    oshaformModelobj.StateList = _UtilityRepo.GetStateProvince(oshaformModelobj.EmployeeOSHA.CountryId);

            }
            //  Bind Lookup data
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _UtilityRepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            oshaformModelobj.ClaimTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.ClaimType).ToList();
            oshaformModelobj.OutComeList = lstlookup.Where(j => j.TableName == LocalizedStrings.OutCome).ToList();
            return View(oshaformModelobj);

        }
        /// <summary>
        /// View to add a new OSHA record for an employee
        /// </summary>
        /// <param name="oshaFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult CreateEmployeeOSHA(OshaFormModel oshaFormModelobj)
        {
            bool success = false;
            if (oshaFormModelobj == null) throw new ArgumentNullException("employeeOSHADetailobj");
            if (oshaFormModelobj.EmployeeOSHA.UserId == 0)
            {
                oshaFormModelobj.EmployeeOSHA.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                oshaFormModelobj.EmployeeOSHA.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                success = _oSHARepository.CreateEmployeeOSHA(oshaFormModelobj.EmployeeOSHA);
            }
            else
                success = _oSHARepository.UpdateEmployeeOSHA(oshaFormModelobj.EmployeeOSHA);
            if (success)
                return RedirectToAction("SelectAllEmployeeOSHA");
            return View();
        }
        /// <summary>
        /// View to show all the OSHA records for an employee in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllEmployeeOSHA()
        {
            int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<EmployeeOSHA> employeeOSHADetailobj = _oSHARepository.SelectEmployeeOSHA(userId,companyId);
            return View(employeeOSHADetailobj);
        }
        /// <summary>
        /// Action method to delete an OSHA record
        /// </summary>
        /// <param name="oshaDetailIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteOSHA(string oshaDetailIds)
        {
            if (oshaDetailIds != null)
            {
                foreach (var OSHADetailId in oshaDetailIds.Split(','))
                {
                    bool success = _oSHARepository.DeleteOSHA(Convert.ToInt32(OSHADetailId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
        [HttpGet]
        [ActionName("CaseNoExists")]
        public JsonResult CaseNoExists(OshaFormModel oshaFormModelobj)
        {
            oshaFormModelobj.EmployeeOSHA.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _oSHARepository.CaseNoExists(oshaFormModelobj.EmployeeOSHA);
            if (oshaFormModelobj.EmployeeOSHA.CaseNumber.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
