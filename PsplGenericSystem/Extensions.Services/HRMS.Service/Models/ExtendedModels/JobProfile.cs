using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(JobProfileMetaData))]
    public partial class JobProfile
    {
        // JobCategoryList = new List<LookUpDataEntity>();
        [DisplayName("Hire Company Description")]
        [Required(ErrorMessage = "Enter company description")]
        public string CompanyDescription { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CreatedByName { get; set; }
        public string JobUrl { get; set; }
        [DisplayName("Hiring Manager Name")]
        public string HiringManagerName { get; set; }

        public string RecruiterFullName{ get; set; }

        public string HiringManagerEmail { get; set; }
        [Required(ErrorMessage = "Enter Comments")]
        public string Comments { get; set; }
        
        [DisplayName("Job Description")]
        public string JobCategoryDesc { get; set; }

        [DisplayName("Recruiters")]
        public string RecruiterNames { get; set; }
        
        public List<LookUpDataEntity> JobCategoryList { get; set; }
        //To check the Job tile for add mode (true) or update mode (false)
        public bool JobProfileMode { get; set; }
        public bool Status1
        {
            get
            {
                return Status.GetValueOrDefault();
            }
            set
            {
                Status = value;
            }
        }
        [DisplayName("Basic Info")]
        public bool IsBasicInfo
        {
            get
            {
                return BasicInfo.GetValueOrDefault();
            }
            set
            {
                BasicInfo = value;
            }
        }
        [DisplayName("Education")]
        public bool IsEducation
        {
            get
            {
                return Education.GetValueOrDefault();
            }
            set
            {
                Education = value;
            }
        }
        [DisplayName("Employment")]
        public bool IsEmployment
        {
            get
            {
                return Employment.GetValueOrDefault();
            }
            set
            {
                Employment = value;
            }
        }
        [DisplayName("Certification")]
        public bool IsCertification
        {
            get
            {
                return Certification.GetValueOrDefault();
            }
            set
            {
                Certification = value;
            }
        }
        [DisplayName("Skill")]
        public bool IsSkill
        {
            get
            {
                return Skill.GetValueOrDefault();
            }
            set
            {
                Skill = value;
            }
        }


    }



    public partial class JobProfileMetaData
    {
        public JobProfileMetaData()
        {

        }

        public int JobProfileId { get; set; }
        public int? CompanyId { get; set; }
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        public string JobCode { get; set; }
        [DisplayName("Job Title")]
        [Required(ErrorMessage = "Enter title")]
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        [Remote("IsTitleExists", "JobProfile", AdditionalFields = "Title,CompanyId,JobProfileId", ErrorMessage = "Title already exists")]
        public string Title { get; set; }
        [DisplayName("Job Description")]
        [Required(ErrorMessage = "Enter Job Description")]
        public string JobDescription { get; set; }
        [DisplayName("Job Category")]
        public int JobCategory { get; set; }
        [DisplayName("City, State, Zip Code")]
        [Required(ErrorMessage = "Enter City, State, Zip Code")]
        public string CityStateOrZipCode { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public bool BasicInfo { get; set; }
        public bool Education { get; set; }
        public bool Employment { get; set; }
        public bool Certification { get; set; }
        public bool Skill { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DisplayName("Post Date")]
        [Required(ErrorMessage="Please select post date.")]
        public DateTime PostDate { get; set; }
        //  public List<LookUpDataEntity> JobCategoryList { get; set; }
        // JobCategoryList = new List<LookUpDataEntity>();

    }
}
