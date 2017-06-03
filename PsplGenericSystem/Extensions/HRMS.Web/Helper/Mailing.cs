using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using HRMS.Service.Interfaces;
using HRMS.Service.Repositories;
using HRMS.Service.Models.EDM;
using HRMS.Common.Helpers;
using System.Web.Mvc;

namespace HRMS.Web.Helper
{
    public class Mailing
    {

        #region Class Level Variables and Constructor
        private static readonly IMailingInfoRepository _mailingInfoRepository = new MailingInfoRepository();

        //public Mailing(IMailingInfoRepository mailingInfoRepository)
        //{
        //    _mailingInfoRepository = mailingInfoRepository;
        //}
        #endregion
        /// <summary>
        ///  Method to supply on employee creation with its credentials
       /// </summary>
       /// <param name="email"></param>
       /// <param name="subject"></param>
       /// <param name="senderName"></param>
       /// <param name="receiverName"></param>
       /// <param name="companyName"></param>
       /// <param name="messageBody"></param>
       /// <param name="redirectUrl"></param>
       /// <param name="mapPathInfo"></param>
       /// <param name="strLoginURL"></param>
       /// <param name="password"></param>
       /// <returns></returns>
        [Authorize]
        public static bool Sendemailtouser(string email, string subject, string senderName, string receiverName, string companyName, string messageBody, string redirectUrl, string mapPathInfo, string strLoginURL,string userName, string password,DateTime dateTime,string title,string companyAddress,string interviewDate,string interviewTime,string interviewType,string candidateInstructions,string interviewerInstructions)
        {
            try
            {
                string finalMessageBody;
                var sr = new StreamReader(mapPathInfo);
                sr = File.OpenText(mapPathInfo);
                string innerMessage = sr.ReadToEnd();
                sr.Dispose();
                innerMessage = innerMessage.Replace("|UserFullName|", receiverName);
                innerMessage = innerMessage.Replace("|LoginPage|", strLoginURL);
                innerMessage = innerMessage.Replace("|UserName|", userName);
                innerMessage = innerMessage.Replace("|Password|", password);
                innerMessage = innerMessage.Replace("|MessageBody|", messageBody);
                innerMessage = innerMessage.Replace("|CompanyName|", companyName);
                innerMessage = innerMessage.Replace("|Datetime|", dateTime.ToString());
                innerMessage = innerMessage.Replace("|Title|", title);
                innerMessage = innerMessage.Replace("|CompanyAddress|", companyAddress);
                innerMessage = innerMessage.Replace("|InterviewDate|", interviewDate);
                innerMessage = innerMessage.Replace("|InterviewTime|", interviewTime);
                innerMessage = innerMessage.Replace("|InterviewType|", interviewType);
                innerMessage = innerMessage.Replace("|CInstructions|", candidateInstructions);
                innerMessage = innerMessage.Replace("|IInstructions|", interviewerInstructions);
                finalMessageBody = innerMessage;

                var mailingInfoObj = new MailingInfo();
                mailingInfoObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                mailingInfoObj.MailFrom = companyName;
                mailingInfoObj.MailRecipientTo = email;
                mailingInfoObj.MailSubject = subject;
                mailingInfoObj.MailContent = finalMessageBody;
                mailingInfoObj.CreatedOn = dateTime;

                //int i= _mailingInfoRepository.CreateMailTemplate(mailingInfoObj);
                //return i > 0;
               return Common.UtilityManager.sendEmailWithCredentials(email, "", subject, "", "", finalMessageBody, "", "");
     

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Sendemailtouser(string email, string subject, string senderName, string receiverName, string companyName, string messageBody, string redirectUrl, string mapPathInfo, string strLoginURL, string userName, string password, DateTime dateTime, string title)
        {
          return  Sendemailtouser(email, subject, senderName, receiverName, companyName, messageBody, redirectUrl, mapPathInfo, strLoginURL, userName, password, dateTime, title,"","","","","","");
        }
    }
}