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
    
    public partial class Timesheetsubmission
    {
        public int TimesheetSubmissionId { get; set; }
        public int UserId { get; set; }
        public int ApprovedUserId { get; set; }
        public bool Submit { get; set; }
        public Nullable<bool> AdminStatus { get; set; }
        public Nullable<bool> ManagerStatus { get; set; }
        public int RoleId { get; set; }
        public int PayPeriodId { get; set; }
        public System.DateTime PayperiodStartDate { get; set; }
        public System.DateTime PayperiodEndDate { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public int ManagerUserId { get; set; }
        public Nullable<int> ManagerRoleId { get; set; }
        public Nullable<System.DateTime> ManagerLastUpdated { get; set; }
        public Nullable<int> AdminUserId { get; set; }
        public Nullable<int> AdminRoleId { get; set; }
        public Nullable<System.DateTime> AdminLastUpdated { get; set; }
        public int CompanyId { get; set; }
    }
}