using System.Globalization;
using System.IO;
using System.Text;
using System.Web.Security;
using HRMS.Common.Enums;
using HRMS.Common.Helpers;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using iTextSharp.text.pdf;
using Newtonsoft.Json;


namespace HRMS.Web.Areas.JobPortal.Controllers
{

    public class JobPortalController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IJobProfileRepository _jobProfileRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IJobApplicantRepository _jobApplicantRepository;
        private readonly ICertificationandLicenseRepository _certificationandLicenseRepository;
        private readonly IUserRepository _userRepository;

        public JobPortalController(IJobProfileRepository jobProfileRepository, IFilesDBRepository filesDBRepository,
            IUtilityRepository utilityRepository, ICompanyRepository companyRepository,
            IJobApplicantRepository jobApplicantRepository,
            ICertificationandLicenseRepository certificationandLicenseRepository)
        {
            _jobProfileRepository = jobProfileRepository;
            _filesDBRepository = filesDBRepository;
            _utilityRepository = utilityRepository;
            _companyRepository = companyRepository;
            _jobApplicantRepository = jobApplicantRepository;
            _certificationandLicenseRepository = certificationandLicenseRepository;

        }

        #endregion

        /// <summary>
        /// To show all the available jobs in a company
        /// </summary>
        /// <returns></returns>
        public ActionResult AvailableJobs()
        {

            var availableJobFormModelObj = new AvailableJobFormModel();
            if ((string.IsNullOrEmpty(GlobalsVariables.CurrentCompanyId)) && (Request.QueryString["CompanyId"] != null) ||
                (Request.QueryString["CompanyId"] != GlobalsVariables.CurrentCompanyId))
            {
                //Session.Abandon();
                //Session.Clear();
                int companyId = Convert.ToInt32(Request.QueryString["CompanyId"]);
                if (companyId != 0)
                    GlobalsVariables.CurrentCompanyId = Convert.ToString(companyId);
            }
            var companyInfoObj =
                _companyRepository.GetEditCompanyInfo(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            GlobalsVariables.CurrentCompanyName = companyInfoObj.CompanyName;
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            availableJobFormModelObj.Jobs =
                _jobProfileRepository.ListAvailableJobsForJobPortal(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            availableJobFormModelObj.JobCategoryList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.JobCategory).ToList();


            if (!string.IsNullOrEmpty(GlobalsVariables.CurrentUserId))
            {
                var listappliedjobs =
                    _jobApplicantRepository.AppliedJobs(Convert.ToInt32(GlobalsVariables.CurrentUserId));
                if (listappliedjobs.Count > 0 && listappliedjobs[0] != null)
                    availableJobFormModelObj.Jobs = (from jobprofiles in availableJobFormModelObj.Jobs
                                                     where listappliedjobs.All(appliedjob => appliedjob.JobProfileId != jobprofiles.JobProfileId)
                                                     select jobprofiles).ToList();
            }

            foreach (var jobprofile in availableJobFormModelObj.Jobs)
            {
                var jobDuties = _jobProfileRepository.ListJobDutiesInJobProfile(jobprofile.JobProfileId);

                foreach (var jobduty in jobDuties)
                {
                    var selectedJobPropertyObj = new SelectedJobProperty();
                    selectedJobPropertyObj.Id = jobduty.JobDutyId;
                    selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobDuty.ToString();
                    selectedJobPropertyObj.Description = jobduty.Description;
                    selectedJobPropertyObj.JobProfileId = jobprofile.JobProfileId;
                    selectedJobPropertyObj.PercentageOfTime = jobduty.PercentageOfTime;
                    availableJobFormModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
                }

                var jobQualifications = _jobProfileRepository.ListJobQualificationsInJobProfile(jobprofile.JobProfileId);
                foreach (var jobqualification in jobQualifications)
                {

                    var selectedJobPropertyObj = new SelectedJobProperty();
                    selectedJobPropertyObj.Id = jobqualification.JobQualificationId;
                    selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobQualification.ToString();
                    selectedJobPropertyObj.Description = jobqualification.Description;
                    selectedJobPropertyObj.JobProfileId = jobprofile.JobProfileId;
                    selectedJobPropertyObj.Proficiency = jobqualification.Proficiency;
                    availableJobFormModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
                }

                var jobPMEs = _jobProfileRepository.ListJobPMEsInJobProfile(jobprofile.JobProfileId);
                foreach (var jobpme in jobPMEs)
                {
                    var selectedJobPropertyObj = new SelectedJobProperty();
                    selectedJobPropertyObj.Id = jobpme.PMEId;
                    selectedJobPropertyObj.Property = GeneralEnum.JobProperties.JobPME.ToString();
                    selectedJobPropertyObj.Description = jobpme.Description;
                    selectedJobPropertyObj.JobProfileId = jobprofile.JobProfileId;
                    availableJobFormModelObj.SelectedJobProperties.Add(selectedJobPropertyObj);
                }
            }


            //availableJobFormModelObj.JobQualifications = _jobProfileRepository.ListJobQualificationsInJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            //availableJobFormModelObj.JobPmes = _jobProfileRepository.ListJobPMEsInJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(availableJobFormModelObj);
        }

        /// <summary>
        /// To show available jobs in a company
        /// </summary>
        /// <param name="availableJobFormModelObj"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AvailableJobs(AvailableJobFormModel availableJobFormModelObj, string command)
        {
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            availableJobFormModelObj.Jobs =
                _jobProfileRepository.ListAvailableJobsForJobPortal(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            availableJobFormModelObj.JobCategoryList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.JobCategory).ToList();


            availableJobFormModelObj.Jobs =
                availableJobFormModelObj.Jobs.Where(p => p.JobCategory == availableJobFormModelObj.JobCategory).ToList();

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
                var jobQualifications =
                    _jobProfileRepository.ListJobQualificationsInJobProfile(jobprofileObj.JobProfileId);
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
        /// Partial view used to register applicant
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public ActionResult _RegisterApplicant(string jobId)
        {
            var registerApplicantFormModelObj = new RegisterApplicantFormModel();
            registerApplicantFormModelObj.JobApplicant = new JobApplicant();
            registerApplicantFormModelObj.JobId = Convert.ToInt32(jobId);
            return PartialView(registerApplicantFormModelObj);

            //TODO:JK: use when needed if further information about applicant such as gender,country and state is required
            //var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            //registerApplicantFormModelObj.GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList();
            //registerApplicantFormModelObj.CountryList = _utilityRepository.GetCountry();
            //if (registerApplicantFormModelObj.JobApplicant.CountryId != 0)
            //    registerApplicantFormModelObj.StateList = _utilityRepository.GetStateProvince(registerApplicantFormModelObj.JobApplicant.CountryId);
        }

        /// <summary>
        /// Partial view used to register applicant
        /// </summary>
        /// <param name="registerApplicantFormModelObj"></param>
        /// <param name="formCollectionObj"></param>
        /// <param name="file"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult _RegisterApplicant(RegisterApplicantFormModel registerApplicantFormModelObj)
        {

            int fileId = 0;
            var passwordgenerator = new RandomStringGenerator();
            string password = passwordgenerator.Generate("LlnlnLlL");
            registerApplicantFormModelObj.JobApplicant.Password = Encryption.Encrypt(password);
            registerApplicantFormModelObj.JobApplicant.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            registerApplicantFormModelObj.JobApplicant.ResumeAttachmentId = fileId;
            registerApplicantFormModelObj.JobApplicant.Status = true;
            int applicantId =
                _jobApplicantRepository.JobApplicantInsertOrUpdate(registerApplicantFormModelObj.JobApplicant);
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
                GlobalsVariables.CurrentUserId = applicantId.ToString();
                GlobalsVariables.CurrentUserName = applicantName;


                bool success = false;
                //String filepath = ConfigurationManager.AppSettings["ScannedDocuments"];
                if (Request.Files.Count > 0)
                {
                    var httpPostedFileBase = Request.Files[0];
                    if (httpPostedFileBase != null &&
                        ((Request.Files.Count > 0) && (httpPostedFileBase.ContentLength > 0)))
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
                        fileId = _filesDBRepository.CreateFileinFilesDB(filesDBobj,
                            Convert.ToInt32(GlobalsVariables.CurrentUserId));
                        registerApplicantFormModelObj.JobApplicant.File = filename;
                        registerApplicantFormModelObj.JobApplicant.ResumeAttachmentId = fileId;
                        registerApplicantFormModelObj.JobApplicant.JobApplicantId =
                            Convert.ToInt32(GlobalsVariables.CurrentUserId);
                        _jobApplicantRepository.JobApplicantResumeUpdate(registerApplicantFormModelObj.JobApplicant);

                    }

                }

                // New Applicant Automation of mailing in recruiting process
                var jobProfileObj = _jobProfileRepository.SelectJobProfileById(registerApplicantFormModelObj.JobId);

                var recruiterList = _jobProfileRepository.SelectJobRecruitersByJobId(registerApplicantFormModelObj.JobId);

                foreach (var recuiterObj in recruiterList)
                {

                    registerApplicantFormModelObj.EmployeeIds.Add(recuiterObj.EmployeeId);


                }
                registerApplicantFormModelObj.EmployeeIds.Add(Convert.ToInt32(jobProfileObj.HiringManager));

                var candidateObj = _jobApplicantRepository.SelectJobApplicantById(registerApplicantFormModelObj.JobApplicant.JobApplicantId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

                foreach (var employeeObj in registerApplicantFormModelObj.EmployeeIds)
                {

                    DateTime dt = System.DateTime.Now;

                    var htmlpath = Convert.ToString(Server.MapPath("~/Utilities/newApplicant.html"));
                    string strHireManagerName = jobProfileObj.HiringManagerName;
                    string strRecruiterName = candidateObj.FirstName + " " + candidateObj.LastName;
                    string strHireManagerEmail = jobProfileObj.HiringManagerEmail;      
                    string strLoginURL = ConfigurationManager.AppSettings["_loginurl"];
                    string strJobTitle = jobProfileObj.Title;
                    string redirectUrl = Encryption.Encrypt(ConfigurationManager.AppSettings["JobPortalRedirectUrl"]);
                    Mailing.Sendemailtouser(strHireManagerEmail, "NewApplicant",
                        "", strHireManagerName, GlobalsVariables.CurrentCompanyName, "", redirectUrl, htmlpath, "", strRecruiterName, "",
                        dt, strJobTitle);
                }

            }
            return RedirectToAction("AvailableJobs");
        }


        /// <summary>
        /// Post method to save applied job by logged in applicant
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [HttpPost]
        public int ApplyJob(int jobId)
        {
            var jobAppliedObj = new JobApplied
            {
                JobProfileId = jobId,
                JobApplicantId = Convert.ToInt32(GlobalsVariables.CurrentUserId),
                Status = (int)GeneralEnum.JobApplicationStatus.IsApplied,
                AppliedOn = DateTime.UtcNow
            };
            var i = _jobApplicantRepository.ApplyJob(jobAppliedObj);
            if (i > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public ActionResult _ApplicantInfo(int jobProfileId, int applicantId)
        {
            List<LookUpDataEntity> lstlookup;
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);

            var applicationInfoFormModelObj = new ApplicationInfoFormModel
            {
                CountryList = _utilityRepository.GetCountry(),
                lstApplicantEducation =
                    _jobApplicantRepository.SelectApplicantEducationById(applicantId),
                lstApplicantEmploymentHistory =
                    _jobApplicantRepository.SelectApplicantEmploymentHistoryById(applicantId, jobProfileId),
                lstApplicantAchievementsAndAssociations =
                    _jobApplicantRepository.SelectApplicantAchievementsAndAssociationsById(applicantId, jobProfileId),
                lstCertificationandLicense =
                    _certificationandLicenseRepository.SelectAllCertificationandLicense(applicantId),
                GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList()
            };

            return PartialView(applicationInfoFormModelObj);
        }
        /// <summary>
        /// View meant to add education info for an applicant
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        //[HttpGet]
        //public ActionResult _AddEducationInfo()
        //{
        //    var lstlookup = new List<LookUpDataEntity>();
        //    lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        //    ApplicationInfoFormModel applicationInfoFormModelObj = new ApplicationInfoFormModel();
        //    applicationInfoFormModelObj.JobApplicant = new JobApplicant();
        //    applicationInfoFormModelObj.ApplicantAchievementsAndAssociations = new ApplicantAchievementsAndAssociations();
        //    applicationInfoFormModelObj.CertificationandLicense = new CertificationandLicense();
        //    applicationInfoFormModelObj.ApplicantEducation = new ApplicantEducation();
        //    applicationInfoFormModelObj.ApplicantEmploymentHistory = new ApplicantEmploymentHistory();
        //    applicationInfoFormModelObj.GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList();
        //    return View(applicationInfoFormModelObj);

        //}
        /// <summary>
        /// To view jobs applied by logged in applicant
        /// </summary>
        /// <returns></returns>
        public ActionResult AppliedJobs()
        {
            var listViewAppliedJobs = new List<AppliedJobsFormModel>();
            var availableJobsList =
                _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (!string.IsNullOrEmpty(GlobalsVariables.CurrentUserId))
            {
                var listappliedjobs =
                    _jobApplicantRepository.AppliedJobs(Convert.ToInt32(GlobalsVariables.CurrentUserId));
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

            return View(listViewAppliedJobs);
        }
        /// <summary>
        /// To add basic applicant information required for an job opening
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult AddApplicationInfo()
        {
            List<LookUpDataEntity> lstlookup;
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            int applicantId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            int userId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            var applicationInfoFormModelObj = new ApplicationInfoFormModel
            {
                JobApplicant = _jobApplicantRepository.SelectJobApplicantById(applicantId, companyId),
                lstApplicantEducation =
                    _jobApplicantRepository.SelectApplicantEducationById(applicantId),
                lstApplicantEmploymentHistory =
                    _jobApplicantRepository.SelectApplicantEmploymentHistoryById(applicantId, 0),
                lstApplicantAchievementsAndAssociations =
                    _jobApplicantRepository.SelectApplicantAchievementsAndAssociationsById(applicantId, 0),
                lstCertificationandLicense =
                    _certificationandLicenseRepository.SelectAllCertificationandLicense(userId),
                GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList()
            };
            return View(applicationInfoFormModelObj);
        }
        /// <summary>
        /// To add basic applicant information required for an job opening
        /// </summary>
        /// <param name="applicationInfoFormModelObj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult AddApplicationInfo(ApplicationInfoFormModel applicationInfoFormModelObj)
        {
            var lstlookup = new List<LookUpDataEntity>();
            var jobApplicantObj = new JobApplicant();
            jobApplicantObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);

            applicationInfoFormModelObj.GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList();


            applicationInfoFormModelObj.ApplicantAchievementsAndAssociations = new ApplicantAchievementsAndAssociations();
            applicationInfoFormModelObj.CertificationandLicense = new CertificationandLicense();
            applicationInfoFormModelObj.ApplicantEducation = new ApplicantEducation();
            applicationInfoFormModelObj.ApplicantEmploymentHistory = new ApplicantEmploymentHistory();


            if (!string.IsNullOrEmpty(GlobalsVariables.CurrentUserId))
            {
                applicationInfoFormModelObj.JobApplicant.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                int jobApplicantinfo = _jobApplicantRepository.JobApplicantUpdate(applicationInfoFormModelObj.JobApplicant);
            }

            if (applicationInfoFormModelObj.lstApplicantEducation[0].ApplicantEducationId == 0)
            {
                applicationInfoFormModelObj.lstApplicantEducation[0].ApplicantEducationId = applicationInfoFormModelObj.lstApplicantEducation[0].ApplicantEducationId;
                _jobApplicantRepository.JobApplicantEducationInsert(applicationInfoFormModelObj.lstApplicantEducation[0]);
            }
            else
            {
                applicationInfoFormModelObj.lstApplicantEducation[0].ApplicantId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                _jobApplicantRepository.ApplicantEducationUpdate(applicationInfoFormModelObj.lstApplicantEducation[0]);
            }

            if (applicationInfoFormModelObj.lstApplicantEmploymentHistory[0].ApplicantEmploymentHistoryId == 0)
            {
                applicationInfoFormModelObj.lstApplicantEmploymentHistory[0].ApplicantEmploymentHistoryId = applicationInfoFormModelObj.lstApplicantEmploymentHistory[0].ApplicantEmploymentHistoryId;
                _jobApplicantRepository.JobApplicantEmploymentInsert(applicationInfoFormModelObj.lstApplicantEmploymentHistory[0]);
            }
            else
            {
                applicationInfoFormModelObj.lstApplicantEmploymentHistory[0].ApplicantId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                _jobApplicantRepository.ApplicantEmploymentUpdate(applicationInfoFormModelObj.lstApplicantEmploymentHistory[0]);
            }

            if (applicationInfoFormModelObj.lstApplicantAchievementsAndAssociations[0].ApplicantAchievementsAndAssociationsId == 0)
            {
                applicationInfoFormModelObj.lstApplicantAchievementsAndAssociations[0].ApplicantAchievementsAndAssociationsId = applicationInfoFormModelObj.lstApplicantAchievementsAndAssociations[0].ApplicantAchievementsAndAssociationsId;
                _jobApplicantRepository.JobApplicantSkillInsert(applicationInfoFormModelObj.lstApplicantAchievementsAndAssociations[0]);
            }
            else
            {
                applicationInfoFormModelObj.lstApplicantAchievementsAndAssociations[0].ApplicantId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                _jobApplicantRepository.ApplicantSkillUpdate(applicationInfoFormModelObj.lstApplicantAchievementsAndAssociations[0]);
            }

            if (applicationInfoFormModelObj.lstCertificationandLicense[0].CertificationLicensesId == 0)
            {
                applicationInfoFormModelObj.lstCertificationandLicense[0].CertificationLicensesId = applicationInfoFormModelObj.lstCertificationandLicense[0].CertificationLicensesId;
                _certificationandLicenseRepository.InsertCertificationandLicense(applicationInfoFormModelObj.lstCertificationandLicense[0]);
            }
            else
            {
                applicationInfoFormModelObj.lstCertificationandLicense[0].CertificationLicensesId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                _certificationandLicenseRepository.UpdateCertificationandLicense(applicationInfoFormModelObj.lstCertificationandLicense[0]);
            }


            //bool addApplicantEducationInfo = _jobApplicantRepository.JobApplicantEducationInsert(applicationInfoFormModelObj.ApplicantEducation);
            //bool addApplicantEmploymentInfo = _jobApplicantRepository.JobApplicantEmploymentInsert(applicationInfoFormModelObj.ApplicantEmploymentHistory);
            //bool addApplicantSkillInfo = _jobApplicantRepository.JobApplicantSkillInsert(applicationInfoFormModelObj.ApplicantAchievementsAndAssociations);   
            //bool success = _certificationandLicenseRepository.InsertCertificationandLicense(applicationInfoFormModelObj.CertificationandLicense);         
            return View(applicationInfoFormModelObj);
        }
        /// <summary>
        /// View meant to add education info for an applicant
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult AddEducationInfo()
        {
            var applicantEducationObj = new ApplicantEducation();
            return View(applicantEducationObj);

        }
        /// <summary>
        ///  View meant to add education info for an applicant
        /// </summary>
        /// <param name="applicationInfoFormModelObj"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPost]
        public ActionResult AddEducationInfo(ApplicantEducation applicantEducationObj)
        {
            applicantEducationObj.ApplicantId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            int result = _jobApplicantRepository.JobApplicantEducationInsert(applicantEducationObj);
            return RedirectToAction("AddApplicationInfo");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationInfoFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateEducationInfo(ApplicationInfoFormModel applicationInfoFormModelObj)
        {
            foreach (var applicanteducation in applicationInfoFormModelObj.lstApplicantEducation)
            {

                _jobApplicantRepository.ApplicantEducationUpdate(applicanteducation);

            }
            return RedirectToAction("AddApplicationInfo");
        }
        /// <summary>
        ///  View meant to add employment info for an applicant
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddEmploymentInfo()
        {
            var applicantEmploymentHistoryObj = new ApplicantEmploymentHistory();
            return View(applicantEmploymentHistoryObj);
        }
        /// <summary>
        ///  View meant to add employment info for an applicant
        /// </summary>
        /// <param name="applicationInfoFormModelObj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult AddEmploymentInfo(ApplicantEmploymentHistory applicantEmploymentHistoryObj)
        {
            applicantEmploymentHistoryObj.ApplicantId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            _jobApplicantRepository.JobApplicantEmploymentInsert(applicantEmploymentHistoryObj);

            return RedirectToAction("AddApplicationInfo");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationInfoFormModelObj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult UpdateEmploymentInfo(ApplicationInfoFormModel applicationInfoFormModelObj)
        {
            foreach (var applicantemployment in applicationInfoFormModelObj.lstApplicantEmploymentHistory)
            {

                _jobApplicantRepository.ApplicantEmploymentUpdate(applicantemployment);

            }
            return RedirectToAction("AddApplicationInfo");
        }
        /// <summary>
        /// View meant to add skills of an applicant
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddSkillInfo()
        {
            var applicantAchievementsAndAssociationsObj = new ApplicantAchievementsAndAssociations();
            return View(applicantAchievementsAndAssociationsObj);
        }
        /// <summary>
        /// View meant to add skills of an applicant
        /// </summary>
        /// <param name="applicationInfoFormModelObj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult AddSkillInfo(ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj)
        {
            applicantAchievementsAndAssociationsObj.ApplicantId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            _jobApplicantRepository.JobApplicantSkillInsert(applicantAchievementsAndAssociationsObj);
            return RedirectToAction("AddApplicationInfo");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationInfoFormModelObj"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult UpdateSkillInfo(ApplicationInfoFormModel applicationInfoFormModelObj)
        {
            foreach (var achievementsAndassociations in applicationInfoFormModelObj.lstApplicantAchievementsAndAssociations)
            {

                _jobApplicantRepository.ApplicantSkillUpdate(achievementsAndassociations);

            }
            return RedirectToAction("AddApplicationInfo");
        }
        /// <summary>
        /// View meant to add certification and licenses of an applicant
        /// </summary>
        /// <returns></returns>
        /// 
        [Authorize]
        public ActionResult AddCertificationLicence()
        {
            var certificationandLicenseformmodelObj = new CertificationandLicenseFormModel();
            return View(certificationandLicenseformmodelObj);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddCertificationLicence(CertificationandLicenseFormModel certificationandLicenseformmodelObj)
        {
            bool success = false;
            certificationandLicenseformmodelObj.CertificationandLicense.UserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            certificationandLicenseformmodelObj.CertificationandLicense.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            certificationandLicenseformmodelObj.CertificationandLicense.CertificationLicensesId = 2;
            certificationandLicenseformmodelObj.CertificationandLicense.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            certificationandLicenseformmodelObj.CertificationandLicense.CreatedOn = System.DateTime.UtcNow;
            success = _certificationandLicenseRepository.InsertCertificationandLicense(certificationandLicenseformmodelObj.CertificationandLicense);
            if (success)
            return RedirectToAction("AddApplicationInfo");
             else
                return RedirectToAction("AddApplicationInfo");

        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateCertificationLicence(ApplicationInfoFormModel applicationInfoFormModelObj)
        {
            foreach (var certificationandLicense in applicationInfoFormModelObj.lstCertificationandLicense)
            {

                _certificationandLicenseRepository.UpdateCertificationandLicense(certificationandLicense);

            }
            return RedirectToAction("AddApplicationInfo");
        }


        /// <summary>
        /// To remove an applicant education based on record id
        /// </summary>
        /// <param name="applicantEducationIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteApplicantEducation(string applicantEducationIds)
        {

            if (!string.IsNullOrEmpty(applicantEducationIds))
            {
                foreach (var applicantEducationId in applicantEducationIds.Split(','))
                {
                    var deleteApplicantEducation =
                           _jobApplicantRepository.DeleteApplicantEducation(Int32.Parse(applicantEducationId));
                }

            }
            return true;
        }
        /// <summary>
        /// To remove an applicant employment history based on record id
        /// </summary>
        /// <param name="applicantEmploymentHistoryIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteApplicantEmployment(string applicantEmploymentHistoryIds)
        {
            if (!string.IsNullOrEmpty(applicantEmploymentHistoryIds))
            {
                foreach (var applicantEmploymentHistoryId in applicantEmploymentHistoryIds.Split(','))
                {
                    var deleteApplicantEmployment =
                           _jobApplicantRepository.DeleteApplicantEmployment(Int32.Parse(applicantEmploymentHistoryId));
                }

            }
            return true;
        }
        /// <summary>
        /// To remove an applicant skill  based on record id
        /// </summary>
        /// <param name="applicantAchievementsAndAssociationsIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteApplicantSkill(string applicantAchievementsAndAssociationsIds)
        {

            if (!string.IsNullOrEmpty(applicantAchievementsAndAssociationsIds))
            {
                foreach (var applicantAchievementsAndAssociationsId in applicantAchievementsAndAssociationsIds.Split(','))
                {
                    var deleteApplicantEducation =
                           _jobApplicantRepository.DeleteApplicantSkill(Int32.Parse(applicantAchievementsAndAssociationsId));
                }

            }
            return true;
        }
        /// <summary>
        /// To remove an applicant certification records  based on record id
        /// </summary>
        /// <param name="certificationandLicenseIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteCertificationandLicense(string certificationandLicenseIds)
        {
            if (certificationandLicenseIds != null)
            {
                foreach (var certificationandLicenseId in certificationandLicenseIds.Split(','))
                {
                    var deleteDependentDetail =
                        _certificationandLicenseRepository.DeleteCertificationandLicense(Int32.Parse(certificationandLicenseId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;

        }
    }
}