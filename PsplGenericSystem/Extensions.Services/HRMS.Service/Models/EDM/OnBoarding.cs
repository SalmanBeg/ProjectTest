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
    
    public partial class OnBoarding
    {
        public int OnBoardingId { get; set; }
        public System.Guid OnBoardingCode { get; set; }
        public int CompanyId { get; set; }
        public string OnBoardingName { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
