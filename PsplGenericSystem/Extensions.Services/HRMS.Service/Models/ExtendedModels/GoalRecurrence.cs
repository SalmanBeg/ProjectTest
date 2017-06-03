using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.ExtendedModels
{
    [MetadataType(typeof(GoalRecurrenceMetaData))]
    public partial class GoalRecurrence
    {
    }
    public partial class GoalRecurrenceMetaData
    {
        public GoalRecurrenceMetaData()
        {

        }
        public int GoalRecurrenceId { get; set; }
        public int EmployeeGoalId { get; set; }
        public string Status { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<double> Incentive { get; set; }

    }
}
