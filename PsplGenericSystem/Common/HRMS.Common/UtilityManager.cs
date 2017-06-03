using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web.Configuration;

namespace HRMS.Common
{
    public class UtilityManager
    {
        public static Boolean sendEmailWithCredentials(string _To, string _From, string _Subject, string _Cc, string _Bcc,string _Message, string _DisplayName, string Signature)
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
                if (_From == string.Empty) _From = mailSettings.Smtp.From;

                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                string str = "noreply@HRMS.com";

                MailAddress _FromADD = new MailAddress(str, "HRMS");
                message.From = _FromADD;
                message.To.Add(_To);
                message.Subject = _Subject;
                message.Body = _Message;
                message.IsBodyHtml = true;
                
                using (var mySMTPclient = new System.Net.Mail.SmtpClient(host, port))
                {
                    NetworkCredential userCredentials = new NetworkCredential(username, password);
                    mySMTPclient.UseDefaultCredentials = false;
                    mySMTPclient.Credentials = userCredentials;

                    mySMTPclient.EnableSsl = SSL;
                    mySMTPclient.Send(message);
                }

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    EventLog.WriteEntry("ASP.NET 4.0.30319.0", ex.ToString(), EventLogEntryType.Error);
                }
                catch (Exception e)
                {
                }
                return false;
            }
        }



        //// public static Boolean sendEmailWithAttachments(string _To, string _From, string _Subject, string _Cc, string _Bcc,string _Message, string _DisplayName, string Signature,Attachment File)
        ////{
        ////    try
        ////    {
        ////        try
        ////        {
        ////            string overrideTo = ConfigurationManager.AppSettings["DebugEmail"];
        ////            if (overrideTo != null && overrideTo.Length > 3)
        ////            {
        ////                _To = overrideTo;
        ////            }
        ////        }
        ////        catch (Exception ex) { }

        ////        #region Email code using credentials

        ////        int port = -1;
        ////        string host = string.Empty;
        ////        string password = string.Empty;
        ////        string username = string.Empty;
        ////        bool SSL = false;
        ////        Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration("~/Web.config");
        ////        MailSettingsSectionGroup mailSettings =
        ////            configurationFile.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
        ////        if (mailSettings != null)
        ////        {
                 
        ////            port = mailSettings.Smtp.Network.Port;
        ////            host = mailSettings.Smtp.Network.Host;
        ////            password = mailSettings.Smtp.Network.Password;
        ////            username = mailSettings.Smtp.Network.UserName;
        ////            SSL = mailSettings.Smtp.Network.EnableSsl;
        ////        }
        ////        if (_From == string.Empty) _From = mailSettings.Smtp.From;

        ////        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

        ////        string str = "noreply@HRMS.com";

        ////        MailAddress _FromADD = new MailAddress(str, "HRMS");
        ////        message.From = _FromADD;
        ////        message.To.Add(_To);
        ////        message.Subject = _Subject;
        ////        message.Body = _Message;
        ////        message.IsBodyHtml = true;
        ////        message.Attachments = File;
                
        ////        using (var mySMTPclient = new System.Net.Mail.SmtpClient(host, port))
        ////        {
        ////            NetworkCredential userCredentials = new NetworkCredential(username, password);
        ////            mySMTPclient.UseDefaultCredentials = false;
        ////            mySMTPclient.Credentials = userCredentials;

        ////            mySMTPclient.EnableSsl = SSL;
        ////            mySMTPclient.Send(message);
        ////        }

        ////        #endregion

        ////        return true;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        try
        ////        {
        ////            EventLog.WriteEntry("ASP.NET 4.0.30319.0", ex.ToString(), EventLogEntryType.Error);
        ////        }
        ////        catch (Exception e)
        ////        {
        ////        }
        ////        return false;
        ////    }
        ////}
    
    }
}
