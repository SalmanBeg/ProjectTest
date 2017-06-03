using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;


namespace HRMS.Service.Interfaces
{
    public interface IScheduleEmployeeRepository
    {
        /// <summary>
        /// Returns all the Employees By  PayPeriodId  and CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ScheduleEmployee> SelectAllEmployeesByPayPeriodIdAndCompanyId(int payPeriodId, int companyId);


        /// <summary>
        /// Returns All ScheduleEmployee Details By CompanyID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //List<ScheduleEmployee> SelectAllScheduleEmployeeDetails(int CompanyId);


        /// <summary>
        /// Returns Selected ScheduleEmployee Details By UserId and CompanyId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ScheduleEmployee> SelectScheduleEmployeeDetailsByScheduleUserId(int userId, int companyId);


        /// <summary>
        /// Insert ScheduleEmployee Information
        /// </summary>
        /// <param name="scheduleEmployeeInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertScheduleEmployee(ScheduleEmployee scheduleEmployeeInfoobj);


        /// <summary>
        /// Update ScheduleEmployee Infomation
        /// </summary>
        /// <param name="scheduleEmployeeInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateScheduleEmployee(ScheduleEmployee scheduleEmployeeInfoobj);


        /// <summary>
        /// Delete ScheduleEmployee Detail by UserId and CompanyId
        /// </summary>
        /// <param name="ScheduleEmployeeId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteScheduleEmployee(int userId, int companyId);
    }
}
