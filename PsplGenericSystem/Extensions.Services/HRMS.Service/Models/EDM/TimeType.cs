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
    
    public partial class TimeType
    {
        public TimeType()
        {
            this.PayType = new HashSet<PayType>();
        }
    
        public int TimeTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Nullable<bool> Status { get; set; }
    
        public virtual ICollection<PayType> PayType { get; set; }
    }
}
