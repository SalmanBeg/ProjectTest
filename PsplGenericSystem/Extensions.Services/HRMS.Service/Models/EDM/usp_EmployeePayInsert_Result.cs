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
    
    public partial class usp_EmployeePayInsert_Result
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int EmployeePayId { get; set; }
        public Nullable<System.Guid> EmployeePayCode { get; set; }
        public Nullable<int> Reason { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<int> PayType { get; set; }
        public Nullable<bool> AutoPay { get; set; }
        public Nullable<decimal> Compensation { get; set; }
        public Nullable<int> CompensationFrequency { get; set; }
        public Nullable<decimal> HourlyRate2 { get; set; }
        public Nullable<decimal> HourlyRate3 { get; set; }
        public Nullable<int> PayFrequency { get; set; }
        public Nullable<double> StandardHours { get; set; }
        public Nullable<decimal> PayPerCheck { get; set; }
        public Nullable<decimal> HourlyEquivalent { get; set; }
        public Nullable<bool> Tipped { get; set; }
        public Nullable<int> PayStatus { get; set; }
        public Nullable<int> PayGrade { get; set; }
        public Nullable<int> PayCode { get; set; }
        public Nullable<System.DateTime> PayPeriodStartDate { get; set; }
        public Nullable<System.DateTime> PayPeriodEndDate { get; set; }
        public string PayrollEEId { get; set; }
        public Nullable<decimal> WeeklyAmount { get; set; }
        public Nullable<System.DateTime> FirstPayDate { get; set; }
        public Nullable<int> ShiftType { get; set; }
        public string ShiftGroup { get; set; }
        public string Premium { get; set; }
        public Nullable<int> JobAssignment { get; set; }
        public Nullable<int> ContractStatus { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> Column1 { get; set; }
    }
}
