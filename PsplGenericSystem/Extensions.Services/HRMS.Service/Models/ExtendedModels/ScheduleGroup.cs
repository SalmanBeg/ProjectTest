using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ScheduleGroupMetaData))]
    public  partial class ScheduleGroup
    {

    }

    public partial class ScheduleGroupMetaData
    {
        public ScheduleGroupMetaData()
        { }

        public int ScheduleGroupId { get; set; }
        public Guid ScheduleGroupCode { get; set; }
        [Display(Name = "Schedule Group Name")]
        public string ScheduleGroupName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
