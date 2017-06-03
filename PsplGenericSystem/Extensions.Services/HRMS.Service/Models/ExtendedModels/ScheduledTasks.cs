using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ScheduledTasksMetaData))]
    public partial class ScheduledTasks
    {
    }
    public partial class ScheduledTasksMetaData
    {
        public ScheduledTasksMetaData()
        {

        }
        public int ScheduledTaskId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BackgroundColor { get; set; }
        public string BorderColor { get; set; }
        public bool AllDay { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
