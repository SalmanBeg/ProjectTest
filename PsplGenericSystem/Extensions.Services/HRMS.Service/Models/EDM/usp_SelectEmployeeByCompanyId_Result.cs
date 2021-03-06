//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS.Service.Models.EDM
{
    using System;
    
    public partial class usp_SelectEmployeeByCompanyId_Result
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int EmploymentDetailId { get; set; }
        public Nullable<System.Guid> EmploymentId { get; set; }
        public string EmployeeNo { get; set; }
        public Nullable<int> ChangeReason { get; set; }
        public string WorkPhone { get; set; }
        public string WorkEmail { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> OriginalHireDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<int> TerminationReason { get; set; }
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
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
