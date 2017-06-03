using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IEmployeeFolderRepository
    {
        /// <summary>
        /// Displays all EmployeeFolder records.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<EmployeeFolder> SelectAllEmployeeFolderByCompanyId(int userId,int companyId);

        /// <summary>
        /// Returns the single record of EmployeeFolder by employeeFolderId.
        /// </summary>
        /// <param name="employeefolderId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<EmployeeFolder> SelectEmployeeFolderById(int companyId, int employeefolderId);

        /// <summary>
        /// Inserts the new record for EmployeeFolder
        /// </summary>
        /// <param name="EmployeeFolderobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int CreateEmployeeFolder(EmployeeFolder employeeFolderobj);

        /// <summary>
        /// Updates the selected record for EmployeeFolder
        /// </summary>
        /// <param name="EmployeeFolderobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateEmployeeFolder(EmployeeFolder employeeFolderobj);

        /// <summary>
        /// Deletes the selected records from EmployeeFolder.
        /// </summary>
        /// <param name="employeefolderId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteEmployeeFolder(int employeefolderId);
    }
}
