using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Service.Repositories;

namespace HRMS.Web.Controllers
{
    public class EmployeeAssetController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IEmployeeAssetRepository _employeeAssetRepository = null;
        public EmployeeAssetController()
        {
            this._employeeAssetRepository = new EmployeeAssetRepository();
        }
        #endregion
        /// <summary>
        /// View to list all the assets for an employee in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllEmployeeAsset()
        {
            var employeeAssetList = _employeeAssetRepository.GetAllEmployeeAssetByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
            return View(employeeAssetList);
        }

        /// <summary>
        /// View to add a new asset for an employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult CreateEmployeeAsset()
        {
            var employeeAssetobj = new EmployeeAsset();
            return View(employeeAssetobj);
        }
        /// <summary>
        /// View to add a new asset for an employee
        /// </summary>
        /// <param name="employeeAssetobj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public ActionResult CreateEmployeeAsset(EmployeeAsset employeeAssetobj)
        {
            employeeAssetobj.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            employeeAssetobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            employeeAssetobj.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            employeeAssetobj.CreatedOn = DateTime.Now;
            bool isStatus = _employeeAssetRepository.CreateEmployeeAsset(employeeAssetobj);
            return RedirectToAction("SelectAllEmployeeAsset");
        }
        /// <summary>
        /// View to edit an asset record of an employee
        /// </summary>
        /// <param name="employeeAssetId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("EditEmployeeAsset")]
        public ActionResult EditEmployeeAsset(int employeeAssetId)
        {
            EmployeeAsset employeeassetObj = _employeeAssetRepository.GetEmployeeAssetByAssetId(employeeAssetId);
            return View(employeeassetObj);

        }
        /// <summary>
        /// View to edit an asset record of an employee
        /// </summary>
        /// <param name="employeeAssetobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ActionName("EditEmployeeAsset")]
        public ActionResult EditEmployeeAsset(EmployeeAsset employeeAssetobj)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                employeeAssetobj.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                employeeAssetobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                employeeAssetobj.ModifiedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                employeeAssetobj.ModifiedOn = DateTime.Now;
                success = _employeeAssetRepository.UpdateEmployeeAssetById(employeeAssetobj);
            }

            //if (success)
            return RedirectToAction("SelectAllEmployeeAsset");
            //return View();
        }
        /// <summary>
        /// Function to delete an asset record
        /// </summary>
        /// <param name="employeeassetIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteAsset(string employeeassetIds)
        {
            if (employeeassetIds != null)
            {
                foreach (var employeeassetId in employeeassetIds.Split(','))
                {
                    var deleteAssetDetail = _employeeAssetRepository.DeleteEmployeeAssetById(Convert.ToInt32(employeeassetId));
                }
            }
            return true;
        }
    }
}