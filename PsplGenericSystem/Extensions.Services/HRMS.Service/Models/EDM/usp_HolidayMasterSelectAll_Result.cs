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
    
    public partial class usp_HolidayMasterSelectAll_Result
    {
        public int HolidayMasterId { get; set; }
        public int HolidayGroupId { get; set; }
        public int HolidayId { get; set; }
        public Nullable<double> HoursBenefit { get; set; }
        public Nullable<bool> WorkBenefit { get; set; }
        public Nullable<bool> OverTimeBenefit { get; set; }
        public Nullable<bool> DoubleTimeBenefit { get; set; }
        public Nullable<int> DaysBefore { get; set; }
        public Nullable<int> DaysAfter { get; set; }
        public Nullable<decimal> DollarPerHour { get; set; }
        public Nullable<bool> BankHoursIfWorked { get; set; }
        public string BankToAccount { get; set; }
        public int CompanyId { get; set; }
    }
}
