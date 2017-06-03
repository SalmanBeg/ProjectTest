using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;


namespace HRMS.Service.Repositories
{
    public class HolidayMasterRepository: IHolidayMasterRepository
    {
        /// <summary>
        /// Returns All HolidayMaster Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayMaster> SelectAllHolidayMasterDetails(int HolidayGroupId,int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_HolidayMasterByHolidayGroupSelectAll_Result> lstHolidayMasterResult = hrmsEntity.usp_HolidayMasterByHolidayGroupSelectAll(HolidayGroupId,CompanyId).ToList();

                var holidayMasterList = lstHolidayMasterResult.Select(holidayMasterObj => new HolidayMaster
                {
                    HolidayId = holidayMasterObj.HolidayId,
                    HolidayName = holidayMasterObj.HolidayName,
                    HolidayGroupId = holidayMasterObj.HolidayGroupId,
                    HolidayMasterId = holidayMasterObj.HolidayMasterId,
                    HoursBenefit = holidayMasterObj.HoursBenefit,
                    WorkBenefit = Convert.ToBoolean(holidayMasterObj.WorkBenefit),
                    OverTimeBenefit = Convert.ToBoolean(holidayMasterObj.OverTimeBenefit),
                    DoubleTimeBenefit = Convert.ToBoolean(holidayMasterObj.DoubleTimeBenefit),
                    DaysBefore = holidayMasterObj.DaysBefore,
                    DaysAfter = holidayMasterObj.DaysAfter,
                    DollarPerHour = holidayMasterObj.DollarPerHour,
                    BankHoursIfWorked = Convert.ToBoolean(holidayMasterObj.BankHoursIfWorked),
                    BankToAccount = holidayMasterObj.BankToAccount,
                    CompanyId = holidayMasterObj.CompanyId
                }).ToList();
                return holidayMasterList;
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
        /// Returns Selected HolidayMaster Details By CompanyId
        /// </summary>
        /// <param name="HolidayMasterId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<HolidayMaster> SelectHolidayMasterDetails(int HolidayMasterId, int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_HolidayMasterSelect_Result> lstHolidayMasterResult = hrmsEntity.usp_HolidayMasterSelect(HolidayMasterId,CompanyId).ToList();

                var holidayMasterList = lstHolidayMasterResult.Select(holidayMasterObj => new HolidayMaster
                {
                    HolidayGroupId = holidayMasterObj.HolidayGroupId,
                    HolidayId = holidayMasterObj.HolidayId,
                    HoursBenefit = holidayMasterObj.HoursBenefit,
                    WorkBenefit = Convert.ToBoolean(holidayMasterObj.WorkBenefit),
                    OverTimeBenefit = Convert.ToBoolean(holidayMasterObj.OverTimeBenefit),
                    DoubleTimeBenefit = Convert.ToBoolean(holidayMasterObj.DoubleTimeBenefit),
                    DaysBefore = holidayMasterObj.DaysBefore,
                    DaysAfter = holidayMasterObj.DaysAfter,
                    DollarPerHour = holidayMasterObj.DollarPerHour,
                    BankHoursIfWorked = Convert.ToBoolean(holidayMasterObj.BankHoursIfWorked),
                    BankToAccount = holidayMasterObj.BankToAccount,
                    CompanyId = holidayMasterObj.CompanyId
                }).ToList();
                return holidayMasterList;
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
        /// Returns All Holiday List to Display In Holiday Master Grid   By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        //public List<HolidayMaster> SelectHolidayMasterGridDetails(int HolidayGroupId, int CompanyId)
        //{
        //    var hrmsEntity = new HRMSEntities1();
        //    try
        //    {
        //        List<usp_HolidayMasterSelectAll_Result> lstHolidayMasterResult = hrmsEntity.usp_HolidayMasterByHolidayGroupSelectAll(HolidayGroupId, CompanyId).ToList();
        //        var holidayMasterList = lstHolidayMasterResult.Select(holidayMasterObj => new HolidayMaster
        //        {
        //            HolidayGroupId = holidayMasterObj.HolidayGroupId,
        //            HolidayId = holidayMasterObj.HolidayId,
        //            HolidayName = holidayMasterObj.HolidayName,
        //            HoursBenefit = holidayMasterObj.HoursBenefit,
        //            WorkBenefit = holidayMasterObj.WorkBenefit,
        //            OverTimeBenefit = holidayMasterObj.OverTimeBenefit,
        //            DoubleTimeBenefit = holidayMasterObj.DoubleTimeBenefit,
        //            DaysBefore = holidayMasterObj.DaysBefore,
        //            DaysAfter = holidayMasterObj.DaysAfter,
        //            DollarPerHour = holidayMasterObj.DollarPerHour,
        //            BankHoursIfWorked = holidayMasterObj.BankHoursIfWorked,
        //            BankToAccount = holidayMasterObj.BankToAccount,
        //            CompanyId = holidayMasterObj.CompanyId
        //        }).ToList();
        //        return holidayMasterList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        hrmsEntity.Dispose();
        //    }
        //}

        /// <summary>
        /// Insert holidayMaster Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        public bool InsertHolidayMaster(HolidayMaster holidaymasterInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                var result = hrmsEntity.usp_HolidayMasterInsert(
                    holidaymasterInfoobj.HolidayGroupId,
                    holidaymasterInfoobj.HolidayId,
                    holidaymasterInfoobj.HoursBenefit,
                    holidaymasterInfoobj.WorkBenefit,
                    holidaymasterInfoobj.OverTimeBenefit,
                    holidaymasterInfoobj.DoubleTimeBenefit,
                    holidaymasterInfoobj.DaysBefore,
                    holidaymasterInfoobj.DaysAfter,
                    holidaymasterInfoobj.DollarPerHour,
                    holidaymasterInfoobj.BankHoursIfWorked,
                    holidaymasterInfoobj.BankToAccount,
                    holidaymasterInfoobj.CompanyId);
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
        /// Update HolidayMaster Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        public bool UpdateHolidayMaster(HolidayMaster holidaymasterInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_HolidayMasterUpdate(
                    holidaymasterInfoobj.HolidayMasterId,
                    holidaymasterInfoobj.HolidayGroupId,
                    holidaymasterInfoobj.HolidayId,
                    holidaymasterInfoobj.HoursBenefit,
                    holidaymasterInfoobj.WorkBenefit,
                    holidaymasterInfoobj.OverTimeBenefit,
                    holidaymasterInfoobj.DoubleTimeBenefit,
                    holidaymasterInfoobj.DaysBefore,
                    holidaymasterInfoobj.DaysAfter,
                    holidaymasterInfoobj.DollarPerHour,
                    holidaymasterInfoobj.BankHoursIfWorked,
                    holidaymasterInfoobj.BankToAccount,
                    holidaymasterInfoobj.CompanyId);
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
        /// Delete HolidayMaster Detail by HolidayMasterId and CompanyId
        /// </summary>
        /// <param name="holidayMasterId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteHolidayMasterDetail(int holidayMasterId, int companyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                var result = hrmsEntity.usp_HolidayMasterDelete(holidayMasterId, companyId);
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
