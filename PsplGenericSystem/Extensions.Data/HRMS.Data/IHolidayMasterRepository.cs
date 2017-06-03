using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public interface IHolidayMasterRepository
    {

        /// <summary>
        /// Returns All HolidayMaster Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        List<HolidayMasterInfo> SelectAllHolidayMasterDetails(int CompanyId);

        /// <summary>
        /// Returns Selected HolidayMaster Details By CompanyId
        /// </summary>
        /// <param name="HolidayMasterId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        List<HolidayMasterInfo> SelectHolidayMasterDetails(int HolidayMasterId, int CompanyId);

        /// <summary>
        /// Insert holidayMaster Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        bool InsertHolidayMaster(HolidayMasterInfo holidaymasterInfoobj);


        /// <summary>
        /// Update HolidayMaster Information
        /// </summary>
        /// <param name="holidayInfoobj"></param>
        /// <returns></returns>
        bool UpdateHolidayMaster(HolidayMasterInfo holidaymasterInfoobj);

        /// <summary>
        /// Delete HolidayMaster Detail by HolidayMasterId and CompanyId
        /// </summary>
        /// <param name="HolidayMasterId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        bool DeleteHolidayMasterDetail(int HolidayMasterId, int CompanyId);


        /// <summary>
        /// Returns All Holiday List to Display In Holiday Master Grid   By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        List<HolidayMasterInfo> SelectHolidayMasterGridDetails(int HolidayGroupId, int CompanyId);

    }
}
