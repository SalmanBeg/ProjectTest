using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;


namespace HRMS.Service.Interfaces
{
    public interface IPayPeriodTypeRepository
    {
        /// <summary>
        /// Returns All PayPeriodType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<PayPeriodType> SelectAllPayPeriodTypeDetails(int CompanyId);

        /// <summary>
        /// Returns Selected PayPeriodType Details By PayPeriodTypeId and CompanyID
        /// </summary>
        /// /// <param name="PayPeriodTypeId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<PayPeriodType> SelectPayPeriodTypeDetails(int PayPeriodTypeId, int CompanyId);
    }
}
