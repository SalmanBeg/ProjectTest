using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace HRMS.Service.Models.EDM
{
    public class RevieewCriteria
    {
        public int? ReviewCriteriaId { get; set; }
        public int ReviewCriteriaTypeId { get; set; }
        //[Display(Name = "Type ")]
        public int? CriteriaTypeId { get; set; }
        //[Display(Name = "Type")]
        public string CategoryType { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitleId { get; set; }
        [Display(Name = "Description")]
        public string Question { get; set; }
        public string PositionId { get; set; }
        [Display(Name = "Category")]
        public string CategoryId { get; set; }
        public string Description { get; set; }
        public string ResponseId { get; set; }
        public string ResponseType { get; set; }
        public int? ScoreId { get; set; }        
        public string Answers { get; set; }
        public int? AnswerId { get; set; }

        public int ItemValue { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Response Type")]
        public int? ResponseTypeId { get; set; }


        public int List { get; set; }
        public int Text { get; set; }
        public int Value { get; set; }

        [Display(Name = " Type")]
        public string CriteriaType { get; set; }

        #region drop down list
        //[Display(Name = "Type")]
        public string CategoryTypeList { get; set; }
        #endregion

    }
}
