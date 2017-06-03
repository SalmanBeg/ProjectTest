using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IPayPeriodRepository
    {
        /// <summary>
        /// Returns All PayPeriod Details By CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<PayPeriods> SelectAllPayPeriodDetails(int companyId);


        /// <summary>
        /// Returns Selected PayPeriod Details By PayPeriodId and CompanyId
        /// </summary>
        /// <param name="payPeriodId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<PayPeriods> SelectPayPeriodDetail(int payPeriodId, int companyId);


        /// <summary>
        /// Insert PayPeriod Information
        /// </summary>
        /// <param name="payperiodInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertPayPeriod(PayPeriods payperiodInfoobj);


        /// <summary>
        /// Update PayPeriod Information
        /// </summary>
        /// <param name="payperiodInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdatePayPeriod(PayPeriods payperiodInfoobj);


        /// <summary>
        /// Delete PayPeriod Detail by PayPeriodId and CompanyId
        /// </summary>
        /// <param name="payPeriodId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeletePayPeriodDetail(int payPeriodId, int companyId);
    }
}
