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
    
    public partial class EmployeeGoalRemainder
    {
        public int EmployeeGoalRemainderId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> SentOn { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> GoalId { get; set; }
        public Nullable<int> RecurrenceId { get; set; }
        public string SentStatus { get; set; }
    }
}
