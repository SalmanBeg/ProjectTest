using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
  public  interface IRoundTypeRepository
    {

        /// <summary>
        /// Returns All RoundType Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
      //[Logger]
      //[ExceptionLogger]  
      //List<RoundType> SelectAllRoundTypeDetails(int CompanyId);


        /// <summary>
        /// Returns Selected RoundType Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
       // TAMasterTableMetaData SelectRoundTypeDetail(int Id, int CompanyId);

        /// <summary>
        /// Insert RoundType Information
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        //bool InsertRoundType(TAMasterTable TAMasterInfoobj);

        /// <summary>
        /// Update RoundType Information
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
       // bool UpdateRoundType(TAMasterTable TAMasterInfoobj);
    }
}
