using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class ScheduleGroupRepository : IScheduleGroupRepository
    {
        /// <summary>
        /// Returns All ScheduleGroup Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<ScheduleGroup> SelectAllScheduleGroupDetails(int CompanyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_ScheduleGroupSelectAll_Result> lstScheduleGroupResult = hrmsEntity.usp_ScheduleGroupSelectAll(CompanyId).ToList();

                    var scheduleGroupList = lstScheduleGroupResult.Select(scheduleGroupObj => new ScheduleGroup
                    {
                        ScheduleGroupId = scheduleGroupObj.ScheduleGroupId,
                        ScheduleGroupCode = scheduleGroupObj.ScheduleGroupCode,
                        ScheduleGroupName = scheduleGroupObj.ScheduleGroupName,
                        Description = scheduleGroupObj.Description,
                        CompanyId = scheduleGroupObj.CompanyId
                    }).ToList();
                    return scheduleGroupList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Returns Selected ScheduleGroup Details By ScheduleGroupId and CompanyId
        /// </summary>
        /// <param name="SheduleGroupId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<ScheduleGroup> SelectScheduleGroupDetailsByScheduleGroupId(int ScheduleGroupId, int CompanyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_ScheduleGroupSelect_Result> lstScheduleGroupResult = hrmsEntity.usp_ScheduleGroupSelect(ScheduleGroupId, CompanyId).ToList();

                    var scheduleGroupList = lstScheduleGroupResult.Select(scheduleGroupObj => new ScheduleGroup
                    {
                        ScheduleGroupId = scheduleGroupObj.ScheduleGroupId,
                        ScheduleGroupCode = scheduleGroupObj.ScheduleGroupCode,
                        ScheduleGroupName = scheduleGroupObj.ScheduleGroupName,
                        Description = scheduleGroupObj.Description,
                        CompanyId = scheduleGroupObj.CompanyId
                    }).ToList();
                    return scheduleGroupList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Insert SheduleGroup Information
        /// </summary>
        /// <param name="scheduleGroupInfoobj"></param>
        /// <returns></returns>
        public bool InsertSheduleGroup(ScheduleGroup scheduleGroupInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_ScheduleGroupInsert(
                        //scheduleGroupInfoobj.ScheduleGroupCode,
                        scheduleGroupInfoobj.ScheduleGroupName,
                        scheduleGroupInfoobj.Description,
                        scheduleGroupInfoobj.CompanyId
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
        /// Update ScheduleGroup Infomation
        /// </summary>
        /// <param name="scheduleGroupInfoobj"></param>
        /// <returns></returns>
        public bool UpdateScheduleGroup(ScheduleGroup scheduleGroupInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_ScheduleGroupUpdate(
                        scheduleGroupInfoobj.ScheduleGroupId,
                        //scheduleGroupInfoobj.ScheduleGroupCode,
                        scheduleGroupInfoobj.ScheduleGroupName,
                        scheduleGroupInfoobj.Description,
                        scheduleGroupInfoobj.CompanyId
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
        /// Deletes ScheduleGroup Detail by ScheduleGroupId and CompanyId
        /// </summary>
        /// <param name="scheduleGroupId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteScheduleGroupDetail(int scheduleGroupId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ScheduleGroupDelete(scheduleGroupId, companyId);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
