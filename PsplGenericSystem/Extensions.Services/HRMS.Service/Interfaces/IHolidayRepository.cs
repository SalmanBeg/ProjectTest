using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IHolidayRepository
    {
        /// <summary>
        /// Returns All Holiday Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Holiday> SelectAllHolidayDetails(int CompanyId);

        /// <summary>
        /// Returns Selected Holiday Details By HolidayId and CompanyId
        /// </summary>
        /// <param name="HolidayId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Holiday> SelectHolidayDetail(int HolidayId, int CompanyId);

        /// <summary>
        /// Insert holiday Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertHoliday(Holiday holidayInfoobj);

        /// <summary>
        /// Update Holiday Infomation
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateHoliday(Holiday holidayInfoobj);

        /// <summary>
        /// Delete Holiday Detail by HolidayId and CompanyId
        /// </summary>
        /// <param name="holidayId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteHolidayDetail(int holidayId, int companyId);
    }
}

