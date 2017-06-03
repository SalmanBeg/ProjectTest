using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public interface IConsentFormRepository
    {
       bool CreateOnBoarding(DataTable consentDocTable, OnBoarding onBoardingobj) ;

       List<ConsentForm> SelectAllConsentFormByCompanyId(int companyId);

       List<ConsentForm> SelectConsentFormById(int attachmentFileId, int companyId);

       bool UpdateConsentFormById(ConsentForm consentFormobj);

       List<ConsentForm> SelectConsentFormsByOnBoardingId(int onBoardingId, int CompanyId);

       List<ConsentForm> SelectConsentFormsByUserId(int userId, int companyId);
    }
}
