using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;
namespace HRMS.Web.ViewModels
{
    public class ReviewCriteriaFormModel
    {
        public ReviewCriteriaFormModel()
        {
            JobTitleList = new List<LookUpDataEntity>();
            CategoryList = new List<RevieewCriteria>();
            //DescriptionList = new List<LookUpDataEntity>();
            ItemValueList = new List<ReviewScoreDescription>();

        }
        public ReviewCriteria ReviewCriteria { get; set; }
        public RevieewCriteria RevieewCriteria { get; set; }
        public ReviewScore ReviewScore { get; set; }
        public ReviewScoreContent ReviewScoreContent { get; set; }
        public ReviewResponseType ReviewResponseType { get; set; }
        public List<LookUpDataEntity> JobTitleList { get; set; }
        public List<RevieewCriteria> CategoryList { get; set; }
        //public List<LookUpDataEntity> DescriptionList { get; set; }
        public List<ReviewScoreDescription> ItemValueList { get; set; }  

    }
}