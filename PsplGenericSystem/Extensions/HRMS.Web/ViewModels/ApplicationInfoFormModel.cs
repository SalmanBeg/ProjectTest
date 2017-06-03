using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class ApplicationInfoFormModel
    {
        public ApplicationInfoFormModel()
        {
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
            lstJobApplicant = new List<JobApplicant>();
            lstApplicantEducation = new List<ApplicantEducation>();
            lstApplicantAchievementsAndAssociations = new List<ApplicantAchievementsAndAssociations>();
            lstApplicantEmploymentHistory = new List<ApplicantEmploymentHistory>();
            lstCertificationandLicense = new List<CertificationandLicense>();
            GenderList = new List<LookUpDataEntity>();
        }
        public JobApplicant JobApplicant { get; set; }
        public JobProfile JobProfile { get; set; }
        public ApplicantAchievementsAndAssociations ApplicantAchievementsAndAssociations { get; set; }
        public CertificationandLicense CertificationandLicense { get; set; }
        public ApplicantEmploymentHistory ApplicantEmploymentHistory { get; set; }
        public ApplicantEducation ApplicantEducation { get; set; }
        public string ApplicantEducationIdList { get; set; }

        public List<JobApplicant> lstJobApplicant { get; set; }
        public List<ApplicantEducation> lstApplicantEducation { get; set; }
        public List<ApplicantAchievementsAndAssociations> lstApplicantAchievementsAndAssociations { get; set; }
        public List<ApplicantEmploymentHistory> lstApplicantEmploymentHistory { get; set; }
        public List<CertificationandLicense> lstCertificationandLicense { get; set; }
        public List<LookUpDataEntity> GenderList { get; set; }
        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }

    }
}