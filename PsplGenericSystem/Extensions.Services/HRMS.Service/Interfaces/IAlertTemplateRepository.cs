
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;
namespace HRMS.Service.Interfaces
{
    public interface IAlertTemplateRepository
    {
        /// <summary>
        /// Adding a new alert criteria
        /// </summary>
        /// <param name="alertTemplateObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int AddAlertTemplate(AlertTemplate alertTemplateObj);
        /// <summary>
        /// Retrieving alert records based on alert id and companyid
        /// </summary>
        /// <param name="alertTemplateId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        AlertTemplate SelectAlertTemplateById(int alertTemplateId, int companyId);
        /// <summary>
        /// To update an existing record pf alert template based on record id
        /// </summary>
        /// <param name="alertTemplateObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateAlertTemplate(AlertTemplate alertTemplateObj); 
        /// <summary>
        /// Deleting an alert template based on alert recordid and companyid
        /// </summary>
        /// <param name="alertTemplateId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteAlertTemplate(int alertTemplateId, int companyId);
        /// <summary>
        /// Populate all alert templates in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<AlertTemplate> SelectAllAlertTemplate(int companyId);
        /// <summary>
        /// to add employees involved in alert criteria
        /// </summary>
        /// <param name="alertTemplateId"></param>
        /// <param name="employeeId"></param>
        /// <param name="status"></param>
        /// <param name="employeeEmail"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool AddAlertEmployee(int alertTemplateId, int employeeId, bool status, string employeeEmail, string employeeName);
        /// <summary>
        /// filter criteria to schedule an alert
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<SendingAlertCondition> GetSendingAlertCondition();
        /// <summary>
        /// filter criteria to schedule an alert
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<SendingAlertDuration> GetSendingAlertDuration();
        /// <summary>
        /// filter criteria to schedule an alert
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<SendingAlertTiming> GetSendingAlertTiming();
        /// <summary>
        /// filter criteria to schedule an alert
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<SendingAlertSchedule> GetSendingAlertSchedule();
        /// <summary>
        /// filter criteria to schedule an alert
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<SendingAlertVia> GetSendingAlertVia();
    }
}
