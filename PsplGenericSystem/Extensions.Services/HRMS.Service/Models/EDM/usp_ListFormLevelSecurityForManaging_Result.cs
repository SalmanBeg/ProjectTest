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
    
    public partial class usp_ListFormLevelSecurityForManaging_Result
    {
        public int FormId { get; set; }
        public string FormName { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public string DisplayName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string RouteAttribute { get; set; }
        public int ModuleId { get; set; }
        public Nullable<bool> IsVisible { get; set; }
        public Nullable<bool> IsEditable { get; set; }
        public Nullable<int> RoleId { get; set; }
    }
}