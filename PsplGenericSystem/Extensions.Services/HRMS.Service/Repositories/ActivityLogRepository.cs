using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        public bool AddActivityLog(ActivityLog activityLogobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ActivityLogInsert(activityLogobj.CompanyId, activityLogobj.Activity, activityLogobj.ActivityDate, activityLogobj.IsActive
                               , activityLogobj.CreatedOn);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<ActivityLog> SelectActivityLogByCompanyId(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_ActivityLogSelectByCompanyId_Result> lstActivityLog = hrmsEntity.usp_ActivityLogSelectByCompanyId(companyId).ToList();
                    var activitylogList = lstActivityLog.Select(activityLogObj => new ActivityLog
                   {
                       ActivityId = activityLogObj.ActivityId,
                       CompanyId = activityLogObj.CompanyId,
                       Activity = activityLogObj.Activity,
                       ActivityDate = activityLogObj.ActivityDate,
                       IsActive = activityLogObj.IsActive,
                       CreatedOn = activityLogObj.CreatedOn
                   }).ToList();
                    return activitylogList;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool DeleteActivityLog(int activityId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstActivityLogResult = hrmsEntity.usp_ActivityLogDelete(activityId, companyId);
                    return lstActivityLogResult > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
