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
    [MetadataType(typeof(ReviewScoreContentMetaData))]
    public partial class ReviewScoreContent
    {
        [Display(Name = "Rating Scale")]
        [Required(ErrorMessage = "Rating Scale is Required")]
        public int ReviewScoreId { get; set; }
        public List<ReviewScoreContent> ReviewScoreContentList { get; set; }
    }
    public partial class ReviewScoreContentMetaData
    {
        
        public int ReviewScoreContentId { get; set; }
        public Guid ReviewScoreContentcode { get; set; }
        [Display(Name = "List Name")]
        [Required(ErrorMessage = "List Name is Required")]
        public string ItemName { get; set; }
        [Display(Name = "List Value")]
        [Required(ErrorMessage = "List Value is Required")]
        public float ItemValue { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
