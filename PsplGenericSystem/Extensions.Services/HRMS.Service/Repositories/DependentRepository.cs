using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class DependentRepository : IDependentRepository
    {
        public bool AddDependent(EmployeeDependent employeeDependentobj)
        {
            try
            {
                // System.Data.Entity.Core.Objects.ObjectParameter errorobj = null;

                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_EmployeeDependentInsert(employeeDependentobj.CompanyId, employeeDependentobj.UserId
                               , employeeDependentobj.FirstName, employeeDependentobj.LastName, employeeDependentobj.MiddleName, employeeDependentobj.Suffix
                               , employeeDependentobj.Alias, employeeDependentobj.Salutation, employeeDependentobj.Street1, employeeDependentobj.Street2
                               , employeeDependentobj.City, employeeDependentobj.CountryId, employeeDependentobj.StateId, employeeDependentobj.Zip
                               , employeeDependentobj.HomeEmail, employeeDependentobj.HomePhone, employeeDependentobj.CellPhone, employeeDependentobj.SSN
                               , employeeDependentobj.BirthDate, employeeDependentobj.Gender, employeeDependentobj.RelationShip,
                               employeeDependentobj.ImputedIncome
                               , employeeDependentobj.Disabled, employeeDependentobj.Smoker, employeeDependentobj.Student,
                               employeeDependentobj.CreatedBy).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<EmployeeDependent> SelectAllEmployeeDependent(int userId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_EmployeeDependentSelectAll_Result> lstEmployeeDependentResult = hrmsEntity.usp_EmployeeDependentSelectAll(companyId, userId).ToList();
                    return lstEmployeeDependentResult.Select(employeedependentObj => new EmployeeDependent
                    {
                        Alias = employeedependentObj.Alias,
                        BirthDate = employeedependentObj.BirthDate,
                        CellPhone = employeedependentObj.CellPhone,
                        City = employeedependentObj.City,
                        CompanyId = employeedependentObj.CompanyId,
                        CountryId = employeedependentObj.CountryId,
                        CreatedBy = employeedependentObj.CreatedBy,
                        CreatedOn = employeedependentObj.CreatedOn,
                        Disabled = employeedependentObj.Disabled,
                        EmployeeDependentCode = employeedependentObj.EmployeeDependentCode,
                        EmployeeDependentId = employeedependentObj.EmployeeDependentId,
                        FirstName = employeedependentObj.FirstName,
                        Gender = employeedependentObj.Gender,
                        HomeEmail = employeedependentObj.HomeEmail,
                        HomePhone = employeedependentObj.HomePhone,
                        ImputedIncome = employeedependentObj.ImputedIncome,
                        LastName = employeedependentObj.LastName,
                        MiddleName = employeedependentObj.MiddleName,
                        ModifiedBy = employeedependentObj.ModifiedBy,
                        ModifiedOn = employeedependentObj.ModifiedOn,
                        RelationShip = employeedependentObj.RelationShip,
                        Salutation = employeedependentObj.Salutation,
                        Smoker = employeedependentObj.Smoker,
                        SSN = employeedependentObj.SSN,
                        StateId = employeedependentObj.StateId,
                        Street1 = employeedependentObj.Street1,
                        Street2 = employeedependentObj.Street2,
                        Student = employeedependentObj.Student,
                        Suffix = employeedependentObj.Suffix,
                        UserId = employeedependentObj.UserId,
                        Zip = employeedependentObj.Zip,
                        RelationShipName = employeedependentObj.RelationShipName
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<EmployeeDependent> SelectEmployeeDependentByDependentId(int employeeDependentId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_EmployeeDependentSelect_Result> lstEmployeeDependentResult = hrmsEntity.usp_EmployeeDependentSelect(companyId, employeeDependentId).ToList();
                    return lstEmployeeDependentResult.Select(employeedependentObj => new EmployeeDependent
                    {
                        Alias = employeedependentObj.Alias,
                        BirthDate = employeedependentObj.BirthDate,
                        CellPhone = employeedependentObj.CellPhone,
                        City = employeedependentObj.City,
                        CompanyId = employeedependentObj.CompanyId,
                        CountryId = employeedependentObj.CountryId,
                        CreatedBy = employeedependentObj.CreatedBy,
                        CreatedOn = employeedependentObj.CreatedOn,
                        Disabled = employeedependentObj.Disabled,
                        EmployeeDependentCode = employeedependentObj.EmployeeDependentCode,
                        EmployeeDependentId = employeedependentObj.EmployeeDependentId,
                        FirstName = employeedependentObj.FirstName,
                        Gender = employeedependentObj.Gender,
                        HomeEmail = employeedependentObj.HomeEmail,
                        HomePhone = employeedependentObj.HomePhone,
                        ImputedIncome = employeedependentObj.ImputedIncome,
                        LastName = employeedependentObj.LastName,
                        MiddleName = employeedependentObj.MiddleName,
                        ModifiedBy = employeedependentObj.ModifiedBy,
                        ModifiedOn = employeedependentObj.ModifiedOn,
                        RelationShip = employeedependentObj.RelationShip,
                        Salutation = employeedependentObj.Salutation,
                        Smoker = employeedependentObj.Smoker,
                        SSN = employeedependentObj.SSN,
                        StateId = employeedependentObj.StateId,
                        Street1 = employeedependentObj.Street1,
                        Street2 = employeedependentObj.Street2,
                        Student = employeedependentObj.Student,
                        Suffix = employeedependentObj.Suffix,
                        UserId = employeedependentObj.UserId,
                        Zip = employeedependentObj.Zip
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateEmployeeDependent(EmployeeDependent employeeDependentobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    //System.Data.Entity.Core.Objects.ObjectParameter errorobj = null;

                    var result = hrmsEntity.usp_EmployeeDependentUpdate(employeeDependentobj.CompanyId, employeeDependentobj.EmployeeDependentId
                        , employeeDependentobj.FirstName, employeeDependentobj.LastName, employeeDependentobj.MiddleName, employeeDependentobj.Suffix
                        , employeeDependentobj.Alias, employeeDependentobj.Salutation, employeeDependentobj.Street1, employeeDependentobj.Street2
                        , employeeDependentobj.City, employeeDependentobj.CountryId, employeeDependentobj.StateId, employeeDependentobj.Zip
                        , employeeDependentobj.HomeEmail, employeeDependentobj.HomePhone, employeeDependentobj.CellPhone, employeeDependentobj.SSN
                        , employeeDependentobj.BirthDate, employeeDependentobj.Gender, employeeDependentobj.RelationShip, employeeDependentobj.ImputedIncome
                        , employeeDependentobj.Disabled, employeeDependentobj.Smoker, employeeDependentobj.Student, employeeDependentobj.ModifiedBy).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteDependent(int employeeDependentId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeDependentResult = hrmsEntity.usp_EmployeeDependentDelete(companyId, employeeDependentId);
                    return lstEmployeeDependentResult > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
