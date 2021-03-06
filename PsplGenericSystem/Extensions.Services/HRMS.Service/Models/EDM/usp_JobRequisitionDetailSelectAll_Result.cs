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
    
    public partial class usp_JobRequisitionDetailSelectAll_Result
    {
        public int JobRequisitionID { get; set; }
        public int PositionID { get; set; }
        public int CompanyID { get; set; }
        public Nullable<int> EmploymentType { get; set; }
        public string City { get; set; }
        public string BudgetedPosition { get; set; }
        public string NumberofOpenings { get; set; }
        public string BudgetFTE { get; set; }
        public string NameofEmployeeReplaced { get; set; }
        public string ReasonClosed { get; set; }
        public int RecruitingCost { get; set; }
        public string Requisition { get; set; }
        public string State { get; set; }
        public string RelocationBudget { get; set; }
        public string PositionsFilled { get; set; }
        public string Status { get; set; }
        public Nullable<int> SalaryRange { get; set; }
        public Nullable<int> To { get; set; }
        public string RequisitionCheckListName { get; set; }
        public string Recruiter { get; set; }
        public Nullable<int> Category { get; set; }
        public Nullable<int> Department { get; set; }
        public Nullable<int> Budget { get; set; }
        public Nullable<System.DateTime> ValidFrom { get; set; }
        public Nullable<System.DateTime> ValidTo { get; set; }
        public Nullable<System.DateTime> DateOpened { get; set; }
        public Nullable<System.DateTime> DateClosed { get; set; }
        public string Interviewers { get; set; }
        public string HiringManager { get; set; }
    }
}
