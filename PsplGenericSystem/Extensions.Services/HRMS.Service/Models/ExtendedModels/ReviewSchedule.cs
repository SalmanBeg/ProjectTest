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
    [MetadataType(typeof(ReviewScheduleMetaData))]
    public partial class ReviewSchedule
    {
    }
    public partial class ReviewScheduleMetaData
    {
        public int ReviewScheduleId { get; set; }
        public Guid ReviewScheduleCode { get; set; }
        [Display(Name = "Schedule Value")]
        public int ScheduleValue { get; set; }
        public int CompanyId { get; set; }
        public int IntervalType { get; set; }
        public string FromSchedule { get; set; }
        public DateTime FromDate { get; set; }
        public int DaysToComplete { get; set; }
        public int ReviewId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}
