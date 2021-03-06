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
    
    public partial class JobDuties
    {
        public JobDuties()
        {
            this.JobProfile = new HashSet<JobProfile>();
        }
    
        public int JobDutyId { get; set; }
        public System.Guid JobDutyCode { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<decimal> PercentageOfTime { get; set; }
        public Nullable<int> Frequency { get; set; }
        public Nullable<int> Essential { get; set; }
        public Nullable<int> Other { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual ICollection<JobProfile> JobProfile { get; set; }
    }
}
