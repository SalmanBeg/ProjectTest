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
    
    public partial class usp_EmployeeDirectDepositSelectById_Result
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int EmployeeDirectDepositId { get; set; }
        public System.Guid EmployeeDirectDepositCode { get; set; }
        public Nullable<int> AccountType { get; set; }
        public string AccountTypeName { get; set; }
        public string TransitorABANumber { get; set; }
        public string AccountNumber { get; set; }
        public string Amount { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
