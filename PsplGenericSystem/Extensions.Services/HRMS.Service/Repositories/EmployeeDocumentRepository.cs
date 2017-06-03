using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class EmployeeDocumentRepository : IEmployeeDocumentRepository
    {
        /// <summary>
        /// Displays all EmployeeDocument records.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDocument> SelectAllEmployeeDocument()
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmpDocumentResult = hrmsEntity.usp_EmployeeDocumentSelectAll().ToList();
                    var employeeDocumentList = lstEmpDocumentResult.Select(employeedocumentObj => new EmployeeDocument
                    {
                        EmployeeDocumentId = employeedocumentObj.EmployeeDocumentId,
                        CompanyDocumentId = employeedocumentObj.CompanyDocumentId,
                        EmployeeId = employeedocumentObj.EmployeeId,
                        EmployeeName = employeedocumentObj.EmployeeName,
                        EmployeeEmail = employeedocumentObj.EmployeeEmail,
                        Status = employeedocumentObj.Status
                    }).ToList();
                    return employeeDocumentList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns the single record of EmployeeDocument by employeeDocumentId.
        /// </summary>
        /// <param name="employeeDocumentId"></param>
        /// <returns></returns>
        public List<EmployeeDocument> SelectEmployeeDocumentById(int employeeDocumentId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_EmployeeDocumentSelect_Result> lstEmpDocumentResult = hrmsEntity.usp_EmployeeDocumentSelect(employeeDocumentId).ToList();
                    var employeeDocumentList = lstEmpDocumentResult.Select(employeedocumentObj => new EmployeeDocument
                    {
                        EmployeeDocumentId = employeedocumentObj.EmployeeDocumentId,
                        CompanyDocumentId = employeedocumentObj.CompanyDocumentId,
                        EmployeeId = employeedocumentObj.EmployeeId,
                        EmployeeName = employeedocumentObj.EmployeeName,
                        EmployeeEmail = employeedocumentObj.EmployeeEmail,
                        Status = employeedocumentObj.Status
                    }).ToList();
                    return employeeDocumentList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserts the new record for EmployeeDocument
        /// </summary>
        /// <param name="employeeDocumentobj"></param>
        /// <returns></returns>
        public bool CreateEmployeeDocument(EmployeeDocument employeeDocumentobj)
        {

            try
            {

                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeDocumentInsert(
                              employeeDocumentobj.CompanyDocumentId,
                              employeeDocumentobj.EmployeeId,
                              employeeDocumentobj.EmployeeName,
                              employeeDocumentobj.EmployeeEmail,
                              employeeDocumentobj.Status
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
        /// Updates the selected record for EmployeeDocument
        /// </summary>
        /// <param name="employeeDocumentobj"></param>
        /// <returns></returns>
        public bool UpdateEmployeeDocument(EmployeeDocument employeeDocumentobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeDocumentUpdate(
                               employeeDocumentobj.EmployeeDocumentId,
                               employeeDocumentobj.CompanyDocumentId,
                               employeeDocumentobj.EmployeeId,
                               employeeDocumentobj.EmployeeName,
                               employeeDocumentobj.EmployeeEmail,
                               employeeDocumentobj.Status
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
        /// Deletes the selected records from EmployeeDocument.
        /// </summary>
        /// <param name="employeeDocumentId"></param>
        /// <returns></returns>
        public bool DeleteEmployeeDocument(int employeeDocumentId)
        {
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeDocumentDelete(employeeDocumentId);
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
