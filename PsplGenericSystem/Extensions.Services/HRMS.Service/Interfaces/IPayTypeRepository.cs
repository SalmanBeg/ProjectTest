using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface IPayTypeRepository
    {
        /// <summary>
        /// Returns All PayType Details By CompanyID
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>

        [Logger]
        [ExceptionLogger]
        List<PayType> SelectAllPayTypeDetails(int companyId);

        /// <summary>
        /// Returns Selected PayType Details By PayTypeId and CompanyId
        /// </summary>
        /// <param name="payTypeId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        
        [Logger]
        [ExceptionLogger]
        List<PayType> SelectPayTypeDetailsByPayTypeId(int payTypeId, int companyId);

        /// <summary>
        /// Insert PayType Information
        /// </summary>
        /// <param name="paytypeInfoobj"></param>
        /// <returns></returns>

        [Logger]
        [ExceptionLogger]
        bool InsertPayType(PayType paytypeInfoobj);

        /// <summary>
        /// Update PayType Infomation
        /// </summary>
        /// <param name="paytypeInfoobj"></param>
        /// <returns></returns>

        [Logger]
        [ExceptionLogger]
        bool UpdatePayType(PayType paytypeInfoobj);

        /// <summary>
        /// Delete PayType Detail by PayTypeId and CompanyId
        /// </summary>
        /// <param name="payTypeId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        
           [Logger]
        [ExceptionLogger]
        bool DeletePayTypeDetail(int payTypeId, int companyId);
    }
}
