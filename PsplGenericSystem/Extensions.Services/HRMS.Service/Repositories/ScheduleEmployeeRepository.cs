using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class ScheduleEmployeeRepository : IScheduleEmployeeRepository
    {
        #region Load Company Employees

        /// <summary>
        /// Returns all the Employees By  PayPeriodId  and CompanyId
        /// </summary>
        /// <param name="payPeriodId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<ScheduleEmployee> SelectAllEmployeesByPayPeriodIdAndCompanyId(int payPeriodId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstScheduleEmployeesResult = hrmsEntity.usp_SelectAllEmployeesByPayPeriodIdAndCompanyIdForSchedule(payPeriodId, companyId).ToList();

                    var scheduleEmployeesList = lstScheduleEmployeesResult.Select(scheduleEmployeesObj => new ScheduleEmployee
                    {
                        UserId = scheduleEmployeesObj.UserId,
                        FirstName = scheduleEmployeesObj.FirstName,
                        LastName = scheduleEmployeesObj.LastName,
                        PayPeriodId = scheduleEmployeesObj.PayPeriodId.GetValueOrDefault(),
                        ScheduleCount = scheduleEmployeesObj.ScheduleCount.GetValueOrDefault()
                    }).ToList();
                    return scheduleEmployeesList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ScheduledEmployee (Edit Schedule)

        /// <summary>
        /// Returns Selected ScheduleEmployee Details By UserId and CompanyId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<ScheduleEmployee> SelectScheduleEmployeeDetailsByScheduleUserId(int userId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstScheduleEmployeesResult = hrmsEntity.usp_ScheduleEmployeeSelect(userId, companyId).ToList();
                    var scheduleEmployeesList = lstScheduleEmployeesResult.Select(scheduleEmployeesObj => new ScheduleEmployee
                    {
                        ScheduleEmployeeId = scheduleEmployeesObj.ScheduleEmployeeId,
                        UserId = scheduleEmployeesObj.UserId,
                        ScheduleDate = scheduleEmployeesObj.ScheduleDate,
                        StartTime = scheduleEmployeesObj.StartTime,
                        EndTime = scheduleEmployeesObj.EndTime,
                        LunchMinutes = scheduleEmployeesObj.LunchMinutes,
                        DepartmentId = scheduleEmployeesObj.DepartmentId,
                        JobId = scheduleEmployeesObj.JobId,
                        ProjectId = scheduleEmployeesObj.ProjectId,
                        // IsScheduleActive = scheduleEmployeesObj.IsScheduleActive,
                        CompanyId = scheduleEmployeesObj.CompanyId
                    }).ToList();
                    return scheduleEmployeesList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Insert ScheduleEmployee Information
        /// </summary>
        /// <param name="scheduleEmployeeInfoobj"></param>
        /// <returns></returns>
        public bool InsertScheduleEmployee(ScheduleEmployee scheduleEmployeeInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ScheduleEmployeeInsert(
                        scheduleEmployeeInfoobj.UserId,
                        scheduleEmployeeInfoobj.ScheduleDate,
                        scheduleEmployeeInfoobj.StartTime,
                        scheduleEmployeeInfoobj.EndTime,
                        scheduleEmployeeInfoobj.LunchMinutes,
                        scheduleEmployeeInfoobj.DepartmentId,
                        scheduleEmployeeInfoobj.JobId,
                        scheduleEmployeeInfoobj.ProjectId,
                        scheduleEmployeeInfoobj.IsScheduleActive,
                        scheduleEmployeeInfoobj.CompanyId
                        );
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Update ScheduleEmployee Infomation
        /// </summary>
        /// <param name="scheduleEmployeeInfoobj"></param>
        /// <returns></returns>
        public bool UpdateScheduleEmployee(ScheduleEmployee scheduleEmployeeInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_ScheduleEmployeeUpdate(
                        scheduleEmployeeInfoobj.ScheduleEmployeeId,
                        scheduleEmployeeInfoobj.UserId,
                        scheduleEmployeeInfoobj.ScheduleDate,
                        scheduleEmployeeInfoobj.StartTime,
                        scheduleEmployeeInfoobj.EndTime,
                        scheduleEmployeeInfoobj.LunchMinutes,
                        scheduleEmployeeInfoobj.DepartmentId,
                        scheduleEmployeeInfoobj.JobId,
                        scheduleEmployeeInfoobj.ProjectId,
                        scheduleEmployeeInfoobj.IsScheduleActive,
                        scheduleEmployeeInfoobj.CompanyId
                        );
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Delete ScheduleEmployee Detail by UserId and CompanyId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteScheduleEmployee(int userId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_ScheduleEmployeeDelete(userId, companyId);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
