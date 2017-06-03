using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System.Data;
using System.Data.SqlClient;

namespace HRMS.Service.Repositories
{
    public class DirectDepositRepository : IDirectDepositRepository
    {
        public EmployeeDirectDeposit AddDirectDeposit(EmployeeDirectDeposit employeeDirectDepositobj)
        {
            if (employeeDirectDepositobj == null) throw new ArgumentNullException("employeeDirectDepositobj");
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeDirectDepositInsert(employeeDirectDepositobj.CompanyId, employeeDirectDepositobj.UserId, employeeDirectDepositobj.AccountType
                                  , employeeDirectDepositobj.TransitorABANumber, employeeDirectDepositobj.AccountNumber, employeeDirectDepositobj.Amount).ToList();

                    var empdirectdeposit = result.Select(x => new EmployeeDirectDeposit()
                    {
                        EmployeeDirectDepositId = x.EmployeeDirectDepositId
                    }).SingleOrDefault();
                    return empdirectdeposit;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteDirectDeposit(int employeeDirectDepositId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeDirectDepositDelete(employeeDirectDepositId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateDirectDeposit(EmployeeDirectDeposit employeeDirectDepositobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeDirectDepositUpdate(employeeDirectDepositobj.CompanyId, employeeDirectDepositobj.EmployeeDirectDepositId
                              , employeeDirectDepositobj.AccountType, employeeDirectDepositobj.TransitorABANumber, employeeDirectDepositobj.AccountNumber
                              , employeeDirectDepositobj.Amount).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<EmployeeDirectDeposit> SelectDirectDeposit(int companyId, int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_EmployeeDirectDepositSelect_Result> lstEmployeeDirectDepositResult = hrmsEntity.usp_EmployeeDirectDepositSelect(companyId, userId).ToList();
                    return lstEmployeeDirectDepositResult.Select(employeedirectdeposit => new EmployeeDirectDeposit
                    {
                        CompanyId = employeedirectdeposit.CompanyId,
                        UserId = employeedirectdeposit.UserId,
                        EmployeeDirectDepositId = employeedirectdeposit.EmployeeDirectDepositId,
                        EmployeeDirectDepositCode = employeedirectdeposit.EmployeeDirectDepositCode,
                        AccountType = employeedirectdeposit.AccountType,
                        AccountNumber = employeedirectdeposit.AccountNumber,
                        Amount = employeedirectdeposit.Amount,
                        TransitorABANumber = employeedirectdeposit.TransitorABANumber,
                        AccountTypeName = employeedirectdeposit.AccountTypeName
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public EmployeeDirectDeposit SelectDirectDepositById(int companyId, int UserId, int DirectDepositId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_EmployeeDirectDepositSelectById_Result> lstEmployeeDirectDepositResult = hrmsEntity.usp_EmployeeDirectDepositSelectById(DirectDepositId, companyId, UserId).ToList();
                    var employeeDirectDepositList = lstEmployeeDirectDepositResult.Select(employeedirectdeposit => new EmployeeDirectDeposit
                    {
                        CompanyId = employeedirectdeposit.CompanyId,
                        UserId = employeedirectdeposit.UserId,
                        EmployeeDirectDepositId = employeedirectdeposit.EmployeeDirectDepositId,
                        EmployeeDirectDepositCode = employeedirectdeposit.EmployeeDirectDepositCode,
                        AccountType = employeedirectdeposit.AccountType,
                        AccountNumber = employeedirectdeposit.AccountNumber,
                        Amount = employeedirectdeposit.Amount,
                        TransitorABANumber = employeedirectdeposit.TransitorABANumber
                    }).ToList();
                    return employeeDirectDepositList.SingleOrDefault();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertEmployeeDirectDepositBulk(DataTable dtEmployeeDirectDeposit)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@tblEmployeeDirectDeposit", SqlDbType.Structured);
                    parameter.Value = dtEmployeeDirectDeposit;
                    parameter.TypeName = "HumanResources.EmployeeDirectDeposit";
                    using (HRMSEntities1 db = new HRMSEntities1())
                    {
                        int i = db.Database.ExecuteSqlCommand("exec HumanResources.usp_InsertDirectDepositBulk @tblEmployeeDirectDeposit", parameter);
                        return Convert.ToBoolean(i);
                    }
                    // return true; 
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public bool UpdateEmployeeDirectDepositBulk(DataTable dtEmployeeDirectDeposit)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@tblEmployeeDirectDeposit", SqlDbType.Structured);
                    parameter.Value = dtEmployeeDirectDeposit;
                    parameter.TypeName = "HumanResources.EmployeeDirectDeposit";
                    using (HRMSEntities1 db = new HRMSEntities1())
                    {
                        int i = db.Database.ExecuteSqlCommand("exec HumanResources.usp_UpdateEmployeeDirectDepositBulk @tblEmployeeDirectDeposit", parameter);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
