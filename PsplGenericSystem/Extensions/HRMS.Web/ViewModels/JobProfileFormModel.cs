using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class JobProfileFormModel
    {
        public JobProfileFormModel()
        {
            JobCategoryList = new List<LookUpDataEntity>();
            JobDuties = new List<JobDuties>();
            JobQualifications=new List<JobQualification>();
            JobPmes = new List<JobPME>();
            RecruitingQuestions = new List<RecruitingQuestions>();
            DashboardCount = new DashboardCount();

        }
        public List<LookUpDataEntity> JobCategoryList { get; set; }
        public JobProfile JobProfile { get; set; }
        public JobApplicant JobApplicant { get; set; }
        public JobApplied JobApplied { get; set; }
        public List<UserLoginModel> EmployeeList { get; set; }
        public string RecruiterCheckedIdList { get; set; }
        public string RecruiterIdList { get; set; }
        public List<JobRecruiter> JobRecruiterList { get; set; }
        public List<Recruiter> ResultList { get; set; }
        public List<UserLoginModel> HiringManagerList { get; set; }
        public List<JobDuties> JobDuties { get; set; }
        public List<JobQualification> JobQualifications { get; set; }
        public List<JobPME> JobPmes { get; set; }
        public List<Interview> Interviews { get; set; }
        public List<RecruitingQuestions> RecruitingQuestions { get; set; }
        public DashboardCount DashboardCount { get; set; }
    }

    public class Recruiter
    {
        
        public int employeeId { get; set; }
        public string recruiterName { get; set; }
        public bool isChecked { get; set; }
    }
    
}