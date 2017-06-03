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
    
    public partial class usp_TimesheetPoliciesSelect_Result
    {
        public int TimesheetPolicyId { get; set; }
        public int UserId { get; set; }
        public Nullable<int> ReportToUserId { get; set; }
        public Nullable<int> TimesheetTypeId { get; set; }
        public Nullable<bool> AllowTimesheet { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> HomeDivisionId { get; set; }
        public Nullable<int> HomeDepartmentId { get; set; }
        public Nullable<int> HomeJobId { get; set; }
        public Nullable<int> Level4Id { get; set; }
        public Nullable<int> Level5Id { get; set; }
        public Nullable<int> PayPeriodId { get; set; }
        public Nullable<decimal> PayRate { get; set; }
        public Nullable<decimal> BillRate { get; set; }
        public Nullable<System.Guid> HolidayGroupCode { get; set; }
        public Nullable<int> LunchId { get; set; }
        public Nullable<int> RoundingId { get; set; }
        public Nullable<int> OvertimeId { get; set; }
        public Nullable<bool> IsScheduleRequire { get; set; }
        public Nullable<int> ShiftMasterId { get; set; }
        public Nullable<int> ShiftId { get; set; }
        public Nullable<int> PTOMasterId { get; set; }
        public Nullable<System.DateTime> BenefitAnnivarsaryDate { get; set; }
        public Nullable<System.DateTime> BenefitStartDate { get; set; }
        public Nullable<int> RateMatrixId { get; set; }
        public Nullable<int> CompensatoryId { get; set; }
        public Nullable<int> ClockProfileId { get; set; }
        public Nullable<decimal> WorkedToDdateHours { get; set; }
        public Nullable<System.DateTime> NextScheduleStartDate { get; set; }
        public string Notes { get; set; }
        public int CompanyId { get; set; }
    }
}