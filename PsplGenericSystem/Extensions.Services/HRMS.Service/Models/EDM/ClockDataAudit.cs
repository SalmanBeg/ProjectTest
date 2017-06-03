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
    
    public partial class ClockDataAudit
    {
        public int ClockAuditId { get; set; }
        public int ClockDataId { get; set; }
        public int PayTypeId { get; set; }
        public string PunchType { get; set; }
        public string PayType { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> JobId { get; set; }
        public Nullable<int> Level4Id { get; set; }
        public string Level5Id { get; set; }
        public Nullable<double> TotalTime { get; set; }
        public Nullable<decimal> Dollars { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<System.DateTime> DateEntered { get; set; }
        public Nullable<int> AutitUserId { get; set; }
        public string AuditType { get; set; }
        public Nullable<System.DateTime> AuditDate { get; set; }
        public string AuditRecType { get; set; }
        public Nullable<int> StartClockLocationId { get; set; }
        public Nullable<int> StartDeviceId { get; set; }
        public Nullable<int> EndClockLocationId { get; set; }
        public Nullable<int> EndClockDeviceId { get; set; }
        public string InTimeZone { get; set; }
        public string OutTimeZone { get; set; }
        public string AdminNotes { get; set; }
        public string ManagerNotes { get; set; }
        public string EmployeeNotes { get; set; }
        public int CompanyId { get; set; }
    
        public virtual ClockData ClockData { get; set; }
        public virtual ClockDevice ClockDevice { get; set; }
        public virtual ClockDevice ClockDevice1 { get; set; }
        public virtual ClockLocation ClockLocation { get; set; }
        public virtual ClockLocation ClockLocation1 { get; set; }
    }
}