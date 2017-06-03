using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IDocumentBasicCriteriaRepository
    {
        /// <summary>
        /// Returns all DocumentBasicCriteria List
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<DocumentBasicCriteria> SelectAllDocumentBasicCriteria();

        /// <summary>
        /// Return the DocumentBasicCriteria by Id
        /// </summary>
        /// <param name="DocumentBasicCriteriaId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<DocumentBasicCriteria> SelectDocumentBasicCriteriaById(int DocumentBasicCriteriaId);

        /// <summary>
        /// Creates a new DocumentBasicCriteria
        /// </summary>
        /// <param name="documentBasicCriteriaobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool CreateDocumentBasicCriteria(DocumentBasicCriteria documentBasicCriteriaobj);

        /// <summary>
        /// Updates the DocumentBasicCriteria
        /// </summary>
        /// <param name="documentBasicCriteriaobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateDocumentBasicCriteria(DocumentBasicCriteria documentBasicCriteriaobj);

        /// <summary>
        /// Deletes the DocumentBasicCriteria
        /// </summary>
        /// <param name="documentBasicCriteriaId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteDocumentBasicCriteria(int documentBasicCriteriaId);
    }
}
