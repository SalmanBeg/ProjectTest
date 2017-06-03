using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface ILookUpTableRepository
    {
        /// <summary>
        /// show all look up data table
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
       [Logger]
       [ExceptionLogger]
        List<LookUpDataEntity> SelectLookUpData(string tableName, int companyId);
       /// <summary>
       /// View to show all the look up data entities
       /// </summary>
       /// <param name="TableName"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool AddLookUpData(LookUpDataEntity lookUpDataEntityObj, string tableName);
       /// <summary>
       /// Returns the single record of the look up data by  primaryId
       /// </summary>
       /// <param name="tableName"></param>
       /// <param name="companyId"></param>
       /// <param name="primaryId"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       LookUpDataEntity SelectLookUpDataById(string tableName, int companyId, int primaryId);
       /// <summary>
       /// To update look up data table record 
       /// </summary>
       /// <param name="lookUpDataEntityObj"></param>
       /// <param name="tableName"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool UpdateLookUpData(LookUpDataEntity lookUpDataEntityObj, string tableName);
       /// <summary>
       /// To remove look up data record based on record id 
       /// </summary>
       /// <param name="recordId"></param>
       /// <param name="tableName"></param>
       /// <param name="companyId"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool DeleteLookUpDataById(int recordId, string tableName, int companyId);
    }
}
