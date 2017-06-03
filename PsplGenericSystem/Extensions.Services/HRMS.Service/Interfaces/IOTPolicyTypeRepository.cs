using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IOTPolicyTypeRepository
    {
        /// <summary>
        /// Returns All OTPolicyType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //List<OTPolicyType> SelectAllOTPolicyTypeDetails(int CompanyId);


        /// <summary>
        /// Returns Selected OTPolicyType Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //TAMasterTableInfo SelectOTPolicyTypeDetail(int Id, int CompanyId);

        /// <summary>
        /// Insert OTPolicyType Information
        /// </summary>
        /// <param name="TAMasterInfoobj"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //bool InsertOTPolicyType(TAMasterTableInfo TAMasterInfoobj);

        /// <summary>
        /// Update OTPayType Information
        /// </summary>
        /// <param name="TAMasterInfoobj"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //bool UpdateOTPolicyType(TAMasterTableInfo TAMasterInfoobj);
    }
}
