using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HRSystem.Services.Interfaces;
using HRSystem.Services.Models;
using HRSystem.Web.Common;

namespace HRSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ICompanyDashboard _companyDashboard;

        public HomeController(ICompanyDashboard companyDashboard)
        {
            _companyDashboard = companyDashboard;
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult companyDashboard()
        {
            var companyDashboard = new List<CompanyDashboards>();
            int companyId = 266;
            companyDashboard = _companyDashboard.GetCompanyDashboard(companyId, Globals.connectionString);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}