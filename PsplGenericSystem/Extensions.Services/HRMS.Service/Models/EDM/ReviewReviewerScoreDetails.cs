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
    
    public partial class ReviewReviewerScoreDetails
    {
        public int ReviewReviewerScoreId { get; set; }
        public int CompanyId { get; set; }
        public Nullable<int> ReviewReviewerEmployeeId { get; set; }
        public Nullable<int> ReviewCriteriaId { get; set; }
        public string Answers { get; set; }
        public Nullable<int> ReviewReviewerId { get; set; }
    }
}
