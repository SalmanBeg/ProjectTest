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
    using System.Collections.Generic;
    
    public partial class ReviewerEmployee
    {
        public int ReviewerEmployeeId { get; set; }
        public Nullable<System.Guid> ReviewerEmployeeCode { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> ReviewDate { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<decimal> ReviewScore { get; set; }
        public Nullable<decimal> ReviewerScore { get; set; }
        public string ReviewerComments { get; set; }
        public Nullable<bool> IsSubmit { get; set; }
        public string HRComments { get; set; }
        public Nullable<int> HRStatus { get; set; }
        public Nullable<int> ReviewerId { get; set; }
        public Nullable<System.DateTime> ReviewEndDate { get; set; }
        public Nullable<int> ReviewerMasterId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> CompanyId { get; set; }
    }
}
