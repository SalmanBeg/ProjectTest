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
    
    public partial class usp_ApplicantEmploymentHistorySelectById_Result
    {
        public int ApplicantEmploymentHistoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> EmploymentStartDate { get; set; }
        public Nullable<System.DateTime> EmploymentEndDate { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public Nullable<int> JobId { get; set; }
    }
}
