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
    
    public partial class usp_SelectEmployeesByRoleId_Result
    {
        public int UserID { get; set; }
        public System.Guid UserCode { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Nullable<int> EmploymentStatus { get; set; }
    }
}
