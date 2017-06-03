using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ReviewReviewerOtherEmployeeMetaData))]
    public partial class ReviewReviewerOtherEmployee
    {
        public string EmployeeName { get; set; }
    }

    public partial class ReviewReviewerOtherEmployeeMetaData
    {
        public int ReviewerOtherEmployeeId { get; set; }
        public Nullable<System.Guid> ReviewerOtherEmployeeCode { get; set; }
        public Nullable<int> ReviewReviewerId { get; set; }
        public string OtherEmployeeId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}
