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
    
    public partial class usp_usp_CompensationPlanSelectAllSelect_Result
    {
        public int CompensationID { get; set; }
        public int CompanyID { get; set; }
        public string PlanDescription { get; set; }
        public string Location { get; set; }
        public Nullable<int> PayRange { get; set; }
        public Nullable<int> PayRangeTo { get; set; }
        public Nullable<int> PayRangePer { get; set; }
        public Nullable<int> VariablePay { get; set; }
        public Nullable<int> VariablePayTo { get; set; }
        public Nullable<int> VariablePayPer { get; set; }
        public string HoursPerWeek { get; set; }
        public Nullable<int> BenfitClass { get; set; }
        public Nullable<bool> Exempt { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
