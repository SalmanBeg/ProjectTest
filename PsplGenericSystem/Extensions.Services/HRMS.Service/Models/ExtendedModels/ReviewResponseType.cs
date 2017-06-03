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
    [MetadataType(typeof(ReviewResponseTypeMetaData))]
    public partial class ReviewResponseType
    {
    }
    public partial class ReviewResponseTypeMetaData
    {
        [Display(Name = "Response Type")]
        [Required(ErrorMessage="Response Type Is Required")]
        public int ReviewResponseTypeId { get; set; }
        public Guid ReviewResponseCode { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
