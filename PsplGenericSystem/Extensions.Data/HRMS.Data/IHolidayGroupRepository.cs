using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public interface IHolidayGroupRepository
    {

        /// <summary>
        /// Returns All HolidayGroup Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        List<HolidayGroupInfo> SelectAllHolidayGroupDetails(int CompanyId);

        /// <summary>
        /// Returns Selected HolidayGroup Details By HolidayGroupId and CompanyId
        /// </summary>
        /// <param name="HolidayGroupId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        List<HolidayGroupInfo> SelectHolidayGroupDetail(int HolidayGroupId, int CompanyId);

        /// <summary>
        /// Insert holidayGroup Information
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        bool InsertHolidayGroup(HolidayGroupInfo holidayGroupInfoobj);

        /// <summary>
        /// Update HolidayGroup Infomation
        /// </summary>
        /// <param name="holidayGroupInfoobj"></param>
        /// <returns></returns>
        bool UpdateHolidayGroup(HolidayGroupInfo holidayGroupInfoobj);

        /// <summary>
        /// Delete HolidayGroup Detail by HolidayGroupId and CompanyId
        /// </summary>
        /// <param name="HolidayGroupId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        bool DeleteHolidayGroupDetail(int HolidayGroupId, int CompanyId);


    }
}
