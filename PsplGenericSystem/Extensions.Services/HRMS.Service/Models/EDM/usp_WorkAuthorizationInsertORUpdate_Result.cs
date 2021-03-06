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
    
    public partial class usp_WorkAuthorizationInsertORUpdate_Result
    {
        public int WorkAuthorizationID { get; set; }
        public System.Guid WorkAuthorizationCode { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> TransactionID { get; set; }
        public Nullable<System.DateTime> SignatureDate { get; set; }
        public string IPAddress { get; set; }
        public Nullable<int> CitizenOfUS { get; set; }
        public string AlienNumber { get; set; }
        public Nullable<System.DateTime> PermanentResidentExpire { get; set; }
        public Nullable<int> AlienCitizenof { get; set; }
        public Nullable<System.DateTime> AlienAuthorisedDate { get; set; }
        public Nullable<int> AlienAuthorisedCitizenof { get; set; }
        public Nullable<bool> FederalLaw { get; set; }
        public Nullable<bool> IsSSN { get; set; }
        public Nullable<bool> IsEmployeeSign { get; set; }
        public string Confirmation { get; set; }
        public Nullable<System.DateTime> EmploymentOn { get; set; }
        public Nullable<bool> IsEmployerSign { get; set; }
        public string EmployerUserID { get; set; }
        public string EmployerTransactionID { get; set; }
        public Nullable<System.DateTime> EmployerSignDate { get; set; }
        public Nullable<System.DateTime> CertificationDate { get; set; }
        public byte[] Attachment { get; set; }
        public string AttachmentType { get; set; }
        public string AttachmentName { get; set; }
        public string AlienRegistrationNumber { get; set; }
        public string AdmissionNumber { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<int> Countryof { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
