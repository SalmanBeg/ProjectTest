using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkExtras.EF6;
using HRMS.Service;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtensionProc;

namespace HRMS.Service.Repositories
{
    public class OnBoardingRepository:IOnBoardingRepository
    {
        public bool CreateOnBoarding(OnBoarding onBoardingobj, List<ConsentForms>consentDocList)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var proc = new ExtendedStoredProcedures.UspInsertOnBoardingConsentDocument()
                          {
                              companyId = onBoardingobj.CompanyId,
                              OnBoardingName = onBoardingobj.OnBoardingName,
                              errorCode = null,
                              UdtConsentDoc = consentDocList.Select(consentForms => new ExtendedStoredProcedures.UdtConsentDoc
                              {
                                  ConsentdocId = consentForms.ConsentFormId
                              }).ToList()
                          };

                    hrmsEntity.Database.ExecuteStoredProcedure(proc);
                    return true; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<OnBoarding> SelectAllOnBoardingByCompanyId(int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstOnBoardingResult = hrmsEntity.usp_OnBoardingSelectAll(companyId).ToList();
                    var onboardingList = lstOnBoardingResult.Select(onboarding => new OnBoarding
                    {
                        OnBoardingId = onboarding.OnBoardingId,
                        OnBoardingCode = onboarding.OnBoardingCode,
                        OnBoardingName = onboarding.OnBoardingName,
                        CompanyId = onboarding.CompanyId,
                        Active = onboarding.Active
                    }).ToList();

                    return onboardingList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }
        public List<OnBoarding> SelectOnBoardingByOnBoardingId(int onBoardingId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstOnBoardingResult = hrmsEntity.usp_OnBoardingSelect(onBoardingId).ToList();
                    var onboardingList = lstOnBoardingResult.Select(onboarding => new OnBoarding
                    {
                        OnBoardingId = onboarding.OnBoardingId,
                        OnBoardingCode = onboarding.OnBoardingCode,
                        OnBoardingName = onboarding.OnBoardingName,
                        CompanyId = onboarding.CompanyId,
                        Active = onboarding.Active
                    }).ToList();
                    return onboardingList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public bool DeleteOnBoarding(int onBoardingId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_OnBoardingDelete(onBoardingId);
                    hrmsEntity.Dispose();
                    return result > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public bool DeleteConsentForm(int consentFormId)
        {
            try
            {
                using(var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ConsentFormDelete(consentFormId);                   
                    return result > 0;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
