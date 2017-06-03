using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Repositories;
using HRMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using Microsoft.SqlServer.Server;

namespace HRMS.Web.Controllers
{
    public class JobPMEController : Controller
    {


        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IJobPMERepository _jobPMERepository;
        private readonly IJobProfileRepository _jobProfileRepository;
        public JobPMEController(IUtilityRepository utilityRepo, CompanyRepository companyRepository, IRegisteredUsersRepository registeredUsersRepository, 
            IEmployeeRepository employeeRepository, IJobPMERepository jobPMERepository, IJobProfileRepository jobProfileRepository)
        {

            _utilityRepository = utilityRepo;
            _companyRepository = companyRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeRepository = employeeRepository;
            _jobPMERepository = jobPMERepository;
            _jobProfileRepository = jobProfileRepository;
        }
        #endregion
        /// <summary>
        /// View to add a new job PME
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult AddJobPME()
        {

            var jobPmeFormModelObj = new JobPMEFormModel();
            jobPmeFormModelObj.JobPME = new JobPME();
            if (!string.IsNullOrEmpty(Request.QueryString["JobPMEId"]))
            {
                jobPmeFormModelObj.JobPME.PMEId = Convert.ToInt32(Request.QueryString["JobPMEId"]);
                jobPmeFormModelObj.JobPME = _jobPMERepository.SelectJobPME(jobPmeFormModelObj.JobPME.PMEId);
            }
            var lookUpEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };

            
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            jobPmeFormModelObj.FrequencyList = lstlookup.Where(m => m.TableName == LocalizedStrings.Frequency).ToList();
            jobPmeFormModelObj.FrequencyList.Insert(0, lookUpEntityObj);
            jobPmeFormModelObj.EssentialList = lstlookup.Where(m => m.TableName == LocalizedStrings.Essential).ToList();
            jobPmeFormModelObj.EssentialList.Insert(0, lookUpEntityObj);
            return View(jobPmeFormModelObj);
        }
        /// <summary>
        /// View to add a new job PME
        /// </summary>
        /// <param name="jobPmeFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddJobPME(JobPMEFormModel jobPmeFormModelObj)
        {
            jobPmeFormModelObj.JobPME.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            jobPmeFormModelObj.JobPME.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            jobPmeFormModelObj.JobPME.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            int result;

            if (jobPmeFormModelObj.JobPME.PMEId.Equals(0))
                result = _jobPMERepository.CreateJobPME(jobPmeFormModelObj.JobPME);
            else
                result = _jobPMERepository.UpdateJobPME(jobPmeFormModelObj.JobPME);

            return RedirectToAction("SelectAllJobPME");

        }
        /// <summary>
        /// Action Method to show all the Job PME in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllJobPME()
        {

            var JobPMEList = _jobPMERepository.SelectAllJobPME(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(JobPMEList);

        }
        /// <summary>
        /// Method to delete a PME based on record Ids
        /// </summary>
        /// <param name="jobpmeIds"></param>
        /// <returns></returns>
        [Authorize]
        public bool DeleteJobPME(string jobpmeIds)
        {
            if (!string.IsNullOrEmpty(jobpmeIds))
            {
                foreach (var pmeid in jobpmeIds.Split(','))
                {
                    var deletejobPME = _jobPMERepository.DeleteJobPME(Convert.ToInt32(pmeid), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
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
        public ActionResult _JobPME(int jobProfileId)
        {
            var jobPmeList = _jobPMERepository.SelectAllJobPME(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var selectedJobPmes = new List<JobPME>();
            selectedJobPmes = _jobProfileRepository.ListJobPMEsInJobProfile(jobProfileId);
            if (TempData["JobPMEIds"] != null)
            {
                string jobPMEIds = Convert.ToString(TempData["JobPMEIds"]);
                if (!string.IsNullOrEmpty(jobPMEIds))
                {
                    string[] jobpmeIdarr = jobPMEIds.Split(',');
                    selectedJobPmes = jobpmeIdarr.Select(jobPmeId => new JobPME { PMEId = Convert.ToInt32(jobPmeId) }).ToList();
                    TempData["JobPMEIds"] = jobPMEIds;
                    TempData.Peek("JobPMEIds");
                }

            }
            var listJobPmeChkProp = (from jobPmeObj in jobPmeList
                                     join selectedJobPmesObj in selectedJobPmes on jobPmeObj.PMEId equals selectedJobPmesObj.PMEId into sub
                                        from sublist in sub.DefaultIfEmpty()
                                     select new { jobPmeObj.PMEId, jobPmeObj.Category, jobPmeObj.Description, jobPmeObj.FrequencyName, IsChecked = (sublist != null) }).ToList();
            List<SelectedPMEFormModel> selectedJobPmesList = new List<SelectedPMEFormModel>();
            if (listJobPmeChkProp.Count > 0)
            {

                foreach (var jobpmeschk in listJobPmeChkProp)
                {
                    SelectedPMEFormModel selectedPMEsObj = new SelectedPMEFormModel();
                    selectedPMEsObj.PMEId = jobpmeschk.PMEId;
                    selectedPMEsObj.PMEChecked = jobpmeschk.IsChecked;
                    selectedPMEsObj.Description = jobpmeschk.Description;
                    selectedPMEsObj.Category = jobpmeschk.Category;
                    selectedPMEsObj.Frequency = jobpmeschk.FrequencyName;
                    selectedJobPmesList.Add(selectedPMEsObj);
                }
            }


            return PartialView(selectedJobPmesList);
        }
        /// <summary>
        /// Partial view involved in new job creation for additional information for job description(POST Method)
        /// </summary>
        /// <param name="jobProfileFormModelObj"></param>
        /// <param name="jobPMEIds"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public bool _JobPME(JobProfileFormModel jobProfileFormModelObj, string jobPMEIds)
        {
            TempData["JobProfileFormModel"] = jobProfileFormModelObj;
            TempData["JobPMEIds"] = jobPMEIds;
            return true;
        }
    }
}