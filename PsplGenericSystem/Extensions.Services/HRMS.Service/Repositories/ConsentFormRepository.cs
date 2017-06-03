using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using System.Data;
using HRMS.Service.Models.EDM;


namespace HRMS.Service.Repositories
{
    public class ConsentFormRepository : IConsentFormRepository
    {
        public bool CreateOnBoarding(DataTable consentDocTable, OnBoarding onBoardingobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_OnBoardingInsert(onBoardingobj.OnBoardingName, onBoardingobj.CompanyId, output);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ConsentForms> SelectAllConsentFormByCompanyId(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstConsentFormResult = hrmsEntity.usp_ConsentFormsSelectAll(companyId).ToList();
                    return lstConsentFormResult.Select(consentform => new ConsentForms
                    {
                        ConsentFormId = consentform.ConsentFormId,
                        // ConsentCode = consentform.ConsentCode,
                   
                        ConsentType = consentform.ConsentType,
                        CompanyId = consentform.CompanyId,
                        Description = consentform.Description,
                        Active = consentform.Active,
                        AttachmentFileId = consentform.AttachmentFileId,
                        DisplayDocInConsent = consentform.DisplayDocInConsent,
                        EnableUploadLink = consentform.EnableUploadLink,
                        DocumentName = consentform.DocumentName,
                        UploadedOn = consentform.UploadedOn,
                        CreatedBy = consentform.CreatedBy
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ConsentForms> SelectConsentFormById(int consentFormId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstConsentFormResult = hrmsEntity.usp_ConsentFormsSelect(consentFormId, companyId).ToList();
                    return lstConsentFormResult.Select(consentform => new ConsentForms
                    {
                        ConsentFormId = consentform.ConsentFormId
                            // , ConsentCode = consentform.ConsentCode
                        ,
                       
                        ConsentType = consentform.ConsentType,
                        CompanyId = consentform.CompanyId,
                        Description = consentform.Description,
                        Active = consentform.Active,
                        AttachmentFileId = consentform.AttachmentFileId,
                        DisplayDocInConsent = consentform.DisplayDocInConsent,
                        EnableUploadLink = consentform.EnableUploadLink,
                        DocumentName = consentform.DocumentName,
                        UploadedOn = consentform.UploadedOn,
                        CreatedBy = consentform.CreatedBy
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateConsentFormById(ConsentForms consentFormobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ConsentFormsUpdate(consentFormobj.ConsentFormId, consentFormobj.CompanyId, consentFormobj.ConsentCode, 
                                 consentFormobj.ConsentType, consentFormobj.DocumentName, consentFormobj.Description, consentFormobj.Active1, consentFormobj.DisplayDocInConsent1, consentFormobj.EnableUploadLink1
                                , consentFormobj.ModifiedBy);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ConsentForms> SelectConsentFormsByOnBoardingId(int onBoardingId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstResult = hrmsEntity.usp_SelectConsentFormsByOnBoardingId(onBoardingId, companyId).ToList();
                    return lstResult.Select(consentform => new ConsentForms
                    {                        
                        AttachmentFileId = consentform.AttachmentFileId,
                        ConsentFormId = consentform.ConsentFormId,
                        DocumentName = consentform.DocumentName,
                        Active=consentform.Active,
                        DisplayDocInConsent=consentform.DisplayDocInConsent,
                        Description=consentform.Description,
                        EnableUploadLink=consentform.EnableUploadLink                                          
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<ConsentForms> SelectConsentFormsByUserId(int userId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstResult = hrmsEntity.usp_SelectConsentFormsByUserId(userId, companyId).ToList();
                    return lstResult.Select(consentforms => new ConsentForms
                    {
                        AttachmentFileId = consentforms.AttachmentFileId,
                        ConsentFormId = consentforms.ConsentFormId,
                        DocumentName = consentforms.DocumentName,
                        EmployeeSignId = consentforms.EmployeeSignId,
                        IsSigned = consentforms.IsSigned
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool CreateConsentForm(ConsentForms consentFormobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                  
                    var result = hrmsEntity.usp_ConsentFormsInsert(consentFormobj.CompanyId,  consentFormobj.ConsentType, consentFormobj.Description
                        , consentFormobj.Active, consentFormobj.AttachmentFileId, consentFormobj.DisplayDocInConsent, consentFormobj.EnableUploadLink, consentFormobj.DocumentName
                        , consentFormobj.UploadedOn, consentFormobj.CreatedOn, consentFormobj.ModifiedOn, consentFormobj.CreatedBy, consentFormobj.ModifiedBy);
                    return result >0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateEmployeeSignId(ConsentForms consentFormobj)
        {
            var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ConsentFormsUpdateSignFileId(consentFormobj.ConsentFormId, consentFormobj.CompanyId, consentFormobj.EmployeeSignId, output).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
