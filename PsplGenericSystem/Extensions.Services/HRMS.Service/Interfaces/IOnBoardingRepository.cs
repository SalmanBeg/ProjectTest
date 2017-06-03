using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
  public interface IOnBoardingRepository
    {
      [Logger]
      [ExceptionLogger]
      List<OnBoarding> SelectAllOnBoardingByCompanyId(int companyId);

      [Logger]
      [ExceptionLogger]
      List<OnBoarding> SelectOnBoardingByOnBoardingId(int onBoardingId);

      [Logger]
      [ExceptionLogger]
      bool DeleteOnBoarding(int onBoardingId);

      [Logger]
      [ExceptionLogger]
      bool DeleteConsentForm(int consentFormId);

      [Logger]
      [ExceptionLogger]
      bool CreateOnBoarding(OnBoarding onBoardingobj, List<ConsentForms> consentDocList);
    }
}
