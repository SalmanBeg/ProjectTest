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
using HRMS.Common.Enums;
using System.Configuration;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.Controllers
{
    public class DocumentController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IEmployeeFolderRepository _employeeRepository;
        public DocumentController(IEmployeeFolderRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        /// <summary>
        /// Displays all EmployeeFolder records.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("Documents")]
        public ActionResult Documents()
        {
            //int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            //int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            //List<EmployeeFolder> employeeFolderList = _employeeRepository.SelectAllEmployeeFolderByCompanyId(userId, companyId);
            //return View(employeeFolderList);
            return View();
        }
	}
}