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
    public class MasterController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IMasterRepository _masterRepository;
        private readonly IUtilityRepository _utilityRepository;
        public MasterController(IUtilityRepository utilityRepo, IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
            _utilityRepository = utilityRepo;
        }
        #endregion
        [HttpGet]
        public ActionResult ReviewNotification()
        {
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var revieweeobj = new Reviewee();
            return View(revieweeobj);
        }
        [HttpPost]
        public ActionResult ReviewNotification(Reviewee revieweeobj)
        {
            revieweeobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            int employeeId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            List<Reviewee> reviewmasterList = _masterRepository.SelectReviewNotification(employeeId, companyId);
            return View(reviewmasterList);
        }

    }
}