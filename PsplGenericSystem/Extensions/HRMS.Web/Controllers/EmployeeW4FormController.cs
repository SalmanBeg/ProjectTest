using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using System.Web.Security;
using System.Configuration;
using System.IO;
using HRMS.Web.Helper;


namespace HRMS.Web.Controllers
{
    public class EmployeeW4FormController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IEmployeeW4FormRepository _employeeW4FormRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private string Filepath = ConfigurationManager.AppSettings["scannedfilepath"];
        public EmployeeW4FormController(IEmployeeW4FormRepository employeeW4FormRepository, IFilesDBRepository filesDBRepository, IUserRepository userRepository)
        {
            _employeeW4FormRepository = employeeW4FormRepository;
            _filesDBRepository = filesDBRepository;
            _userRepository = userRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult AddEmployeeW4Form()
        {
            EmployeeW4Form employeeW4Formobj = new EmployeeW4Form();

            return View(employeeW4Formobj);
        }

        [HttpPost]
        public ActionResult AddEmployeeW4Form(EmployeeW4Form employeeW4Formobj)
        {           
            employeeW4Formobj.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            employeeW4Formobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            bool success = _employeeW4FormRepository.AddEmployeeW4Form(employeeW4Formobj);
            return View(employeeW4Formobj);
        }

       
    }
}
