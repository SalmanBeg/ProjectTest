using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IDocumentCategoryRepository
    {
        /// <summary>
        /// Returns all Document Category by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<DocumentCategory> SelectAllDocumentCategory(int companyId);

        /// <summary>
        /// Returns only selecte Document Category by companyId and DocumentCategoryId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="DocumentCategoryId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<DocumentCategory> SelectDocumentCategoryById(int DocumentCategoryId);

        /// <summary>
        /// Creates New Company Link
        /// </summary>
        /// <param name="documentCategoryobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool CreateDocumentCategory(DocumentCategory documentCategoryobj);

        /// <summary>
        /// Updates the Selected Document Category
        /// </summary>
        /// <param name="documentCategoryobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateDocumentCategory(DocumentCategory documentCategoryobj);

        /// <summary>
        /// Deletes the Document Category
        /// </summary>
        /// <param name="DocumentCategoryId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteDocumentCategory(int DocumentCategoryId);
    }
}
