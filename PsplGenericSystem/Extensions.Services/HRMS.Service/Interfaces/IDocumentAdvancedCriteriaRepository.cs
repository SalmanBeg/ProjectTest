using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IDocumentAdvancedCriteriaRepository
    {
        /// <summary>
        /// Returns all DocumentAdvancedCriteria List
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<DocumentAdvancedCriteria> SelectAllDocumentAdvancedCriteria();

        /// <summary>
        /// Returns the DocumentAdvancedCriteria by Id
        /// </summary>
        /// <param name="DocumentAdvancedCriteriaId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<DocumentAdvancedCriteria> SelectDocumentAdvancedCriteriaById(int DocumentAdvancedCriteriaId);

        /// <summary>
        /// Crates a new DocumentAdvancedCriteria
        /// </summary>
        /// <param name="documentAdvancedCriteriaobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool CreateDocumentAdvancedCriteria(DocumentAdvancedCriteria documentAdvancedCriteriaobj);

        /// <summary>
        /// Updates the DocumentAdvancedCriteria
        /// </summary>
        /// <param name="documentAdvancedCriteriaobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateDocumentAdvancedCriteria(DocumentAdvancedCriteria documentAdvancedCriteriaobj);

        /// <summary>
        /// Deletes the DocumentAdvancedCriteria
        /// </summary>
        /// <param name="documentAdvancedCriteriaId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteDocumentAdvancedCriteria(int documentAdvancedCriteriaId);
    }
}
