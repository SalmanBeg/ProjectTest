using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IHolidayGroupRepository
    {
        /// <summary>
        /// Returns All HolidayGroup Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<HolidayGroup> SelectAllHolidayGroupDetails(int CompanyId);

        /// <summary>
        /// Returns Selected HolidayGroup Details By HolidayGroupId and CompanyId
        /// </summary>
        /// <param name="HolidayGroupId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<HolidayGroup> SelectHolidayGroupDetail(int HolidayGroupId, int CompanyId);

        /// <summary>
        /// Insert holidayGroup Information
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertHolidayGroup(HolidayGroup holidayGroupInfoobj);

        /// <summary>
        /// Update HolidayGroup Infomation
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateHolidayGroup(HolidayGroup holidayGroupInfoobj);

        /// <summary>
        /// Delete HolidayGroup Detail by HolidayGroupId and CompanyId
        /// </summary>
        /// <param name="holidayGroupId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteHolidayGroupDetail(int holidayGroupId, int companyId);
    }
}
