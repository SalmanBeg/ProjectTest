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
    
    public partial class ApplicantEducation
    {
        public int ApplicantEducationId { get; set; }
        public string University { get; set; }
        public string Degree { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string Activities { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        public Nullable<int> JobId { get; set; }
    }
}
