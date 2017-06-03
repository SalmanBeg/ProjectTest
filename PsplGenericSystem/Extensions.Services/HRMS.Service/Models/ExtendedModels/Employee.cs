using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee 
    {
        public string EmploymentCode { get; set; }
        [Display(Name = "Workers Compensation Code")]
        public string WorkersCompCode { get; set; }
        [Display(Name = "Pay Group Name")]
        //[Required(ErrorMessage = "Please enter pay group name.")]
        public int? PayGroupName { get; set; }
        [Display(Name = "New Hire Reported")]
        public Boolean NewHireReported { get; set; }
        [Display(Name = "EEO Class")]
        public string EEOClass { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please enter status.")]
        public string Status { get; set; }
        public Guid UserCode { get; set; }
        public string UserName { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsSubmitted { get; set; }
    }
    public partial class EmployeeMetaData
    {
        public EmployeeMetaData()
        {
        }
        public int EmploymentDetailId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }       
        [Display(Name = "Compliance Code")]
        public int? ComplianceCode { get; set; }
        [Display(Name = "Benefit Class")]
        public int? BenefitClass { get; set; }
        [Display(Name = "District")]
        public string DistrictCode { get; set; }
        [Display(Name = "Check Distribution")]
        public string CheckDistribution { get; set; }
        [Display(Name = "Direct Deposit Email")]
        public Boolean DirectDepositEmail { get; set; }
        [Display(Name = "Ok To Rehire")]
        public Boolean? OkToRehire { get; set; }
        [Display(Name = "WCJob ClassCode")]
        public int WCJobClassCode { get; set; }
        [Display(Name = "WCStatus")]
        public int WCStatus { get; set; }
        [Display(Name = "WCType")]
        public int WCType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }       
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Display(Name = "Work Email")]
        [Required(ErrorMessage = "Please enter work email.")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[\w\._-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Please enter a valid email address")]
        public string WorkEmail { get; set; }      
        [Display(Name = "Salutation")]
        public string Salutation { get; set; }     
        [Required(ErrorMessage = "Please enter a first name.")]
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Suffix { get; set; }
        [Required(ErrorMessage = "Please enter an email address.")]
       // [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[\w\._-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        public string City { get; set; }
        //[Required(ErrorMessage = "Please enter a ZIP.")]

        [Display(Name = "Zip")]
        [Required(ErrorMessage = "Please enter a valid ZIP Code.")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZIP { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please enter a country.")]
        public int CountryId { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "Please select the state.")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please enter the SSN.")]
        [RegularExpression(@"^\d{9}|\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
        public string SSN { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide your home phone number.")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "You must provide a proper phone number.")]
        [RegularExpression("^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$", ErrorMessage = "You must provide a proper phone number.")]
        public string HomePhone { get; set; }

        //[RegularExpression(@"^([\+]|0)[(\s]{0,1}[2-9][0-9]{0,2}[\s-)]{0,2}[0-9][0-9][0-9\s-]*[0-9]$", ErrorMessage = "Invalid Home Phone Number")]
        //[DataType(DataType.PhoneNumber)]
        //[Display(Name = "Home Phone")]
        //public string HomePhone { get; set; }
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "1/1/1753", "1/1/2020", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        [Required(ErrorMessage = "Please select the birth date.")]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Please enter gender.")]
        public int Gender { get; set; }
        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Please enter marital status.")]
        public int? MaritalStatus { get; set; }
        [Display(Name = "Home Email")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[\w\._-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Please enter a valid email address")]
        public string HomeEmail { get; set; }
        [Display(Name = "Termination Reason")]
        public int? TerminationReason { get; set; }
         [Required(ErrorMessage = "Please select employment status.")]
        [Display(Name = "Employment Status")]
        public int EmploymentStatus { get; set; }
        [Display(Name = "Job Profile")]
        //[Required(ErrorMessage = "Please enter job profile.")]
        public int JobProfileId { get; set; }
        [Display(Name = "Position")]
        //[Required(ErrorMessage = "Please enter position.")]
        public int? PositionId { get; set; }
        [Display(Name = "Location")]
        public int? LocationId { get; set; }
        [Display(Name = "Division")]
        //[Required(ErrorMessage = "Please enter Division")]
        public int? DivisionId { get; set; }
        [Display(Name = "Department")]
        //public int? UserSignUp { get; set; }
        //[Display(Name = "UserSignUp")]
        public int DepartmentId { get; set; }
        [Display(Name = "FLSA Status")]
        public int FLSAStatus { get; set; }
       // public int UserSignUp { get; set; }
        [Display(Name = "Union")]
        //[Required(ErrorMessage = "Please enter Union")]
        public int? Union { get; set; }
        [Required(ErrorMessage = "Please enter Employment Type")]
        [Display(Name = "Employment Type")]
        public int? EmploymentType { get; set; }
          [Required(ErrorMessage = "Please select change reason.")]
        [Display(Name = "Change Reason")]
        public int ChangeReason { get; set; }
        [Display(Name = "Manager")]
        public int? ManagerId { get; set; }
        #region Date Properties
        [Required(ErrorMessage = "Please enter hire date.")]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
        [Display(Name = "Original Hire Date")]
        public DateTime? OriginalHireDate { get; set; }
        [Display(Name = "Termination Date")]
        public DateTime? TerminationDate { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
           
        //[DataCompareValidation("HireDate", ErrorMessage = "Seniority date should be Greater than Hire date")]
        [DataType(DataType.Date)]
        //[DateGreaterThanAttribute("StartDate")]  
        [Display(Name = "Seniority Date")]
        public DateTime? SeniorityDate { get; set; }
        [Display(Name = "Last Paid Date")]
        public DateTime? LastPaidDate { get; set; }
        [Display(Name = "Last Pay Rise")]
        public DateTime? LastPayRise { get; set; }
        [Display(Name = "Last Promotion Date")]
        public DateTime? LastPromotionDate { get; set; }
        [Display(Name = "Last Review Date")]
        public DateTime? LastReviewDate { get; set; }
        [Display(Name = "Next Review Date")]
        public DateTime? NextReviewDate { get; set; }
        [Display(Name = "New Hire Report Date")]
        public DateTime? NewHireReportDate { get; set; }
        #endregion        
    }
}
