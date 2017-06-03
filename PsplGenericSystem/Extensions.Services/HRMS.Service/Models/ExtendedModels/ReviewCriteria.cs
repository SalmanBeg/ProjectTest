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
    [MetadataType(typeof(ReviewCriteriaMetaData))]
    public partial class ReviewCriteria
    {
       
    }
    public partial class ReviewCriteriaMetaData
    {
        public int ReviewCriteriaId { get; set; }
        public Guid ReviewCriteriaCode { get; set; }
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Please Enter Criteria Type")]
        [Display(Name = "Type ")]
        public int CriteriaTypeId { get; set; }
        [Display(Name = "Job Title")]
        [Required(ErrorMessage="Job Title is Required")]
        public int JobTitleId { get; set; }
        public int PositionId { get; set; }
        
        [Display(Name = "Category ")]
        public int CategoryId { get; set; }
        public int Description { get; set; }
        [Display(Name = "Response Type")]
        public int ResponseTypeId { get; set; }
        public bool IsActive { get; set; }
        public int ScoreId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    

        



    }

}
