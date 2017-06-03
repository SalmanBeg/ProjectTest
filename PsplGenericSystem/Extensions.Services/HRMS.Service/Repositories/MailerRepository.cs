using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System.Net;
using System.Net.Mail;
using System.Net.Configuration;
using System.Web;
using System.Web.Configuration;

namespace HRMS.Service.Repositories
{
    public class MailerRepository : IMailerRepository
    {
        public List<AlertTemplate> GetMailDetailsByStatus(bool status)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstAlertTemplateResult = hrmsEntity.usp_EmployeeAlertSelect(status).ToList();
                    return lstAlertTemplateResult.Select(alertTemplate => new AlertTemplate
                    {
                        AlertTemplateId = alertTemplate.AlertTemplateId,
                        AlertTemplateName = alertTemplate.AlertTemplateName,
                        AlertTemplateBody = alertTemplate.AlertTemplateBody,
                        AlertTemplateSubject = alertTemplate.AlertTemplateSubject,
                        EmployeeId = alertTemplate.EmployeeId,
                        CompanyId = alertTemplate.CompanyId,
                        Email = alertTemplate.EmployeeEmail,
                        Status = alertTemplate.Status,
                        ScheduleValue = alertTemplate.ScheduleValue,
                        CriteriaCondition = alertTemplate.CriteriaCondition,
                        CriteriaDuration = alertTemplate.CriteriaDuration,
                        CriteriaValue = alertTemplate.CriteriaValue,
                        CriteriaTiming = alertTemplate.CriteriaTiming,
                        CustomDate = alertTemplate.CustomDate,
                        CountToSend = alertTemplate.CountToSend,
                        SendVia = alertTemplate.SendVia
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public Boolean sendEmailWithCredentials(string _To, string _Subject, string _Message)
        {
            try
            {
                try
                {
                    string overrideTo = ConfigurationManager.AppSettings["DebugEmail"];
                    if (overrideTo != null && overrideTo.Length > 3)
                    {
                        _To = overrideTo;
                    }
                }
                catch (Exception) { }

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
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateEmployeeAlertStatus(string email, int employeeId, bool status)
        {
           
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeAlertUpdate(email, employeeId, status);
                    return result > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
