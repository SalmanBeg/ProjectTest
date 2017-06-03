using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
 
namespace  HRMS.Service.Models.EDM
{
    [MetadataType(typeof(TimesheetPolicyInfoMetaData))]
    public partial class TimesheetPolicyInfo
    {
    }

    public partial class TimesheetPolicyInfoMetaData
    {
        public int TimesheetPolicyId { get; set; }
        public int UserId { get; set; }
        public int ReportToUserId { get; set; }
        public int TimesheetTypeId { get; set; }
        public Boolean AllowTimesheet { get; set; }
        [Display(Name = "Status")]
        public int? EmploymentStatus { get; set; }
        [Display(Name = "Division")]
        public int? DivisionId { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        [Display(Name = "Job Profile")]
        public int? JobProfileId { get; set; }
        public int Level4Id { get; set; }
        public int Level5Id { get; set; }
        [Display(Name = "Pay Period")]
        public int? PayPeriodId { get; set; }
        public decimal PayRate { get; set; }
        public decimal BillRate { get; set; }
        [Display(Name = "Holiday Group")]
        public int? HolidayGroupId { get; set; }
        [Display(Name = "Lunch")]
        public int? LunchId { get; set; }
        [Display(Name = "Rounding")]
        public int? RoundingId { get; set; }
        [Display(Name = "OverTime")]
        public int? OvertimeId { get; set; }
        public Boolean IsScheduleRequire { get; set; }
        public int ShiftMasterId { get; set; }
        public int ShiftId { get; set; }
        public int PTOMasterId { get; set; }
        public DateTime? BenefitAnnivarsaryDate { get; set; }
        public DateTime? BenefitStartDate { get; set; }
        public int RateMatrixId { get; set; }
        public int CompensatoryId { get; set; }
        public int ClockProfileId { get; set; }
        public decimal WorkedToDdateHours { get; set; }
        public DateTime? NextScheduleStartDate { get; set; }
        public string Notes { get; set; }
        public int CompanyId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Boolean RowChecked { get; set; }


        public List<Lunch> LunchList { get; set; }
        public List<Rounding> RoundingList { get; set; }
        public List<OverTimePolicy> OverTimePolicyList { get; set; }
        public List<PayPeriods> PayPeriodList { get; set; }
        public List<HolidayGroup> HolidayGroupList { get; set; }
        public List<LookUpDataEntity> EmployementStatusList { get; set; }
        public List<LookUpDataEntity> DivisionList { get; set; }
        public List<LookUpDataEntity> DepartmentList { get; set; }
        public List<LookUpDataEntity> JobProfileList { get; set; }

    }
}
