using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface ICompensationProfileRepository
    {
        /// <summary>
        /// View to list all the compensation profile records in a company
        /// </summary>
        /// <param name="companyid"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CompensationProfile> SelectAllCompensationProfiles(int companyid);
        /// <summary>
        /// View to add a new record for a compensation profile
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int AddCompensationProfile(CompensationProfile obj);
        /// <summary>
        /// View to update an existing compensation profile record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int UpdateCompensationProfile(CompensationProfile obj);
        /// <summary>
        /// View to list all the compensation profile records based on compensationprofileId
        /// </summary>
        /// <param name="intCompensationProfileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        CompensationProfile SelectAllCompensationProfileById(int intCompensationProfileId);
        /// <summary>
        /// Function to delete records based on recordIds
        /// </summary>
        /// <param name="CompensationprofileIds"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int DeleteCompensationProfile(string CompensationprofileIds);
      
        [Logger]
        [ExceptionLogger]
        bool IsTitleExists(CompensationProfile compensationProfileObj);

    }
}
