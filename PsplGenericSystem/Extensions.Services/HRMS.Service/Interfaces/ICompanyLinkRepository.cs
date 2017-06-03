using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface ICompanyLinkRepository
    {
        /// <summary>
        /// Returns all Company Links by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CompanyLink> SelectAllCompanyLink(int companyId);

        /// <summary>
        /// Returns only selecte company link by companyId and companyLinkId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="companyLinkId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CompanyLink> SelectCompanyLinkById(int companyLinkId);

        /// <summary>
        /// Creates New Company Link
        /// </summary>
        /// <param name="companyLinkobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool CreateCompanyLink(CompanyLink companyLinkobj);

        /// <summary>
        /// Updates the Selected Company Link
        /// </summary>
        /// <param name="companyLinkobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateCompanyLink(CompanyLink companyLinkobj);

        /// <summary>
        /// Deletes the Company Link
        /// </summary>
        /// <param name="companyLinkId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteCompanyLink(int companyLinkId);
    }
}
