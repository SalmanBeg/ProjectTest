using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface IRoundMinuteRepository
    {
        /// <summary>
        /// Returns All RoundMinutes Details By CompanyID
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       List<RoundMinute> SelectAllRoundMinuteDetails(int CompanyId);

        /// <summary>
        /// Returns Selected RoundMinutes Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
      //  TAMasterTable SelectRoundMinuteDetail(int Id, int CompanyId);

        /// <summary>
        /// Insert RoundMinutes Information
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
      //  bool InsertRoundMinute(TAMasterTable TAMasterInfoobj);


        /// <summary>
        /// Update RoundMinutes Information
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
       // bool UpdateRoundMinute(TAMasterTable TAMasterInfoobj);

    }
}
