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
    
    public partial class usp_JobApplicantSelect_Result
    {
        public int JobApplicantId { get; set; }
        public int JobProfileId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Phone { get; set; }
        public Nullable<int> ResumeAttachmentId { get; set; }
        public string ResumeText { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> AppliedStatus { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Notes { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
