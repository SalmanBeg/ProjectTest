using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface ICompanyDocumentRepository
    {
        /// <summary>
        /// Returns all Company Documents by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CompanyDocument> SelectAllCompanyDocumentByCompanyId(int companyId);

        /// <summary>
        /// Retuns the selected Company document by CompanyDocumentId.
        /// </summary>
        /// <param name="companyDocumentId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CompanyDocument> SelectCompanyDocumentById(int companyDocumentId);

        /// <summary>
        /// Inserts new Company Document.
        /// </summary>
        /// <param name="companyDocumentobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int CreateCompanyDocument(CompanyDocument companyDocumentobj);

        /// <summary>
        /// Updates the selected company document.
        /// </summary>
        /// <param name="companyDocumentobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateCompanyDocument(CompanyDocument companyDocumentobj);

        /// <summary>
        /// Deletes the company document by companyDocumentId.
        /// </summary>
        /// <param name="companyDocumentId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteCompanyDocument(int companyDocumentId);
        [Logger]
        [ExceptionLogger]
        bool IsTitleExists(CompanyDocument companyDocumentobj);
    }
}
