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
    
    public partial class usp_ConsentFormsSelectAll_Result
    {
        public int ConsentFormId { get; set; }
        public int CompanyId { get; set; }
        public System.Guid ConsentCode { get; set; }
        public Nullable<int> ConsentType { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> AttachmentFileId { get; set; }
        public Nullable<bool> DisplayDocInConsent { get; set; }
        public Nullable<bool> EnableUploadLink { get; set; }
        public string DocumentName { get; set; }
        public Nullable<System.DateTime> UploadedOn { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}