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
    
    public partial class usp_ActivityLogSelectByCompanyId_Result
    {
        public int ActivityId { get; set; }
        public System.Guid ActivityCode { get; set; }
        public int CompanyId { get; set; }
        public string Activity { get; set; }
        public Nullable<System.DateTime> ActivityDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
