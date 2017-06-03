using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(OverTimePolicyMetaData))]
    public partial class OverTimePolicy
    {
        public string OTPolicytypeName { get; set; }
        public string SatPayTypeName { get; set; }
        public string SunPayTypeName { get; set; }
    }

    public partial class OverTimePolicyMetaData
    {
        public OverTimePolicyMetaData()
        { }

        public int OvertimeId { get; set; }
        public Guid OverTimeCode { get; set; }
        [Display(Name = "Policy Name")]
        [Required(ErrorMessage = "OTPolicy Name  is required")]
        public string OTPolicyName { get; set; }
        [Display(Name = "Policy Type")]
        public int? OTPolicytype { get; set; }
        [Display(Name = "Daily OT Hours")]
        public double? DailyOTHours { get; set; }
        [Display(Name = "Weekly OT Hours")]
        public double? WeeklyOTHours { get; set; }
        [Display(Name = "Daily DT Hours")]
        public double? DailyDTHours { get; set; }
        [Display(Name = "Weekly DT Hours")]
        public double? WeeklyDTHours { get; set; }
        [Display(Name = "Saturday")]
        public Int16? SatPayType { get; set; }
        [Display(Name = "Sunday")]
        public Int16? SunPayType { get; set; }
        [Display(Name = "$Premium")]
        public Single? SatDolPremium { get; set; }
        [Display(Name = "$Premium")]
        public Single? SunDolPremium { get; set; }
        [Display(Name = "CR Daily Rules")]
        public Boolean CRDailyRules { get; set; }
        [Display(Name = "CR Daily OT Hours")]
        public double? CRDailyOTHours { get; set; }
        [Display(Name = "CR Daily DT Hours")]
        public double? CRDailyDTHours { get; set; }
        [Display(Name = "Policy Type")]
        public Boolean CRWeeklyRule { get; set; }
        [Display(Name = "CR Weekly OT Hours")]
        public double? CRWeeklyOTHours { get; set; }
        [Display(Name = "CR Weekly DT Hours")]
        public double? CRWeeklyDTHours { get; set; }
        public Boolean ConsecutiveDayRules { get; set; }
        public int? CDRMinimumWorkDays { get; set; }
        public double? CDRMinimumWorkHours { get; set; }
        public double? CDROTHours { get; set; }
        public double? CDRDTHours { get; set; }
        public Boolean ForceApproval { get; set; }
        public int CompanyId { get; set; }
    }
}
