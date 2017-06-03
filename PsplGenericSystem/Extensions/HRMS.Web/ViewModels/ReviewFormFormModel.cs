using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;
namespace HRMS.Web.ViewModels
{
    public class ReviewFormFormModel
    {
        public ReviewFormFormModel()
        {
            ItemValueList = new List<ReviewScoreDescription>();
            

        }
        public ReviewerEmployee ReviewerEmployee { get; set; }
        public RevieewCriteria RevieewCriteria { get; set; }
        public ReviewScore ReviewScore { get; set; }
        public ReviewScoreContent ReviewScoreContent { get; set; }
        public ReviewReviewerScoreDetails ReviewReviewerScoreDetails { get; set; }
        public Review Review { get; set; }
        public Reviewer Reviewer { get; set; }
        public ReviewCriteria ReviewCriteria { get; set; }
        public ReviewResponseType ReviewResponseType { get; set; }
        public List<RevieewCriteria> lstReviewCriteria { get; set; }
        public List<ReviewScoreDescription> ItemValueList { get; set; }
        public List<ReviewScoreContent> ReviewScoreContentList { get; set; }
    }
}