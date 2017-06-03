using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class DocumentBasicCriteriaRepository : IDocumentBasicCriteriaRepository
    {
        /// <summary>
        /// Returns all DocumentBasicCriteria List
        /// </summary>
        /// <returns></returns>
        public List<DocumentBasicCriteria> SelectAllDocumentBasicCriteria()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_DocumentBasicCriteriaSelectAll_Result> lstDocumentBasicCriteria = hrmsEntity.usp_DocumentBasicCriteriaSelectAll().ToList();
                    var documentBasicCriteriaList = lstDocumentBasicCriteria.Select(documentBasicCriteriaobj => new DocumentBasicCriteria
                    {
                        DocumentBasicCriteriaId = documentBasicCriteriaobj.DocumentBasicCriteriaId,
                        CompanyDocumentId = documentBasicCriteriaobj.CompanyDocumentId,
                        DocumentSendTypeId = documentBasicCriteriaobj.DocumentSendTypeId,
                        SelectedCriteriaListId = documentBasicCriteriaobj.SelectedCriteriaListId
                    }).ToList();
                    return documentBasicCriteriaList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Return the DocumentBasicCriteria by Id
        /// </summary>
        /// <param name="DocumentBasicCriteriaId"></param>
        /// <returns></returns>
        public List<DocumentBasicCriteria> SelectDocumentBasicCriteriaById(int DocumentBasicCriteriaId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_DocumentBasicCriteriaSelect_Result> lstDocumentBasicCriteria = hrmsEntity.usp_DocumentBasicCriteriaSelect(DocumentBasicCriteriaId).ToList();
                    var documentBasicCriteriaList = lstDocumentBasicCriteria.Select(documentBasicCriteriaobj => new DocumentBasicCriteria
                    {
                        DocumentBasicCriteriaId = documentBasicCriteriaobj.DocumentBasicCriteriaId,
                        CompanyDocumentId = documentBasicCriteriaobj.CompanyDocumentId,
                        DocumentSendTypeId = documentBasicCriteriaobj.DocumentSendTypeId,
                        SelectedCriteriaListId = documentBasicCriteriaobj.SelectedCriteriaListId
                    }).ToList();
                    return documentBasicCriteriaList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates a new DocumentBasicCriteria
        /// </summary>
        /// <param name="documentBasicCriteriaobj"></param>
        /// <returns></returns>
        public bool CreateDocumentBasicCriteria(DocumentBasicCriteria documentBasicCriteriaobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_DocumentBasicCriteriaInsert(
                        //documentBasicCriteriaobj.DocumentBasicCriteriaId,
                        documentBasicCriteriaobj.CompanyDocumentId,
                        documentBasicCriteriaobj.DocumentSendTypeId,
                        documentBasicCriteriaobj.SelectedCriteriaListId
                        ).ToList();
                    hrmsEntity.Dispose();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the DocumentBasicCriteria
        /// </summary>
        /// <param name="documentBasicCriteriaobj"></param>
        /// <returns></returns>
        public bool UpdateDocumentBasicCriteria(DocumentBasicCriteria documentBasicCriteriaobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_DocumentBasicCriteriaUpdate(
                        documentBasicCriteriaobj.DocumentBasicCriteriaId,
                        documentBasicCriteriaobj.CompanyDocumentId,
                        documentBasicCriteriaobj.DocumentSendTypeId,
                        documentBasicCriteriaobj.SelectedCriteriaListId
                        ).ToList();
                    hrmsEntity.Dispose();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the DocumentBasicCriteria
        /// </summary>
        /// <param name="documentBasicCriteriaId"></param>
        /// <returns></returns>
        public bool DeleteDocumentBasicCriteria(int documentBasicCriteriaId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var result = hrmsEntity.usp_DocumentBasicCriteriaDelete(documentBasicCriteriaId);
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
