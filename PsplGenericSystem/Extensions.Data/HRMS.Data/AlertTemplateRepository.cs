using HRMS.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Data
{
    public class AlertTemplateRepository : IAlertTemplateRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public class AlertTemplateFields
        {
            public const string AlertTemplateId = "AlertTemplateId";
            public const string AlertTemplateCode = "AlertTemplateCode";
            public const string AlertTemplateName = "AlertTemplateName";
            public const string AlertTemplateSubject = "AlertTemplateSubject";
            public const string AlertTemplateBody = "AlertTemplateBody";
            public const string CompanyId = "CompanyId";
            public const string AttachmentId = "AttachmentId";
            public const string IsAcknowledgementRequired = "IsAcknowledgementRequired";
            public const string FromAddress = "FromAddress";
            public const string AlertSendCriteriaId = "AlertSendCriteriaId";
            public const string Status = "Status";
            public const string CreatedBy = "CreatedBy";
            public const string ModifiedBy = "ModifiedBy";
            public const string CreatedOn = "CreatedOn";
            public const string ModifiedOn = "ModifiedOn";
            public const string AcknowledgementDescription = "AcknowledgementDescription";
        }
        public int AddAlertTemplate(AlertTemplate alertTemplateDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@AlertTemplateName", alertTemplateDetailobj.AlertTemplateName);
                _oDatabaseHelper.AddParameter("@AlertTemplateSubject", alertTemplateDetailobj.AlertTemplateSubject);
                _oDatabaseHelper.AddParameter("@AlertTemplateBody", alertTemplateDetailobj.AlertTemplateBody);
                _oDatabaseHelper.AddParameter("@CompanyId", alertTemplateDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@AttachmentId", alertTemplateDetailobj.AttachmentId);
                _oDatabaseHelper.AddParameter("@IsAcknowledgementRequired", alertTemplateDetailobj.IsAcknowledgementRequired);
                _oDatabaseHelper.AddParameter("@AcknowledgementDescription", alertTemplateDetailobj.AcknowledgementDescription);
                _oDatabaseHelper.AddParameter("@FromAddress", alertTemplateDetailobj.FromAddress);
                _oDatabaseHelper.AddParameter("@AlertSendCriteriaId", alertTemplateDetailobj.AlertSendCriteriaId);
                _oDatabaseHelper.AddParameter("@Status", alertTemplateDetailobj.Status);
                _oDatabaseHelper.AddParameter("@CreatedBy", alertTemplateDetailobj.CreatedBy);
                _oDatabaseHelper.AddParameter("@SendTo", alertTemplateDetailobj.SendTo);
                _oDatabaseHelper.AddParameter("@AlertTemplateId", -1, System.Data.ParameterDirection.Output);
                Convert.ToInt32(_oDatabaseHelper.ExecuteScalar("HumanResources.usp_AlertTemplateInsert", ref executionState));
                int alertTemplateId = (Int32)_oDatabaseHelper.Command.Parameters["@AlertTemplateId"].Value;
                return alertTemplateId;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public AlertTemplate SelectAlertTemplateById(int alertTemplateId, int companyId)
        {
            try
            {
                var alertTemplateDetailobj = new AlertTemplate();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                _oDatabaseHelper.AddParameter("@AlertTemplateId", alertTemplateId);
                IDataReader alertTemplaterdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_AlertTemplateSelect", ref executionState);
                while (alertTemplaterdr.Read())
                {
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateId)))
                        alertTemplateDetailobj.AlertTemplateId = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateId));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AcknowledgementDescription)))
                        alertTemplateDetailobj.AcknowledgementDescription = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AcknowledgementDescription));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateName)))
                        alertTemplateDetailobj.AlertTemplateName = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateName));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateBody)))
                        alertTemplateDetailobj.AlertTemplateBody = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateBody));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateSubject)))
                        alertTemplateDetailobj.AlertTemplateSubject = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateSubject));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.CompanyId)))
                        alertTemplateDetailobj.CompanyId = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.CompanyId));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AttachmentId)))
                        alertTemplateDetailobj.AttachmentId = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AttachmentId));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.IsAcknowledgementRequired)))
                        alertTemplateDetailobj.IsAcknowledgementRequired = alertTemplaterdr.GetBoolean(alertTemplaterdr.GetOrdinal(AlertTemplateFields.IsAcknowledgementRequired));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.FromAddress)))
                        alertTemplateDetailobj.FromAddress = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.FromAddress));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertSendCriteriaId)))
                        alertTemplateDetailobj.AlertSendCriteriaId = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertSendCriteriaId));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.Status)))
                        alertTemplateDetailobj.Status = alertTemplaterdr.GetBoolean(alertTemplaterdr.GetOrdinal(AlertTemplateFields.Status));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.CreatedBy)))
                        alertTemplateDetailobj.CreatedBy = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.CreatedBy));
                }
                alertTemplaterdr.Close();
                return alertTemplateDetailobj;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public bool UpdateAlertTemplate(AlertTemplate alertTemplateDetailobj)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@AlertTemplateId", alertTemplateDetailobj.AlertTemplateId);
                _oDatabaseHelper.AddParameter("@AlertTemplateName", alertTemplateDetailobj.AlertTemplateName);
                _oDatabaseHelper.AddParameter("@AlertTemplateSubject", alertTemplateDetailobj.AlertTemplateSubject);
                _oDatabaseHelper.AddParameter("@AlertTemplateBody", alertTemplateDetailobj.AlertTemplateBody);
                _oDatabaseHelper.AddParameter("@CompanyId", alertTemplateDetailobj.CompanyId);
                _oDatabaseHelper.AddParameter("@AttachmentId", alertTemplateDetailobj.AttachmentId);
                _oDatabaseHelper.AddParameter("@IsAcknowledgementRequired", alertTemplateDetailobj.IsAcknowledgementRequired);
                _oDatabaseHelper.AddParameter("@AcknowledgementDescription", alertTemplateDetailobj.AcknowledgementDescription);
                _oDatabaseHelper.AddParameter("@FromAddress", alertTemplateDetailobj.FromAddress);
                _oDatabaseHelper.AddParameter("@AlertSendCriteriaId", alertTemplateDetailobj.AlertSendCriteriaId);
                _oDatabaseHelper.AddParameter("@Status", alertTemplateDetailobj.Status);
                _oDatabaseHelper.AddParameter("@ModifiedBy", alertTemplateDetailobj.ModifiedBy);
                _oDatabaseHelper.AddParameter("@SendTo", alertTemplateDetailobj.SendTo);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_AlertTemplateUpdate", ref executionState);
                return executionState;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public bool DeleteAlertTemplate(int alertTemplateId, int companyId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@AlertTemplateId", alertTemplateId);
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_AlertTemplateDelete", ref executionState);
                _oDatabaseHelper.Dispose();
                return executionState;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public List<AlertTemplate> SelectAllAlertTemplate(int companyId)
        {
            try
            {
                var alertTemplateDetailList = new List<AlertTemplate>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@CompanyId", companyId);
                IDataReader alertTemplaterdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_AlertTemplateSelectAll", ref executionState);
                while (alertTemplaterdr.Read())
                {
                    var alertTemplateDetailobj = new AlertTemplate();
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateId)))
                        alertTemplateDetailobj.AlertTemplateId = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateId));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AcknowledgementDescription)))
                        alertTemplateDetailobj.AcknowledgementDescription = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AcknowledgementDescription));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateName)))
                        alertTemplateDetailobj.AlertTemplateName = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateName));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateSubject)))
                        alertTemplateDetailobj.AlertTemplateSubject = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertTemplateSubject));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.CompanyId)))
                        alertTemplateDetailobj.CompanyId = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.CompanyId));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AttachmentId)))
                        alertTemplateDetailobj.AttachmentId = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AttachmentId));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.IsAcknowledgementRequired)))
                        alertTemplateDetailobj.IsAcknowledgementRequired = alertTemplaterdr.GetBoolean(alertTemplaterdr.GetOrdinal(AlertTemplateFields.IsAcknowledgementRequired));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.FromAddress)))
                        alertTemplateDetailobj.FromAddress = alertTemplaterdr.GetString(alertTemplaterdr.GetOrdinal(AlertTemplateFields.FromAddress));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertSendCriteriaId)))
                        alertTemplateDetailobj.AlertSendCriteriaId = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.AlertSendCriteriaId));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.Status)))
                        alertTemplateDetailobj.Status = alertTemplaterdr.GetBoolean(alertTemplaterdr.GetOrdinal(AlertTemplateFields.Status));
                    if (!alertTemplaterdr.IsDBNull(alertTemplaterdr.GetOrdinal(AlertTemplateFields.CreatedBy)))
                        alertTemplateDetailobj.CreatedBy = alertTemplaterdr.GetInt32(alertTemplaterdr.GetOrdinal(AlertTemplateFields.CreatedBy));
                    alertTemplateDetailList.Add(alertTemplateDetailobj);
                }
                alertTemplaterdr.Close();
                return alertTemplateDetailList;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public bool AddAlertEmployee(int alertTemplateId, int employeeId, bool status, string employeeEmail, string employeeName)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@AlertTemplateId", alertTemplateId);
                _oDatabaseHelper.AddParameter("@EmployeeId", employeeId);
                _oDatabaseHelper.AddParameter("@Status", status);
                _oDatabaseHelper.AddParameter("@EmployeeEmail", employeeEmail);
                _oDatabaseHelper.AddParameter("@EmployeeName", employeeName);
                _oDatabaseHelper.AddParameter("@ErrorCode", -1, System.Data.ParameterDirection.Output);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeAlertInsert", ref executionState);
                return executionState;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
        public bool SaveAlertCriteria(int alertSendCriteriaId, int alertTemplateId, int selectedId)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@AlertSendCriteriaId", alertSendCriteriaId);
                _oDatabaseHelper.AddParameter("@AlertTemplateId", alertTemplateId);
                _oDatabaseHelper.AddParameter("@SelectedId", selectedId);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_AlertCriteriaSaveLogInsert", ref executionState);
                return executionState;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _oDatabaseHelper.Dispose();
            }
        }
    }
}
