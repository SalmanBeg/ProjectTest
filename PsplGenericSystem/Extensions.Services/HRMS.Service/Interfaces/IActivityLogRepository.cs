using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;
namespace HRMS.Service.Interfaces
{
    public interface IActivityLogRepository
    {
        /// <summary>
        /// Logging activities for executable methods in the application
        /// </summary>
        /// <param name="activityLogobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool AddActivityLog(ActivityLog activityLogobj);
        /// <summary>
        /// Retrieve activity logs for company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ActivityLog> SelectActivityLogByCompanyId(int companyId);
        /// <summary>
        /// Soft delete activities
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteActivityLog(int activityId, int companyId);
    }
}
