using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;


namespace HRMS.Service.Repositories
{
    public class EmployeeFolderRepository : IEmployeeFolderRepository
    {
        /// <summary>
        /// Displays all EmployeeFolder records.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<EmployeeFolder> SelectAllEmployeeFolderByCompanyId(int userId, int companyId)
        {
            var hrmsEntity = new HRMSEntities1();
            try
            {
                var lstEmpFolderResult = hrmsEntity.usp_EmployeeFolderSelectAll(userId, companyId).ToList();
                var employeefolderList = lstEmpFolderResult.Select(employeefolderObj => new EmployeeFolder
                {
                    CategoryName=employeefolderObj.CategoryName,
                    EmployeeFolderId = employeefolderObj.EmployeeFolderId,
                    UserId = employeefolderObj.UserId,
                    DocumentName = employeefolderObj.DocumentName,
                    FilesDBId = employeefolderObj.FilesDBId,
                   // File = employeefolderObj.
                    CategoryId = employeefolderObj.CategoryId,
                    Shared = employeefolderObj.Shared,
                    CompanyId = employeefolderObj.CompanyId
                }).ToList();
                return employeefolderList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                hrmsEntity.Dispose();
            }
        }

        /// <summary>
        /// Returns the single record of EmployeeFolder by employeeFolderId.
        /// </summary>
        /// <param name="employeefolderId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<EmployeeFolder> SelectEmployeeFolderById(int companyId, int employeefolderId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmpFolderResult = hrmsEntity.usp_EmployeeFolderSelect(companyId, employeefolderId).ToList();
                    var employeefolderList = lstEmpFolderResult.Select(employeefolderObj => new EmployeeFolder
                    {
                        CategoryName=employeefolderObj.CategoryName,
                        EmployeeFolderId = employeefolderObj.EmployeeFolderId,
                        UserId = employeefolderObj.UserId,
                        DocumentName = employeefolderObj.DocumentName,
                        FilesDBId = employeefolderObj.FilesDBId,
                        CategoryId = employeefolderObj.CategoryId,
                        Shared = employeefolderObj.Shared,
                        CompanyId = employeefolderObj.CompanyId
                    }).ToList();
                    return employeefolderList;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Inserts the new record for EmployeeFolder
        /// </summary>
        /// <param name="employeeFolderobj"></param>
        /// <returns></returns>
        public int CreateEmployeeFolder(EmployeeFolder employeeFolderobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));

                    var result = hrmsEntity.usp_EmployeeFolderInsert(
                        employeeFolderobj.UserId,
                        employeeFolderobj.CompanyId,
                        employeeFolderobj.DocumentName,
                        employeeFolderobj.FilesDBId,
                        employeeFolderobj.CategoryId,
                        employeeFolderobj.Shared,
                        outputParam
                        );
                    return result ;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the selected record for EmployeeFolder
        /// </summary>
        /// <param name="employeeFolderobj"></param>
        /// <returns></returns>
        public bool UpdateEmployeeFolder(EmployeeFolder employeeFolderobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeFolderUpdate(
                                employeeFolderobj.EmployeeFolderId,
                                employeeFolderobj.UserId,
                                employeeFolderobj.CompanyId,
                                employeeFolderobj.DocumentName,
                                employeeFolderobj.FilesDBId,
                                employeeFolderobj.CategoryId,
                                employeeFolderobj.Shared
                                ).ToList();

                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes the selected records from EmployeeFolder.
        /// </summary>
        /// <param name="employeefolderId"></param>
        /// <returns></returns>
        public bool DeleteEmployeeFolder(int employeefolderId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeFolderDelete(employeefolderId);
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
