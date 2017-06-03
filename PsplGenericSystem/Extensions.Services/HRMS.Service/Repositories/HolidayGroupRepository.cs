using System;
using System.Collections.Generic;
using System.Linq;

using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class HolidayGroupRepository :IHolidayGroupRepository
    {
        /// <summary>
        /// Returns All HolidayGroup Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayGroup> SelectAllHolidayGroupDetails(int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_HolidayGroupSelectAll_Result> lstHolidayGroupResult = hrmsEntity.usp_HolidayGroupSelectAll(CompanyId).ToList();
                var holidayGroupList = lstHolidayGroupResult.Select(holidayGroupObj => new HolidayGroup
                {
                    HolidayGroupId = holidayGroupObj.HolidayGroupId,
                    HolidayGroupCode = holidayGroupObj.HolidayGroupCode,
                    HolidayGroupName = holidayGroupObj.HolidayGroupName,
                    HolidayDescription = holidayGroupObj.HolidayDescription,
                    CompanyId = holidayGroupObj.CompanyId
                }).ToList();
                return holidayGroupList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                hrmsEntity.Dispose();
            }
        }


        /// <summary>
        /// Returns Selected HolidayGroup Details By HolidayGroupId and CompanyId
        /// </summary>
        /// <param name="HolidayGroupId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayGroup> SelectHolidayGroupDetail(int HolidayGroupId, int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_HolidayGroupSelect_Result> lstHolidayGroupResult = hrmsEntity.usp_HolidayGroupSelect(HolidayGroupId,CompanyId).ToList();
                var holidayGroupList = lstHolidayGroupResult.Select(holidayGroupObj => new HolidayGroup
                {
                    HolidayGroupId = holidayGroupObj.HolidayGroupId,
                    HolidayGroupCode = holidayGroupObj.HolidayGroupCode,
                    HolidayGroupName = holidayGroupObj.HolidayGroupName,
                    HolidayDescription = holidayGroupObj.HolidayDescription,
                    CompanyId = holidayGroupObj.CompanyId
                }).ToList();
                return holidayGroupList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                hrmsEntity.Dispose();
            }
        }


        /// <summary>
        /// Insert holidayGroup Information
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        public bool InsertHolidayGroup(HolidayGroup holidayGroupInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                //System.Data.Entity.Core.Objects.ObjectParameter errorobj = null;
                //var result = hrmsEntity.usp_HolidayGroupInsert(
                //    holidayGroupInfoobj.HolidayGroupName,
                //    holidayGroupInfoobj.HolidayDescription, 
                //    holidayGroupInfoobj.CompanyId);
                //return Convert.ToBoolean(result);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                hrmsEntity.Dispose();
            }
        }


        /// <summary>
        /// Update HolidayGroup Infomation
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        public bool UpdateHolidayGroup(HolidayGroup holidayGroupInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_HolidayGroupUpdate(
                    holidayGroupInfoobj.HolidayGroupId,
                    holidayGroupInfoobj.HolidayGroupName,
                    holidayGroupInfoobj.HolidayDescription,
                    holidayGroupInfoobj.CompanyId);
                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                hrmsEntity.Dispose();
            }
        }


        /// <summary>
        /// Delete HolidayGroup Detail by HolidayGroupId and CompanyId
        /// </summary>
        /// <param name="holidayGroupId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteHolidayGroupDetail(int holidayGroupId, int companyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_HolidayGroupDelete(holidayGroupId, companyId);
                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                hrmsEntity.Dispose();
            }
        }
    }
}
