using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class EmployeeSignRepository : IEmployeeSignRepository
    {
        public bool CreateEmployeeSign(EmployeeSign employeeSignobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeSignInsert(employeeSignobj.UserId, employeeSignobj.CompanyId, employeeSignobj.Name
                              , employeeSignobj.EmployeeSignFileId, employeeSignobj.IsDefault, employeeSignobj.ConsentFormId).ToList();
                    hrmsEntity.Dispose();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateEmployeeSignById(EmployeeSign employeeSignobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeSignUpdate(employeeSignobj.EmployeeSignId, employeeSignobj.UserId, employeeSignobj.CompanyId, employeeSignobj.Name
                              , employeeSignobj.EmployeeSignFileId).ToList();
                    hrmsEntity.Dispose();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public EmployeeSign GetEmployeeSign(int employeeSignId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeSignResult = hrmsEntity.usp_EmployeeSignSelect(employeeSignId).ToList();
                    return lstEmployeeSignResult.Select(employeesign => new EmployeeSign
                    {
                        CompanyId = employeesign.CompanyId,
                        Name = employeesign.Name,
                        UserId = employeesign.UserId,
                        EmployeeSignId = employeesign.EmployeeSignId,
                        EmployeeSignFileId = employeesign.EmployeeSignFileId
                    }).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<EmployeeSign> GetAllEmployeeSignByUserId(int userId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeSignResult = hrmsEntity.usp_EmployeeSignSelectAll(userId).ToList();
                    return lstEmployeeSignResult.Select(employeesign => new EmployeeSign
                    {
                        CompanyId = employeesign.CompanyId,
                        Name = employeesign.Name,
                        UserId = employeesign.UserId,
                        EmployeeSignId = employeesign.EmployeeSignId,
                        EmployeeSignFileId = employeesign.EmployeeSignFileId,
                        SignFileBytes = employeesign.FileBytes,
                        IsDefault = employeesign.IsDefault,
                        ConsentFormId = employeesign.ConsentFormId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployeeSignById(int employeeSignById)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeSignDelete(employeeSignById);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateEmployeeDefaultSign(int userId, int companyId, int signId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeDefaultSignUpdate(userId, companyId, signId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool DeleteEmployeeSign(int employeeSignId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeSignDelete(employeeSignId);
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
