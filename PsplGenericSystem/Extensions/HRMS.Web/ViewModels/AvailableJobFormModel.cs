using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class AvailableJobFormModel
    {
        public AvailableJobFormModel()
        {
            Jobs = new List<JobProfile>();
            JobCategoryList = new List<LookUpDataEntity>();
            SelectedJobProperties = new List<SelectedJobProperty>();
            JobCategoryList = new List<LookUpDataEntity>();
            JobDuties = new List<JobDuties>();
            JobQualifications = new List<JobQualification>();
            JobPmes = new List<JobPME>();

          
        }
        public List<JobProfile> Jobs { get; set; }
        public List<LookUpDataEntity> JobCategoryList { get; set; }
        public List<UserLoginModel> HiringManagerList { get; set; }
        public List<UserLoginModel> EmployeeList { get; set; }
        public List<JobRecruiter> JobRecruiterList { get; set; }
        public List<Interview> Interviews { get; set; }
        public List<Recruiter> ResultList { get; set; }
        public JobProfile JobProfile { get; set; }
        public List<JobDuties> JobDuties { get; set; }
        public List<JobQualification> JobQualifications { get; set; }
        public List<JobPME> JobPmes { get; set; }
        public int JobCategory { get; set; }
        public string CompanyName {get; set;}
        public string RecruiterCheckedIdList { get; set; }
        public string RecruiterIdList { get; set; }

        public List<SelectedJobProperty> SelectedJobProperties { get; set; }

    }
    public class SelectedJobProperty
    {
        public int Id { get; set; }
        public string Property { get; set; }
        public string Description { get; set; }
        public decimal? PercentageOfTime { get; set; }
        public string Proficiency { get; set; }
        public int JobProfileId { get; set; }
    }
}
