using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IOverTimePolicyRepository
    {
        /// <summary>
        /// Returns All the OverTime Policy By Company Id
        /// </summary>
        /// <param name="OvertimeId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<OverTimePolicy> SelectAllOverTimeDetailsByCompanyId(int CompanyId);

        /// <summary>
        /// Returns Selected OverTime Policy By OverTime Id
        /// </summary>
        /// <param name="OvertimeId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        OverTimePolicy SelectOverTimeDetailsByOverTimeId(int OvertimeId, int CompanyId);

        /// <summary>
        /// Insert OverTime Policy 
        /// </summary>
        /// <param name="OverTimeInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertOverTimePolicy(OverTimePolicy OverTimeInfoobj);

        /// <summary>
        /// Update OverTimePolicy
        /// </summary>
        /// <param name="overTimeInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateOverTimePolicy(OverTimePolicy overTimeInfoobj);

        /// <summary>
        /// Delete OverTime Policy By OverTime Id
        /// </summary>
        /// <param name="overtimeId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteOverTimeDetail(int overtimeId, int companyId);
    }
}
