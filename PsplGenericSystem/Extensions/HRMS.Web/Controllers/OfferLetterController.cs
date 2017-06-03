using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Repositories;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using System.IO;
using System.Configuration;

namespace HRMS.Web.Controllers
{
    public class OfferLetterController : Controller
    {

        #region Class Level Variables and Constructor

        private readonly ICompanyRepository _companyRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IJobProfileRepository _jobProfileRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly IOfferLetterRepository _offerLetterRepository;

        public OfferLetterController(ICompanyRepository companyRepository, IUtilityRepository utilityRepository, IJobProfileRepository jobProfileRepository,
            IEmployeeRepository employeeRepository, IRegisteredUsersRepository registeredUsersRepository,
            IJobApplicantRepository jobApplicantRepository, IOfferLetterRepository offerLetterRepository)
        {
            _companyRepository = companyRepository;
            _utilityRepository = utilityRepository;
            _jobProfileRepository = jobProfileRepository;
            _employeeRepository = employeeRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _jobApplicantRepository = jobApplicantRepository;
            _offerLetterRepository = offerLetterRepository;
        }
        #endregion

        // GET: /OfferLetter/
        [HttpGet]
        public ActionResult OfferLetter()
        {
            var candidateOfferLetterObj = new CandidateOfferLetter();
            if (!string.IsNullOrEmpty(Request.QueryString["jobApplicantId"]) && !string.IsNullOrEmpty(Request.QueryString["jobProfileId"]))
            {
                candidateOfferLetterObj.CandidateId = Convert.ToInt32(Request.QueryString["jobApplicantId"]);
                candidateOfferLetterObj.JobProfileId = Convert.ToInt32(Request.QueryString["jobProfileId"]);
                
            }
                var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                candidateOfferLetterObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                candidateOfferLetterObj.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);               
                //candidateOfferLetterObj.HiringManagerList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.CurrentUserId)).ToList();
                //candidateOfferLetterObj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            

            return View(candidateOfferLetterObj);

        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult OfferLetter(CandidateOfferLetter candidateOfferLetterObj)
        {
           
                candidateOfferLetterObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                candidateOfferLetterObj.CreatedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                candidateOfferLetterObj.ModifiedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                candidateOfferLetterObj.CreatedOn = DateTime.UtcNow;
                _offerLetterRepository.CreateOfferLetter(candidateOfferLetterObj);
                 if (candidateOfferLetterObj.LetterMailtoRecruiter.Equals(true))
                 {
                     MailOfferLetterTo(candidateOfferLetterObj);
                 }
                 return RedirectToAction("CandidatePreview", "Recruiting", new { JobApplicantId = candidateOfferLetterObj.CandidateId });
        }
    /// <summary>
    /// Method of sending a copy of Offer Letter for verification to selected Recruiter
    /// </summary>
    /// <returns></returns>
        public bool MailOfferLetterTo(CandidateOfferLetter candidateOfferLetterObj)
        {
                                               
                var RecruitersList = _jobProfileRepository.SelectJobRecruitersByJobId(candidateOfferLetterObj.JobProfileId);
                foreach (var recruiterObj in RecruitersList)
                {
                    var employeedetails = _employeeRepository.SelectEmployeeById(recruiterObj.EmployeeId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                    if (employeedetails != null)
                    {
                        string strPreviewURL = ConfigurationManager.AppSettings["_OfferLetterPreview"];
                        strPreviewURL = strPreviewURL + "?jobApplicantId=" + Convert.ToString(candidateOfferLetterObj.CandidateId) + "&jobProfileId=" + Convert.ToString(candidateOfferLetterObj.JobProfileId) + "&candidateOfferLetterId=" + Convert.ToString(candidateOfferLetterObj.CandidateOfferLetterId);
                        //var offerLetterObj = _offerLetterRepository.GetOfferLetterPreview(candidateId, jobProfileId, candidateOfferLetterId);
                        string strRecruiterName = employeedetails.FirstName + " " + employeedetails.LastName;
                        string strRecruiterEmail = employeedetails.Email;
                        string strSubject = "Offer Letter";
                        DateTime dt = System.DateTime.Now;
                        var path = Convert.ToString(Server.MapPath("~/Utilities/OfferLetterapprovalbyRecruiter.html"));                                           
                        string messageBody = candidateOfferLetterObj.CandidateOfferLetterContent;
                        Mailing.Sendemailtouser(strRecruiterEmail, strSubject, "", strRecruiterName, GlobalsVariables.CurrentCompanyName, messageBody, "", path, strPreviewURL, GlobalsVariables.CurrentUserName, "", dt, "");
                    }
                }
           
            return true;
        }
        [HttpGet]
        public ActionResult OfferLetterApproval()
        {
            var candidateOfferLetterObj = new CandidateOfferLetter();
            if (!string.IsNullOrEmpty(Request.QueryString["jobApplicantId"]) && !string.IsNullOrEmpty(Request.QueryString["jobProfileId"]) && !string.IsNullOrEmpty(Request.QueryString["candidateOfferLetterId"]))
            {

                candidateOfferLetterObj.CandidateId = Convert.ToInt32(Request.QueryString["jobApplicantId"]);
                candidateOfferLetterObj.JobProfileId = Convert.ToInt32(Request.QueryString["jobProfileId"]);
                candidateOfferLetterObj.CandidateOfferLetterId = Convert.ToInt32(Request.QueryString["candidateOfferLetterId"]);  
            }
            var offerletterinfo = _offerLetterRepository.GetOfferLetterContent(candidateOfferLetterObj.CandidateOfferLetterId);
            return View(offerletterinfo);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult OfferLetterApproval(string Command, CandidateOfferLetter candidateOfferLetterObj)
        {
            candidateOfferLetterObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            candidateOfferLetterObj.ModifiedBy = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            candidateOfferLetterObj.ModifiedOn = DateTime.UtcNow;

            if (Command == "Approve")
            {
                candidateOfferLetterObj.Status = true;
            }
            else if(Command == "Reject")
            {
                candidateOfferLetterObj.Status = false;
            }
            _offerLetterRepository.UpdateOfferLetterforApproval(candidateOfferLetterObj);                     
            return View(candidateOfferLetterObj);
        }
    }
}