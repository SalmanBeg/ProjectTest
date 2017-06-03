using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;


namespace HRMS.Service.Repositories
{
    public class OverTimePolicyRepository : IOverTimePolicyRepository
    {
        /// <summary>
        /// Returns All the OverTime Policy By Company Id
        /// </summary>
        /// <param name="OvertimeId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<OverTimePolicy> SelectAllOverTimeDetailsByCompanyId(int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_OverTimePolicySelectAll_Result> lstOvertimePolicyTypeResult = hrmsEntity.usp_OverTimePolicySelectAll(CompanyId).ToList();

                var overtimePolicyList = lstOvertimePolicyTypeResult.Select(overtimePolicyObj => new OverTimePolicy
                {
                    OvertimeId = overtimePolicyObj.OvertimeId,
                    OverTimeCode = overtimePolicyObj.OverTimeCode,
                    OTPolicyName = overtimePolicyObj.OTPolicyName,
                    OTPolicytype =Convert.ToInt32(overtimePolicyObj.OTPolicytype),
                    DailyOTHours = overtimePolicyObj.DailyOTHours,
                    WeeklyOTHours = overtimePolicyObj.WeeklyOTHours,
                    DailyDTHours = overtimePolicyObj.DailyDTHours,
                    WeeklyDTHours = overtimePolicyObj.WeeklyDTHours,
                    SatPayType = overtimePolicyObj.SatPayType,
                    SunPayType = overtimePolicyObj.SunPayType,
                    SatDolPremium = overtimePolicyObj.SatDolPremium,
                    SunDolPremium = overtimePolicyObj.SunDolPremium,
                    CRDailyRules = overtimePolicyObj.CRDailyRules,
                    CRDailyOTHours = overtimePolicyObj.CRDailyOTHours,
                    CRDailyDTHours = overtimePolicyObj.CRDailyDTHours,
                    CRWeeklyRule = overtimePolicyObj.CRWeeklyRule,
                    CRWeeklyOTHours = overtimePolicyObj.CRWeeklyOTHours,
                    CRWeeklyDTHours = overtimePolicyObj.CRWeeklyDTHours,
                    ConsecutiveDayRules = overtimePolicyObj.ConsecutiveDayRules,
                    CDRMinimumWorkDays = overtimePolicyObj.CDRMinimumWorkDays,
                    CDRMinimumWorkHours = overtimePolicyObj.CDRMinimumWorkHours,
                    CDROTHours = overtimePolicyObj.CDROTHours,
                    CDRDTHours = overtimePolicyObj.CDRDTHours,
                    ForceApproval = overtimePolicyObj.ForceApproval,
                    CompanyId = overtimePolicyObj.CompanyId
                }).ToList();
                return overtimePolicyList;
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
        /// Returns Selected OverTime Policy By OverTime Id
        /// </summary>
        /// <param name="OvertimeId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public OverTimePolicy SelectOverTimeDetailsByOverTimeId(int OvertimeId, int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_OverTimePolicySelect_Result> lstOvertimePolicyTypeResult = hrmsEntity.usp_OverTimePolicySelect(OvertimeId, CompanyId).ToList();

