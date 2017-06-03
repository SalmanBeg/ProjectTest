using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkExtras.EF6;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtensionProc;

namespace HRMS.Service.Repositories
{
    public class I9WorkAuthorizationRepository : II9WorkAuthorizationRepository
    {

        public WorkAuthorization GetI9AuthorizationInfo(int userId)
        {
            //var hrmsEntity = new HRMSEntities1();
            //try
            //{
            //    List<I9FormSelect_Result> lstI9WorkauthorizationResult =hrmsEntity.I9FormSelect(userId).ToList();
            //    var i9Workauthorizationlist = lstI9WorkauthorizationResult.Select(i9Workauthorization => new I9WorkAuthorization
            //    {
            //        WorkAuthorizationID = i9Workauthorization.I9FormId, SignatureDate = i9Workauthorization.SignatureDate, TransactionID = i9Workauthorization.TransactionId, IPAddress = i9Workauthorization.IPAddress
            //    }).ToList();
            //    return i9Workauthorizationlist.SingleOrDefault();

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    hrmsEntity.Dispose();
            //}
            return new WorkAuthorization();
        }


        public List<LookUpDataEntity> GetI9AcceptableDocumentsInfo(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstResult = hrmsEntity.usp_I9AcceptableDocuments1SelectByCompanyID(companyId).ToList();

                    return lstResult.Select(i9Workauthorization => new LookUpDataEntity
                    {
                        Name = i9Workauthorization.Name,
                        CompanyId = i9Workauthorization.CompanyID,
                        Description = i9Workauthorization.Description,
                        Status = i9Workauthorization.Status,
                        TableName = i9Workauthorization.TableName
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int AddI9WorkAuthorizationDetails(WorkAuthorization WorkAuthorizationobj, List<WorkAuthorizationDocumentation> lstworkdoc)
        {


            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("WorkAuthId", typeof(int));
                    var proc = new ExtendedStoredProcedures.InsertUpdateFormI9ComplianceDetails()
                    {

                        WorkAuthorizationId = WorkAuthorizationobj.WorkAuthorizationId,
                        CompanyId = WorkAuthorizationobj.CompanyId,
                        UserId = WorkAuthorizationobj.UserId,
                        CitizenOfUS = WorkAuthorizationobj.CitizenOfUS,
                        AlienNumber = WorkAuthorizationobj.AlienNumber,
                        PermanentResidentExpire = WorkAuthorizationobj.PermanentResidentExpire,
                        AlienCitizenof = WorkAuthorizationobj.AlienCitizenof,
                        AlienAuthorisedDate = WorkAuthorizationobj.AlienAuthorisedDate,
                        AlienAutharisedCitizenof = WorkAuthorizationobj.AlienAuthorisedCitizenof,
                        CertificationDate = WorkAuthorizationobj.CertificationDate,
                        Attachment = WorkAuthorizationobj.Attachment,
                        AttachmentName = WorkAuthorizationobj.AttachmentName,
                        AttachmentType = WorkAuthorizationobj.AttachmentType,
                        AlienRegistrationNumber = WorkAuthorizationobj.AlienRegistrationNumber,
                        AdmissionNumber = WorkAuthorizationobj.AdmissionNumber,
                        PassportNumber = WorkAuthorizationobj.PassportNumber,
                        Countryof = WorkAuthorizationobj.Countryof,
                        ModifiedBy = WorkAuthorizationobj.ModifiedBy,
                        FederalLaw = WorkAuthorizationobj.FederalLaw,
                        IsSSN = WorkAuthorizationobj.IsSSN,
                        EmployeeSignId = WorkAuthorizationobj.EmployeeSignId,
                        EmployeeSignDate = WorkAuthorizationobj.EmployeeSignDate,
                        EmployerSignId = WorkAuthorizationobj.EmployerSignId,
                        UdtWorkAuthorizationDocumentation = lstworkdoc.Select(workdoc => new ExtendedStoredProcedures.UdtWorkAuthorizationDocumentation
                        {
                            WorkAuthorizationDocumentationTypeId = workdoc.WorkAuthorizationDocumentationTypeId,
                            WorkAuthorizationId = workdoc.WorkAuthorizationId,
                            DocumentTitle = workdoc.DocumentTitle,
                            DocumentIssuingAuthority = workdoc.DocumentIssuingAuthority,
                            DocumentNumber = workdoc.DocumentNumber,
                            ExpirationDate = workdoc.ExpirationDate
                            // UpdateBy=Convert.ToInt32(workdoc.UpdateBy)
                        }).ToList(),
                    };
                    hrmsEntity.Database.ExecuteStoredProcedure(proc);
                    return proc.WorkauthId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<WorkAuthorization> GetI9WorkAuthorizationDetails(int userId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var i9list = hrmsEntity.WorkAuthorization.Where(w => w.UserId == userId && w.CompanyId == companyId);
                    return i9list.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<WorkAuthorizationDocumentation> GetI9DoumentationDetails(int workAuthorizationId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var i9list = hrmsEntity.WorkAuthorizationDocumentations.Where(wd => wd.WorkAuthorizationId == workAuthorizationId);
                    return i9list.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public WorkAuthorization SelectFileByWorkAuthorizationID(int workAuthorizationId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var i9list = hrmsEntity.WorkAuthorization.Where(w => w.WorkAuthorizationId == workAuthorizationId).Single();
                    return i9list;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public bool DeleteFileByWorkAuthorizationID(int workAuthorizationId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var i9list = hrmsEntity.WorkAuthorization.Where(w => w.WorkAuthorizationId == workAuthorizationId).Single();
                    i9list.Attachment = null;
                    i9list.AttachmentName = null;
                    i9list.AttachmentType = null;
                    hrmsEntity.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //public bool AddI9WorkAuthorizationDetails(I9WorkAuthorization i9WorkAuthorizationobj, WorkAuthorizationDocumentation workAuthorizationDocobj, WorkAuthorizationDocumentationType workAuthorizationtypeobj, System.Data.DataTable documentList, int optselect)
        //{

        //    var hrmsEntity = new HRMSEntities1();
        //    try
        //    {
        //        var result =
        //           hrmsEntity.InsertUpdateFormI9DocumentationAddNewHireEmployee(
        //               i9WorkAuthorizationobj.WorkAuthorizationID, i9WorkAuthorizationobj.CompanyID, i9WorkAuthorizationobj.UserID,
        //               i9WorkAuthorizationobj.CitizenOfUS, i9WorkAuthorizationobj.AlienNumber, i9WorkAuthorizationobj.PermanentResidentExpire,
        //            i9WorkAuthorizationobj.AlienCitizenof, i9WorkAuthorizationobj.AlienAuthorisedDate,
        //               i9WorkAuthorizationobj.AlienAuthorisedCitizenof, i9WorkAuthorizationobj.CertificationDateA,
        //               i9WorkAuthorizationobj.Attachment, i9WorkAuthorizationobj.AttachmentName,
        //               i9WorkAuthorizationobj.AttachmentType, i9WorkAuthorizationobj.AlienRegistrationNumber,
        //               i9WorkAuthorizationobj.AdmissionNumber, i9WorkAuthorizationobj.PassportNumber,
        //               i9WorkAuthorizationobj.Countryof, i9WorkAuthorizationobj.ModifiedBy);
        //        return result > 0;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        hrmsEntity.Dispose();
        //    }
        //}

        public bool _AddI9WorkAuthorizationDetails(WorkAuthorization i9WorkAuthorizationobj, WorkAuthorizationDocumentation workAuthorizationDocobj, WorkAuthorizationDocumentationType workAuthorizationtypeobj, int optselect)
        {
            //var hrmsEntity = new HRMSEntities1();
            //try
            //{
            //    var result = hrmsEntity.usp_WorkAuthorizationFormI9Employee(i9WorkAuthorizationobj.UserId, i9WorkAuthorizationobj.CompanyId,
            //          Convert.ToInt32(i9WorkAuthorizationobj.TransactionId), i9WorkAuthorizationobj.SignatureDate, i9WorkAuthorizationobj.IPAddress,
            //          i9WorkAuthorizationobj.EmploymentOn, i9WorkAuthorizationobj.CitizenOfUS, i9WorkAuthorizationobj.AlienNumber, i9WorkAuthorizationobj.PermanentResidentExpire,
            //          i9WorkAuthorizationobj.AlienCitizenof, i9WorkAuthorizationobj.AlienAuthorisedDate, i9WorkAuthorizationobj.AlienAuthorisedCitizenof, i9WorkAuthorizationobj.FederalLaw,
            //          i9WorkAuthorizationobj.IsSSN, i9WorkAuthorizationobj.IsEmployeeSign, i9WorkAuthorizationobj.AlienRegistrationNumber, i9WorkAuthorizationobj.AdmissionNumber,
            //          i9WorkAuthorizationobj.PassportNumber, i9WorkAuthorizationobj.Countryof, i9WorkAuthorizationobj.CreatedBy);
            //    return result > 0;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    hrmsEntity.Dispose();
            //}
            return true;
        }
    }
}
