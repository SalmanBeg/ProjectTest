using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.ExtendedModels
{
    [MetadataType(typeof(EmployeeGoalRemainderMetaData))]
    public partial class EmployeeGoalRemainder
    {
    }
    public partial class EmployeeGoalRemainderMetaData
    {
        public EmployeeGoalRemainderMetaData()
        {

        }
        public int EmployeeGoalRemainderId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> SentOn { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> GoalId { get; set; }
        public Nullable<int> RecurrenceId { get; set; }
        public string SentStatus { get; set; }
    }
}
