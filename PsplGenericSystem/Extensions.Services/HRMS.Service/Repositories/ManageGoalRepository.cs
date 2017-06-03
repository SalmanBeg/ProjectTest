using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class ManageGoalRepository:IManageGoalRepository
    {
        // public bool AddManageGoal(EmployeeGoal employeeGoalobj)
        //{
        //     try
        //     {
        //         using (var hrmsEntity = new HRMSEntities1())
        //         {
        //             var result = hrmsEntity.usp_EmployeeGoalInsert(employeeGoalobj.AssignedTo, employeeGoalobj.AssignedBy, employeeGoalobj.Status, employeeGoalobj.GoalDescription
        //                 , employeeGoalobj.StartDate, employeeGoalobj.EndDate, employeeGoalobj.Indicator, employeeGoalobj.Value, employeeGoalobj.Reminder, employeeGoalobj.Incentive
        //                 , employeeGoalobj.Prorate, employeeGoalobj.CompanyId, employeeGoalobj.Recurrenceschedule, employeeGoalobj.IsExcludeSunday
        //                 , employeeGoalobj.IsExcludeSaturdaysunday, employeeGoalobj.Time, employeeGoalobj.IsOneTimeGoal, employeeGoalobj.IsGoalIncentive, employeeGoalobj.ClientDateTime
        //                 , employeeGoalobj.ClientTimeZone);
        //             return result.Count > 0;
        //         }
        //     }
        //     catch(Exception)
        //     {
        //         throw;
        //     }
        //}
    }
}
