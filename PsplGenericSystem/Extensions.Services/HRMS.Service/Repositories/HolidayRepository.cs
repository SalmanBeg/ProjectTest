using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class HolidayRepository: IHolidayRepository
    {
        /// <summary>
        /// Returns All Holiday Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<Holiday> SelectAllHolidayDetails(int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_HolidaysSelectAll_Result> lstHolidaysResult = hrmsEntity.usp_HolidaysSelectAll(CompanyId).ToList();
                var holidayList = lstHolidaysResult.Select(holidaysObj => new Holiday
                {
                    HolidayId = holidaysObj.HolidayId,
                    HolidayName = holidaysObj.HolidayName,
                    HolidayDate = holidaysObj.HolidayDate,
                    CompanyId = holidaysObj.CompanyId
                }).ToList();
                return holidayList;
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
        /// Returns Selected Holiday Details By HolidayId and CompanyId
        /// </summary>
        /// <param name="HolidayId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<Holiday> SelectHolidayDetail(int HolidayId, int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_HolidaysSelect_Result> lstHolidaysResult = hrmsEntity.usp_HolidaysSelect(HolidayId,CompanyId).ToList();
                var holidayList = lstHolidaysResult.Select(holidaysObj => new Holiday
                {
                    HolidayId = holidaysObj.HolidayId,
                    HolidayName = holidaysObj.HolidayName,
                    HolidayDate = holidaysObj.HolidayDate,
                    CompanyId = holidaysObj.CompanyId
                }).ToList();
                return holidayList;
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
        /// Insert holiday Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        public bool InsertHoliday(Holiday holidayInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_HolidaysInsert(
                        holidayInfoobj.HolidayName,
                        holidayInfoobj.HolidayDate,
                        holidayInfoobj.CompanyId);
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
        /// Update Holiday Infomation
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        public bool UpdateHoliday(Holiday holidayInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_HolidaysUpdate(
                        holidayInfoobj.HolidayId,
                        holidayInfoobj.HolidayName,
                        holidayInfoobj.HolidayDate,
                        holidayInfoobj.CompanyId);
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
        /// Delete Holiday Detail by HolidayId and CompanyId
        /// </summary>
        /// <param name="holidayId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteHolidayDetail(int holidayId, int companyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                var result = hrmsEntity.usp_HolidaysDelete(holidayId, companyId);
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
