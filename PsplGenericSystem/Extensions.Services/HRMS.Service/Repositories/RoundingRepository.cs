using System;
using System.Collections.Generic;
using System.Linq;

using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class RoundingRepository : IRoundingRepository
    {

        /// <summary>
        /// Returns All the Rounding Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<Rounding> SelectAllRoundingDetailsByCompanyId(int CompanyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_RoundingSelectAll_Result> lstRoundingResult = hrmsEntity.usp_RoundingSelectAll(CompanyId).ToList();

                    var roundingList = lstRoundingResult.Select(roundingObj => new Rounding
                    {
                        RoundingId = roundingObj.RoundingId,
                        RoundingPolicyCode = roundingObj.RoundingPolicyCode,
                        RoundingDescription = roundingObj.RoundingDescription,
                        StartRoundType = roundingObj.StartRoundType,
                        StartRoundMinutes = roundingObj.StartRoundMinutes,
                        EndRoundType = roundingObj.EndRoundType,
                        EndPunchMinutes = roundingObj.EndPunchMinutes,
                        LunchStartRoundType = roundingObj.LunchStartRoundType,
                        LunchStartRoundMinutes = roundingObj.LunchStartRoundMinutes,
                        LunchEndRoundType = roundingObj.LunchEndRoundType,
                        LunchEndRoundTMinutes = roundingObj.LunchEndRoundTMinutes,
                        BreakStartRoundType = roundingObj.BreakStartRoundType,
                        BreakStartRoundMinutes = roundingObj.BreakStartRoundMinutes,
                        BreakEndRoundType = roundingObj.BreakEndRoundType,
                        BreakEndRoundTMinutes = roundingObj.BreakEndRoundTMinutes,
                        RoundingMethod = roundingObj.RoundingMethod,
                        RptExceptions = roundingObj.RptExceptions,
                        ReportEarlyIn = roundingObj.ReportEarlyIn,
                        ReportEarlyOut = roundingObj.ReportEarlyOut,
                        ReportLateIn = roundingObj.ReportLateIn,
                        ReportLateOut = roundingObj.ReportLateOut,
                        ReportLunchUnder = roundingObj.ReportLunchUnder,
                        ReportLunchOver = roundingObj.ReportLunchOver,
                        CompanyId = roundingObj.CompanyId
                    }).ToList();
                    return roundingList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Returns Selected Rounding Details By RoundingId
        /// </summary>
        /// <param name="RoundingId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public Rounding SelectRoundingDetailsByRoundingId(int RoundingId, int CompanyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_RoundingSelect_Result> lstRoundingResult = hrmsEntity.usp_RoundingSelect(RoundingId, CompanyId).ToList();

                    var roundingList = lstRoundingResult.Select(roundingObj => new Rounding
                    {
                        RoundingId = roundingObj.RoundingId,
                        RoundingPolicyCode = roundingObj.RoundingPolicyCode,
                        RoundingDescription = roundingObj.RoundingDescription,
                        StartRoundType = roundingObj.StartRoundType,
                        StartRoundMinutes = roundingObj.StartRoundMinutes,
                        EndRoundType = roundingObj.EndRoundType,
                        EndPunchMinutes = roundingObj.EndPunchMinutes,
                        LunchStartRoundType = roundingObj.LunchStartRoundType,
                        LunchStartRoundMinutes = roundingObj.LunchStartRoundMinutes,
                        LunchEndRoundType = roundingObj.LunchEndRoundType,
                        LunchEndRoundTMinutes = roundingObj.LunchEndRoundTMinutes,
                        BreakStartRoundType = roundingObj.BreakStartRoundType,
                        BreakStartRoundMinutes = roundingObj.BreakStartRoundMinutes,
                        BreakEndRoundType = roundingObj.BreakEndRoundType,
                        BreakEndRoundTMinutes = roundingObj.BreakEndRoundTMinutes,
                        RoundingMethod = roundingObj.RoundingMethod,
                        RptExceptions = roundingObj.RptExceptions,
                        ReportEarlyIn = roundingObj.ReportEarlyIn,
                        ReportEarlyOut = roundingObj.ReportEarlyOut,
                        ReportLateIn = roundingObj.ReportLateIn,
                        ReportLateOut = roundingObj.ReportLateOut,
                        ReportLunchUnder = roundingObj.ReportLunchUnder,
                        ReportLunchOver = roundingObj.ReportLunchOver,
                        CompanyId = roundingObj.CompanyId
                    }).ToList();
                    return roundingList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Insert Rounding Information
        /// </summary>
        /// <param name="RoundingInfoobj"></param>
        /// <returns></returns>
        public bool InsertRounding(Rounding RoundingInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                  
                    var result = hrmsEntity.usp_RoundingInsert(RoundingInfoobj.RoundingDescription, RoundingInfoobj.StartRoundType, RoundingInfoobj.StartRoundMinutes,
                        RoundingInfoobj.EndRoundType, RoundingInfoobj.EndPunchMinutes, RoundingInfoobj.LunchStartRoundType, RoundingInfoobj.LunchStartRoundMinutes,
                        RoundingInfoobj.LunchEndRoundType, RoundingInfoobj.LunchEndRoundTMinutes, RoundingInfoobj.BreakStartRoundType, RoundingInfoobj.BreakStartRoundMinutes,
                          RoundingInfoobj.BreakEndRoundType, RoundingInfoobj.BreakEndRoundTMinutes, RoundingInfoobj.RoundingMethod, RoundingInfoobj.RptExceptions,
                         RoundingInfoobj.ReportEarlyIn, RoundingInfoobj.ReportEarlyOut, RoundingInfoobj.ReportLateIn, RoundingInfoobj.ReportLateOut, RoundingInfoobj.ReportLunchUnder,
                          RoundingInfoobj.ReportLunchOver, RoundingInfoobj.CompanyId);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Update Rounding information
        /// </summary>
        /// <param name="roundingInfoobj"></param>
        /// <returns></returns>
        public bool UpdateRounding(Rounding roundingInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_RoundingUpdate(roundingInfoobj.RoundingId, roundingInfoobj.RoundingDescription, roundingInfoobj.StartRoundType, roundingInfoobj.StartRoundMinutes,
                        roundingInfoobj.EndRoundType, roundingInfoobj.EndPunchMinutes, roundingInfoobj.LunchStartRoundType, roundingInfoobj.LunchStartRoundMinutes,
                        roundingInfoobj.LunchEndRoundType, roundingInfoobj.LunchEndRoundTMinutes, roundingInfoobj.BreakStartRoundType, roundingInfoobj.BreakStartRoundMinutes,
                          roundingInfoobj.BreakEndRoundType, roundingInfoobj.BreakEndRoundTMinutes, roundingInfoobj.RoundingMethod, roundingInfoobj.RptExceptions,
                         roundingInfoobj.ReportEarlyIn, roundingInfoobj.ReportEarlyOut, roundingInfoobj.ReportLateIn, roundingInfoobj.ReportLateOut, roundingInfoobj.ReportLunchUnder,
                          roundingInfoobj.ReportLunchOver, roundingInfoobj.CompanyId);
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Delete Rounding Details by RoundingId
        /// </summary>
        /// <param name="roundingId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteroundingDetail(int roundingId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_RoundingDelete(roundingId, companyId);
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
