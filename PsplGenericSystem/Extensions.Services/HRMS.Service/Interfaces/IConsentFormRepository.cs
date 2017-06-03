using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;
using System.Data;

namespace HRMS.Service.Interfaces
{
    public interface IConsentFormRepository
    {
        /// <summary>
        /// View to add a new onboarding profile record with consent documents
        /// </summary>
        /// <param name="consentDocTable"></param>
        /// <param name="onBoardingobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
         bool CreateOnBoarding(DataTable consentDocTable, OnBoarding onBoardingobj);
        /// <summary>
        /// view to show all  onbaording profile 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ConsentForms> SelectAllConsentFormByCompanyId(int companyId);
        /// <summary>
        /// to show consent form by consent form Id
        /// </summary>
        /// <param name="consentFormId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ConsentForms> SelectConsentFormById(int consentFormId, int companyId);
        /// <summary>
        /// View to update existing record of consent document record
        /// </summary>
        /// <param name="consentFormobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
         bool UpdateConsentFormById(ConsentForms consentFormobj);
        /// <summary>
        ///  Method to return to consent name
        /// </summary>
        /// <param name="onBoardingId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ConsentForms> SelectConsentFormsByOnBoardingId(int onBoardingId, int companyId);
        /// <summary>
        /// to show consent form by user Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ConsentForms> SelectConsentFormsByUserId(int userId, int companyId);
        /// <summary>
        /// to create new consent form 
        /// </summary>
        /// <param name="consentFormobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool CreateConsentForm(ConsentForms consentFormobj);
        /// <summary>
        /// to update employee sign by for an individaul consent form
        /// </summary>
        /// <param name="consentFormobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateEmployeeSignId(ConsentForms consentFormobj);
    }
}
