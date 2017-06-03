using HRMS.Common.Helpers;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Web.ViewModels;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;
using HRMS.Service.Repositories;

namespace HRMS.Web.Controllers
{
    public class JobProfileController : Controller
    {
        #region Class Level Variables and constructor
        public readonly IJobProfileRepository _jobProfileRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        public JobProfileController(IJobProfileRepository jobProfileController, IUtilityRepository utilityRepo, CompanyRepository companyRepository, IRegisteredUsersRepository registeredUsersRepository, IEmployeeRepository employeeRepository)
        {
            _jobProfileRepository = jobProfileController;
            _utilityRepository = utilityRepo;
            _companyRepository = companyRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeRepository = employeeRepository;
        }
        #endregion
        /// <summary>
        /// View to add a new job profile in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddJobProfile()
        {
            var jobProfileFormModelobj = new JobProfileFormModel();
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            jobProfileFormModelobj.JobCategoryList = lstlookup.Where(j => j.TableName == LocalizedStrings.JobCategory).ToList();
            jobProfileFormModelobj.JobCategoryList.Insert(0, lookUpDataEntityobj);
            jobProfileFormModelobj.JobProfile = new JobProfile();
            jobProfileFormModelobj.JobProfile.Status1 = true;         
            return View(jobProfileFormModelobj);
        }
        /// <summary>
        /// View to add a new job profile in a company
        /// </summary>
        /// <param name="jobProfileFormModelobj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public ActionResult AddJobProfile(JobProfileFormModel jobProfileFormModelobj)
        {
            ModelState.Remove("CityStateZipCode");

            jobProfileFormModelobj.JobProfile.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            jobProfileFormModelobj.JobProfile.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            jobProfileFormModelobj.JobProfile.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            jobProfileFormModelobj.JobProfile.JobProfileMode = true;
            jobProfileFormModelobj.JobProfile.IsRequisiton = false;
            //TODO:New Job Profile
            var addJobProfile = _jobProfileRepository.CreateJobProfile(jobProfileFormModelobj.JobProfile, jobProfileFormModelobj.JobDuties,jobProfileFormModelobj.JobQualifications,jobProfileFormModelobj.JobPmes
                ,jobProfileFormModelobj.RecruitingQuestions);
            
            if (Convert.ToBoolean(addJobProfile))
            {
                ModelState.AddModelError("", "Job Profile Created Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Job Profile cannot be created, Please try again.");
            }
            return RedirectToAction("ShowAllJobProfile");
        }
        /// <summary>
        /// View to add a new job profile in a company ajax call
        /// </summary>
        /// <param name="jobProfileObj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public ActionResult AddJobProfileAsync(JobProfile jobProfileObj)
        {
            ModelState.Remove("CityStateZipCode");

            jobProfileObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            jobProfileObj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            jobProfileObj.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            jobProfileObj.JobProfileMode = true;
            jobProfileObj.IsRequisiton = false;
            //TODO:New Job Profile
            var addJobProfile = _jobProfileRepository.CreateJobProfile(jobProfileObj,null,null,null,null);
            
            if (Convert.ToBoolean(addJobProfile))
            {
                ModelState.AddModelError("", "Job Profile Created Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Job Profile cannot be created, Please try again.");
            }
            return RedirectToAction("ShowAllJobProfile");
        }
        /// <summary>
        /// View to show all the created Job Profile in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ShowAllJobProfile()
        {
            var lstlookup = new List<LookUpDataEntity>();
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            List<JobProfile> jobProfileList = _jobProfileRepository.SelectJobProfile(companyId);
            foreach (var a in jobProfileList)
            {
                a.JobCategoryList = lstlookup.Where(j => j.TableName == LocalizedStrings.JobCategory).ToList();
                a.JobCategoryList = a.JobCategoryList.Where(m => m.Id == a.JobCategory).ToList();
            }
            return View(jobProfileList);
        }
        /// <summary>
        /// Action method to delete a job profile based on record Ids
        /// </summary>
        /// <param name="jobprofileIds"></param>
        /// <returns></returns>
        [Authorize]
        public bool DeleteJobprofile(string jobprofileIds)
        {
            if (jobprofileIds != null)
            {
                foreach (var jobprofileId in jobprofileIds.Split(','))
                {
                    var deleteJobProfile =
                        _jobProfileRepository.DeleteJobprofile(Int32.Parse(jobprofileId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
        /// <summary>
        /// View to update existing job profile record based on record id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult UpdateJobProfileById()
        {
            var jobProfileFormModelobj = new JobProfileFormModel();
            var id = Request.QueryString["JobProfileId"];
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            jobProfileFormModelobj.JobProfile = _jobProfileRepository.SelectJobProfileById(Convert.ToInt32(id));
            jobProfileFormModelobj.JobCategoryList = lstlookup.Where(j => j.TableName == LocalizedStrings.JobCategory).ToList();
            return View(jobProfileFormModelobj);
        }
        /// <summary>
        /// View to update existing job profile record based on record id(POST Method)
        /// </summary>
        /// <param name="jobProfileFormModelobj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateJobProfileById(JobProfileFormModel jobProfileFormModelobj)
        {
            ModelState.Remove("CityStateZipCode");
            //TODO:New Job Profile
            var success = _jobProfileRepository.CreateJobProfile(jobProfileFormModelobj.JobProfile, jobProfileFormModelobj.JobDuties,jobProfileFormModelobj.JobQualifications,jobProfileFormModelobj.JobPmes
                ,jobProfileFormModelobj.RecruitingQuestions);
            
            if (Convert.ToBoolean(success))
            {
                ModelState.AddModelError("", "Job Profile Updated Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Job Profile cannot be updated, Please try again.");
            }
            return RedirectToAction("ShowAllJobProfile");
        }
        /// <summary>
        /// Validation to check for duplication of job profiles while in add mode
        /// </summary>
        /// <param name="jobProfileFormModelObj"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("IsTitleExists")]
        public JsonResult IsTitleExists(JobProfileFormModel jobProfileFormModelObj)
        {
            jobProfileFormModelObj.JobProfile.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _jobProfileRepository.IsTitleExists(jobProfileFormModelObj.JobProfile);
            if (jobProfileFormModelObj.JobProfile.JobProfileId.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}