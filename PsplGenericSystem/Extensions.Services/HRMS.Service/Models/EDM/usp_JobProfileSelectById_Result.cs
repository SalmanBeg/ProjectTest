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
    
    public partial class usp_JobProfileSelectById_Result
    {
        public int JobProfileID { get; set; }
        public string JobCode { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Title { get; set; }
        public string CityStateOrZipCode { get; set; }
        public string JobDescription { get; set; }
        public Nullable<int> JobCategory { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> IsPosted { get; set; }
        public Nullable<int> PageVisitorCount { get; set; }
        public Nullable<int> HiringManager { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }
        public Nullable<bool> BasicInfo { get; set; }
        public Nullable<bool> Education { get; set; }
        public Nullable<bool> Employment { get; set; }
        public Nullable<bool> Certification { get; set; }
        public Nullable<bool> Skill { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string HiringManagerName { get; set; }
        public string HiringManagerEmail { get; set; }
    }
}