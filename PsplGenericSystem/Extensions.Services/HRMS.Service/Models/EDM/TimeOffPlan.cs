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
    
    public partial class TimeOffPlan
    {
        public int TimeOffPlanId { get; set; }
        public int PTOMasterId { get; set; }
        public int PayTypeId { get; set; }
        public string PayCode { get; set; }
        public Nullable<byte> TimeUnits { get; set; }
        public Nullable<byte> Method { get; set; }
        public Nullable<decimal> HoursInDay { get; set; }
        public Nullable<byte> CalculateTo { get; set; }
        public Nullable<byte> AccrueYearFrom { get; set; }
        public Nullable<byte> UserFrom { get; set; }
        public Nullable<byte> AccrueOT { get; set; }
        public Nullable<byte> ArrruePTO { get; set; }
        public Nullable<bool> BalanceDisplay { get; set; }
        public int CompanyId { get; set; }
    
        public virtual TimeOffMaster TimeOffMaster { get; set; }
        public virtual PayType PayType { get; set; }
    }
}
