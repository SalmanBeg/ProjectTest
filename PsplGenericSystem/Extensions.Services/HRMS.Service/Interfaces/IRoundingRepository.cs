using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface IRoundingRepository
    {

        /// <summary>
        /// Returns All the Rounding Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
       [Logger]
       [ExceptionLogger] 
       List<Rounding> SelectAllRoundingDetailsByCompanyId(int CompanyId);

        /// <summary>
        /// Returns Selected Rounding Details By RoundingId
        /// </summary>
        /// <param name="RoundingId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
       [Logger]
       [ExceptionLogger] 
       Rounding SelectRoundingDetailsByRoundingId(int RoundingId, int CompanyId);

        /// <summary>
        /// Insert Rounding Information
        /// </summary>
        /// <param name="RoundingInfoobj"></param>
        /// <returns></returns>
       [Logger]
       [ExceptionLogger] 
       bool InsertRounding(Rounding RoundingInfoobj);

        /// <summary>
        /// Update Rounding information
        /// </summary>
        /// <param name="roundingInfoobj"></param>
        /// <returns></returns>
       [Logger]
       [ExceptionLogger] 
       bool UpdateRounding(Rounding roundingInfoobj);

        /// <summary>
        /// Delete Rounding Details by RoundingId
        /// </summary>
        /// <param name="roundingId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
       [Logger]
       [ExceptionLogger] 
       bool DeleteroundingDetail(int roundingId, int companyId);
    }
}
