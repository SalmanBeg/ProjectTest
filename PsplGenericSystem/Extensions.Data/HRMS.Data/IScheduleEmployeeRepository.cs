using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IScheduleEmployeeRepository
    {
        /// <summary>
        /// Returns all the Employees By  PayPeriodId  and CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        List<ScheduleEmployeeInfo> SelectAllEmployeesByPayPeriodIdAndCompanyId(int PayPeriodId, int companyId);
        

        /// <summary>
        /// Returns All ScheduleEmployee Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        List<ScheduleEmployeeInfo> SelectAllScheduleEmployeeDetails(int CompanyId);



        /// <summary>
        /// Returns Selected ScheduleEmployee Details By UserId and CompanyId
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        List<ScheduleEmployeeInfo> SelectScheduleEmployeeDetailsByScheduleUserId(int UserId, int CompanyId);



        /// <summary>
        /// Insert ScheduleEmployee Information
        /// </summary>
        /// <param name="scheduleEmployeeInfoobj"></param>
        /// <returns></returns>
        bool InsertScheduleEmployee(ScheduleEmployeeInfo scheduleEmployeeInfoobj);

        /// <summary>
        /// Update ScheduleEmployee Infomation
        /// </summary>
        /// <param name="scheduleEmployeeInfoobj"></param>
        /// <returns></returns>
        bool UpdateScheduleEmployee(ScheduleEmployeeInfo scheduleEmployeeInfoobj);

        /// <summary>
        /// Delete ScheduleEmployee Detail by UserId and CompanyId
        /// </summary>
        /// <param name="ScheduleEmployeeId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        bool DeleteScheduleEmployee(int UserId, int CompanyId);
    }
}
