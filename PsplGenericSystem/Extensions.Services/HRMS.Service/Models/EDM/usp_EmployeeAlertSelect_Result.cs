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
    
    public partial class usp_EmployeeAlertSelect_Result
    {
        public int AlertTemplateId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string AlertTemplateName { get; set; }
        public string AlertTemplateSubject { get; set; }
        public string AlertTemplateBody { get; set; }
        public Nullable<int> ScheduleValue { get; set; }
        public Nullable<int> CriteriaValue { get; set; }
        public Nullable<int> CriteriaDuration { get; set; }
        public Nullable<int> CriteriaTiming { get; set; }
        public Nullable<int> CriteriaCondition { get; set; }
        public Nullable<int> CountToSend { get; set; }
        public Nullable<System.DateTime> CustomDate { get; set; }
        public Nullable<int> SendVia { get; set; }
        public string EmployeeEmail { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
