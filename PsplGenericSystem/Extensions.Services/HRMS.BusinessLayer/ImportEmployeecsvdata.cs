using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HRMS.BusinessLayer
{
    public class ImportEmployeecsvdata
    {
       

        public ImportEmployeecsvdata()
        {
            ChangeReasonList = new List<LookUpDataEntity>();
            EmploymentStatusList = new List<LookUpDataEntity>();
            EmploymentTypeList = new List<LookUpDataEntity>();
            PositionList = new List<LookUpDataEntity>();
            JobProfileList = new List<LookUpDataEntity>();
            LocationList = new List<LookUpDataEntity>();
            TerminationReasonList = new List<LookUpDataEntity>();
            DivisionList = new List<LookUpDataEntity>();
            DepartmentList = new List<LookUpDataEntity>();
            FLSAStatusList = new List<LookUpDataEntity>();
            UnionList = new List<LookUpDataEntity>();
            ManagerList = new List<UserLoginModel>();

            MaritalStatusList = new List<LookUpDataEntity>();
            GenderList = new List<LookUpDataEntity>();
            SalutationList = new List<LookUpDataEntity>();
            SuffixList = new List<LookUpDataEntity>();
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
        }     
        public int EmploymentDetailId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string EmploymentCode { get; set; }
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
        public Boolean OkToRehire { get; set; }
        [Display(Name = "WCJob ClassCode")]
        public int WCJobClassCode { get; set; }
        [Display(Name = "WCStatus")]
        public int WCStatus { get; set; }
        [Display(Name = "WCType")]
        public int WCType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please enter status.")]
        public string Status { get; set; }
        [Display(Name = "EEO Class")]
        public string EEOClass { get; set; }
        [Display(Name = "Workers Compensation Code")]
        public string WorkersCompCode { get; set; }
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Display(Name = "Work Email")]
        [Required(ErrorMessage = "Please enter work email.")]
        public string WorkEmail { get; set; }
        [Display(Name = "Pay Group Name")]
        //[Required(ErrorMessage = "Please enter pay group name.")]
        public int? PayGroupName { get; set; }
        [Display(Name = "New Hire Reported")]
        public Boolean NewHireReported { get; set; }
        public string Salutation { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Suffix { get; set; }
        [Required(ErrorMessage = "Please enter a email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        //[Required(ErrorMessage = "Please enter a ZIP.")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please enter a country.")]
        public int CountryId { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "Please enter a state.")]
        public int StateId { get; set; }
        //[Required(ErrorMessage = "Please enter a SSN.")]
        public string SSN { get; set; }
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "1/1/1753", "1/1/2020", ErrorMessage = "Value for {0} must be between {1} and {2}")]       
        [Required(ErrorMessage = "Please enter a birth date.")]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Please enter gender.")]
        public int Gender { get; set; } 
        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Please enter marital status.")]
        public int? MaritalStatus { get; set; }
        [Display(Name = "Home Email")]
        public string HomeEmail { get; set; }
        public string Country { get; set; }
        public string State { get; set; }

        public Boolean DeleteCheckstatus { get; set; }

        public string CostCenter1 { get; set; }
        public string CostCenter2 { get; set; }
        public string CostCenter3 { get; set; }
        public string CostCenter4 { get; set; }
        public string CostCenter5 { get; set; }
        public string JobCode { get; set; }
        public string JobClass { get; set; }
        public string Compensation { get; set; }
        public string Per { get; set; }
        public DateTime? RateEffectiveDate { get; set; }
        public string PayrollEEID { get; set; }
        public string FederalTaxStatus { get; set; }
        public string FederalTaxExemptions { get; set; }
        public string StateTaxExemptions { get; set; }
        public string StateTaxAdditionalWithholding { get; set; }
        public string LiveinCountry { get; set; }
      //  public string StateTaxExemptions { get; set; }
      //  public string StateTaxAdditionalWithholding { get; set; }
      //  public string LiveinCountry { get; set; }
        public string LiveinState { get; set; }
        public string WorkinCountry { get; set; }
        public string WorkinState { get; set; }
        public string PayPeriod { get; set; }
        public string Type { get; set; }
       // public string WCJobClassCode { get; set; }
       // public string WCstatus { get; set; }
       // public string WCType { get; set; }

        // Name fields for id values
        [Required(ErrorMessage = "Please enter gender.")]
        public string TGender { get; set; }
        public string TChangeReason { get; set; }
        public string TPosition { get; set; }
        public string TJobProfile { get; set; }
        public string TMaritalStatus { get; set; } 
        public string TPayGroupName { get; set; }
        public string TFLSAStatus { get; set; }
        public int Suffixid { get; set; }
        //
        public List<LookUpDataEntity> MaritalStatusList { get; set; }
        public List<LookUpDataEntity> GenderList { get; set; }
        public List<LookUpDataEntity> SalutationList { get; set; }
        public List<LookUpDataEntity> SuffixList { get; set; }
        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }
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
        public string ImportTag { get; set; }
        public string Password { get; set; }
        #endregion

        #region Dropdown Properties
        public List<LookUpDataEntity> TerminationReasonList { get; set; }
        [Display(Name = "Termination Reason")]
        public int? TerminationReason { get; set; }

        public List<LookUpDataEntity> EmploymentStatusList { get; set; }
        [Display(Name = "Employment Status")]
        public int EmploymentStatus { get; set; }

        public List<LookUpDataEntity> JobProfileList { get; set; }
        [Display(Name = "Job Profile")]
        [Required(ErrorMessage = "Please enter job profile.")]
        public int JobProfile { get; set; }

        public List<LookUpDataEntity> PositionList { get; set; }
        [Display(Name = "Position")]
        //[Required(ErrorMessage = "Please enter position.")]
        public int? Position { get; set; }

        public List<LookUpDataEntity> LocationList { get; set; }
        [Display(Name = "Location")]
        public int? Location { get; set; }

        public List<LookUpDataEntity> DivisionList { get; set; }
        [Display(Name = "Division")]
        public int? Division { get; set; }

        public List<LookUpDataEntity> DepartmentList { get; set; }
        [Display(Name = "Department")]
        public int Department { get; set; }

        public List<LookUpDataEntity> FLSAStatusList { get; set; }
        [Display(Name = "FLSA Status")]
        public int FLSAStatus { get; set; }

        public List<LookUpDataEntity> UnionList { get; set; }
        [Display(Name = "Union")]
        public int? Union { get; set; }

        public List<LookUpDataEntity> EmploymentTypeList { get; set; }
        [Display(Name = "Employment Type")]
        public int? EmploymentType { get; set; }

        public List<LookUpDataEntity> ChangeReasonList { get; set; }
        [Display(Name = "Change Reason")]
        public int ChangeReason { get; set; }

        public List<UserLoginModel> ManagerList { get; set; }
        [Display(Name = "Manager")]
        public int? Manager { get; set; }

        public List<UserLoginModel> UserList { get; set; }
        [Display(Name = "Manager")]
        public int? User { get; set; }

        #endregion


    }
}
