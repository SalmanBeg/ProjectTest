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
    [MetadataType(typeof(RevieweeMetaData))]
    public partial class Reviewee
    {
        public String ReviewName { get; set; }

    }
    public partial class RevieweeMetaData
    {
        public Review Review { get; set; }

        public int RevieweeId { get; set; }
        public Guid RevieweeCode { get; set; }
        public int CompanyId { get; set; }
        public string Type { get; set; }
        public int ReviewId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public int JobTitleId { get; set; }
        public int EmployeeId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
