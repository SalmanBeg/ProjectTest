using System.Web.Script.Serialization;
using System.Web.UI.WebControls.WebParts;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Repositories;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using HRMS.Common.Helpers;

namespace HRMS.Web.Controllers
{
    public class JobDutiesController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IJobDutiesRepository _jobDutiesRepository;
        private readonly IJobProfileRepository _jobProfileRepository;
        public JobDutiesController(IUtilityRepository utilityRepo, CompanyRepository companyRepository,
            IRegisteredUsersRepository registeredUsersRepository, IEmployeeRepository employeeRepository, IJobDutiesRepository jobDutiesRepository, IJobProfileRepository jobprofileRepository)
        {

            _utilityRepository = utilityRepo;
            _companyRepository = companyRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeRepository = employeeRepository;
            _jobDutiesRepository = jobDutiesRepository;
            _jobProfileRepository = jobprofileRepository;
        }
        #endregion

        /// <summary>
        /// View to add new job duty related to job profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult AddJobDuties()
        {
            var jobDutiesObj = new JobDutiesFormModel();
            jobDutiesObj.JobDuties = new JobDuties();
            if (!string.IsNullOrEmpty(Request.QueryString["JobDutyId"]))
            {
                jobDutiesObj.JobDuties.JobDutyId = Convert.ToInt32(Request.QueryString["JobDutyId"]);
                jobDutiesObj.JobDuties = _jobDutiesRepository.SelectJobDuty(jobDutiesObj.JobDuties.JobDutyId);
            }
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };

            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            jobDutiesObj.PriorityList = lstlookup.Where(j => j.TableName == LocalizedStrings.Priority).ToList();
            jobDutiesObj.PriorityList.Insert(0, lookUpDataEntityobj);
            jobDutiesObj.FrequencyList = lstlookup.Where(j => j.TableName == LocalizedStrings.Frequency).ToList();
            jobDutiesObj.FrequencyList.Insert(0, lookUpDataEntityobj);
            jobDutiesObj.EssentialList = lstlookup.Where(j => j.TableName == LocalizedStrings.Essential).ToList();
            jobDutiesObj.EssentialList.Insert(0, lookUpDataEntityobj);
            jobDutiesObj.OtherList = lstlookup.Where(j => j.TableName == LocalizedStrings.Other).ToList();
            jobDutiesObj.OtherList.Insert(0, lookUpDataEntityobj);


            return View(jobDutiesObj);
        }
        /// <summary>
        /// View to add new job duty related to job profile(POST Method)
        /// </summary>
        /// <param name="jobDutiesFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddJobDuties(JobDutiesFormModel jobDutiesFormModelObj)
        {
            jobDutiesFormModelObj.JobDuties.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            jobDutiesFormModelObj.JobDuties.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            jobDutiesFormModelObj.JobDuties.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            int result;
            if (jobDutiesFormModelObj.JobDuties.JobDutyId.Equals(0))
                result = _jobDutiesRepository.CreateJobDuties(jobDutiesFormModelObj.JobDuties);
            else
                result = _jobDutiesRepository.UpdateJobDuties(jobDutiesFormModelObj.JobDuties);

            return RedirectToAction("SelectAllJobDuties");

        }
        /// <summary>
        /// View to show all Job duties in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllJobDuties()
        {
            var jobDutiesList = _jobDutiesRepository.SelectAllJobDuties(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(jobDutiesList);
        }
        /// <summary>
        /// Method to delete a job duty based on job dutyId
        /// </summary>
        /// <param name="jobdutyIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteJobDuties(string jobdutyIds)
        {

            if (!string.IsNullOrEmpty(jobdutyIds))
            {
                foreach (var jobDutyId in jobdutyIds.Split(','))
                {
                    var deleteJobDuty =
                           _jobDutiesRepository.DeleteJobDuties(Int32.Parse(jobDutyId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }

            }
            return true;
        }
        /// <summary>
        /// Partial view involved in new job creation for additional information for job description
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult _JobDuties(int jobProfileId)
        {

            var jobDutiesList = _jobDutiesRepository.SelectAllJobDuties(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            //if (jobProfileId != 0)
            //{
            var selectedJobDuties = new List<JobDuties>();
            selectedJobDuties = _jobProfileRepository.ListJobDutiesInJobProfile(jobProfileId);
            if (TempData["JobDutyIds"] != null)
            {
                string jobDutyIds = Convert.ToString(TempData["JobDutyIds"]);
                if (!string.IsNullOrEmpty(jobDutyIds))
                {
                    string[] jobDutyIdarr = jobDutyIds.Split(',');
                    selectedJobDuties = jobDutyIdarr.Select(jobDutyId => new JobDuties { JobDutyId = Convert.ToInt32(jobDutyId) }).ToList();
                    TempData["JobDutyIds"] = jobDutyIds;
                    TempData.Peek("JobDutyIds");
                }
            }
            var listJobDutiesChkProp = (from jobDutiesObj in jobDutiesList
                                        join selectedJobDutyObj in selectedJobDuties on jobDutiesObj.JobDutyId equals selectedJobDutyObj.JobDutyId into sub
                                        from sublist in sub.DefaultIfEmpty()
                                        select new { jobDutiesObj.JobDutyId, jobDutiesObj.PriorityName, jobDutiesObj.Description, jobDutiesObj.Category, IsChecked = (sublist != null) }).ToList();
            List<SelectedDutiesFormModel> selectedJobDutiesList = new List<SelectedDutiesFormModel>();
            if (listJobDutiesChkProp.Count > 0)
            {

                foreach (var jobdutieschk in listJobDutiesChkProp)
                {
                    SelectedDutiesFormModel selectedDutiesObj = new SelectedDutiesFormModel();
                    selectedDutiesObj.JobDutyId = jobdutieschk.JobDutyId;
                    selectedDutiesObj.DutiesChecked = jobdutieschk.IsChecked;
                    selectedDutiesObj.Description = jobdutieschk.Description;
                    selectedDutiesObj.Category = jobdutieschk.Category;
                    selectedDutiesObj.Priority = jobdutieschk.PriorityName;
                    selectedJobDutiesList.Add(selectedDutiesObj);
                }
            }
            //}

            return PartialView(selectedJobDutiesList);

        }
        /// <summary>
        /// Partial view involved in new job creation for additional information for job description(POST Method)
        /// </summary>
        /// <param name="jobProfileFormModelObj"></param>
        /// <param name="jobDutyIds"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public bool _JobDuties(JobProfileFormModel jobProfileFormModelObj, string jobDutyIds)
        {
            TempData["JobProfileFormModel"] = jobProfileFormModelObj;
            TempData["JobDutyIds"] = jobDutyIds;
            return true;
        }
    }
}
