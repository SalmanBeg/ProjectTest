using HRMS.Common.Helpers;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.Helper;

namespace HRMS.Web.Controllers
{
    public class JobQualificationController : Controller
    {

        #region Class Level Variables and Constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IJobQualificationRepository _jobQualificationRepository;
        private readonly IJobProfileRepository _jobProfileRepository;
        public JobQualificationController(IUtilityRepository utilityRepo, ICompanyRepository companyRepository, 
            IRegisteredUsersRepository registeredUsersRepository, IEmployeeRepository employeeRepository, 
            IJobQualificationRepository jobQualificationRepository, IJobProfileRepository jobProfileRepository)
        {
            _utilityRepository = utilityRepo;
            _companyRepository = companyRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeRepository = employeeRepository;
            _jobQualificationRepository= jobQualificationRepository;
            _jobProfileRepository = jobProfileRepository;
        }
        #endregion

        /// <summary>
        /// View to add a new job qualification in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddJobQualification()
        {
            var jobQualificationFormModelObj = new JobQualificationFormModel();
            jobQualificationFormModelObj.JobQualification = new JobQualification();
            if (!string.IsNullOrEmpty(Request.QueryString["JobQualificationID"]))
            {
                jobQualificationFormModelObj.JobQualification.JobQualificationId = Convert.ToInt32(Request.QueryString["JobQualificationID"]);
                jobQualificationFormModelObj.JobQualification = _jobQualificationRepository.SelectJobQualification(jobQualificationFormModelObj.JobQualification.JobQualificationId);
            }
            
             
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            jobQualificationFormModelObj.TypeList = lstlookup.Where(m => m.TableName == LocalizedStrings.JobQualificationType).ToList();
            jobQualificationFormModelObj.TypeList.Insert(0, lookUpDataEntityobj);

            return View(jobQualificationFormModelObj);
        }
        /// <summary>
        /// View to add a new job qualification in a company
        /// </summary>
        /// <param name="jobQualificationFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddJobQualification(JobQualificationFormModel jobQualificationFormModelObj)
        {
            
            jobQualificationFormModelObj.JobQualification.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            jobQualificationFormModelObj.JobQualification.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            jobQualificationFormModelObj.JobQualification.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            int result;
            if (jobQualificationFormModelObj.JobQualification.JobQualificationId.Equals(0))
                result = _jobQualificationRepository.CreateJobQualification(jobQualificationFormModelObj.JobQualification);
            else
                result = _jobQualificationRepository.UpdateJobQualification(jobQualificationFormModelObj.JobQualification);
            return RedirectToAction("SelectAllJobQualification");
        }
        /// <summary>
        /// View to show all the job qualification records in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllJobQualification()
        {

            var jobQualificationList = _jobQualificationRepository.SelectAllJobQualification(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(jobQualificationList);

        }
        /// <summary>
        /// Action method to delete a job qualification based on record Id
        /// </summary>
        /// <param name="jobqualificationIds"></param>
        /// <returns></returns>
        [Authorize]
        public bool DeleteJobQualification(string jobqualificationIds)
        {

            if (!string.IsNullOrEmpty(jobqualificationIds))
            {
                foreach (var jobQualificationId in jobqualificationIds.Split(','))
                {
                    var deleteJobQualification =
                           _jobQualificationRepository.DeleteJobQualification(Int32.Parse(jobQualificationId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            
            }
            return true;
        }
        /// <summary>
        /// Partial view involved in new job creation for additional information for job description(POST Method)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult _JobQualification(int jobProfileId)
        {
            var jobQualificationList = _jobQualificationRepository.SelectAllJobQualification(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var selectedJobQualifications = new List<JobQualification>();
                selectedJobQualifications = _jobProfileRepository.ListJobQualificationsInJobProfile(jobProfileId);

            if(TempData["JobQualificationIds"]!=null)
            {
                string jobQualificationIds = Convert.ToString(TempData["JobQualificationIds"]);
                if (!string.IsNullOrEmpty(jobQualificationIds))
                {
                    string[] jobQualificationIdarr = jobQualificationIds.Split(',');
                    selectedJobQualifications = jobQualificationIdarr.Select(jobQualificationId => new JobQualification { JobQualificationId = Convert.ToInt32(jobQualificationId) }).ToList();
                    TempData["JobQualificationIds"] = jobQualificationIds;
                    TempData.Peek("JobQualificationIds");
                }
            }

            var listJobQualificationsChkProp = (from jobQualificaitonsObj in jobQualificationList
                                                join selectedJobQualificationsObj in selectedJobQualifications on jobQualificaitonsObj.JobQualificationId equals selectedJobQualificationsObj.JobQualificationId into sub
                                                from sublist in sub.DefaultIfEmpty()
                                                select new { jobQualificaitonsObj.JobQualificationId, jobQualificaitonsObj.SubjectArea, jobQualificaitonsObj.Proficiency, jobQualificaitonsObj.Description, IsChecked = (sublist != null) }).ToList();
            List<SelectedQualificationsFormModel> selectedJobQualificationsList = new List<SelectedQualificationsFormModel>();
            if (listJobQualificationsChkProp.Count > 0)
            {

                foreach (var jobqualificationschk in listJobQualificationsChkProp)
                {
                    SelectedQualificationsFormModel selectedQualificationsObj = new SelectedQualificationsFormModel();
                    selectedQualificationsObj.JobQualificationId = jobqualificationschk.JobQualificationId;
                    selectedQualificationsObj.SubjectArea = jobqualificationschk.SubjectArea;
                    selectedQualificationsObj.Proficiency = jobqualificationschk.Proficiency;
                    selectedQualificationsObj.Description = jobqualificationschk.Description;
                    selectedQualificationsObj.QualificationsChecked = jobqualificationschk.IsChecked;
                    selectedJobQualificationsList.Add(selectedQualificationsObj);
                }
            }


            return PartialView(selectedJobQualificationsList);
           
        }
        /// <summary>
        /// Partial view involved in new job creation for additional information for job description(POST Method)
        /// </summary>
        /// <param name="jobProfileFormModelObj"></param>
        /// <param name="jobQualificationIds"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public bool _JobQualification(JobProfileFormModel jobProfileFormModelObj, string jobQualificationIds)
        {
            TempData["JobProfileFormModel"] = jobProfileFormModelObj;
            TempData["JobQualificationIds"] = jobQualificationIds;
            return true;
        }
	}
}