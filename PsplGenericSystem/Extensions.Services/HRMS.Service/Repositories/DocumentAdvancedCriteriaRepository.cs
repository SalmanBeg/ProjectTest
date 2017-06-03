using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class DocumentAdvancedCriteriaRepository : IDocumentAdvancedCriteriaRepository
    {
        /// <summary>
        /// Returns all DocumentAdvancedCriteria List
        /// </summary>
        /// <returns></returns>
        public List<DocumentAdvancedCriteria> SelectAllDocumentAdvancedCriteria()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_DocumentAdvancedCriteriaSelectAll_Result> lstDocumentAdvancedCriteria = hrmsEntity.usp_DocumentAdvancedCriteriaSelectAll().ToList();
                    var documentAdvancedCriteriaList = lstDocumentAdvancedCriteria.Select(documentAdvancedCriteriaobj => new DocumentAdvancedCriteria
                    {
                        DocumentAdvancedCriteriaId = documentAdvancedCriteriaobj.DocumentAdvancedCriteriaId,
                        CompanyDocumentId = documentAdvancedCriteriaobj.CompanyDocumentId,
                        DocumentSendTypeId = documentAdvancedCriteriaobj.DocumentSendTypeId,
                        DocumentSendCriteriaId = documentAdvancedCriteriaobj.DocumentSendCriteriaId,
                        SelectedCriteriaListId = documentAdvancedCriteriaobj.SelectedCriteriaListId
                    }).ToList();
                    return documentAdvancedCriteriaList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns the DocumentAdvancedCriteria by Id
        /// </summary>
        /// <param name="DocumentAdvancedCriteriaId"></param>
        /// <returns></returns>
        public List<DocumentAdvancedCriteria> SelectDocumentAdvancedCriteriaById(int DocumentAdvancedCriteriaId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_DocumentAdvancedCriteriaSelect_Result> lstDocumentAdvancedCriteria = hrmsEntity.usp_DocumentAdvancedCriteriaSelect(DocumentAdvancedCriteriaId).ToList();
                    var documentAdvancedCriteriaList = lstDocumentAdvancedCriteria.Select(documentAdvancedCriteriaobj => new DocumentAdvancedCriteria
                    {
                        DocumentAdvancedCriteriaId = documentAdvancedCriteriaobj.DocumentAdvancedCriteriaId,
                        CompanyDocumentId = documentAdvancedCriteriaobj.CompanyDocumentId,
                        DocumentSendTypeId = documentAdvancedCriteriaobj.DocumentSendTypeId,
                        DocumentSendCriteriaId = documentAdvancedCriteriaobj.DocumentSendCriteriaId,
                        SelectedCriteriaListId = documentAdvancedCriteriaobj.SelectedCriteriaListId
                    }).ToList();
                    return documentAdvancedCriteriaList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Crates a new DocumentAdvancedCriteria
        /// </summary>
        /// <param name="documentAdvancedCriteriaobj"></param>
        /// <returns></returns>
        public bool CreateDocumentAdvancedCriteria(DocumentAdvancedCriteria documentAdvancedCriteriaobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_DocumentAdvancedCriteriaInsert(
                        //documentAdvancedCriteriaobj.DocumentAdvancedCriteriaId,
                        documentAdvancedCriteriaobj.CompanyDocumentId,
                        documentAdvancedCriteriaobj.DocumentSendTypeId,
                        documentAdvancedCriteriaobj.DocumentSendCriteriaId,
                        documentAdvancedCriteriaobj.SelectedCriteriaListId
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
        /// Updates the DocumentAdvancedCriteria
        /// </summary>
        /// <param name="documentAdvancedCriteriaobj"></param>
        /// <returns></returns>
        public bool UpdateDocumentAdvancedCriteria(DocumentAdvancedCriteria documentAdvancedCriteriaobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_DocumentAdvancedCriteriaUpdate(
                        documentAdvancedCriteriaobj.DocumentAdvancedCriteriaId,
                        documentAdvancedCriteriaobj.CompanyDocumentId,
                        documentAdvancedCriteriaobj.DocumentSendTypeId,
                        documentAdvancedCriteriaobj.DocumentSendCriteriaId,
                        documentAdvancedCriteriaobj.SelectedCriteriaListId
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
        /// Deletes the DocumentAdvancedCriteria
        /// </summary>
        /// <param name="documentAdvancedCriteriaId"></param>
        /// <returns></returns>
        public bool DeleteDocumentAdvancedCriteria(int documentAdvancedCriteriaId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_DocumentAdvancedCriteriaDelete(documentAdvancedCriteriaId);
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
