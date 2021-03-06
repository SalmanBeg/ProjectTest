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
    
    public partial class ExpenseReport
    {
        public ExpenseReport()
        {
            this.ExpenseEmployees = new HashSet<ExpenseEmployee>();
        }
    
        public int ExpenseReportId { get; set; }
        public System.Guid ExpenseReportCode { get; set; }
        public string ReportName { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> IsPaid { get; set; }
        public Nullable<bool> IsMgrApproved { get; set; }
        public Nullable<bool> IsAdminApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> IsSubmitted { get; set; }
        public Nullable<System.DateTime> SubmittedDate { get; set; }
        public Nullable<System.DateTime> ManagerApprovedDate { get; set; }
        public Nullable<System.DateTime> AdminApprovedDate { get; set; }
        public string ManagerComments { get; set; }
        public string AdminComments { get; set; }
        public int CompanyId { get; set; }
    
        public virtual ICollection<ExpenseEmployee> ExpenseEmployees { get; set; }
    }
}
