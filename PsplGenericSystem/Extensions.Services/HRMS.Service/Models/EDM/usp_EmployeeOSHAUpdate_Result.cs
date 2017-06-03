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
    
    public partial class usp_EmployeeOSHAUpdate_Result
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int EmployeeOSHAId { get; set; }
        public Nullable<System.Guid> EmployeeOSHACode { get; set; }
        public Nullable<int> CaseNumber { get; set; }
        public Nullable<bool> IsNotReported { get; set; }
        public Nullable<System.DateTime> IncidentDateTime { get; set; }
        public string MedicalCosts { get; set; }
        public string Advisor { get; set; }
        public Nullable<System.DateTime> CaseClosedOn { get; set; }
        public string CompletedBy { get; set; }
        public string WorkPhone { get; set; }
        public Nullable<System.DateTime> FiledOn { get; set; }
        public string ClaimType { get; set; }
        public string OutCome { get; set; }
        public Nullable<bool> IsEmployeeinEmergency { get; set; }
        public Nullable<bool> IsEmployeeInPatient { get; set; }
        public string Physician { get; set; }
        public string Street { get; set; }
        public string Facility { get; set; }
        public string City { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public string Zip { get; set; }
        public string IncidentDetailsMisc1 { get; set; }
        public string IncidentDetailsMisc2 { get; set; }
        public string IncidentDetailsMisc3 { get; set; }
        public string InjuryDetailsMisc1 { get; set; }
        public string InjuryDetailsMisc2 { get; set; }
        public string InjuryDetailsMisc3 { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> JobTitle { get; set; }
    }
}
