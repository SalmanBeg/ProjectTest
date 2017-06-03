using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class PayPeriodTypeRepository : IPayPeriodTypeRepository
    {
        /// <summary>
        /// Returns All PayPeriodType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<PayPeriodType> SelectAllPayPeriodTypeDetails(int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_PayPeriodTypeSelectAll_Result> lstPayPeriodTypeResult = hrmsEntity.usp_PayPeriodTypeSelectAll(CompanyId).ToList();
                var payPeriodTypeList = lstPayPeriodTypeResult.Select(payPeriodTypeObj => new PayPeriodType
                {
                    PayPeriodTypeId = payPeriodTypeObj.PayPeriodTypeId,
                    Name = payPeriodTypeObj.Name,
                    Description = payPeriodTypeObj.Description,
                    Days = payPeriodTypeObj.Days,
                    Status = payPeriodTypeObj.Status,
                    CompanyId = payPeriodTypeObj.CompanyId
                }).ToList();
                return payPeriodTypeList;
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
        /// Returns Selected PayPeriodType Details By PayPeriodTypeId and CompanyID
        /// </summary>
        /// /// <param name="PayPeriodTypeId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public List<PayPeriodType> SelectPayPeriodTypeDetails(int PayPeriodTypeId, int CompanyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                List<usp_PayPeriodTypeSelect_Result> lstPayPeriodTypeResult = hrmsEntity.usp_PayPeriodTypeSelect(PayPeriodTypeId,CompanyId).ToList();
                var payPeriodTypeList = lstPayPeriodTypeResult.Select(payPeriodTypeObj => new PayPeriodType
                {
                    PayPeriodTypeId = payPeriodTypeObj.PayPeriodTypeId,
                    Name = payPeriodTypeObj.Name,
                    Description = payPeriodTypeObj.Description,
                    Days = payPeriodTypeObj.Days,
                    Status = payPeriodTypeObj.Status,
                    CompanyId = payPeriodTypeObj.CompanyId
                }).ToList();
                return payPeriodTypeList;
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
    }
}
