using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class DocumentCategoryRepository : IDocumentCategoryRepository
    {
        /// <summary>
        /// Returns all Document Category by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<DocumentCategory> SelectAllDocumentCategory(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_DocumentCategorySelectAll_Result> lstDocumentCategoryResult = hrmsEntity.usp_DocumentCategorySelectAll(companyId).ToList();
                    var documentCategoryList = lstDocumentCategoryResult.Select(documentCategoryObj => new DocumentCategory
                    {
                        DocumentCategoryId = documentCategoryObj.DocumentCategoryId,
                        Name = documentCategoryObj.Name,
                        Description = documentCategoryObj.Description,
                        CompanyId = documentCategoryObj.CompanyId,
                        Status = documentCategoryObj.Status
                    }).ToList();
                    return documentCategoryList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns only selecte Document Category by companyId and DocumentCategoryId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="DocumentCategoryId"></param>
        /// <returns></returns>
        public List<DocumentCategory> SelectDocumentCategoryById(int DocumentCategoryId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_DocumentCategorySelect_Result> lstDocumentCategoryResult = hrmsEntity.usp_DocumentCategorySelect(DocumentCategoryId).ToList();
                    var documentCategoryList = lstDocumentCategoryResult.Select(documentCategoryObj => new DocumentCategory
                    {
                        DocumentCategoryId = documentCategoryObj.DocumentCategoryId,
                        Name = documentCategoryObj.Name,
                        Description = documentCategoryObj.Description,
                        CompanyId = documentCategoryObj.CompanyId,
                        Status = documentCategoryObj.Status
                    }).ToList();
                    return documentCategoryList;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Creates New Company Link
        /// </summary>
        /// <param name="documentCategoryobj"></param>
        /// <returns></returns>
        public bool CreateDocumentCategory(DocumentCategory documentCategoryobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_DocumentCategoryInsert(
                        documentCategoryobj.Name,
                        documentCategoryobj.Description,
                        documentCategoryobj.CompanyId,
                        documentCategoryobj.Status
                        );
                    hrmsEntity.Dispose();
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Updates the Selected Document Category
        /// </summary>
        /// <param name="documentCategoryobj"></param>
        /// <returns></returns>
        public bool UpdateDocumentCategory(DocumentCategory documentCategoryobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_DocumentCategoryUpdate(
                        documentCategoryobj.DocumentCategoryId,
                        documentCategoryobj.Name,
                        documentCategoryobj.Description,
                        documentCategoryobj.CompanyId,
                        documentCategoryobj.Status
                        );
                    hrmsEntity.Dispose();
                    return Convert.ToBoolean(result);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Deletes the Document Category
        /// </summary>
        /// <param name="DocumentCategoryId"></param>
        /// <returns></returns>
        public bool DeleteDocumentCategory(int DocumentCategoryId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    System.Data.Entity.Core.Objects.ObjectParameter errorobj = null;
                    var result = hrmsEntity.usp_DocumentCategoryDelete(DocumentCategoryId);
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
