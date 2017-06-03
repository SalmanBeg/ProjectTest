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
    
    public partial class EmployeeAsset
    {
        public int EmployeeAssetId { get; set; }
        public Nullable<System.Guid> EmployeeAssetCode { get; set; }
        public string Asset { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public Nullable<decimal> AssetCost { get; set; }
        public Nullable<System.DateTime> PurchasedDate { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<System.DateTime> OutOn { get; set; }
        public Nullable<System.DateTime> DueBack { get; set; }
        public Nullable<System.DateTime> Returned { get; set; }
        public string Comment { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}
