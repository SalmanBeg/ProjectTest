using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface ILunchRepository
    {

        /// <summary>
        /// Returns All Lunch Details By CompanyId
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Lunch> SelectAllLunchDetails(int CompanyId);

        /// <summary>
        /// Returns Selected Lunch Details By LunchId and CompanyId
        /// </summary>
        /// <param name="LunchId"></param>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        Lunch SelectLunchDetailsByLunchId(int LunchId, int CompanyId);


        /// <summary>
        /// Insert Lunch Information
        /// </summary>
        /// <param name="lunchInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertLunch(Lunch lunchInfoobj);


        /// <summary>
        /// Update Lunch Infomation
        /// </summary>
        /// <param name="lunchInfoobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateLunch(Lunch lunchInfoobj);

        /// <summary>
        /// Delete Lunch Detail by LunchId and CompanyId
        /// </summary>
        /// <param name="lunchId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteLunchDetail(int lunchId, int companyId);
    }
}
