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
    
    public partial class ReviewCriteria
    {
        public ReviewCriteria()
        {
            this.ReviewReviewerCriterias = new HashSet<ReviewReviewerCriteria>();
        }
    
        public int ReviewCriteriaId { get; set; }
        public Nullable<System.Guid> ReviewCriteriaCode { get; set; }
        public int CompanyId { get; set; }
        public Nullable<int> CriteriaTypeId { get; set; }
        public Nullable<int> JobTitleId { get; set; }
        public Nullable<int> PositionId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Description { get; set; }
        public Nullable<int> ResponseTypeId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> ScoreId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    
        public virtual ICollection<ReviewReviewerCriteria> ReviewReviewerCriterias { get; set; }
    }
}
