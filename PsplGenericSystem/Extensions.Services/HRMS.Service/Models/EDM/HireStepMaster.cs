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
    
    public partial class HireStepMaster
    {
        public HireStepMaster()
        {
            this.HireApprovalSetups = new HashSet<HireApprovalSetup>();
        }
    
        public int StepId { get; set; }
        public Nullable<System.Guid> StepCode { get; set; }
        public string StepName { get; set; }
        public Nullable<int> OrderNo { get; set; }
    
        public virtual ICollection<HireApprovalSetup> HireApprovalSetups { get; set; }
    }
}
