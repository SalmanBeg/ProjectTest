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
    [MetadataType(typeof(EmployeeGoalMetaData))]
    public partial class EmployeeGoal
    {

    }
    public partial class EmployeeGoalMetaData
    {
        public EmployeeGoalMetaData()
        {

        }

        public int EmployeeGoalId { get; set; }
        public Nullable<System.Guid> AssignedTo { get; set; }
        public Nullable<System.Guid> AssignedBy { get; set; }
        public string Status { get; set; }
        [Display(Name="Goal Description")]
        public string GoalDescription { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string Indicator { get; set; }
        public double Value { get; set; }
        public Nullable<int> Reminder { get; set; }
        public Nullable<double> Incentive { get; set; }
        public bool Prorate { get; set; }
        public int CompanyId { get; set; }
        public bool Isrecurrenceschedule { get; set; }
        public int Recurrenceschedule { get; set; }
        public bool Exclude { get; set; }
        public bool IsExcludeSunday { get; set; }
        public bool IsExcludeSaturdaysunday { get; set; }
        public DateTime Time { get; set; }
        public Nullable<bool> IsOneTimeGoal { get; set; }
        public Nullable<bool> IsGoalIncentive { get; set; }
        public string ClientTimeZone { get; set; }
        public DateTime ClientDateTime { get; set; }
    }
}
