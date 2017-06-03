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
    [MetadataType(typeof(ReviewCriteriaCategoryMetaData))]
    public partial  class ReviewCriteriaCategory
    {
    }
    public partial class ReviewCriteriaCategoryMetaData
    {
        public int ReviewCriteriaCategoryId { get; set; }
        public Guid ReviewCriteriaCategoryCode { get; set; }
        public string Code { get; set; }
        public string CategoryDesc { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
