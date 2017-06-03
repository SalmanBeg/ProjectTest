using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;


namespace HRMS.Web.Controllers
{
    public class TrainingEmployeeViewController : Controller
    {
         #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly ITrainingEmployeeRepository _trainingEmployeeRepository;
        public TrainingEmployeeViewController(IUtilityRepository utilityRepo, ITrainingEmployeeRepository trainingEmployeeRepository)
        {
            _trainingEmployeeRepository = trainingEmployeeRepository;
            _utilityRepository = utilityRepo;
        }
        #endregion
        [Authorize]
        public ActionResult TrainingEmployeeView()
        {
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var trainingEmployeeViewFormModelobj = new TrainingEmployeeViewFormModel();
            trainingEmployeeViewFormModelobj.TrainingEmployeeView = new TrainingEmployeeView();
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            return View(trainingEmployeeViewFormModelobj);
        }
        [HttpPost]
        [Authorize]
        public ActionResult TrainingEmployeeView(TrainingEmployeeViewFormModel trainingEmployeeViewFormModelobj)
        {
            trainingEmployeeViewFormModelobj.TrainingEmployeeView.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            bool success = _trainingEmployeeRepository.TrainingEmployeeView(trainingEmployeeViewFormModelobj.TrainingEmployeeView);
            return RedirectToAction("SelectAllTrainingEmployee");
        }
        [Authorize]
        public ActionResult SelectAllTrainingEmployee()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<TrainingEmployeeView> trainingEmployeeViewList = _trainingEmployeeRepository.SelectAllTrainingEmployee(companyId);
            return View(trainingEmployeeViewList);
        }
        [Authorize]
        public bool DeleteTrainingEmployee(string trainingEmployeeViewIds)
        {
            if(trainingEmployeeViewIds !=null)
            {
                foreach(var trainingEmployeeViewId in  trainingEmployeeViewIds.Split(','))
                {
                     var deletetrainingEmployeeView =
                        _trainingEmployeeRepository.DeleteTrainingEmployee(Int32.Parse(trainingEmployeeViewId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
	}
}