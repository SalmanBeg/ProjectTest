using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class RatingScaleFormModel
    {
        public RatingScaleFormModel()
        {
            ReviewScoreContent = new ReviewScoreContent();
            ReviewScoreDescription = new ReviewScoreDescription();
            lstReviewScoreContent = new List<ReviewScoreContent>();

        }
        public ReviewScore ReviewScore { get; set; }
        public ReviewScoreContent ReviewScoreContent { get; set; }
        public ReviewScoreDescription ReviewScoreDescription { get; set; }

        public List<ReviewScoreContent> lstReviewScoreContent { get; set; }

    }
}