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
    using System.Collections.Generic;
    
    public partial class FormLevelSecurity
    {
        public int FormLevelSecurityId { get; set; }
        public System.Guid FormLevelSecurityCode { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
        public int FormId { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEditable { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}