using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Interfaces
{
    public  interface ITimesheetPolicyRepository
    {

       /// <summary>
       /// Returns All Employees Details By CompanyId
       /// </summary>
       /// <param name="CompanyId"></param>
       /// <returns></returns>
        List<TimesheetPolicy> SelectAllEmployeeDetails(int CompanyId);

       /// <summary>
       /// Insert TimesheetPolicy Information
       /// </summary>
       /// <param name="holidayInfoobj"></param>
       /// <returns></returns>
        bool InsertTimesheetPolicy(TimesheetPolicy timesheetPolicyInfoobj);

       /// <summary>
       /// Update TimesheetPolicy Information
       /// </summary>
       /// <param name="holidayInfoobj"></param>
       /// <returns></returns>
        bool UpdateTimesheetPolicy(TimesheetPolicy timesheetPolicyInfoobj);

       /// <summary>
       /// Returns Selected TimesheetPolicy Details By userId and CompanyId
       /// </summary>
       /// <param name="UserId"></param>
       /// <param name="CompanyId"></param>
       /// <returns></returns>
        TimesheetPolicy SelectTimesheetPolicy(int UserId, int CompanyId);
    }
}
