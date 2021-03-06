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
    
    public partial class CompensatoryEmployeeHistory
    {
        public int CompEmpHistoryId { get; set; }
        public int CompensatoryId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> PayPeriodId { get; set; }
        public Nullable<int> CompensationEarned { get; set; }
        public Nullable<int> CompensationTaken { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public int CompanyId { get; set; }
    
        public virtual CompensatoryTimePlan CompensatoryTimePlan { get; set; }
        public virtual PayPeriods PayPeriods { get; set; }
    }
}
