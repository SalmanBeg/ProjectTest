using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IEmployeeDocumentRepository
    {
        /// <summary>
        /// Displays all EmployeeDocument records.
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<EmployeeDocument> SelectAllEmployeeDocument();

        /// <summary>
        /// Returns the single record of EmployeeDocument by employeeDocumentId.
        /// </summary>
        /// <param name="employeeDocumentId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<EmployeeDocument> SelectEmployeeDocumentById(int employeeDocumentId);

        /// <summary>
        /// Inserts the new record for EmployeeDocument
        /// </summary>
        /// <param name="employeeDocumentobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool CreateEmployeeDocument(EmployeeDocument employeeDocumentobj);

        /// <summary>
        /// Updates the selected record for EmployeeDocument
        /// </summary>
        /// <param name="employeeDocumentobj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateEmployeeDocument(EmployeeDocument employeeDocumentobj);

        /// <summary>
        /// Deletes the selected records from EmployeeDocument.
        /// </summary>
        /// <param name="employeeDocumentId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteEmployeeDocument(int employeeDocumentId);
    }
}
