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
    
    public partial class usp_SelectUsersByUsername_Result
    {
        public int UserId { get; set; }
        public System.Guid UserCode { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
    }
}
