using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class PayPeriodRepository : IPayPeriodRepository
    {
        /// <summary>
        /// Returns All PayPeriod Details By CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<PayPeriods> SelectAllPayPeriodDetails(int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstPayPeriodsResult = hrmsEntity.usp_PayPeriodsSelectAll(companyId).ToList();
                    var payPeriodsList = lstPayPeriodsResult.Select(payPeriodsObj => new PayPeriods
                    {
                        PayPeriodId = payPeriodsObj.PayPeriodId,
                        PayPeriodCode = payPeriodsObj.PayPeriodCode,
                        PayPeriodDescription = payPeriodsObj.PayPeriodDescription,
                        PayPeriodTypeId = payPeriodsObj.PayPeriodTypeId,
                        //PayPeriodDays = payPeriodsObj.PayPeriodDays,
                        StartDateTime = payPeriodsObj.StartDateTime,
                        EndDateTime = payPeriodsObj.EndDateTime,
                        StartDayOfWeek = payPeriodsObj.StartDayOfWeek,
                        NextSchedule = payPeriodsObj.NextSchedule,
                        CompanyId = payPeriodsObj.CompanyId
                    }).ToList();
                    return payPeriodsList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }



        /// <summary>
        /// Returns Selected PayPeriod Details By PayPeriodId and CompanyId
        /// </summary>
        /// <param name="payPeriodId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<PayPeriods> SelectPayPeriodDetail(int payPeriodId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstPayPeriodsResult = hrmsEntity.usp_PayPeriodsSelect(payPeriodId, companyId).ToList();
                    var payPeriodsList = lstPayPeriodsResult.Select(payPeriodsObj => new PayPeriods
                    {
                        PayPeriodId = payPeriodsObj.PayPeriodId,
                        PayPeriodCode = payPeriodsObj.PayPeriodCode,
                        PayPeriodDescription = payPeriodsObj.PayPeriodDescription,
                        PayPeriodTypeId = payPeriodsObj.PayPeriodTypeId,
                        //PayPeriodDays = payPeriodsObj.PayPeriodDays,
                        StartDateTime = payPeriodsObj.StartDateTime,
                        EndDateTime = payPeriodsObj.EndDateTime,
                        StartDayOfWeek = payPeriodsObj.StartDayOfWeek,
                        NextSchedule = payPeriodsObj.NextSchedule,
                        CompanyId = payPeriodsObj.CompanyId
                    }).ToList();
                    return payPeriodsList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }


        /// <summary>
        /// Insert PayPeriod Information
        /// </summary>
        /// <param name="payperiodInfoobj"></param>
        /// <returns></returns>
        public bool InsertPayPeriod(PayPeriods payperiodInfoobj)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_PayPeriodsInsert(
                        //payperiodInfoobj.PayPeriodCode,
                        payperiodInfoobj.PayPeriodDescription,
                        payperiodInfoobj.PayPeriodTypeId,
                        //PayPeriodDays = payPeriodsObj.PayPeriodDays,
                        payperiodInfoobj.StartDateTime,
                        payperiodInfoobj.EndDateTime, payperiodInfoobj.EndDateTime,
                        payperiodInfoobj.StartDayOfWeek,
                        payperiodInfoobj.NextSchedule,
                        payperiodInfoobj.CompanyId);
                    return Convert.ToBoolean(result); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update PayPeriod Information
        /// </summary>
        /// <param name="payperiodInfoobj"></param>
        /// <returns></returns>
        public bool UpdatePayPeriod(PayPeriods payperiodInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_PayPeriodsUpdate(
                               payperiodInfoobj.PayPeriodId,
                        //payperiodInfoobj.PayPeriodCode,
                               payperiodInfoobj.PayPeriodDescription,
                               payperiodInfoobj.PayPeriodTypeId,
                        //PayPeriodDays = payPeriodsObj.PayPeriodDays,
                               payperiodInfoobj.StartDateTime,
                               payperiodInfoobj.EndDateTime,
                               payperiodInfoobj.EndDateTime,
                               payperiodInfoobj.StartDayOfWeek,
                               payperiodInfoobj.NextSchedule,
                               payperiodInfoobj.CompanyId);
                    return Convert.ToBoolean(result); 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        /// <summary>
        /// Delete PayPeriod Detail by PayPeriodId and CompanyId
        /// </summary>
        /// <param name="payPeriodId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeletePayPeriodDetail(int payPeriodId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_PayPeriodsDelete(payPeriodId, companyId);
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
