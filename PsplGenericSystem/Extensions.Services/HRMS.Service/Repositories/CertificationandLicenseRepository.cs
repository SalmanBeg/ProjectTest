using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class CertificationandLicenseRepository : ICertificationandLicenseRepository
    {
        /// <summary>
        /// inserting an individual certification and license record.
        /// </summary>
        /// <param name="certificationandLicenseobj"></param>
        /// <returns>boolean if true inserted or if false not inserted</returns>
        public bool InsertCertificationandLicense(CertificationandLicense certificationandLicenseobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_CertificationLicensesInsert(certificationandLicenseobj.CompanyId,certificationandLicenseobj.UserId, certificationandLicenseobj.Type, certificationandLicenseobj.Name
                               , certificationandLicenseobj.Certification, certificationandLicenseobj.LicenseNumber, certificationandLicenseobj.LicenseCountry
                               , certificationandLicenseobj.LicenseState, certificationandLicenseobj.School, certificationandLicenseobj.Endorsements, certificationandLicenseobj.Areas, certificationandLicenseobj.FileName
                               , certificationandLicenseobj.Document, certificationandLicenseobj.IssueDate, certificationandLicenseobj.RenewalDate
                               , certificationandLicenseobj.ExpirationDate, certificationandLicenseobj.CreatedBy, certificationandLicenseobj.CreatedOn);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// updating an existing certification and license record
        /// </summary>
        /// <param name="certificationandLicenseobj"></param>
        /// <returns>boolean after successful operation</returns>
        public bool UpdateCertificationandLicense(CertificationandLicense certificationandLicenseobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_CertificationLicensesUpdate(certificationandLicenseobj.CompanyId, certificationandLicenseobj.UserId, certificationandLicenseobj.CertificationLicensesId
                                , certificationandLicenseobj.Type, certificationandLicenseobj.Name, certificationandLicenseobj.Certification
                                , certificationandLicenseobj.LicenseNumber, certificationandLicenseobj.LicenseCountry, certificationandLicenseobj.LicenseState
                                , certificationandLicenseobj.School, certificationandLicenseobj.Endorsements, certificationandLicenseobj.Areas
                                , certificationandLicenseobj.Document, certificationandLicenseobj.IssueDate, certificationandLicenseobj.RenewalDate
                                , certificationandLicenseobj.ExpirationDate, certificationandLicenseobj.CreatedBy, certificationandLicenseobj.ModifiedBy);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// to delete an record from records
        /// </summary>
        /// <param name="certificationLicensesId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteCertificationandLicense(int certificationLicensesId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_CertificationLicensesDelete(certificationLicensesId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// to list all the certification and licenses for a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns>collection of list</returns>
        public List<CertificationandLicense> SelectAllCertificationandLicense(int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CertificationLicensesSelectAll_Result> lstCertificationLicensesResult = hrmsEntity.usp_CertificationLicensesSelectAll(userId).ToList();
                    return lstCertificationLicensesResult.Select(certificationandLicenseObj => new CertificationandLicense
                    {
                        CertificationLicensesId = certificationandLicenseObj.CertificationLicensesId,
                        CertificationType=certificationandLicenseObj.CertificationType,
                        FileName = certificationandLicenseObj.FileName,
                        Document = certificationandLicenseObj.Document,
                        CertificationLicensesCode = certificationandLicenseObj.CertificationLicensesCode,
                        CompanyId = certificationandLicenseObj.CompanyId,
                        Type = certificationandLicenseObj.Type,
                        Name = certificationandLicenseObj.Name,
                        Certification = certificationandLicenseObj.Certification,
                        LicenseNumber = certificationandLicenseObj.LicenseNumber,
                        LicenseCountry = certificationandLicenseObj.LicenseCountry,
                        LicenseState = certificationandLicenseObj.LicenseState,
                        School = certificationandLicenseObj.School,
                        Endorsements = certificationandLicenseObj.Endorsements,
                        Areas = certificationandLicenseObj.Areas,
                        IssueDate = certificationandLicenseObj.IssueDate,
                        RenewalDate = certificationandLicenseObj.RenewalDate,
                        ExpirationDate = certificationandLicenseObj.ExpirationDate,
                        CreatedOn = certificationandLicenseObj.CreatedOn,
                        ModifiedOn = certificationandLicenseObj.ModifiedOn,
                        UserId=certificationandLicenseObj.UserId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
         public List<CertificationandLicense> SelectCertificationandLicense(int companyId,int CertificationLicensesId)
        {
             try
             {
                 using (var hrmsEntity = new HRMSEntities1())
                 {
                     List<usp_CertificationLicensesSelect_Result> lstCertificationLicensesResult = hrmsEntity.usp_CertificationLicensesSelect(companyId, CertificationLicensesId).ToList();
                     return lstCertificationLicensesResult.Select(certificationandLicenseObj => new CertificationandLicense
                     {
                        CertificationLicensesId = certificationandLicenseObj.CertificationLicensesId,
                         UserId = certificationandLicenseObj.UserId,
                        CertificationType=certificationandLicenseObj.CertificationType,
                        FileName = certificationandLicenseObj.FileName,
                        Document = certificationandLicenseObj.Document,
                        CertificationLicensesCode = certificationandLicenseObj.CertificationLicensesCode,
                        CompanyId = certificationandLicenseObj.CompanyId,
                        Type = certificationandLicenseObj.Type,
                        Name = certificationandLicenseObj.Name,
                        Certification = certificationandLicenseObj.Certification,
                        LicenseNumber = certificationandLicenseObj.LicenseNumber,
                        LicenseCountry = certificationandLicenseObj.LicenseCountry,
                        LicenseState = certificationandLicenseObj.LicenseState,
                        School = certificationandLicenseObj.School,
                        Endorsements = certificationandLicenseObj.Endorsements,
                        Areas = certificationandLicenseObj.Areas,
                        IssueDate = certificationandLicenseObj.IssueDate,
                        RenewalDate = certificationandLicenseObj.RenewalDate,
                        ExpirationDate = certificationandLicenseObj.ExpirationDate,
                        CreatedOn = certificationandLicenseObj.CreatedOn,
                        ModifiedOn = certificationandLicenseObj.ModifiedOn
                       
                     }).ToList();
                 }
             }
             catch(Exception)
             {
                 throw;
             }
        }
    }
}
