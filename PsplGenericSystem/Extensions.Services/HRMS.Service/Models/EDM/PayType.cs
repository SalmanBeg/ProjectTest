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
    
    public partial class PayType
    {
        public PayType()
        {
            this.ClockData = new HashSet<ClockData>();
            this.TimeOffEmployee = new HashSet<TimeOffEmployee>();
            this.TimeOffEmployeeHistory = new HashSet<TimeOffEmployeeHistory>();
            this.TimeOffPlan = new HashSet<TimeOffPlan>();
            this.TimeOffService = new HashSet<TimeOffService>();
            this.Timesheet = new HashSet<Timesheet>();
        }
    
        public int PayTypeId { get; set; }
        public string PayCode { get; set; }
        public string PayTypeCode { get; set; }
        public string Description { get; set; }
        public string PunchType { get; set; }
        public int TimeTypeId { get; set; }
        public bool AccrueToOT { get; set; }
        public string MapToHR { get; set; }
        public string MapToPayroll { get; set; }
        public bool Display { get; set; }
        public Nullable<decimal> RateFactor { get; set; }
        public string GLCode { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public string PayrollCode { get; set; }
        public bool BypassBRM { get; set; }
        public int CompanyId { get; set; }
    
        public virtual ICollection<ClockData> ClockData { get; set; }
        public virtual TimeType TimeType { get; set; }
        public virtual ICollection<TimeOffEmployee> TimeOffEmployee { get; set; }
        public virtual ICollection<TimeOffEmployeeHistory> TimeOffEmployeeHistory { get; set; }
        public virtual ICollection<TimeOffPlan> TimeOffPlan { get; set; }
        public virtual ICollection<TimeOffService> TimeOffService { get; set; }
        public virtual ICollection<Timesheet> Timesheet { get; set; }
    }
}