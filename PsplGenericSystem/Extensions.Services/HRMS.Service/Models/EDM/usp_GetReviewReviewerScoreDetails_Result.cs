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
    
    public partial class usp_GetReviewReviewerScoreDetails_Result
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Nullable<int> ReviewReviewerEmployeeId { get; set; }
        public Nullable<int> ReviewCriteriaId { get; set; }
        public string Answers { get; set; }
        public Nullable<int> ReviewReviewerId { get; set; }
    }
}
