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
    [MetadataType(typeof(ReviewScoreDescriptionMetaData))]
    public partial class ReviewScoreDescription
    {
    }
    public partial class ReviewScoreDescriptionMetaData
    {
        public int ReviewScoreDescriptionId { get; set; }
        public Guid ReviewScoreDescriptionCode { get; set; }
        [Display(Name = "Rating Scale")]
        [Required(ErrorMessage = "Rating Scale Is Required")]
        public string Description { get; set; }
        [Display(Name = "Visible to Child Companies")]
        public bool IsChildCompany { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
