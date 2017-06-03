using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using HRMS.Common.Enums;


namespace HRMS.Web.ViewModels
{
    public class CandidateProcessingFormModel
    {
        public CandidateProcessingFormModel()
        {
            FilesDBList = new List<FilesDB>();
            lstJobProfiles = new List<JobProfile>();
            lstApplicantEducation = new List<ApplicantEducation>();
            lstApplicantAchievementsAndAssociations = new List<ApplicantAchievementsAndAssociations>();
            lstApplicantEmploymentHistory = new List<ApplicantEmploymentHistory>();
            lstCertificationandLicense = new List<CertificationandLicense>();
            ApplicantStatus = new GeneralEnum.JobApplicationStatus();
            AppliedJobsInfo = new List<AppliedJobsFormModel>();
            RecruiterComments = new List<RecruiterComments>();
          

        }

        public List<RecruiterComments> RecruiterComments { get; set; }
        public JobApplicant JobApplicant { get; set; }
        public List<JobProfile> lstJobProfiles { get; set; }
        public List<ApplicantEducation> lstApplicantEducation { get; set; }
        public List<ApplicantAchievementsAndAssociations> lstApplicantAchievementsAndAssociations { get; set; }
        public List<ApplicantEmploymentHistory> lstApplicantEmploymentHistory { get; set; }
        public List<CertificationandLicense> lstCertificationandLicense { get; set; }
        public int Candidatestatusid { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public int ResumeId { get; set; }
        public byte Resumee { get; set; }
        public string ApplicantName { get; set; }
        public GeneralEnum.JobApplicationStatus ApplicantStatus { get; set; }
        public List<AppliedJobsFormModel> AppliedJobsInfo { get; set; }
        public int Jobprofileid { get; set; }
        public string OfferLetter { get; set; }
        public bool EmailtoRecruiter { get; set; }
        public bool IsHired { get; set; }

        public List<FilesDB> FilesDBList { get; set; }
    }

    public class RecruiterComments
    {
        public int CommentId { get; set; }
        public string Comments { get; set; }
        public string RecruiterName { get; set; }
        public string PostedDate { get; set; }
    }
}