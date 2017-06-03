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
using System.Web.Script.Serialization;
using System.Data;
using System.Data.Entity;
using HRMS.Common.Enums;
using System.Configuration;
using System.Web.Security;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using Rotativa;
using Rotativa.Options;

namespace HRMS.Web.Controllers
{
    public class RecruitingController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IJobProfileRepository _jobProfileRepository;
        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IRecruitingQuestionsRepository _recrutingQuestionsRepository;
        private readonly IJobDutiesRepository _jobDutiesRepository;
        private readonly IJobQualificationRepository _jobQualificationRepository;
        private readonly IJobPMERepository _jobPmeRepository;
        private readonly IRecruitingAnswersRepository _recruitingAnswersRepository;
        private readonly IInterviewRepository _interviewRepository;
 

        public RecruitingController(IJobProfileRepository jobProfileRepository, IUtilityRepository utilityRepository, CompanyRepository companyRepository,
            IRegisteredUsersRepository registeredUsersRepository, IEmployeeRepository employeeRepository, IJobApplicantRepository jobApplicantRepository,
            IRecruitingQuestionsRepository recruitingQuestionsRepository, IJobDutiesRepository jobDutiesRepository,
            IJobQualificationRepository jobQualificationRepository, IJobPMERepository jobPmeRepository, IRecruitingAnswersRepository recruitingAnswersRepository, IInterviewRepository interviewRepository, IFilesDBRepository filesDBRepository)
        {
            _jobProfileRepository = jobProfileRepository;
            _jobApplicantRepository = jobApplicantRepository;
            _utilityRepository = utilityRepository;
            _filesDBRepository = filesDBRepository;
            _companyRepository = companyRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeRepository = employeeRepository;
            _recrutingQuestionsRepository = recruitingQuestionsRepository;
            _jobDutiesRepository = jobDutiesRepository;
            _jobQualificationRepository = jobQualificationRepository;
            _jobPmeRepository = jobPmeRepository;
            _recruitingAnswersRepository = recruitingAnswersRepository;
            _interviewRepository = interviewRepository;
        }
        #endregion
        /// <summary>
        /// Dashboard to show all the navigation properties for the properties involved in recruiting process
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult RecruitingDashboard(JobProfileFormModel jobProfileModelObj)
        {
            List<JobProfile> Jobslist = _jobProfileRepository.ListAvailableJobsForJobPortal(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (Jobslist.Count() > 0)
                jobProfileModelObj.DashboardCount.NewHireCount = Jobslist.Count;
            else
            {
                jobProfileModelObj.DashboardCount.NewHireCount = 0;
            }
            return View(jobProfileModelObj);
        }
        /// <summary>
        /// View to add a new job in recruiting process
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateNewJob()
        {
            //variable declared for adding new element in dropdown
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var jobProfileModelObj = new JobProfileFormModel();
            jobProfileModelObj.JobProfile = new JobProfile();
            if (TempData["JobProfileFormModel"] != null)
            {
                jobProfileModelObj = TempData["JobProfileFormModel"] as JobProfileFormModel;
            }
            if (!string.IsNullOrEmpty(Request.QueryString["Mode"]) && Request.QueryString["Mode"].Equals("Add"))
            {
                jobProfileModelObj = new JobProfileFormModel();
                jobProfileModelObj.JobProfile = new JobProfile();
                TempData["JobDutyIds"] = string.Empty;
                TempData["JobQualificationIds"] = string.Empty;
                TempData["JobPMEIds"] = string.Empty;
                TempData["RecruitingQuestionIds"] = string.Empty;
            }
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            jobProfileModelObj.JobCategoryList = lstlookup.Where(j => j.TableName == LocalizedStrings.JobCategory).ToList();
            jobProfileModelObj.JobCategoryList.Insert(0, lookUpDataEntityobj);
            var companyInfo = _companyRepository.GetEditCompanyInfo(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            if (companyInfo.Description != null)
                jobProfileModelObj.JobProfile.CompanyDescription = companyInfo.Description;

            //Get all employees from current company
            jobProfileModelObj.HiringManagerList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.CurrentUserId)).ToList();
            jobProfileModelObj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));


            //To select selected job duties to bind in description field
            string jobDutyIds = Convert.ToString(TempData["JobDutyIds"]);
            string jobQualificationIds = Convert.ToString(TempData["JobQualificationIds"]);
            string jobPMEIds = Convert.ToString(TempData["JobPMEIds"]);
            string recruitingQuestionIds = Convert.ToString(TempData["RecruitingQuestionIds"]);
            if (!string.IsNullOrEmpty(jobDutyIds))
                jobProfileModelObj.JobDuties = _jobDutiesRepository.ListSelectedJobDuties(jobDutyIds.Split(',').Select(n => int.Parse(n)).ToArray(), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (!string.IsNullOrEmpty((jobQualificationIds)))
                jobProfileModelObj.JobQualifications = _jobQualificationRepository.ListSelectedJobQualifications(jobQualificationIds.Split(',').Select(n => int.Parse(n)).ToArray(), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (!string.IsNullOrEmpty(jobPMEIds))
                jobProfileModelObj.JobPmes = _jobPmeRepository.ListSelectedJobPMEs(jobPMEIds.Split(',').Select(n => int.Parse(n)).ToArray(), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (!string.IsNullOrEmpty(recruitingQuestionIds))
                jobProfileModelObj.RecruitingQuestions = _recrutingQuestionsRepository.ListSelectedRecruitingQuestion(recruitingQuestionIds.Split(',').Select(n => int.Parse(n)).ToArray(), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            foreach (var jobDuty in jobProfileModelObj.JobDuties)
            {
                jobProfileModelObj.JobProfile.JobDescription += jobDuty.Description;
            }
            foreach (var jobQualification in jobProfileModelObj.JobQualifications)
            {
                jobProfileModelObj.JobProfile.JobDescription += jobQualification.Description;
            }
            foreach (var jobPME in jobProfileModelObj.JobPmes)
            {
                jobProfileModelObj.JobProfile.JobDescription += jobPME.Description;
            }
            //foreach (var recruitingQuestion in jobProfileModelObj.RecruitingQuestions)
            //{
            //    jobProfileModelObj.JobProfile.JobDescription = recruitingQuestion.RecruitingQuestionId;
            //}
            TempData["JobDutyIds"] = jobDutyIds;
            TempData.Peek("JobDutyIds");
            TempData["JobQualificationIds"] = jobQualificationIds;
            TempData.Peek("JobQualificationIds");
            TempData["JobPMEIds"] = jobPMEIds;
            TempData.Peek("JobPMEIds");
            TempData["RecruitingQuestionIds"] = recruitingQuestionIds;
            TempData.Peek("RecruitingQuestionIds");
            return View(jobProfileModelObj);
        }
        /// <summary>
        ///  View to add a new job in recruiting process(POST Method)
        /// </summary>
        /// <param name="jobProfileModelObj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateNewJob(JobProfileFormModel jobProfileModelObj)
        {
            int jobId = 0;
            string jobDutyIds = Convert.ToString(TempData["JobDutyIds"]);
            if (!string.IsNullOrEmpty(jobDutyIds))
            {
                string[] jobDutyIdarr = jobDutyIds.Split(',');
                var jobDuties = jobDutyIdarr.Select(jobDutyId => new JobDuties { JobDutyId = Convert.ToInt32(jobDutyId) }).ToList();
                jobProfileModelObj.JobDuties = jobDuties;
            }
            string jobQualificationIds = Convert.ToString(TempData["JobQualificationIds"]);
            if (!string.IsNullOrEmpty(jobQualificationIds))
            {
                string[] jobQualificationIdarr = jobQualificationIds.Split(',');
                var jobQualifications = jobQualificationIdarr.Select(jobQualificationId => new JobQualification { JobQualificationId = Convert.ToInt32(jobQualificationId) }).ToList();
                jobProfileModelObj.JobQualifications = jobQualifications;
            }
            string jobPMEIds = Convert.ToString(TempData["JobPMEIds"]);
            if (!string.IsNullOrEmpty(jobPMEIds))
            {
                string[] jobpmeIdarr = jobPMEIds.Split(',');
                var jobPMEs = jobpmeIdarr.Select(jobPmeId => new JobPME { PMEId = Convert.ToInt32(jobPmeId) }).ToList();
                jobProfileModelObj.JobPmes = jobPMEs;
            }
            string recruitingQuestionIds = Convert.ToString(TempData["RecruitingQuestionIds"]);
            if (!string.IsNullOrEmpty(recruitingQuestionIds))
            {
                string[] recruitingquestionIdIdarr = recruitingQuestionIds.Split(',');
                var recruitingQuestions = recruitingquestionIdIdarr.Select(recruitingQuestionId => new RecruitingQuestions { RecruitingQuestionId = Convert.ToInt32(recruitingQuestionId) }).ToList();
                jobProfileModelObj.RecruitingQuestions = recruitingQuestions;
            }
            jobProfileModelObj.JobProfile.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            jobProfileModelObj.JobProfile.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            jobProfileModelObj.JobProfile.ModifiedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);

            jobProfileModelObj.JobProfile.Status = true;
            jobProfileModelObj.JobProfile.IsRequisiton = true;
            if (jobProfileModelObj.JobProfile.IsPosted == null)
                jobProfileModelObj.JobProfile.IsPosted = false;
            //TODO:New Job Profile
            jobId = _jobProfileRepository.CreateJobProfile(jobProfileModelObj.JobProfile, jobProfileModelObj.JobDuties, jobProfileModelObj.JobQualifications, jobProfileModelObj.JobPmes
                , jobProfileModelObj.RecruitingQuestions);
            //jobId = 54;

            //var Jobslist = _jobProfileRepository.ListAvailableJobsForJobPortal(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            //if (Jobslist.Count() > 0)
            //    jobProfileModelObj.DashboardCount.NewJobsCount = Jobslist.Count;
            //else
            //{
            //    jobProfileModelObj.DashboardCount.NewJobsCount = 0;
            //}

            if (jobId > 0)
            {
                if (jobProfileModelObj.RecruiterIdList != null)
                    foreach (var recruiterId in jobProfileModelObj.RecruiterIdList.Split(','))
                    {
                        _jobProfileRepository.AddJobRecruiter(jobId, Convert.ToInt32(recruiterId));
                    }


                TempData["JobProfileID"] = Convert.ToString(jobId);
                var rqrdpath = Convert.ToString(Server.MapPath("~/Utilities/RequisitionApproval.html"));

                //string strPreviewURL = "~/Recruiting/RecruitingPreview";
                string strPreviewURL = ConfigurationManager.AppSettings["_RecruitingPrview"];
                strPreviewURL = strPreviewURL + "?JobId=" + Convert.ToString(jobId) + "";
                var jobProfileObj = _jobProfileRepository.JobProfileGetPreview(jobId);
                string strHireManagerName = jobProfileObj.HiringManagerName;
                string strHireManagerEmail = jobProfileObj.HiringManagerEmail;
                string comp = jobProfileObj.CompanyDescription;
                string strSubject = "Requisition Approval";
                string strJobTitle = jobProfileModelObj.JobProfile.Title;
                DateTime dt = System.DateTime.Now;
                Mailing.Sendemailtouser(strHireManagerEmail, strSubject, "", strHireManagerName, GlobalsVariables.CurrentCompanyName, "", "", rqrdpath, strPreviewURL, GlobalsVariables.CurrentUserName, "", dt, strJobTitle);


                return RedirectToAction("RecruitingDashboard", "Recruiting");
            }

            return View(jobProfileModelObj);

        }

        /// <summary>
        /// View to list all the jobs
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult MyJobs()
        {
            List<JobProfile> lstJobProfile = _jobProfileRepository.ListAvailableJobsForJobPortal(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            return View(lstJobProfile);
        }


        public ActionResult RecruitingPreview()
        {
            int jobProfileID = Convert.ToInt32(Request.QueryString["JobId"]);
            var jobProfileObj = _jobProfileRepository.JobProfileGetPreview(jobProfileID);

            return View(jobProfileObj);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RecruitingPreview(JobProfile jobProfileObj)
        {
            // int jobProfileID = Convert.ToInt32(Request.QueryString["JobId"]);
            _jobProfileRepository.JobProfileHiringManagerCommentsUpdate(jobProfileObj.JobProfileId, jobProfileObj.Comments);

            return RedirectToAction("RecruitingDashboard", "Recruiting");
        }

        /// <summary>
        /// View to show the candidate information for all the jobs
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Quiz()
        {
            int jobId = Convert.ToInt32(Request.QueryString["JobProfileId"]);
            var jobProfileModelObj = new AvailableJobFormModel();
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            jobProfileModelObj.JobCategoryList = lstlookup.Where(j => j.TableName == LocalizedStrings.JobCategory).ToList();
            jobProfileModelObj.JobProfile = new JobProfile();
            //Get all employees from current company
            jobProfileModelObj.HiringManagerList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.CurrentUserId)).ToList();
            jobProfileModelObj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            jobProfileModelObj.JobRecruiterList = _jobProfileRepository.SelectJobRecruitersByJobId(jobId);
            jobProfileModelObj.Interviews = _interviewRepository.InterviewSelectAll(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var result = (from employees in jobProfileModelObj.EmployeeList
                          join recruiters in jobProfileModelObj.JobRecruiterList on employees.UserId equals recruiters.EmployeeId into gj
                          from sublist in gj.DefaultIfEmpty()
                          select new { employees.UserId, employees.UserName, IsChecked = (sublist != null) }).ToList();

            jobProfileModelObj.ResultList = result.Select(x => new Recruiter
            {
                employeeId = x.UserId,
                recruiterName = x.UserName,
                isChecked = x.IsChecked
            }).ToList();

            TempData["JobProfileId"] = jobId;
            //Get company description from companyinfo table

            var companyInfo = _companyRepository.GetEditCompanyInfo(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (companyInfo.Description != null)
                jobProfileModelObj.JobProfile.CompanyDescription = companyInfo.Description;
            jobProfileModelObj.JobCategoryList = lstlookup.Where(j => j.TableName == LocalizedStrings.JobCategory).ToList();
            jobProfileModelObj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            jobProfileModelObj.JobProfile = _jobProfileRepository.SelectJobProfileById(jobId);
            string baseURL = System.Configuration.ConfigurationManager.AppSettings["BaseURL"];
            jobProfileModelObj.JobProfile.JobUrl = baseURL + "JobPortal/JobPortal/AvailableJobs?CompanyId=" + Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            if (jobProfileModelObj.JobProfile == null)
                jobProfileModelObj.JobProfile = new JobProfile();
            //if createdBy exists get the name of the employee from employee table
            var employeeObj = new Employee();
            if (jobProfileModelObj.JobProfile.CreatedBy != null)
            { employeeObj = _employeeRepository.SelectEmployeeById(Convert.ToInt32(jobProfileModelObj.JobProfile.CreatedBy), Convert.ToInt32(jobProfileModelObj.JobProfile.CompanyId)); }
            jobProfileModelObj.JobProfile.CreatedByName = employeeObj.FirstName + "" + employeeObj.LastName;


            //Listing properties of job profile
            var jobDuties = _jobProfileRepository.ListJobDutiesInJobProfile(jobId);
            foreach (var jobduty in jobDuties)
            {
                var selectedJobPropertyObj = new SelectedJobProperty();
                selectedJobPropertyObj.Id = jobduty.JobDutyId;
                selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobDuty.ToString();
                selectedJobPropertyObj.Description = jobduty.Description;
                selectedJobPropertyObj.JobProfileId = jobId;
                selectedJobPropertyObj.PercentageOfTime = jobduty.PercentageOfTime;
                jobProfileModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
            }
            var jobQualifications = _jobProfileRepository.ListJobQualificationsInJobProfile(jobId);
            foreach (var jobqualification in jobQualifications)
            {
                var selectedJobPropertyObj = new SelectedJobProperty();
                selectedJobPropertyObj.Id = jobqualification.JobQualificationId;
                selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobQualification.ToString();
                selectedJobPropertyObj.Description = jobqualification.Description;
                selectedJobPropertyObj.JobProfileId = jobId;
                selectedJobPropertyObj.Proficiency = jobqualification.Proficiency;
                jobProfileModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
            }

            var jobPMEs = _jobProfileRepository.ListJobPMEsInJobProfile(jobId);
            foreach (var jobpme in jobPMEs)
            {
                var selectedJobPropertyObj = new SelectedJobProperty();
                selectedJobPropertyObj.Id = jobpme.PMEId;
                selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobPME.ToString();
                selectedJobPropertyObj.Description = jobpme.Description;
                selectedJobPropertyObj.JobProfileId = jobId;
                jobProfileModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
            }
            return View(jobProfileModelObj);

        }
        /// <summary>
        /// Partial view to show the Job the way it looks in portal
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _Preview()
        {
            var availableJobFormModelObj = new AvailableJobFormModel();
            availableJobFormModelObj.Jobs =
               _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var tmpdata = TempData["JobProfileId"] as JobProfile;

            availableJobFormModelObj.Jobs = availableJobFormModelObj.Jobs.Where(p => p.JobProfileId == availableJobFormModelObj.JobCategory).ToList();

            foreach (var jobprofileObj in availableJobFormModelObj.Jobs)
            {
                var jobDuties = _jobProfileRepository.ListJobDutiesInJobProfile(jobprofileObj.JobProfileId);
                foreach (var jobduty in jobDuties)
                {
                    var selectedJobPropertyObj = new SelectedJobProperty();
                    selectedJobPropertyObj.Id = jobduty.JobDutyId;
                    selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobDuty.ToString();
                    selectedJobPropertyObj.Description = jobduty.Description;
                    selectedJobPropertyObj.JobProfileId = jobprofileObj.JobProfileId;
                    selectedJobPropertyObj.PercentageOfTime = jobduty.PercentageOfTime;
                    availableJobFormModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
                }
                var jobQualifications = _jobProfileRepository.ListJobQualificationsInJobProfile(jobprofileObj.JobProfileId);
                foreach (var jobqualification in jobQualifications)
                {
                    var selectedJobPropertyObj = new SelectedJobProperty();
                    selectedJobPropertyObj.Id = jobqualification.JobQualificationId;
                    selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobQualification.ToString();
                    selectedJobPropertyObj.Description = jobqualification.Description;
                    selectedJobPropertyObj.JobProfileId = jobprofileObj.JobProfileId;
                    selectedJobPropertyObj.Proficiency = jobqualification.Proficiency;
                    availableJobFormModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
                }

                var jobPMEs = _jobProfileRepository.ListJobPMEsInJobProfile(jobprofileObj.JobProfileId);
                foreach (var jobpme in jobPMEs)
                {
                    var selectedJobPropertyObj = new SelectedJobProperty();
                    selectedJobPropertyObj.Id = jobpme.PMEId;
                    selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobPME.ToString();
                    selectedJobPropertyObj.Description = jobpme.Description;
                    selectedJobPropertyObj.JobProfileId = jobprofileObj.JobProfileId;
                    availableJobFormModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
                }
            }
            return View(availableJobFormModelObj);
        }
        /// <summary>
        /// Partial view to load all the details of a job
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _Summary()
        {
            return View();
        }
        /// <summary>
        /// Partial view to edit an existing job
        /// </summary>
        /// <param name="jobProfileModelObj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public ActionResult _EditJob(JobProfileFormModel jobProfileModelObj)
        {
            int jobId = 0;
            string jobDutyIds = Convert.ToString(TempData["JobDutyIds"]);
            if (!string.IsNullOrEmpty(jobDutyIds))
            {
                string[] jobDutyIdarr = jobDutyIds.Split(',');
                var jobDuties = jobDutyIdarr.Select(jobDutyId => new JobDuties { JobDutyId = Convert.ToInt32(jobDutyId) }).ToList();
                jobProfileModelObj.JobDuties = jobDuties;
            }
            string jobQualificationIds = Convert.ToString(TempData["JobQualificationIds"]);
            if (!string.IsNullOrEmpty(jobQualificationIds))
            {
                string[] jobQualificationIdarr = jobQualificationIds.Split(',');
                var jobQualifications = jobQualificationIdarr.Select(jobQualificationId => new JobQualification { JobQualificationId = Convert.ToInt32(jobQualificationId) }).ToList();
                jobProfileModelObj.JobQualifications = jobQualifications;
            }
            string jobPMEIds = Convert.ToString(TempData["JobPMEIds"]);
            if (!string.IsNullOrEmpty(jobPMEIds))
            {
                string[] jobpmeIdarr = jobPMEIds.Split(',');
                var jobPMEs = jobpmeIdarr.Select(jobPmeId => new JobPME { PMEId = Convert.ToInt32(jobPmeId) }).ToList();
                jobProfileModelObj.JobPmes = jobPMEs;
            }
            string recruitingQuestionIds = Convert.ToString(TempData["RecruitingQuestionIds"]);
            if (!string.IsNullOrEmpty(recruitingQuestionIds))
            {
                string[] recruitingquestionIdIdarr = recruitingQuestionIds.Split(',');
                var recruitingQuestions = recruitingquestionIdIdarr.Select(recruitingQuestionId => new RecruitingQuestions { RecruitingQuestionId = Convert.ToInt32(recruitingQuestionId) }).ToList();
                jobProfileModelObj.RecruitingQuestions = recruitingQuestions;
            }
            jobProfileModelObj.JobProfile.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            jobProfileModelObj.JobProfile.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            jobProfileModelObj.JobProfile.ModifiedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            jobProfileModelObj.JobProfile.Status = true;
            //TODO:New Job Profile
            jobId = _jobProfileRepository.CreateJobProfile(jobProfileModelObj.JobProfile, jobProfileModelObj.JobDuties, jobProfileModelObj.JobQualifications, jobProfileModelObj.JobPmes
                , jobProfileModelObj.RecruitingQuestions);
            if (jobId > 0)
            {
                if (jobProfileModelObj.RecruiterIdList != null)
                    foreach (var recruiterId in jobProfileModelObj.RecruiterIdList.Split(','))
                    {
                        _jobProfileRepository.DeleteJobRecruiter(jobId, Convert.ToInt32(recruiterId));
                    }
                if (jobProfileModelObj.RecruiterCheckedIdList != null)
                    foreach (var recruiterId in jobProfileModelObj.RecruiterCheckedIdList.Split(','))
                    {
                        _jobProfileRepository.AddJobRecruiter(jobId, Convert.ToInt32(recruiterId));
                    }
                return RedirectToAction("Quiz", "Recruiting", new { @JobProfileId = jobId });
            }
            return View(jobProfileModelObj);
        }
        /// <summary>
        /// Method to remove a job 
        /// </summary>
        /// <param name="jobIds"></param>
        /// <returns></returns>
        [Authorize]
        public bool DeleteJob(string jobIds)
        {
            if (!string.IsNullOrEmpty(jobIds))
            {

                foreach (var jobId in jobIds.Split(','))
                {

                    var JobProId = _jobProfileRepository.DeleteJobprofile(Convert.ToInt32(jobId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

                }
            }
            return true;
        }
        public ActionResult _AddInterview()
        {
            return View();
        }
        /// <summary>
        /// View to add list of recruiting questions used in a job creation
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult AddRecruitingQuestions()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var recruitingQuestionsFormModelObj = new RecruitingQuestionsFormModel();
            recruitingQuestionsFormModelObj.RecruitingQuestions = new RecruitingQuestions();
            recruitingQuestionsFormModelObj.RecruitingAnswers = new RecruitingAnswers();
            recruitingQuestionsFormModelObj.RecruitingAnswers.CompanyId = companyId;


            if (!string.IsNullOrEmpty(Request.QueryString["RecruitingQuestionId"]))
            {
                recruitingQuestionsFormModelObj.RecruitingQuestions.CompanyID = companyId;
                recruitingQuestionsFormModelObj.RecruitingQuestions.RecruitingQuestionId = Convert.ToInt32(Request.QueryString["RecruitingQuestionId"]);
                recruitingQuestionsFormModelObj.RecruitingQuestions = _recrutingQuestionsRepository.SelectRecruitingQuestions(recruitingQuestionsFormModelObj.RecruitingQuestions.RecruitingQuestionId);
                recruitingQuestionsFormModelObj.RecruitingAnswers.QuestionId = Convert.ToInt32(Request.QueryString["RecruitingQuestionId"]);
                recruitingQuestionsFormModelObj.lstRecruitingAnswers = _recruitingAnswersRepository.SelectRecruitingAnswers(recruitingQuestionsFormModelObj.RecruitingAnswers.QuestionId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            }
            recruitingQuestionsFormModelObj.QuestionTypes = _recrutingQuestionsRepository.SelectQuestionType(0);
            return View(recruitingQuestionsFormModelObj);
        }
        /// <summary>
        /// View to add list of recruiting questions used in a job creation
        /// </summary>
        /// <param name="recruitingQuestionsFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddRecruitingQuestions(RecruitingQuestionsFormModel recruitingQuestionsFormModelObj, FormCollection fc)
        {
            
            recruitingQuestionsFormModelObj.RecruitingQuestions.CompanyID = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            recruitingQuestionsFormModelObj.RecruitingQuestions.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            recruitingQuestionsFormModelObj.RecruitingQuestions.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            recruitingQuestionsFormModelObj.QuestionTypes = _recrutingQuestionsRepository.SelectQuestionType(0);
            int result;
            if (recruitingQuestionsFormModelObj.RecruitingQuestions.RecruitingQuestionId.Equals(0))
                recruitingQuestionsFormModelObj.RecruitingQuestions.RecruitingQuestionId = _recrutingQuestionsRepository.CreateRecruitingQuestions(recruitingQuestionsFormModelObj.RecruitingQuestions);
            else
                result = _recrutingQuestionsRepository.UpdateRecruitingQuestions(recruitingQuestionsFormModelObj.RecruitingQuestions);

            //recruitingQuestionsFormModelObj.lstRecruitingAnswers[0].QuestionId = recruitingQuestionsFormModelObj.RecruitingQuestions.RecruitingQuestionId;
            //recruitingQuestionsFormModelObj.lstRecruitingAnswers[0].CompanyId = companyId;
            //recruitingQuestionsFormModelObj.lstRecruitingAnswers[0].QuestionTypeId = recruitingQuestionsFormModelObj.RecruitingQuestions.QuestionType;
            
            foreach (var recruitinganswer in recruitingQuestionsFormModelObj.lstRecruitingAnswers)
            {
                if (recruitingQuestionsFormModelObj.lstRecruitingAnswers.Equals(0))
                    _recruitingAnswersRepository.AddRecruitingAnswers(recruitinganswer);
                else
                    _recruitingAnswersRepository.UpdateRecruitingAnswers(recruitinganswer);


            }
            return RedirectToAction("SelectAllRecruitingQuestions");
        }
        /// <summary>
        /// View to show all the list of recruting questions super set to be used in jobs
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllRecruitingQuestions()
        {
            var recruitingQuestionsList = _recrutingQuestionsRepository.SelectAllRecruitingQuestions(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(recruitingQuestionsList);

        }
        /// <summary>
        /// Method to delete a recruting question record
        /// </summary>
        /// <param name="recruitingquestionsIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteRecruitingQuestions(string recruitingquestionsIds)
        {
            if (!string.IsNullOrEmpty(recruitingquestionsIds))
            {
                foreach (var recruitingquestionsId in recruitingquestionsIds.Split(','))
                {
                    var recruitingquestions = _recrutingQuestionsRepository.DeleteRecruitingQuestions(Int32.Parse(recruitingquestionsId));
                }
            }
            return true;
        }
        public DataTable RecruitingAnswersSchema()
        {
            var dt = new DataTable();
            dt.Columns.Add("Active", typeof(bool));
            dt.Columns.Add("Answers", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            dt.Columns.Add("KnockOutValue", typeof(bool));
            dt.Columns.Add("QuestionId", typeof(int));
            dt.Columns.Add("AnswerId", typeof(int));
            dt.Columns.Add("QuestionTypeId", typeof(int));
            dt.Columns.Add("CompanyId", typeof(int));
            return dt;
        }
        public ActionResult Candidates()
        {
            var candidateFormModelObj = new CandidateFormModel
            {
                JobApplicantsList =
                    _jobApplicantRepository.GetJobApplicants(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)),
                AppliedjobsList = AppliedJobswithDetails()
            };

            return View(candidateFormModelObj);
        }
        //public JsonResult SendRating(string r, string s, string id, string url)
        //{
        //    int RateId = 0;
        //    Int16 thisRate = 0;
        //    int  jobApplicantId;
        //    //Int16.TryParse(s, out jobApplicantId);
        //    Int16.TryParse(r, out thisRate);
        //    int.TryParse(id, out RateId);

        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return Json("Not authenticated!");
        //    }

        //    if (RateId.Equals(0))
        //    {
        //        return Json("Sorry, record to vote doesn't exists");
        //    }

        //    switch (s)
        //    {
        //        case "5": // school voting
        //            // check if he has already Rating
        //            var hrmsEntity = new HRMSEntities1();
        //            var list = hrmsEntity.JobApplicant.Where(k => k.JobApplicantId == jobApplicantId && k.FirstName.Equals(User.Identity.Name, StringComparison.InvariantCultureIgnoreCase)
        //                && k.JobApplicantId == RateId).FirstOrDefault();
        //            if (list != null)
        //            {
        //                // keep the  rating flag to stop rating by this member
        //                HttpCookie cookie = new HttpCookie(url, "true");
        //                Response.Cookies.Add(cookie);
        //                return Json("<br />You have already rated this post, thanks !");
        //            }

        //            var sch = hrmsEntity.JobApplicant.Where(sc => sc.JobApplicantId == RateId).FirstOrDefault();
        //            if (sch != null)

        //                object obj = sch.Rating;

        //                string updateRating = string.Empty;
        //                string[] Ratings = null;
        //                if (obj != null && obj.ToString().Length > 0)
        //                {
        //                    string currentRatings = obj.ToString(); // rating pattern will be 0,0,0,0,0
        //                    Ratings = currentRatings.Split(',');
        //                    // if proper vote data is there in the database
        //                    if (Ratings.Length.Equals(5))
        //                    {
        //                        // get the current number of Rating count of the selected rate, always say -1 than the current rate in the array 
        //                        int currentNumberOfRating = int.Parse(Ratings[thisRate - 1]);
        //                        // increase 1 for this vote
        //                        currentNumberOfRating++;
        //                        // set the updated value into the selected votes
        //                        Ratings[thisRate - 1] = currentNumberOfRating.ToString();
        //                    }
        //                    else
        //                    {
        //                        Ratings = new string[] { "0", "0", "0", "0", "0" };
        //                        Ratings[thisRate - 1] = "1";
        //                    }
        //                }
        //                else
        //                {
        //                    Ratings = new string[] { "0", "0", "0", "0", "0" };
        //                    Ratings[thisRate - 1] = "1";
        //                }

        //                // concatenate all arrays now
        //                foreach (string ss in Ratings)
        //                {
        //                    updateRating += ss + ",";
        //                }
        //                updateRating = updateRating.Substring(0, updateRating.Length - 1);

        //                hrmsEntity.Entry(sch).State = EntityState.Modified;
        //                sch.Rating = Convert.ToInt32(updateRating);
        //                hrmsEntity.SaveChanges();

        //                JobApplicant vm = new JobApplicant()
        //                {
        //                    FirstName=User.Identity.Name,
        //                    JobApplicantId=Int16.Parse(s),                          
        //                    Rating = thisRate,

        //                };

        //                hrmsEntity.JobApplicant.Add(vm);

        //                hrmsEntity.SaveChanges();

        //                // keep the Rating voting flag to stop rating by this member
        //                HttpCookie cookie1 = new HttpCookie(url, "true");
        //                Response.Cookies.Add(cookie1);
        //              break;
        //        default:
        //            break;
        //            }
        //       return Json("<br />You rated " + r + " star(s), thanks !");

        //    }      
        /// <summary>
        /// A function to return all the applicants with their corresponding applied jobs
        /// </summary>
        /// <returns></returns>
        public List<AppliedJobsFormModel> AppliedJobswithDetails()
        {
            var listViewAppliedJobs = new List<AppliedJobsFormModel>();
            var availableJobsList =
                _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (!string.IsNullOrEmpty(GlobalsVariables.CurrentCompanyId))
            {
                var listappliedjobs =
                    _jobApplicantRepository.AppliedJobsWithNoFilter();
                if (listappliedjobs.Count > 0 && listappliedjobs[0] != null)
                {
                    var appliedJobs = from jobprofiles in availableJobsList
                                      join appliedJob in listappliedjobs on jobprofiles.JobProfileId equals appliedJob.JobProfileId
                                      select new
                                      {
                                          jobprofiles.Title,
                                          jobprofiles.JobProfileId,
                                          jobprofiles.CityStateOrZipCode,
                                          appliedJob.IsApproved,
                                          appliedJob.Rating,
                                          appliedJob.IsHired,
                                          appliedJob.AppliedOn,
                                          appliedJob.Status,
                                          appliedJob.JobApplicantId
                                      };
                    foreach (var appliedjob in appliedJobs)
                    {
                        var appliedJobsFormModelObj = new AppliedJobsFormModel();
                        appliedJobsFormModelObj.JobTitle = appliedjob.Title;
                        if (appliedjob.Rating != null)
                            appliedJobsFormModelObj.Rating = (int)appliedjob.Rating;
                        appliedJobsFormModelObj.JobProfileId = appliedjob.JobProfileId;
                        appliedJobsFormModelObj.JobLocation = appliedjob.CityStateOrZipCode;
                        appliedJobsFormModelObj.JobStatus = appliedjob.Status;
                        appliedJobsFormModelObj.JobAppliedOn = Convert.ToDateTime(appliedjob.AppliedOn);
                        if (appliedjob.IsApproved != null)
                            appliedJobsFormModelObj.IsApproved = (bool)appliedjob.IsApproved;
                        if (appliedjob.IsHired != null)
                            appliedJobsFormModelObj.IsHired = (bool)appliedjob.IsHired;
                        appliedJobsFormModelObj.JobApplicantId = appliedjob.JobApplicantId;
                        listViewAppliedJobs.Add(appliedJobsFormModelObj);
                    }
                }
            }
            return listViewAppliedJobs;
        }
        [HttpGet]
        [Authorize]
        public ActionResult _AddRecruitingQuestions(int jobProfileId)
        {
            var recruitingQuestionsList = _recrutingQuestionsRepository.SelectAllRecruitingQuestions(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var selectedRecruitingQuestions = new List<RecruitingQuestions>();
            selectedRecruitingQuestions = _jobProfileRepository.ListRecQuestionsInJobProfile(jobProfileId);
            if (TempData["RecruitingQuestionIds"] != null)
            {
                string recruitingQuestionIds = Convert.ToString(TempData["RecruitingQuestionIds"]);
                if (!string.IsNullOrEmpty(recruitingQuestionIds))
                {
                    string[] recruitingquestionIdIdarr = recruitingQuestionIds.Split(',');
                    selectedRecruitingQuestions = recruitingquestionIdIdarr.Select(recruitingQuestionId => new RecruitingQuestions { RecruitingQuestionId = Convert.ToInt32(recruitingQuestionId) }).ToList();
                    TempData["RecruitingQuestionIds"] = recruitingQuestionIds;
                    TempData.Peek("RecruitingQuestionIds");
                }
            }
            var listRecruitingQuestionsChkProp = (from recQuestionsObj in recruitingQuestionsList
                                                  join selectedRecruitingQuestionsObj in selectedRecruitingQuestions on recQuestionsObj.RecruitingQuestionId equals selectedRecruitingQuestionsObj.RecruitingQuestionId into sub
                                     from sublist in sub.DefaultIfEmpty()
                                                  select new { recQuestionsObj.RecruitingQuestionId, recQuestionsObj.IsRequired,recQuestionsObj.IsActive, recQuestionsObj.TheSequenceNumber, recQuestionsObj.QuestionType,recQuestionsObj.QuestionText, IsChecked = (sublist != null) }).ToList();
            List<SelectedRecruitingQuestionsFormModel> selectedRecruitingQuestionsList = new List<SelectedRecruitingQuestionsFormModel>();
            if (listRecruitingQuestionsChkProp.Count > 0)
            {

                foreach (var recruitingQuestionschk in listRecruitingQuestionsChkProp)
                {
                    SelectedRecruitingQuestionsFormModel selectedRecruitingQuestionsObj = new SelectedRecruitingQuestionsFormModel();
                    selectedRecruitingQuestionsObj.RecruitingQuestionId = recruitingQuestionschk.RecruitingQuestionId;
                    selectedRecruitingQuestionsObj.RecruitingQuestionsChecked = recruitingQuestionschk.IsChecked;
                    selectedRecruitingQuestionsObj.IsRequired = recruitingQuestionschk.IsRequired;
                    selectedRecruitingQuestionsObj.SequenceNumber = recruitingQuestionschk.TheSequenceNumber;
                    selectedRecruitingQuestionsObj.QuestionText = recruitingQuestionschk.QuestionText;
                    selectedRecruitingQuestionsObj.QuestionType = recruitingQuestionschk.QuestionType;
                    selectedRecruitingQuestionsList.Add(selectedRecruitingQuestionsObj);
                }
            }

            return PartialView(selectedRecruitingQuestionsList);
        }
        [HttpPost, ValidateInput(false)]
        [Authorize]
        public bool _AddRecruitingQuestions(RecruitingQuestionsFormModel recruitingQuestionsFormModelObj, string recruitingQuestionIds)
        {
            TempData["RecruitingQuestionsFormModel"] = recruitingQuestionsFormModelObj;
            TempData["RecruitingQuestionIds"] = recruitingQuestionIds;
            return true;
        }

        public ActionResult ResumeDatabase(string jobId)
        {
            var registerApplicantFormModelObj = new RegisterApplicantFormModel();
            registerApplicantFormModelObj.JobApplicant = new JobApplicant();
            registerApplicantFormModelObj.JobId = Convert.ToInt32(jobId);
            return PartialView(registerApplicantFormModelObj);
        }
        [HttpPost]
        [Authorize]
        public ActionResult ResumeDatabase(RegisterApplicantFormModel registerApplicantFormModelObj, FormCollection formCollectionObj, HttpPostedFileBase file, JobApplicant obj)
        {
            int fileId = 0;
            bool success = false;
            String filepath = ConfigurationManager.AppSettings["ScannedDocuments"];
            var httpPostedFileBase = Request.Files[0];
            if (httpPostedFileBase != null && ((Request.Files.Count > 0) && (httpPostedFileBase.ContentLength > 0)))
            {
                string filename = System.IO.Path.GetFileName(Request.Files[0].FileName);
                var filesDBobj = new FilesDB();
                System.IO.Stream filestream = Request.Files[0].InputStream;
                var bytesInStream = new byte[filestream.Length];
                filestream.Read(bytesInStream, 0, bytesInStream.Length);
                string extension = System.IO.Path.GetExtension(filename);
                filesDBobj.FileName = filename;
                filesDBobj.FileExtension = extension;
                filesDBobj.FileBytes = bytesInStream;
                filesDBobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                filesDBobj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                filesDBobj.FileType = GeneralEnum.FileType.ResumeAttachment.ToString();
                fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj, Convert.ToInt32(GlobalsVariables.CurrentUserId));
                registerApplicantFormModelObj.JobApplicant.File = filename;

            }
            registerApplicantFormModelObj.JobApplicant.ResumeAttachmentId = fileId;
            var passwordgenerator = new RandomStringGenerator();
            string password = passwordgenerator.Generate("LlnlnLlL");
            registerApplicantFormModelObj.JobApplicant.Password = Encryption.Encrypt(password);
            registerApplicantFormModelObj.JobApplicant.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            registerApplicantFormModelObj.JobApplicant.ResumeAttachmentId = fileId;
            registerApplicantFormModelObj.JobApplicant.Status = true;
            int applicantId = _jobApplicantRepository.JobApplicantInsertOrUpdate(registerApplicantFormModelObj.JobApplicant);
            string applicantName = string.Format("{0} {1}", registerApplicantFormModelObj.JobApplicant.FirstName,
              registerApplicantFormModelObj.JobApplicant.LastName);


            if (applicantId > 0)
            {
                //create cookie for authentication ticket
                string basicuserdata = JsonConvert.SerializeObject(registerApplicantFormModelObj.JobApplicant);

                var authTicket = new FormsAuthenticationTicket(
                   1,
                   "HRMSJobPortallogin",
                   DateTime.Now,
                   DateTime.Now.AddMinutes(15),
                   false,
                   basicuserdata);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                var faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                Response.Cookies.Add(faCookie);
                var httpCookie = Response.Cookies["HRMSJobPortallogin"];
                if (httpCookie != null)
                    httpCookie.Expires = DateTime.Now.AddMinutes(20);
                //assigning session variables
                GlobalsVariables.CurrentUserId = applicantId.ToString(CultureInfo.InvariantCulture);
                GlobalsVariables.CurrentUserName = applicantName;
                //configuring email parameteres
                const string messageBody = "You are registered with us. Please wait until we further process your application.";
                var path = Convert.ToString(Server.MapPath("~/Utilities/RegisterApplicant.html"));
                string jobPortalRedirectUrl = string.Format("?redirectUrl={0}{1}", ConfigurationManager.AppSettings["JobPortalRedirectUrl"], GlobalsVariables.CurrentCompanyId);
                string strLoginURL = ConfigurationManager.AppSettings["_loginurl"];
                string redirectUrl = Encryption.Encrypt(ConfigurationManager.AppSettings["JobPortalRedirectUrl"]);
                DateTime dateTime = System.DateTime.Now;
                //ApplyJob(registerApplicantFormModelObj.JobId);
                Mailing.Sendemailtouser(registerApplicantFormModelObj.JobApplicant.Email, "Registration",
                    GlobalsVariables.CurrentCompanyName, applicantName,
                    GlobalsVariables.CurrentCompanyName, messageBody, strLoginURL, path, strLoginURL,
                    registerApplicantFormModelObj.JobApplicant.Email, password, dateTime, "");
            }
            return RedirectToAction("AvailableJobs");
            //}
            //return applicantId > 0;
            return View();
        }
        public ActionResult AddNewApplicant()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult CandidatePreview()
        {
            var companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var candidateProcessingFormModelObj = new CandidateProcessingFormModel();
            candidateProcessingFormModelObj.JobApplicant = new JobApplicant();
            if (!string.IsNullOrEmpty(Request.QueryString["JobApplicantId"]))
            {
                int applicantid = Convert.ToInt32(Request.QueryString["JobApplicantId"]);
                GlobalsVariables.SelectedCandidateId = Convert.ToString(applicantid);
                candidateProcessingFormModelObj.JobApplicant = _jobApplicantRepository.SelectJobApplicantById(applicantid, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                var applicantName = candidateProcessingFormModelObj.JobApplicant.FirstName + " " + candidateProcessingFormModelObj.JobApplicant.LastName;
                candidateProcessingFormModelObj.ApplicantName = applicantName;
                //retreiving all the applicants and applied jobs in a company
                var appliedJobsInaCompany = AppliedJobswithDetails();
                //filtering the applied jobs for an applicant with his id
                candidateProcessingFormModelObj.AppliedJobsInfo = (from appliedJobsInaCompanyObj in appliedJobsInaCompany where appliedJobsInaCompanyObj.JobApplicantId == applicantid select appliedJobsInaCompanyObj).ToList();
                candidateProcessingFormModelObj.IsHired = (from appliedJobsInaCompanyObj in appliedJobsInaCompany where appliedJobsInaCompanyObj.IsHired == true select appliedJobsInaCompanyObj.IsHired).FirstOrDefault();
                candidateProcessingFormModelObj.RecruiterComments = SimplifyCommentsbyRecruiters(applicantid);
                candidateProcessingFormModelObj.lstApplicantEducation = _jobApplicantRepository.SelectApplicantEducationById(applicantid);
                candidateProcessingFormModelObj.lstApplicantEmploymentHistory = _jobApplicantRepository.SelectApplicantEmploymentHistoryById(applicantid, 0);
                candidateProcessingFormModelObj.lstApplicantAchievementsAndAssociations = _jobApplicantRepository.SelectApplicantAchievementsAndAssociationsById(applicantid, 0);

                if (candidateProcessingFormModelObj.lstJobProfiles.Any())
                {
                    var jobProfileObj = candidateProcessingFormModelObj.lstJobProfiles.FirstOrDefault();
                    if (jobProfileObj != null)
                    {
                        candidateProcessingFormModelObj.Jobprofileid = jobProfileObj.JobProfileId;

                    }
                }
                //if (candidateProcessingFormModelObj.IsHired == true)
                //{
                                      
                //}
            }

            return View(candidateProcessingFormModelObj);
        }
        /// <summary>
        /// Method to add Comments to an Applicant
        /// </summary>
        /// <param name="comments"></param>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool RecruiterComments(string comments, int applicantId)
        {
            var candidateHiringCommentsObj = new CandidateHiringComments();
            candidateHiringCommentsObj.ApplicantId = applicantId;
            candidateHiringCommentsObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            candidateHiringCommentsObj.HiringComments = comments;
            candidateHiringCommentsObj.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            candidateHiringCommentsObj.CreatedOn = DateTime.UtcNow;
            int result = _jobApplicantRepository.InsertHiringComments(candidateHiringCommentsObj);
            return result > 0;

        }
        /// <summary>
        /// Method To Update Candidate Status in Candidate Preview Screen
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="jobProfileId"></param>
        /// <param name="applicantStatus"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool CandidateStatus(int applicantId, int jobProfileId, string applicantStatus)
        {
            //ApplicantStatusId is by default "IsApplied"=1.
            int applicantStatusId = 1;
            if (!string.IsNullOrEmpty(applicantStatus))
                applicantStatusId = (int)(Enum.Parse(typeof(GeneralEnum.JobApplicationStatus), applicantStatus));
            int result = _jobApplicantRepository.UpdateCandidateStatus(applicantId, jobProfileId, applicantStatusId);
            return result > 0;
        }

        [HttpPost]
        [Authorize]
        public bool UpdateCandidateRating(int applicantId, int jobProfileId, int rating)
        {

            int result = _jobApplicantRepository.UpdateRatingOfApplicant(applicantId, jobProfileId, rating);
            return result > 0;
        }

        public List<RecruiterComments> SimplifyCommentsbyRecruiters(int applicantId)
        {
            var lstRecruiterCommentses = new List<RecruiterComments>();
            var hiringComments = _jobApplicantRepository.GetHiringCommentsbyCandidate(applicantId);
            var employeeInfoList =
                _employeeRepository.SelectEmployeeByCompanyId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (hiringComments != null)
            {
                var recuiterCommentsList = (from hiringcommentObj in hiringComments
                                            join employeeInfoObj in employeeInfoList on hiringcommentObj.CreatedBy equals employeeInfoObj.UserId
                                            select new
                                            {
                                                RecruiterName = (string.Format("{0} {1}", employeeInfoObj.FirstName, employeeInfoObj.LastName)),
                                                hiringcommentObj.HiringComments,
                                                hiringcommentObj.HiringCommentsId,
                                                hiringcommentObj.CreatedOn
                                            }).ToList();

                lstRecruiterCommentses =
                    recuiterCommentsList.Select(recruiterCommentObj => new RecruiterComments
                    {
                        RecruiterName = recruiterCommentObj.RecruiterName,
                        Comments = recruiterCommentObj.HiringComments,
                        PostedDate = Convert.ToString(recruiterCommentObj.CreatedOn),
                        CommentId = recruiterCommentObj.HiringCommentsId
                    }).ToList();

            }
            return lstRecruiterCommentses;
        }
        [HttpGet]
        public ActionResult UpdateResultBasedonJobProfileId(int applicantId,int jobProfileid)
        {
            var appliedJobsDetailsForapplicant = AppliedJobswithDetails();
            var selectedJobProfileObj =
                appliedJobsDetailsForapplicant.Where(
                    j => j.JobApplicantId == applicantId && j.JobProfileId == jobProfileid).FirstOrDefault();
            return Json(selectedJobProfileObj, JsonRequestBehavior.AllowGet);  
        }

        public ActionResult OfferLetter()
        {

            return View();
        }
        //[HttpGet]
        //public ActionResult Download(string filePath, string fileName)
        //{
        //    string fullName = Path.Combine(GetBaseDir(), filePath, fileName);

        //    byte[] fileBytes = GetFile(fullName);
        //    return File(
        //        fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //}
        //byte[] GetFile(string s)
        //{
        //    System.IO.FileStream fs = System.IO.File.OpenRead(s);
        //    byte[] data = new byte[fs.Length];
        //    int br = fs.Read(data, 0, data.Length);
        //    if (br != fs.Length)
        //        throw new System.IO.IOException(s);
        //    return data;
        //}
        public ActionResult Download(int fileDBId)
        {
            try
            {
                var filesDBList = new List<FilesDB>();
                filesDBList = _filesDBRepository.SelectFileByFileDBId(fileDBId);
                string fileName = filesDBList[0].FileName;
                byte[] fileBytes = filesDBList[0].FileBytes;
                string contentType = filesDBList[0].ContentType;
                Response.Buffer = true;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.ContentType = contentType;              
                Response.BinaryWrite(fileBytes);
                Response.End();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult PrintPreview(int fileDBId)
        {
            var filesDBList = new List<FilesDB>();
            filesDBList = _filesDBRepository.SelectFileByFileDBId(fileDBId);
            string fileName = filesDBList[0].FileName;
            return new ActionAsPdf(
                           "PrintPreview",
                           new { fileDBId = fileDBId }) { FileName = "" + fileName + "" };
        }

        public bool HireCandidate(int applicantId, int jobProfileId)
        {

            int result = _jobApplicantRepository.HireCandidate(applicantId, jobProfileId);
            return result>0;
        }

        //public FileResult Download()
        //{
        //    int fileId = 0;
        //    bool success = false;
        //    String filepath = ConfigurationManager.AppSettings["ScannedDocuments"];
        //    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filepath + "\"");
        //    Response.TransmitFile(Server.MapPath(filepath));
        //    Response.End();
        //    return result;
        //}
    }
}

