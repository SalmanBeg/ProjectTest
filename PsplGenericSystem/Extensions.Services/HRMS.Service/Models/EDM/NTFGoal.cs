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
    
    public partial class NTFGoal
    {
        public int NTFGoalId { get; set; }
        public string GoalDescription { get; set; }
        public System.Guid AssignedBy { get; set; }
        public System.Guid AssignedTo { get; set; }
        public int CompanyId { get; set; }
        public Nullable<System.DateTime> AssignedDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<double> KeyIndicator { get; set; }
        public Nullable<double> Target { get; set; }
        public Nullable<double> Currentvalue { get; set; }
        public string Incentive { get; set; }
        public Nullable<bool> Prorated { get; set; }
        public Nullable<double> IncentiveEarned { get; set; }
        public string Status { get; set; }
    }
}
