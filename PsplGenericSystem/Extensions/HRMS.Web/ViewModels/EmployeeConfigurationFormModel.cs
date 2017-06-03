using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Mvc;
using HRMS.Common.Helpers;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class EmployeeConfigurationFormModel
    {

        public EmployeeConfigurationFormModel()
        {
            JobProfileList = new List<JobProfile>();
            OnBoardingList = new List<OnBoarding>();
            HireStepList = new List<HireStepMaster>();
            ManagerList = new List<UserLoginModel>();
            EmploymentStatusList = new List<LookUpDataEntity>();
            CompensationFrequencyList=new List<LookUpDataEntity>();
        }

        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        [RegularExpression("^([a-zA-Z '-]+)$", ErrorMessage = "Only Alphabets.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        [RegularExpression("^([a-zA-Z '-]+)$", ErrorMessage = "Only Alphabets")] 
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter an email.")]
        [RegularExpression(@"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Please enter a valid email address")]
        //[DataType(DataType.EmailAddress)]
        [Remote("CheckForDuplicationbyCompany", "Account", HttpMethod = "POST", ErrorMessage = "Email is registerd with us, please try using other email.")]
        [Display(Name = "Email")]
        public string EMail { get; set; } 
        public string Password { get; set; }
        public string EmployeeNo { get; set; }
        public Boolean IsApproved { get; set; }
        public Boolean IsLockedOut { get; set; }
        [Display(Name = "Password Question")]
        public string PasswordQuestion { get; set; }                            
        [Display(Name = "Password Answer")]
        public string PasswordAnswer { get; set; }
        public List<JobProfile> JobProfileList { get; set; }
        [Required]
        [Display(Name = "Job Profile")]
        public int JobProfile { get; set; }
        [Required(ErrorMessage = "Please enter hire date.")]
        [Display(Name = "Hire Date")]
        [DataType(DataType.DateTime)]
        public DateTime? HireDate { get; set; }
        public List<OnBoarding> OnBoardingList { get; set; }
        public int OnBoardingId { get; set; }
        [Display(Name = "Employment Status")]
        public int EmploymentStatusId { get; set; }
        [Display(Name = "Manager")]
       // [Required(ErrorMessage = "Please enter manager.")]
        public int? ManagerId { get; set; }
        [Display(Name = "Per")]
        [Required(ErrorMessage = "Please select compensation frequency.")]
        public int CompensationFrequency { get; set; }
        [Required(ErrorMessage = "Please enter compensation.")]
        public decimal? Compensation { get; set; }

        public List<LookUpDataEntity> CompensationFrequencyList { get; set; }
        public List<LookUpDataEntity> EmploymentStatusList { get; set; }
        public List<UserLoginModel> ManagerList { get; set; }
        public List<HireStepMaster> HireStepList { get; set; }
    }
}






