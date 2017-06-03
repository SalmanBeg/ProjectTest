using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Configuration;
using HRMS.BusinessLayer;
using System.Net.Configuration;
using System.Data;

namespace HRMS.Data
{
    public class MailerRepository : IMailerRepository
    {
        private DatabaseHelper _oDatabaseHelper = new DatabaseHelper();
        public Boolean sendEmailWithCredentials(string _To, string _Subject,
                                       string _Message)
        {
            try
            {
                try
                {
                    string overrideTo = System.Configuration.ConfigurationManager.AppSettings["DebugEmail"];
                    if (overrideTo != null && overrideTo.Length > 3)
                    {
                        _To = overrideTo;
                    }
                }
                catch (Exception ex) { }

                #region Email code using credentials

                int port = -1;
                string host = string.Empty;
                string password = string.Empty;
                string username = string.Empty;
                bool SSL = false;
                Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration("~/Web.config");
                MailSettingsSectionGroup mailSettings =
                    configurationFile.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
                if (mailSettings != null)
                {
                    port = mailSettings.Smtp.Network.Port;
                    host = mailSettings.Smtp.Network.Host;
                    password = mailSettings.Smtp.Network.Password;
                    username = mailSettings.Smtp.Network.UserName;
                    SSL = mailSettings.Smtp.Network.EnableSsl;
                }
                
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                string str = ConfigurationManager.AppSettings["fromEmail"];
                MailAddress _FromADD = new MailAddress(str, "PSPL");
                message.From = _FromADD;
                message.To.Add(_To);
                message.Subject = _Subject;
                // _Message += "<br><br>" + (Signature == string.Empty ? "With Regards " + "<br>" + Globals.gCompanyName+"." : Signature);
                message.Body = _Message;

                message.IsBodyHtml = true;

                //Attachment imgAtt = new Attachment(HttpContext.Current.Server.MapPath(("../all.png")));
                ////give it a content id that corresponds to the src we added in the body img tag
                //imgAtt.ContentId = "all.png";
                ////add the attachment to the email
                //message.Attachments.Add(imgAtt);

                using (var mySMTPclient = new System.Net.Mail.SmtpClient(host, port))
                {
                    NetworkCredential userCredetials = new NetworkCredential(username, password);
                    mySMTPclient.UseDefaultCredentials = false;
                    mySMTPclient.Credentials = userCredetials;

                    mySMTPclient.EnableSsl = SSL;
                    mySMTPclient.Send(message);
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<AlertTemplate> GetMailDetailsByStatus(bool status)
        {
            try
            {
                var alertTemplateDetailList = new List<AlertTemplate>();
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@Status", status);
                IDataReader alertDetailsrdr = _oDatabaseHelper.ExecuteReader("HumanResources.usp_EmployeeAlertSelect", ref executionState);
                while (alertDetailsrdr.Read())
                {
                    var alertTemplateDetailobj = new AlertTemplate();
                    if (!alertDetailsrdr.IsDBNull(alertDetailsrdr.GetOrdinal("AlertTemplateId")))
                        alertTemplateDetailobj.AlertTemplateId = alertDetailsrdr.GetInt32(alertDetailsrdr.GetOrdinal("AlertTemplateId"));
                    if (!alertDetailsrdr.IsDBNull(alertDetailsrdr.GetOrdinal("AlertTemplateName")))
                        alertTemplateDetailobj.AlertTemplateName = alertDetailsrdr.GetString(alertDetailsrdr.GetOrdinal("AlertTemplateName"));
                    if (!alertDetailsrdr.IsDBNull(alertDetailsrdr.GetOrdinal("AlertTemplateSubject")))
                        alertTemplateDetailobj.AlertTemplateSubject = alertDetailsrdr.GetString(alertDetailsrdr.GetOrdinal("AlertTemplateSubject"));
                    if (!alertDetailsrdr.IsDBNull(alertDetailsrdr.GetOrdinal("AlertTemplateBody")))
                        alertTemplateDetailobj.AlertTemplateBody = alertDetailsrdr.GetString(alertDetailsrdr.GetOrdinal("AlertTemplateBody"));
                    if (!alertDetailsrdr.IsDBNull(alertDetailsrdr.GetOrdinal("EmployeeEmail")))
                        alertTemplateDetailobj.Email = alertDetailsrdr.GetString(alertDetailsrdr.GetOrdinal("EmployeeEmail"));
                    if (!alertDetailsrdr.IsDBNull(alertDetailsrdr.GetOrdinal("EmployeeId")))
                        alertTemplateDetailobj.EmployeeId = alertDetailsrdr.GetInt32(alertDetailsrdr.GetOrdinal("EmployeeId"));
                    if (!alertDetailsrdr.IsDBNull(alertDetailsrdr.GetOrdinal("Status")))
                        alertTemplateDetailobj.Status = alertDetailsrdr.GetBoolean(alertDetailsrdr.GetOrdinal("Status"));
                    alertTemplateDetailList.Add(alertTemplateDetailobj);
                }
                alertDetailsrdr.Close();
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
        public bool UpdateEmployeeAlertStatus(string email, int employeeId,bool status)
        {
            try
            {
                bool executionState = false;
                _oDatabaseHelper = new DatabaseHelper();
                _oDatabaseHelper.AddParameter("@EmployeeEmail", email);
                _oDatabaseHelper.AddParameter("@EmployeeId", employeeId);
                _oDatabaseHelper.AddParameter("@Status", status);
                _oDatabaseHelper.ExecuteScalar("HumanResources.usp_EmployeeAlertUpdate", ref executionState);
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
