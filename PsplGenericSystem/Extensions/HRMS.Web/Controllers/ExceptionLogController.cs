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
    public class ExceptionLogController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        public ExceptionLogController(IUtilityRepository utilityRepository)
        {
            _utilityRepository = utilityRepository;
        }
        #endregion
        [HttpGet]
        public ActionResult SelectAllExceptionLog()
        {
            List<ExceptionLog> exceptionLogList = _utilityRepository.ListExceptions();
            return View(exceptionLogList);
        }
	}
}