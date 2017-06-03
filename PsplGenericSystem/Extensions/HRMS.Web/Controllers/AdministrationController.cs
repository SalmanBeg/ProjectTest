using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;

namespace HRMS.Web.Controllers
{
    public class AdministrationController : Controller
    {
       #region Class Level Variables and constructor
        private readonly IHireConfigurationSetupRepository _hireConfigurationSetupRepository;
        private readonly IScreenVerbiageRepository _screenVerbiageRepository;
        public AdministrationController(IHireConfigurationSetupRepository hireConfigurationSetupRepository, IScreenVerbiageRepository screenVerbiageRepository)
        {
            _hireConfigurationSetupRepository = hireConfigurationSetupRepository;
            _screenVerbiageRepository = screenVerbiageRepository;
        }

        
        #endregion 
        /// <summary>
        /// View listing all the admin setup such as Add new lookupdata,
        /// </summary>
        /// <returns></returns>
         [Authorize]
        public ActionResult AdministrationDashboard()
        { 
            return View();
        }
        /// <summary>
        /// Navigating to grid showing submitted new hires
        /// </summary>
        /// <returns></returns>
         [Authorize]
        public ActionResult SubmittedNewHires()
        {
            List<Employee> submittedNewHiresList = new List<Employee>();
            submittedNewHiresList = _hireConfigurationSetupRepository.SelectAllNewHires(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(submittedNewHiresList);
        }
        /// <summary>
        /// Navigates to a view where welcome screen,approval screen verbiage is saved and fetched in OnBoarding process
        /// </summary>
        /// <returns></returns>
         [Authorize]
        public ActionResult CustomizeScreenVerbiage()
        {
            var screenVerbiageObj = new ScreenVerbiage();
            screenVerbiageObj = _screenVerbiageRepository.SelectScreenVerbiage(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(screenVerbiageObj);
        }
        /// <summary>
        /// Post to save screen verbiage for onboarding process
        /// </summary>
        /// <param name="screenVerbiageObj"></param>
        /// <returns></returns>
         [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult CustomizeScreenVerbiage(ScreenVerbiage screenVerbiageObj)
        {
            
            if (screenVerbiageObj.CompanyId == 0)
            {
                screenVerbiageObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                _screenVerbiageRepository.InsertScreenVerbiage(screenVerbiageObj);
            }
            else
                _screenVerbiageRepository.UpdateScreenVerbiage(screenVerbiageObj);
            return View(screenVerbiageObj);
        }
    }
}
