using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class ScreenVerbiageRepository : IScreenVerbiageRepository
    {
        public ScreenVerbiage SelectScreenVerbiage(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstResult = hrmsEntity.usp_ScreenVerbiageSelect(companyId);
                    var screenVerbiageList = lstResult.Select(screenVerbiageobj => new ScreenVerbiage
                    {
                        CompanyId = screenVerbiageobj.CompanyId,
                        HireWizardWelcomeText = screenVerbiageobj.HireWizardWelcomeText,
                        HireWizardSubmitText = screenVerbiageobj.HireWizardSubmitText,
                        HireWizardApprovalText = screenVerbiageobj.HireWizardApprovalText
                    }).ToList();
                    return screenVerbiageList.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool InsertScreenVerbiage(ScreenVerbiage screenVerbiageObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ScreenVerbiageInsert(screenVerbiageObj.CompanyId, screenVerbiageObj.HireWizardWelcomeText, screenVerbiageObj.HireWizardSubmitText
                                  , screenVerbiageObj.HireWizardApprovalText);

                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateScreenVerbiage(ScreenVerbiage screenVerbiageObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ScreenVerbiageUpdate(screenVerbiageObj.CompanyId, screenVerbiageObj.HireWizardWelcomeText
                                , screenVerbiageObj.HireWizardSubmitText, screenVerbiageObj.HireWizardApprovalText);

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


