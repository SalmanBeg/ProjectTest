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
    
    public partial class usp_CertificationLicensesSelect_Result
    {
        public int CertificationLicensesId { get; set; }
        public int CompanyId { get; set; }
        public System.Guid CertificationLicensesCode { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Type { get; set; }
        public string CertificationType { get; set; }
        public string Name { get; set; }
        public Nullable<int> Certification { get; set; }
        public string LicenseNumber { get; set; }
        public Nullable<int> LicenseCountry { get; set; }
        public Nullable<int> LicenseState { get; set; }
        public string School { get; set; }
        public Nullable<int> Endorsements { get; set; }
        public Nullable<int> Areas { get; set; }
        public string FileName { get; set; }
        public Nullable<int> Document { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> RenewalDate { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
