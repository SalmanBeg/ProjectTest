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
    
    public partial class usp_ShowAllEmployeesPendingListByCompanyId_Result
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.Guid UserCode { get; set; }
        public Nullable<bool> IsSubmitted { get; set; }
        public string CreatedBy { get; set; }
        public int CompanyId { get; set; }
    }
}
