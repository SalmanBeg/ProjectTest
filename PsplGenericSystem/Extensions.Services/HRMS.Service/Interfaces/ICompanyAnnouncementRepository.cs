using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface ICompanyAnnouncementRepository
    {
        /// <summary>
        /// Returns all Company Announcement by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CompanyAnnouncement> SelectAllCompanyAnnouncementByCompanyId(int companyId);

        /// <summary>
        /// Retuns the selected Company Announcement by CompanyAnnouncementId.
        /// </summary>
        /// <param name="companyAnnouncementId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CompanyAnnouncement> SelectCompanyAnnouncementById(int companyAnnouncementId);

        /// <summary>
        /// Inserts new Company Announcement.
        /// </summary>
        /// <param name="companyAnnouncementobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool CreateCompanyAnnouncement(CompanyAnnouncement companyAnnouncementobj);

        /// <summary>
        /// Updates the selected company document.
        /// </summary>
        /// <param name="companyAnnouncementobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateCompanyAnnouncement(CompanyAnnouncement companyAnnouncementobj);

        /// <summary>
        /// Deletes the Company Announcement by CompanyAnnouncementId.
        /// </summary>
        /// <param name="companyAnnouncementId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteCompanyAnnouncement(int companyAnnouncementId);
        [Logger]
        [ExceptionLogger]
        bool IsTitleExists(CompanyAnnouncement companyAnnouncementObj);

    }
}
