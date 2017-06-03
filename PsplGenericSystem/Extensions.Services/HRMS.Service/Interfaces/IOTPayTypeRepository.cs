using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IOTPayTypeRepository
    {
        /// <summary>
        /// Returns All OTPayType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<OTPayType> SelectAllOTPayTypeDetails(int CompanyId);
        
        /// <summary>
        /// Returns Selected OTPayType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //TAMasterTableInfo SelectOTPayTypeDetail(int Id, int CompanyId);
        
        /// <summary>
        /// Insert OTPayType Information
        /// </summary>
        /// <param name="TAMasterInfoobj"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //bool InsertOTPayType(TAMasterTableInfo TAMasterInfoobj);

        /// <summary>
        /// Update OTPayType Information
        /// </summary>
        /// <param name="TAMasterInfoobj"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //bool UpdateOTPayType(TAMasterTableInfo TAMasterInfoobj);
    }
}
