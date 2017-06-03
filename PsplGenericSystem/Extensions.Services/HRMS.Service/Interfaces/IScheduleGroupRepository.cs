using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IScheduleGroupRepository
    {
        /// <summary>
        /// Returns All ScheduleGroup Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ScheduleGroup> SelectAllScheduleGroupDetails(int CompanyId);

        /// <summary>
        /// Returns Selected ScheduleGroup Details By ScheduleGroupId and CompanyId
        /// </summary>
        /// <param name="SheduleGroupId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ScheduleGroup> SelectScheduleGroupDetailsByScheduleGroupId(int SheduleGroupId, int CompanyId);

        /// <summary>
        /// Insert SheduleGroup Information
        /// </summary>
        /// <param name="scheduleGroupInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertSheduleGroup(ScheduleGroup scheduleGroupInfoobj);

        /// <summary>
        /// Update ScheduleGroup Infomation
        /// </summary>
        /// <param name="scheduleGroupInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateScheduleGroup(ScheduleGroup scheduleGroupInfoobj);

        /// <summary>
        /// Delete ScheduleGroup Detail by ScheduleGroupId and CompanyId
        /// </summary>
        /// <param name="scheduleGroupId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteScheduleGroupDetail(int scheduleGroupId, int companyId);
    }
}
