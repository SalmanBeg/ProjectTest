using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class EmployeeGoalFormModel
    {
        public EmployeeGoalFormModel()
        {

        }
        public Employee Employee { get; set; }
        public EmployeeGoal EmployeeGoal { get; set; }
        public EmployeeGoalRemainder EmployeeGoalRemainder { get; set; }
        public GoalRecurrence GoalRecurrence { get; set; }
        public NTFGoal NTFGoal { get; set; }
    }
}