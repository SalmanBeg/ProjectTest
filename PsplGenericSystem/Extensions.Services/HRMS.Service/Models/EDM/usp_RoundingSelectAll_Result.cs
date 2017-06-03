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
    
    public partial class usp_RoundingSelectAll_Result
    {
        public int RoundingId { get; set; }
        public int CompanyId { get; set; }
        public System.Guid RoundingPolicyCode { get; set; }
        public string RoundingDescription { get; set; }
        public Nullable<short> StartRoundType { get; set; }
        public Nullable<short> StartRoundMinutes { get; set; }
        public Nullable<short> EndRoundType { get; set; }
        public Nullable<short> EndPunchMinutes { get; set; }
        public Nullable<short> LunchStartRoundType { get; set; }
        public Nullable<short> LunchStartRoundMinutes { get; set; }
        public Nullable<short> LunchEndRoundType { get; set; }
        public Nullable<short> LunchEndRoundTMinutes { get; set; }
        public Nullable<short> BreakStartRoundType { get; set; }
        public Nullable<short> BreakStartRoundMinutes { get; set; }
        public Nullable<short> BreakEndRoundType { get; set; }
        public Nullable<short> BreakEndRoundTMinutes { get; set; }
        public string RoundingMethod { get; set; }
        public Nullable<bool> RptExceptions { get; set; }
        public Nullable<short> ReportEarlyIn { get; set; }
        public Nullable<short> ReportEarlyOut { get; set; }
        public Nullable<short> ReportLateIn { get; set; }
        public Nullable<short> ReportLateOut { get; set; }
        public Nullable<short> ReportLunchUnder { get; set; }
        public Nullable<short> ReportLunchOver { get; set; }
    }
}
