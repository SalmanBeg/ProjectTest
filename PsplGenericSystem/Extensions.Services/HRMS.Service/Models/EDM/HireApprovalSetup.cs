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
    
    public partial class HireApprovalSetup
    {
        public int HireApprovalSetupId { get; set; }
        public Nullable<int> HireConfigurationId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string StepName { get; set; }
        public Nullable<int> StepId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<System.DateTime> ApprovedOn { get; set; }
        public Nullable<int> ApprovedBy { get; set; }
        public Nullable<System.DateTime> RejectedOn { get; set; }
        public Nullable<int> RejectedBy { get; set; }
        public Nullable<bool> IsSubmitted { get; set; }
        public Nullable<System.DateTime> SubmittedDate { get; set; }
    
        public virtual HireStepMaster HireStepMaster { get; set; }
    }
}
