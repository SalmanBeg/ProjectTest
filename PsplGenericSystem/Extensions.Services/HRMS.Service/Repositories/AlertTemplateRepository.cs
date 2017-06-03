using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class AlertTemplateRepository : IAlertTemplateRepository
    {
        /// <summary>
        /// inserting a ne alert for a company
        /// </summary>
        /// <param name="alertTemplateObj"></param>
        /// <returns>alert id</returns>
        public int AddAlertTemplate(AlertTemplate alertTemplateObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("AlertTemplateId", typeof(int));
                    var alertTemplateId = hrmsEntity.usp_AlertTemplateInsert(alertTemplateObj.CompanyId, alertTemplateObj.AlertTemplateName,
                        alertTemplateObj.AlertTemplateSubject, alertTemplateObj.AlertTemplateBody,
                        alertTemplateObj.AttachmentId, alertTemplateObj.IsAcknowledgementRequired,
                        alertTemplateObj.AcknowledgementDescription, alertTemplateObj.FromAddress,
                        alertTemplateObj.AlertSendCriteriaId, alertTemplateObj.Status, alertTemplateObj.SendTo,
                        alertTemplateObj.ScheduleValue, alertTemplateObj.CriteriaValue, alertTemplateObj.CriteriaDuration,
                        alertTemplateObj.CriteriaTiming, alertTemplateObj.CriteriaCondition, alertTemplateObj.CustomDate,
                        alertTemplateObj.CountToSend, alertTemplateObj.SendVia,
                        alertTemplateObj.CreatedBy, outputParam);
                    return Convert.ToInt32(outputParam.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// returning a result based on alertid and companyid
        /// </summary>
        /// <param name="alertTemplateId"></param>
        /// <param name="companyId"></param>
        /// <returns>a single alert</returns>
        public AlertTemplate SelectAlertTemplateById(int alertTemplateId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_AlertTemplateSelect_Result> lstAlertTemplateResult = hrmsEntity.usp_AlertTemplateSelect(alertTemplateId, companyId).ToList();

                    return lstAlertTemplateResult.Select(alerttemplate => new AlertTemplate
                    {
                        AlertTemplateId = alerttemplate.AlertTemplateId,
                        AcknowledgementDescription = alerttemplate.AcknowledgementDescription,
                        AlertTemplateName = alerttemplate.AlertTemplateName,
                        AlertTemplateBody = alerttemplate.AlertTemplateBody,
                        AlertTemplateSubject = alerttemplate.AlertTemplateSubject,
                        CompanyId = alerttemplate.CompanyId,
                        AttachmentId = alerttemplate.AttachmentId,
                        IsAcknowledgementRequired = alerttemplate.IsAcknowledgementRequired,
                        FromAddress = alerttemplate.FromAddress,
                        AlertSendCriteriaId = alerttemplate.AlertSendCriteriaId,
                        Status = alerttemplate.Status,
                        SendTo = alerttemplate.SendTo,
                        ScheduleValue = alerttemplate.ScheduleValue,
                        CriteriaValue = alerttemplate.CriteriaValue,
                        CriteriaTiming = alerttemplate.CriteriaTiming,
                        CriteriaDuration = alerttemplate.CriteriaDuration,
                        CriteriaCondition = alerttemplate.CriteriaCondition,
                        CountToSend = alerttemplate.CountToSend,
                        SendVia = alerttemplate.SendVia,
                        CreatedBy = alerttemplate.CreatedBy
                    }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// for updating an exiing alert
        /// </summary>
        /// <param name="alertTemplateObj"></param>
        /// <returns>boolean</returns>
        public bool UpdateAlertTemplate(AlertTemplate alertTemplateObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_AlertTemplateUpdate(alertTemplateObj.AlertTemplateId, alertTemplateObj.CompanyId, alertTemplateObj.AlertTemplateName,
                        alertTemplateObj.AlertTemplateSubject, alertTemplateObj.AlertTemplateBody,
                        alertTemplateObj.AttachmentId, alertTemplateObj.IsAcknowledgementRequired,
                        alertTemplateObj.AcknowledgementDescription, alertTemplateObj.FromAddress,
                        alertTemplateObj.AlertSendCriteriaId, alertTemplateObj.Status, alertTemplateObj.SendTo,
                        alertTemplateObj.ScheduleValue, alertTemplateObj.CriteriaValue, alertTemplateObj.CriteriaDuration,
                        alertTemplateObj.CriteriaTiming, alertTemplateObj.CriteriaCondition, alertTemplateObj.CustomDate,
                        alertTemplateObj.CountToSend, alertTemplateObj.SendVia,
                        alertTemplateObj.ModifiedBy, outputParam);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// for deleting an alert
        /// </summary>
        /// <param name="alertTemplateId"></param>
        /// <param name="companyId"></param>
        /// <returns>boolean if true deleted else false</returns>
        public bool DeleteAlertTemplate(int alertTemplateId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_AlertTemplateDelete(alertTemplateId, companyId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// returns all the alerts for a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>collectin of alerts ina company</returns>
        public List<AlertTemplate> SelectAllAlertTemplate(int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_AlertTemplateSelectAll_Result> lstAlertTemplateResult = hrmsEntity.usp_AlertTemplateSelectAll(companyId).ToList();

                    return lstAlertTemplateResult.Select(alerttemplate => new AlertTemplate
                    {
                        AlertTemplateId = alerttemplate.AlertTemplateId,
                        AcknowledgementDescription = alerttemplate.AcknowledgementDescription,
                        AlertTemplateName = alerttemplate.AlertTemplateName,
                        AlertTemplateBody = alerttemplate.AlertTemplateBody,
                        AlertTemplateSubject = alerttemplate.AlertTemplateSubject,
                        CompanyId = alerttemplate.CompanyId,
                        AttachmentId = alerttemplate.AttachmentId,
                        IsAcknowledgementRequired = alerttemplate.IsAcknowledgementRequired,
                        FromAddress = alerttemplate.FromAddress,
                        AlertSendCriteriaId = alerttemplate.AlertSendCriteriaId,
                        Status = alerttemplate.Status,
                        SendTo = alerttemplate.SendTo,
                        ScheduleValue = alerttemplate.ScheduleValue,
                        CriteriaValue = alerttemplate.CriteriaValue,
                        CriteriaTiming = alerttemplate.CriteriaTiming,
                        CriteriaDuration = alerttemplate.CriteriaDuration,
                        CriteriaCondition = alerttemplate.CriteriaCondition,
                        CountToSend = alerttemplate.CountToSend,
                        SendVia = alerttemplate.SendVia,
                        CreatedBy = alerttemplate.CreatedBy
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// based on the search criteria satisfied employee reocrds gets inserted to
        /// an intermediate table from where the service sends email whose status is not sent
        /// </summary>
        /// <param name="alertTemplateId"></param>
        /// <param name="employeeId"></param>
        /// <param name="status"></param>
        /// <param name="employeeEmail"></param>
        /// <param name="employeeName"></param>
        /// <returns>boolean</returns>
        public bool AddAlertEmployee(int alertTemplateId, int employeeId, bool status, string employeeEmail, string employeeName)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_EmployeeAlertInsert(alertTemplateId, employeeId, status, employeeEmail, employeeName, outputParam);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// for scheduling an alert based on condition
        /// </summary>
        /// <returns></returns>
        public List<SendingAlertCondition> GetSendingAlertCondition()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var query = (from sendingAlertCondition in hrmsEntity.SendingAlertConditions
                                 where sendingAlertCondition.CompanyId == 0
                                 select sendingAlertCondition).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// sending alert for schedule for a duration master records to fill duration dropdown 
        /// </summary>
        /// <returns></returns>
        public List<SendingAlertDuration> GetSendingAlertDuration()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var query = (from sendingAlertDuration in hrmsEntity.SendingAlertDurations
                                 where sendingAlertDuration.CompanyId == 0
                                 select sendingAlertDuration).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// sending alert for schedule for a duration master records to fill time dropdown  such as days,weeks etc..
        /// </summary>
        /// <returns></returns>
        public List<SendingAlertTiming> GetSendingAlertTiming()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var query = (from sendingAlertTiming in hrmsEntity.SendingAlertTimings
                                 where sendingAlertTiming.CompanyId == 0
                                 select sendingAlertTiming).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// sending alert for schedule for a duration master records to fill schedule dropdown in alerts screen
        /// </summary>
        /// <returns></returns>
        public List<SendingAlertSchedule> GetSendingAlertSchedule()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var query = (from sendingAlertSchedule in hrmsEntity.SendingAlertSchedules
                                 where sendingAlertSchedule.CompanyId == 0
                                 select sendingAlertSchedule).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// sending alert for schedule for a duration master records to fill communication via dropdown such as email,email&SMS
        /// </summary>
        /// <returns></returns>
        public List<SendingAlertVia> GetSendingAlertVia()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var query = (from sendingAlertVia in hrmsEntity.SendingAlertVias
                                 where sendingAlertVia.CompanyId == 0
                                 select sendingAlertVia).ToList();
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
