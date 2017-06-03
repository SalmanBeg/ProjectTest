using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IUtilityRepository
    {
        /// <summary>
        /// Selects all the default companies
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CountryRegion> GetCountry();
        /// <summary>
        /// Selects all the state names based on country Id
        /// </summary>
        /// <param name="countryRegionId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<StateProvince> GetStateProvince(int? countryRegionId);
        /// <summary>
        /// Retrieves an individual record based on state id
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<StateProvince> GetStateProvinceByStateId(int stateId);
        List<LookUpDataEntity> GetLookUpData(int companyId);
        /// <summary>
        /// Default records to fill different types of alerts
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<AlertSendType> GetAlertSendType();
        /// <summary>
        /// Default records to fill alert criteria
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<AlertSendCriteria> GetAlertSendCriteria();
        /// <summary>
        /// Default records to fill security criteria to setup for employee filtering
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ManageSecurityCriteria> GetManageSecurityCriteria();
        //TODO: JK: Duplicate methos remove it
        [Logger]
        [ExceptionLogger]
        List<StateProvince> GetState(int countryRegionId);
        /// <summary>
        /// Selects all the states
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<StateProvince> GetState1();
        /// <summary>
        /// Default records to fill company documents type
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<DocumentSendType> GetDocumentSendType();
        /// <summary>
        /// To filter with the employees to filter employee to whom the documents are visible
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<DocumentSendCriteria> GetDocumentSendCriteria();
        /// <summary>
        /// For listing all the exceptions generated in the application
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ExceptionLog> ListExceptions();


    }
}
