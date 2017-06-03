using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using HRMS.Service;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ReviewReviewerCriteriaMetaData))]
    public partial class ReviewReviewerCriteria
    {
    }
    public partial class ReviewReviewerCriteriaMetaData
    {
        public int ReviewReviewerCriteriaId { get; set; }
        public Guid ReviewReviewerCriteriaCode { get; set; }
        public int ReviewReviewerId { get; set; }
        public int ReviewCriteriaId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
