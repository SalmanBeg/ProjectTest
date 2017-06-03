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
    [MetadataType(typeof(TrainingClassScheduleDateMetaData))]
    public partial class  TrainingClassScheduleDate
    {

    }
    public partial class TrainingClassScheduleDateMetaData
    {
        public int TrainingClassScheduleDateId { get; set; }    
        public int CompanyId { get; set; }
        [Display(Name = "Maximum Class Size")]
        public string MaximumClassSize { get; set; }
        public string Location { get; set; }
        [Display(Name = "Schedule Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Schedule End Date")]
        public DateTime? EndDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }

}
