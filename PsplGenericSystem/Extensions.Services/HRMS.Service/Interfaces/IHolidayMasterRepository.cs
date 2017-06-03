using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IHolidayMasterRepository
    {
        /// <summary>
        /// Returns All HolidayMaster Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<HolidayMaster> SelectAllHolidayMasterDetails(int HolidayGroupId, int CompanyId);

        /// <summary>
        /// Returns Selected HolidayMaster Details By CompanyId
        /// </summary>
        /// <param name="HolidayMasterId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<HolidayMaster> SelectHolidayMasterDetails(int HolidayMasterId, int CompanyId);

        /// <summary>
        /// Insert holidayMaster Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertHolidayMaster(HolidayMaster holidaymasterInfoobj);


        /// <summary>
        /// Update HolidayMaster Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateHolidayMaster(HolidayMaster holidaymasterInfoobj);

        /// <summary>
        /// Delete HolidayMaster Detail by HolidayMasterId and CompanyId
        /// </summary>
        /// <param name="holidayMasterId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteHolidayMasterDetail(int holidayMasterId, int companyId);


        /// <summary>
        /// Returns All Holiday List to Display In Holiday Master Grid   By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        // List<HolidayMaster> SelectHolidayMasterGridDetails(int HolidayGroupId, int CompanyId);
    }
}