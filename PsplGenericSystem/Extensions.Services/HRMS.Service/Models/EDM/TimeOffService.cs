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
    
    public partial class TimeOffService
    {
        public int TimeOffServiceId { get; set; }
        public int PTOMasterId { get; set; }
        public int PayTypeId { get; set; }
        public string PayCode { get; set; }
        public int From { get; set; }
        public Nullable<int> To { get; set; }
        public Nullable<double> AccrualFormula { get; set; }
        public Nullable<double> MaxCarry { get; set; }
        public Nullable<double> MaxTime { get; set; }
        public bool AllowNegativeAccrual { get; set; }
        public int CompanyId { get; set; }
    
        public virtual TimeOffMaster TimeOffMaster { get; set; }
        public virtual PayType PayType { get; set; }
    }
}
