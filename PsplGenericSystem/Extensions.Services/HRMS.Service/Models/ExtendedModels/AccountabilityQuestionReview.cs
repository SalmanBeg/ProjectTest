using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using HRMS.Service.Models.EDM;
using System.Threading.Tasks;

namespace HRMS.Service.Models.ExtendedModels
{
    [MetadataType(typeof(AccountabilityQuestionReviewMetaData))]
    public partial class AccountabilityQuestionReview
    {
    }
    public partial class AccountabilityQuestionReviewMetaData
    {
        public ReviewCriteria ReviewCriteria { get; set; }
        public ReviewReviewerScoreDetails ReviewReviewerScoreDetails { get; set; }
        public ReviewScore ReviewScore { get; set; }
    }
}
