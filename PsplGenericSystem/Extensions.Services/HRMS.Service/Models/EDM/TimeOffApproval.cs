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
    
    public partial class TimeOffApproval
    {
        public int TimeOffApprovalId { get; set; }
        public int UserId { get; set; }
        public System.DateTime DateOff { get; set; }
        public Nullable<int> PayTypeId { get; set; }
        public string PayCode { get; set; }
        public Nullable<double> TimeOff { get; set; }
        public Nullable<double> AllowedTimeOff { get; set; }
        public Nullable<bool> Approved { get; set; }
        public Nullable<bool> Disapproved { get; set; }
        public Nullable<bool> Applied { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> IsMgrApproved { get; set; }
        public Nullable<System.Guid> LeaveRequestGUID { get; set; }
        public Nullable<System.DateTime> LeaveRequestDate { get; set; }
        public string ApprovalType { get; set; }
        public int CompanyId { get; set; }
    }
}
