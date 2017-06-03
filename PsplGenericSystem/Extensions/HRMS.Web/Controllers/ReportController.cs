using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Web.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult EmployeeAssetReport()
        {
            return View();
        }

        public ActionResult EmployeeDemographicReport()
        {
            return View();
        }

        public ActionResult EmployeeDirectoryReport()
        {
            return View();
        }

        public ActionResult EmployeeEmergencyContactReport()
        {
            return View();
        }
      
	}
}