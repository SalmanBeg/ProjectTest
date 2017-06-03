using HRMS.Common.Helpers;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Repositories;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Configuration;

namespace HRMS.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class InterviewController : Controller
    {
        #region //Class Level Variables and Constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly IFilesDBRepository _filesDbRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IInterviewRepository _interviewRepository;
        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IJobProfileRepository _jobProfileRepository;
        public InterviewController(IUtilityRepository utilityRepo, CompanyRepository companyRepository, IFilesDBRepository filesDbRepository,IRegisteredUsersRepository registeredUsersRepository, IEmployeeRepository employeeRepository, IInterviewRepository interviewRepository
            , IJobApplicantRepository jobApplicantRepository, IJobProfileRepository jobProfileRepository)
        {

            _utilityRepository = utilityRepo;
            _filesDbRepository = filesDbRepository;
            _companyRepository = companyRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _employeeRepository = employeeRepository;
            _interviewRepository = interviewRepository;
            _jobApplicantRepository = jobApplicantRepository;
            _jobProfileRepository = jobProfileRepository;
        }
        #endregion
        /// <summary>
        /// View to add an interview schedule to a candidate
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddInterview()
        {


            var interviewFormModelObj = new InterviewFormModel();
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            interviewFormModelObj.Interview = new Interview();
            if (!string.IsNullOrEmpty(Request.QueryString["InterviewId"]))
            {
                interviewFormModelObj.Interview.InterviewId = Convert.ToInt32(Request.QueryString["InterviewId"]);
                interviewFormModelObj.Interview = _interviewRepository.InterviewSelect(interviewFormModelObj.Interview.InterviewId);

            }
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            interviewFormModelObj.InterviewType = lstlookup.Where(j => j.TableName == LocalizedStrings.InterviewType).ToList();
            interviewFormModelObj.InterviewType.Insert(0, lookUpDataEntityobj);
            interviewFormModelObj.InterviewRoom = lstlookup.Where(j => j.TableName == LocalizedStrings.InterviewRoom).ToList();
            interviewFormModelObj.InterviewRoom.Insert(0, lookUpDataEntityobj);
            interviewFormModelObj.InterviewStatus = lstlookup.Where(j => j.TableName == LocalizedStrings.InterviewStatus).ToList();
            interviewFormModelObj.InterviewStatus.Insert(0, lookUpDataEntityobj);

            interviewFormModelObj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (!string.IsNullOrEmpty(Request.QueryString["applicantId"]) && !string.IsNullOrEmpty(Request.QueryString["jobProfileId"]))
            {
                interviewFormModelObj.Interview = new Interview();
                interviewFormModelObj.Interview.CandidateId = Convert.ToInt32(Request.QueryString["applicantId"]);
                interviewFormModelObj.Interview.JobProfileId = Convert.ToInt32(Request.QueryString["jobProfileId"]);
                var applicantinfo = _jobApplicantRepository.SelectJobApplicantById(Convert.ToInt32(interviewFormModelObj.Interview.CandidateId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                interviewFormModelObj.Interview.ApplicantName = applicantinfo.FirstName + " " + applicantinfo.LastName;
                var jobinfo = _jobProfileRepository.SelectJobProfileById(interviewFormModelObj.Interview.JobProfileId);
                interviewFormModelObj.Interview.JobTitle = jobinfo.Title;
            }


            var jobInterviewers = _interviewRepository.JobInterviewers(interviewFormModelObj.Interview.InterviewId);

            var result = (from employees in interviewFormModelObj.EmployeeList
                          join jobinterviewer in jobInterviewers on employees.UserId equals jobinterviewer.InterviewerId into gj
                          from sublist in gj.DefaultIfEmpty()
                          select new { employees.UserId, employees.UserName, InterviewerStatus = (sublist == null ? false : true) }).ToList();

            interviewFormModelObj.InterviewersList = result.Select(userObj => new Interviewers
            {
                InterviewerId = userObj.UserId,
                InterviewerName = userObj.UserName,
                InterviewerStatus = userObj.InterviewerStatus
            }).ToList();


            return View(interviewFormModelObj);
        }
        /// <summary>
        /// Method to Post InterviewDetails to Database
        /// </summary>
        /// <param name="interviewFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddInterview(InterviewFormModel interviewFormModelObj)
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            interviewFormModelObj.Interview.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            interviewFormModelObj.Interview.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            interviewFormModelObj.Interview.ModifiedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            var jobProfileObj = _jobProfileRepository.SelectJobProfileById(interviewFormModelObj.Interview.JobProfileId);
            var applicantObj = _jobApplicantRepository.SelectJobApplicantById(Convert.ToInt32(interviewFormModelObj.Interview.CandidateId), companyId);
            int result;
            
            //var resumeInfoFromFile = _filesDbRepository.SelectFileByFileDBId(applicantObj.ResumeAttachmentId);
            var jobInterviewersList = new List<JobInterviewers>();
            if (interviewFormModelObj.InterviewersList != null)
            {
                foreach (var interviewerId in interviewFormModelObj.InterviewersIdList.Split(','))
                {
                    var jobInterviewersObj = new JobInterviewers();
                    jobInterviewersObj.InterviewerId = Convert.ToInt32(interviewerId);
                    jobInterviewersList.Add(jobInterviewersObj);
                }
            }
            if (interviewFormModelObj.Interview.InterviewId.Equals(0))
            {
                result = _interviewRepository.CreateInterview(interviewFormModelObj.Interview, jobInterviewersList);
                interviewFormModelObj.Interview.InterviewId = result;
                if (!interviewFormModelObj.Interview.JobProfileId.Equals(0) && !interviewFormModelObj.Interview.CandidateId.Equals(0))
                {
                    ApplicantInterview applicantInterviewObj = new ApplicantInterview();
                    applicantInterviewObj.InterviewId = interviewFormModelObj.Interview.InterviewId;
                    applicantInterviewObj.JobApplicantId = Convert.ToInt32(interviewFormModelObj.Interview.CandidateId);
                    applicantInterviewObj.JobProfileId = interviewFormModelObj.Interview.JobProfileId;
                    var applicantinterviewstatus = _interviewRepository.ApplicantInterviews(applicantInterviewObj);
                }
            }
            else
            {
                result = _interviewRepository.UpdateInterview(interviewFormModelObj.Interview);
            }
            var emailto = _interviewRepository.InterviewSelect(interviewFormModelObj.Interview.InterviewId);
            interviewFormModelObj.Interview.SendCandidateEmail1 = emailto.SendCandidateEmail1;
            interviewFormModelObj.Interview.SendInterviewerEmail1 = emailto.SendInterviewerEmail1;
            var interviewerList = _interviewRepository.JobInterviewers(interviewFormModelObj.Interview.InterviewId);
            if (applicantObj != null && jobProfileObj != null)
            {
                string jobProfileTitle = jobProfileObj.Title;
                string applicantName = applicantObj.FirstName + " " + applicantObj.LastName;
                string applicantEmailId = applicantObj.Email;
                if (interviewerList.Count > 0)
                {
                    foreach (var interviewer in interviewerList)
                    {
                        var employeeObj = _employeeRepository.SelectEmployeeById(interviewer.InterviewerId, companyId);
                        List<Interview> interviewInfoList = _interviewRepository.InterviewSelectAll(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                        //Send an email notification for interview schedule to interviewers
                        if (interviewFormModelObj.Interview.SendInterviewerEmail1)
                        {
                            var interviewInfo = interviewInfoList.Where(j => j.InterviewId == interviewFormModelObj.Interview.InterviewId).FirstOrDefault();                                                     
                            var path = Convert.ToString(Server.MapPath("~/Utilities/InterviewInfo.html"));
                            var interviewDate = (interviewFormModelObj.Interview.InterviewDate != null ? interviewFormModelObj.Interview.InterviewDate.ToString() : "");
                            var interviewTime = (interviewFormModelObj.Interview.ScheduledInterviewTime != null ? Convert.ToString(interviewFormModelObj.Interview.ScheduledInterviewTime) : "");
                            var interviewType = (interviewInfo.InterviewType != null ? Convert.ToString(interviewInfo.InterviewType) : "");
                            var interviewerInstructions = interviewFormModelObj.Interview.InterviewerInstructions;
                            string messageBody = "";
                            string subject = "Intimation of Scheduled Interview";
                            string interviewerName = employeeObj.FirstName + " " + employeeObj.LastName;
                            string interviewerEmail = !string.IsNullOrEmpty(employeeObj.WorkEmail) ? employeeObj.WorkEmail : employeeObj.Email;
                            DateTime dateTime = System.DateTime.Now;

                            


                            Mailing.Sendemailtouser(interviewerEmail, subject, GlobalsVariables.CurrentCompanyName,
                            interviewerName, GlobalsVariables.CurrentCompanyName, messageBody, "", path, "",applicantName, "", dateTime,  "", "", interviewDate, interviewTime, interviewType, "",interviewerInstructions);
                        }
                    }
                }
                if (interviewFormModelObj.Interview.SendCandidateEmail1)
                {
                    var companyInfo = _companyRepository.GetEditCompanyInfo(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    var companyAddress = GlobalsVariables.CurrentCompanyName + "," +companyInfo.Address1 + "," + companyInfo.Address2;
                    List<Interview> interviewInfoList = _interviewRepository.InterviewSelectAll(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    if (interviewInfoList.Count() > 0)
                    {
                        var interviewInfo = interviewInfoList.Where(j => j.InterviewId == interviewFormModelObj.Interview.InterviewId).FirstOrDefault();
                        var interviewDate = (interviewFormModelObj.Interview.InterviewDate != null ? interviewFormModelObj.Interview.InterviewDate.ToString() : "");
                        var interviewTime = (interviewFormModelObj.Interview.ScheduledInterviewTime != null ? Convert.ToString(interviewFormModelObj.Interview.ScheduledInterviewTime) : "");
                        var interviewType = (interviewInfo.InterviewType != null ? Convert.ToString(interviewInfo.InterviewType) : "");
                        var candidateInstructions = interviewFormModelObj.Interview.CandidateInstructions;                        
                        string messageBody = "";
                        //const string messageBody = "You have been shortlisted. Please find the Interview Details.";
                        var path = Convert.ToString(Server.MapPath("~/Utilities/ScheduledInterview.html"));
                        DateTime dateTime = System.DateTime.Now;
                        string subject = "Interview Call Letter";
                        Mailing.Sendemailtouser(applicantEmailId, subject,
                        GlobalsVariables.CurrentCompanyName, applicantName, GlobalsVariables.CurrentCompanyName, messageBody, "", path, "", "", "", dateTime, "", companyAddress, interviewDate, interviewTime, interviewType, candidateInstructions,"");
                    }
                }
            }
            return RedirectToAction("InterviewSelectAll");
        }
        /// <summary>
        /// Method to Display all Scheduled Interviews in a grid
        /// </summary>
        /// <returns></returns>
        public ActionResult InterviewSelectAll()
        {
            var InterviewList = _interviewRepository.InterviewSelectAll(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(InterviewList);
        }
        /// <summary>
        /// Method to Delete a Record of Interview
        /// </summary>
        /// <param name="deleteInterviewIds"></param>
        /// <returns></returns>
        [HttpPost]
        public bool DeleteInterview(string deleteInterviewIds)
        {
            if (!string.IsNullOrEmpty(deleteInterviewIds))
            {
                foreach (var deleteInterviewId in deleteInterviewIds.Split(','))
                {
                    var DeleteInterviewId = _interviewRepository.DeleteInterview(Int32.Parse(deleteInterviewId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }

            }
            return true;
        }
        /// <summary>
        /// Method to Display All Scheduled Interviews Partial View
        /// </summary>
        /// <returns></returns>
        public ActionResult _InterviewSelectAll()
        {
            var InterviewList = _interviewRepository.InterviewSelectAll(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return PartialView(InterviewList);
        }
        /// <summary>
        /// Method to Load AddInterview Partial View Screen
        /// </summary>
        /// <returns></returns>
        public ActionResult _AddInterview()
        {
            var interviewFormModelObj = new InterviewFormModel();
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            interviewFormModelObj.Interview = new Interview();
            if (!string.IsNullOrEmpty(Request.QueryString["InterviewId"]))
            {
                interviewFormModelObj.Interview.InterviewId = Convert.ToInt32(Request.QueryString["InterviewId"]);
                interviewFormModelObj.Interview = _interviewRepository.InterviewSelect(interviewFormModelObj.Interview.InterviewId);
            }
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            interviewFormModelObj.InterviewType = lstlookup.Where(j => j.TableName == LocalizedStrings.InterviewType).ToList();
            interviewFormModelObj.InterviewType.Insert(0, lookUpDataEntityobj);
            interviewFormModelObj.InterviewRoom = lstlookup.Where(j => j.TableName == LocalizedStrings.InterviewRoom).ToList();
            interviewFormModelObj.InterviewRoom.Insert(0, lookUpDataEntityobj);
            interviewFormModelObj.InterviewStatus = lstlookup.Where(j => j.TableName == LocalizedStrings.InterviewStatus).ToList();
            interviewFormModelObj.InterviewStatus.Insert(0, lookUpDataEntityobj);
            interviewFormModelObj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return PartialView(interviewFormModelObj);
        }
        /// <summary>
        /// Post Method of AddInterview Partial View 
        /// </summary>
        /// <param name="interviewFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        public bool _AddInterview(InterviewFormModel interviewFormModelObj)
        {

            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            interviewFormModelObj.Interview.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            interviewFormModelObj.Interview.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            interviewFormModelObj.Interview.ModifiedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            int result;
            if (interviewFormModelObj.Interview.InterviewId.Equals(0))
                result = 0;
            //result = _interviewRepository.CreateInterview(interviewFormModelObj.Interview);
            else
                result = _interviewRepository.UpdateInterview(interviewFormModelObj.Interview);

            return result > 0;
        }


    }
}