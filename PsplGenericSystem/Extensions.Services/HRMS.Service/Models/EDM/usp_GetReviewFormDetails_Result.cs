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
    
    public partial class usp_GetReviewFormDetails_Result
    {
        public int ReviewReviewerId { get; set; }
        public int ReviewerEmployeeId { get; set; }
        public string ReviewTitle { get; set; }
        public string EmployeeName { get; set; }
        public string ManagerName { get; set; }
        public Nullable<decimal> ReviewScore { get; set; }
        public Nullable<decimal> ReviewerScore { get; set; }
        public Nullable<System.DateTime> ReviewDate { get; set; }
        public Nullable<int> Status { get; set; }
        public string ReviewerComments { get; set; }
        public string ReviewerName { get; set; }
        public Nullable<int> HRStatus { get; set; }
        public string HRComments { get; set; }
    }
}
