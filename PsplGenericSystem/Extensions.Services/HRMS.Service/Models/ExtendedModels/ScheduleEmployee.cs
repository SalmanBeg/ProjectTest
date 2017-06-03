using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ScheduleEmployeeMetaData))]
    public  partial class ScheduleEmployee
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int PayPeriodId { get; set; }
        public bool ScheduledChecked { get; set; }
        public int ScheduleCount { get; set; }
        public int? TempDepartmentId { get; set; }
        public int? TempJobId { get; set; }
        public int? TempProjectId { get; set; }
    }

    public  partial class ScheduleEmployeeMetaData
    {
        public ScheduleEmployeeMetaData()
        { 
        }
        public int ScheduleEmployeeId { get; set; }
        [Display(Name = ("Employee"))]
        public int UserId { get; set; }
        [Display(Name = ("Date"))]
        public DateTime ScheduleDate { get; set; }

        [Display(Name = ("Start Time"))]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        public DateTime? StartTime { get; set; }
        [Display(Name = ("End Time"))]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "Lunch Minutes")]
        public double? LunchMinutes { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        [Display(Name = "Job")]
        public int? JobId { get; set; }
        [Display(Name = "Project")]
        public int? ProjectId { get; set; }
        public Boolean IsScheduleActive { get; set; }
        public int CompanyId { get; set; }
    }
}
