using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class ReviewScoreFormModel
    {
        public ReviewScoreFormModel()
        {
            ReviewScoreContent = new ReviewScoreContent();
            ReviewScoreDescription = new ReviewScoreDescription();


        }

        public ReviewScoreContent ReviewScoreContent { get; set; }
        public ReviewScoreDescription ReviewScoreDescription { get; set; }
    }
}