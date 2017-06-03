using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface ICertificationandLicenseRepository
    {
        /// <summary>
        /// to save individual new record for CL
        /// </summary>
        /// <param name="certificationandLicensebj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertCertificationandLicense(CertificationandLicense certificationandLicensebj);
        /// <summary>
        /// To list all the certifications and licenses for a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CertificationandLicense> SelectAllCertificationandLicense(int userId);
        /// <summary>
        ///  to update individual selected record for CL
        /// </summary>
        /// <param name="certificationandLicenseobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateCertificationandLicense(CertificationandLicense certificationandLicenseobj);
        /// <summary>
        /// To list the certifications and licenses for a company based on company and certificationId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="certificationandLicenseId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CertificationandLicense> SelectCertificationandLicense(int companyId, int certificationandLicenseId);
        /// <summary>
        /// To remove an selected record from database
        /// </summary>
        /// <param name="CertificationLicensesId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteCertificationandLicense(int CertificationLicensesId, int companyId);

    }
}
