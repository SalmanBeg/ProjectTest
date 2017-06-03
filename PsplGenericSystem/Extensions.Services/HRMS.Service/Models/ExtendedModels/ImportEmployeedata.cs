using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ImportEmployeedataMetaData))]
    public partial class ImportEmployeedata
    {
        public int RowID { get; set; }
        public string WorkPhone1 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Suffixid { get; set; }
        public string TGender { get; set; }
        public string TChangeReason { get; set; }
        public string TPosition { get; set; }
        public string TJobProfile { get; set; }
        public string TFLSAStatus { get; set; }
        public string TMaritalStatus { get; set; }
        public string Status { get; set; }

        public List<LookUpDataEntity> MaritalStatusList { get; set; }
        public List<LookUpDataEntity> GenderList { get; set; }
        public List<LookUpDataEntity> SalutationList { get; set; }
        public List<LookUpDataEntity> SuffixList { get; set; }
        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }


        #region Dropdown Properties
        public List<LookUpDataEntity> TerminationReasonList { get; set; }


        public List<LookUpDataEntity> EmploymentStatusList { get; set; }


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



        public List<LookUpDataEntity> UnionList { get; set; }

        public List<LookUpDataEntity> EmploymentTypeList { get; set; }


        public List<LookUpDataEntity> ChangeReasonList { get; set; }

        public List<UserLoginModel> ManagerList { get; set; }
        [Display(Name = "Manager")]
        public int? Manager { get; set; }

        public List<UserLoginModel> UserList { get; set; }
        [Display(Name = "Manager")]
        public int? User { get; set; }

        #endregion
    }
    public partial class ImportEmployeedataMetaData
    {
        public ImportEmployeedataMetaData()
        {
        }

        public string UserName { get; set; }
        public int ImportEmployeeId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string CompanyId { get; set; }
        public Nullable<System.Guid> ImportEmployeeCode { get; set; }
        public string EmployeeNo { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public string SSN { get; set; }
        public string HomePhone { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<int> MaritalStatus { get; set; }
        public string HomeEmail { get; set; }
        public Nullable<int> ChangeReason { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> OriginalHireDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<int> TerminationReason { get; set; }
        public string WorkPhone { get; set; }
        public string WorkEmail { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> SeniorityDate { get; set; }
        public Nullable<System.DateTime> LastPaidDate { get; set; }
        public Nullable<System.DateTime> LastPayRise { get; set; }
        public Nullable<System.DateTime> LastPromotionDate { get; set; }
        public Nullable<System.DateTime> LastReviewDate { get; set; }
        public Nullable<System.DateTime> NextReviewDate { get; set; }
        public Nullable<System.DateTime> NewHireReportDate { get; set; }
        public Nullable<int> EmploymentStatus { get; set; }
        public Nullable<int> JobProfileId { get; set; }
        public Nullable<int> PositionId { get; set; }
        public Nullable<int> PayGroup { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public Nullable<int> EmploymentType { get; set; }
        public Nullable<int> ComplianceCode { get; set; }
        public Nullable<int> BenefitClass { get; set; }
        public Nullable<int> FLSAStatus { get; set; }
        public Nullable<int> Union { get; set; }
        public string DistrictCode { get; set; }
        public string CheckDistribution { get; set; }
        public Nullable<bool> DirectDepositEmail { get; set; }
        public Nullable<bool> OkToRehire { get; set; }
        public Nullable<int> WCJobClassCode { get; set; }
        public Nullable<int> WCStatus { get; set; }
        public Nullable<int> WCType { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ImportTag { get; set; }
        public string Batchkey { get; set; }
        public string Password { get; set; }


    }
}
