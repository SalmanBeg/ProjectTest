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
    [MetadataType(typeof(ReviewScoreMetaData))]
    public partial class ReviewScore
    {
        [Display(Name = "Rating Scale")]
        public string Description { get; set; }
        [Display(Name = "Visible to Child Companies")]
        public bool IsChildCompany { get; set; }
        public string Item { get; set; }
    }
    public partial class ReviewScoreMetaData
    {
        public Review Review { get; set; }

        public int ReviewScoreId { get; set; }
        public Guid ReviewScoreCode { get; set; }
        public double Question { get; set; }
        public double Accountability { get; set; }
        public double Competency { get; set; }
        public double Goal { get; set; }
        public int ReviewId { get; set; }
        public int CompanyId { get; set; }
        public bool WeightedAverage { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
