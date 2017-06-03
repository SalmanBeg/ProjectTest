using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class CompanyDocumentRepository : ICompanyDocumentRepository
    {
        /// <summary>
        /// Returns all Company Documents by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<CompanyDocument> SelectAllCompanyDocumentByCompanyId(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyDocumentSelectAll_Result> lstCompanyDocumentResult = hrmsEntity.usp_CompanyDocumentSelectAll(companyId).ToList();
                    var companyDocumentList = lstCompanyDocumentResult.Select(companyDocumentObj => new CompanyDocument
                    {
                        CompanyDocumentId = companyDocumentObj.CompanyDocumentId,
                        CompanyDocumentTitle = companyDocumentObj.CompanyDocumentTitle,
                        CompanyDocumentText = companyDocumentObj.CompanyDocumentText,
                        CompanyId = companyDocumentObj.CompanyId,
                        AttachmentId = companyDocumentObj.AttachmentId,
                        CategoryId = companyDocumentObj.CategoryId,
                        CategoryName = companyDocumentObj.CategoryName,
                        IsShowDocumentOnHomePage = companyDocumentObj.IsShowDocumentOnHomePage,
                        FromAddress = companyDocumentObj.FromAddress,
                        Status = companyDocumentObj.Status,
                        SendTo = companyDocumentObj.SendTo,
                        CreatedOn = companyDocumentObj.CreatedOn,
                        ModifiedOn = companyDocumentObj.ModifiedOn,
                        CreatedBy = companyDocumentObj.CreatedBy,
                        ModifiedBy = companyDocumentObj.ModifiedBy
                    }).ToList();
                    return companyDocumentList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Retuns the selected Company document by CompanyDocumentId.
        /// </summary>
        /// <param name="companyDocumentId"></param>
        /// <returns></returns>
        public List<CompanyDocument> SelectCompanyDocumentById(int companyDocumentId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_CompanyDocumentSelect_Result> lstCompanyDocumentResult = hrmsEntity.usp_CompanyDocumentSelect(companyDocumentId).ToList();
                    var companyDocumentList = lstCompanyDocumentResult.Select(companyDocumentobj => new CompanyDocument
                    {
                        CompanyDocumentId = companyDocumentobj.CompanyDocumentId,
                        CompanyDocumentTitle = companyDocumentobj.CompanyDocumentTitle,
                        CompanyDocumentText = companyDocumentobj.CompanyDocumentText,
                        CompanyId = companyDocumentobj.CompanyId,
                        AttachmentId = companyDocumentobj.AttachmentId,
                        CategoryId = companyDocumentobj.CategoryId,
                        IsShowDocumentOnHomePage = companyDocumentobj.IsShowDocumentOnHomePage,
                        FromAddress = companyDocumentobj.FromAddress,
                        Status = companyDocumentobj.Status,
                        SendTo = companyDocumentobj.SendTo,
                        CreatedOn = companyDocumentobj.CreatedOn,
                        ModifiedOn = companyDocumentobj.ModifiedOn,
                        CreatedBy = companyDocumentobj.CreatedBy,
                        ModifiedBy = companyDocumentobj.ModifiedBy
                    }).ToList();
                    return companyDocumentList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserts new Company Document.
        /// </summary>
        /// <param name="companyDocumentobj"></param>
        /// <returns></returns>
        public int CreateCompanyDocument(CompanyDocument companyDocumentobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_CompanyDocumentInsert(
                        //companyDocumentobj.CompanyDocumentId,
                        companyDocumentobj.CompanyDocumentTitle,
                        companyDocumentobj.CompanyDocumentText,
                        companyDocumentobj.CompanyId,
                        companyDocumentobj.AttachmentId,
                        companyDocumentobj.CategoryId,
                        companyDocumentobj.IsShowDocumentOnHomePage,
                        companyDocumentobj.FromAddress,
                        companyDocumentobj.Status,
                        companyDocumentobj.SendTo,
                        companyDocumentobj.CreatedOn,
                        //companyDocumentobj.ModifiedOn,
                        companyDocumentobj.CreatedBy,
                        //companyDocumentobj.ModifiedBy,
                        outputParam
                        );
                    hrmsEntity.Dispose();
                    return Convert.ToInt32(outputParam.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the selected company document.
        /// </summary>
        /// <param name="companyDocumentobj"></param>
        /// <returns></returns>
        public bool UpdateCompanyDocument(CompanyDocument companyDocumentobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_CompanyDocumentUpdate(
                        companyDocumentobj.CompanyDocumentId,
                        companyDocumentobj.CompanyDocumentTitle,
                        companyDocumentobj.CompanyDocumentText,
                        companyDocumentobj.CompanyId,
                        companyDocumentobj.AttachmentId,
                        companyDocumentobj.CategoryId,
                        companyDocumentobj.IsShowDocumentOnHomePage,
                        companyDocumentobj.FromAddress,
                        companyDocumentobj.Status,
                        companyDocumentobj.SendTo,
                        //companyDocumentobj.CreatedOn,
                        companyDocumentobj.ModifiedOn,
                        //companyDocumentobj.CreatedBy,
                        companyDocumentobj.ModifiedBy
                        );
                    hrmsEntity.Dispose();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the company document by companyDocumentId.
        /// </summary>
        /// <param name="companyDocumentId"></param>
        /// <returns></returns>
        public bool DeleteCompanyDocument(int companyDocumentId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_CompanyDocumentDelete(companyDocumentId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
        public bool IsTitleExists(CompanyDocument companyDocumentObj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var companyDocumentObjList = hrmsEntity.CompanyDocuments.ToList();
                    CompanyDocument companyDocumentObj1 = companyDocumentObjList.Where(m => m.CompanyId == companyDocumentObj.CompanyId && m.CompanyDocumentTitle.ToLower() == companyDocumentObj.CompanyDocumentTitle.ToLower() && m.CompanyDocumentId != companyDocumentObj.CompanyDocumentId).FirstOrDefault();
                    if (companyDocumentObj1 != null)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }

}