                var overtimePolicyList = lstOvertimePolicyTypeResult.Select(overtimePolicyObj => new OverTimePolicy
                {
                    OvertimeId = overtimePolicyObj.OvertimeId,
                    OverTimeCode = overtimePolicyObj.OverTimeCode,
                    OTPolicyName = overtimePolicyObj.OTPolicyName,
                    OTPolicytype = Convert.ToInt32(overtimePolicyObj.OTPolicytype),
                    DailyOTHours = overtimePolicyObj.DailyOTHours,
                    WeeklyOTHours = overtimePolicyObj.WeeklyOTHours,
                    DailyDTHours = overtimePolicyObj.DailyDTHours,
                    WeeklyDTHours = overtimePolicyObj.WeeklyDTHours,
                    SatPayType = overtimePolicyObj.SatPayType,
                    SunPayType = overtimePolicyObj.SunPayType,
                    SatDolPremium = overtimePolicyObj.SatDolPremium,
                    SunDolPremium = overtimePolicyObj.SunDolPremium,
                    CRDailyRules = overtimePolicyObj.CRDailyRules,
                    CRDailyOTHours = overtimePolicyObj.CRDailyOTHours,
                    CRDailyDTHours = overtimePolicyObj.CRDailyDTHours,
                    CRWeeklyRule = overtimePolicyObj.CRWeeklyRule,
                    CRWeeklyOTHours = overtimePolicyObj.CRWeeklyOTHours,
                    CRWeeklyDTHours = overtimePolicyObj.CRWeeklyDTHours,
                    ConsecutiveDayRules = overtimePolicyObj.ConsecutiveDayRules,
                    CDRMinimumWorkDays = overtimePolicyObj.CDRMinimumWorkDays,
                    CDRMinimumWorkHours = overtimePolicyObj.CDRMinimumWorkHours,
                    CDROTHours = overtimePolicyObj.CDROTHours,
                    CDRDTHours = overtimePolicyObj.CDRDTHours,
                    ForceApproval = overtimePolicyObj.ForceApproval,
                    CompanyId = overtimePolicyObj.CompanyId
                }).ToList();
                return overtimePolicyList.SingleOrDefault();
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
        /// Insert OverTime Policy 
        /// </summary>
        /// <param name="OverTimeInfoobj"></param>
        /// <returns></returns>
        public bool InsertOverTimePolicy(OverTimePolicy OverTimeInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_OverTimePolicyInsert(
                    //OverTimeInfoobj.OvertimeId,
                    //OverTimeInfoobj.OverTimeCode,
                    OverTimeInfoobj.OTPolicyName,
                    OverTimeInfoobj.OTPolicytype,
                    OverTimeInfoobj.DailyOTHours,
                    OverTimeInfoobj.WeeklyOTHours,
                    OverTimeInfoobj.DailyDTHours,
                    OverTimeInfoobj.WeeklyDTHours,
                    OverTimeInfoobj.SatPayType,
                    OverTimeInfoobj.SunPayType,
                    OverTimeInfoobj.SatDolPremium,
                    OverTimeInfoobj.SunDolPremium,
                    OverTimeInfoobj.CRDailyRules,
                    OverTimeInfoobj.CRDailyOTHours,
                    OverTimeInfoobj.CRDailyDTHours,
                    OverTimeInfoobj.CRWeeklyRule,
                    OverTimeInfoobj.CRWeeklyOTHours,
                    OverTimeInfoobj.CRWeeklyDTHours,
                    OverTimeInfoobj.ConsecutiveDayRules,
                    OverTimeInfoobj.CDRMinimumWorkDays,
                    OverTimeInfoobj.CDRMinimumWorkHours,
                    OverTimeInfoobj.CDROTHours,
                    OverTimeInfoobj.CDRDTHours,
                    OverTimeInfoobj.ForceApproval,
                    OverTimeInfoobj.CompanyId);
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
        /// Update OverTimePolicy
        /// </summary>
        /// <param name="overTimeInfoobj"></param>
        /// <returns></returns>
        public bool UpdateOverTimePolicy(OverTimePolicy overTimeInfoobj)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                
                var result = hrmsEntity.usp_OverTimePolicyUpdate(
                    overTimeInfoobj.OvertimeId,
                    //OverTimeInfoobj.OverTimeCode,
                    overTimeInfoobj.OTPolicyName,
                    overTimeInfoobj.OTPolicytype,
                    overTimeInfoobj.DailyOTHours,
                    overTimeInfoobj.WeeklyOTHours,
                    overTimeInfoobj.DailyDTHours,
                    overTimeInfoobj.WeeklyDTHours,
                    overTimeInfoobj.SatPayType,
                    overTimeInfoobj.SunPayType,
                    overTimeInfoobj.SatDolPremium,
                    overTimeInfoobj.SunDolPremium,
                    overTimeInfoobj.CRDailyRules,
                    overTimeInfoobj.CRDailyOTHours,
                    overTimeInfoobj.CRDailyDTHours,
                    overTimeInfoobj.CRWeeklyRule,
                    overTimeInfoobj.CRWeeklyOTHours,
                    overTimeInfoobj.CRWeeklyDTHours,
                    overTimeInfoobj.ConsecutiveDayRules,
                    overTimeInfoobj.CDRMinimumWorkDays,
                    overTimeInfoobj.CDRMinimumWorkHours,
                    overTimeInfoobj.CDROTHours,
                    overTimeInfoobj.CDRDTHours,
                    overTimeInfoobj.ForceApproval,
                    overTimeInfoobj.CompanyId);
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
        /// Delete OverTime Policy By OverTime Id
        /// </summary>
        /// <param name="overtimeId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteOverTimeDetail(int overtimeId, int companyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                var result = hrmsEntity.usp_OverTimePolicyDelete(overtimeId, companyId);
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