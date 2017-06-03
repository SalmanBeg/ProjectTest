using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public bool CreateEmployee(Employee employeeobj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));

                    var result = hrmsEntity.usp_EmployeeInsertORUpdate(employeeobj.UserId, employeeobj.CompanyId, employeeobj.ChangeReason, employeeobj.HireDate
                        , employeeobj.OriginalHireDate, employeeobj.TerminationDate, employeeobj.TerminationReason, employeeobj.StartDate
                            , employeeobj.SeniorityDate, employeeobj.LastPaidDate, employeeobj.LastPayRise, employeeobj.LastPromotionDate
                            , employeeobj.LastReviewDate, employeeobj.NextReviewDate, employeeobj.NewHireReportDate, employeeobj.EmploymentStatus, employeeobj.JobProfileId
                            , employeeobj.PositionId, employeeobj.PayGroup, employeeobj.LocationId, employeeobj.DivisionId, employeeobj.DepartmentId
                            , employeeobj.ManagerId, employeeobj.EmploymentType, employeeobj.ComplianceCode, employeeobj.BenefitClass, employeeobj.FLSAStatus
                            , employeeobj.Union, employeeobj.DistrictCode, employeeobj.CheckDistribution, employeeobj.DirectDepositEmail, employeeobj.OkToRehire
                            , employeeobj.WCJobClassCode, employeeobj.WCStatus, employeeobj.WCType, employeeobj.WorkPhone, employeeobj.WorkEmail
                            , employeeobj.Salutation, employeeobj.FirstName, employeeobj.MiddleName, employeeobj.LastName, employeeobj.Suffix
                            , employeeobj.Email, employeeobj.Address1, employeeobj.Address2, employeeobj.City, employeeobj.ZIP, employeeobj.CountryId
                            , employeeobj.StateId, employeeobj.SSN, employeeobj.HomePhone, employeeobj.BirthDate, employeeobj.Gender, employeeobj.MaritalStatus
                            , employeeobj.HomeEmail, output).ToList();

                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Employee SelectEmployeeById(int userId, int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeResult = hrmsEntity.usp_SelectEmployeeById(userId, companyId).ToList();
                    var employeeList = lstEmployeeResult.Select(employeeObj => new Employee
                    {
                        EmploymentId = employeeObj.EmploymentId,
                        CountryId = employeeObj.CountryId,
                        FirstName = employeeObj.FirstName,
                        LastName = employeeObj.LastName,
                        MaritalStatus = employeeObj.MaritalStatus,
                        OkToRehire = employeeObj.OkToRehire,
                        Address1 = employeeObj.Address1,
                        Address2 = employeeObj.Address2,
                        BenefitClass = employeeObj.BenefitClass,
                        BirthDate = employeeObj.BirthDate,
                        ChangeReason = employeeObj.ChangeReason,
                        CheckDistribution = employeeObj.CheckDistribution,
                        City = employeeObj.City,
                        ComplianceCode = employeeObj.ComplianceCode,
                        DepartmentId = employeeObj.DepartmentId,
                        DirectDepositEmail = employeeObj.DirectDepositEmail,
                        DistrictCode = employeeObj.DistrictCode,
                        DivisionId = employeeObj.DivisionId,
                        Email = employeeObj.Email,
                        EmployeeNo = employeeObj.EmployeeNo,
                        EmploymentDetailId = employeeObj.EmploymentDetailId,
                        EmploymentStatus = employeeObj.EmploymentStatus,
                        EmploymentType = employeeObj.EmploymentType,
                        FLSAStatus = employeeObj.FLSAStatus,
                        Gender = employeeObj.Gender,
                        HireDate = employeeObj.HireDate,
                        HomeEmail = employeeObj.HomeEmail,
                        HomePhone = employeeObj.HomePhone,
                        JobProfileId = employeeObj.JobProfileId,
                        LastPaidDate = employeeObj.LastPaidDate,
                        LastPayRise = employeeObj.LastPayRise,
                        LastPromotionDate = employeeObj.LastPromotionDate,
                        LastReviewDate = employeeObj.LastReviewDate,
                        LocationId = employeeObj.LocationId,
                        ManagerId = employeeObj.ManagerId,
                        MiddleName = employeeObj.MiddleName,
                        NewHireReportDate = employeeObj.NewHireReportDate,
                        NextReviewDate = employeeObj.NextReviewDate,
                        OriginalHireDate = employeeObj.OriginalHireDate,
                        PayGroup = employeeObj.PayGroup,
                        PositionId = employeeObj.PositionId,
                        Salutation = employeeObj.Salutation,
                        SeniorityDate = employeeObj.SeniorityDate,
                        SSN = employeeObj.SSN,
                        StartDate = employeeObj.StartDate,
                        StateId = employeeObj.StateId,
                        Suffix = employeeObj.Suffix,
                        TerminationDate = employeeObj.TerminationDate,
                        TerminationReason = employeeObj.TerminationReason,
                        Union = employeeObj.Union,
                        UserId = employeeObj.UserId,
                        WCJobClassCode = employeeObj.WCJobClassCode,
                        WCStatus = employeeObj.WCStatus,
                        WCType = employeeObj.WCType,
                        WorkEmail = employeeObj.WorkEmail,
                        WorkPhone = employeeObj.WorkPhone,
                        ZIP = employeeObj.ZIP
                    }).ToList();
                    return employeeList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Returnss Employees By ComanyId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<Employee> SelectEmployeeByCompanyId(int companyId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeResult = hrmsEntity.usp_SelectEmployeeByCompanyId(companyId).ToList();
                    var employeeList = lstEmployeeResult.Select(employeeObj => new Employee
                    {
                        EmploymentId = employeeObj.EmploymentId,
                        CountryId = employeeObj.CountryId,
                        FirstName = employeeObj.FirstName,
                        LastName = employeeObj.LastName,
                        MaritalStatus = employeeObj.MaritalStatus,
                        OkToRehire = employeeObj.OkToRehire,
                        Address1 = employeeObj.Address1,
                        Address2 = employeeObj.Address2,
                        BenefitClass = employeeObj.BenefitClass,
                        BirthDate = employeeObj.BirthDate,
                        ChangeReason = employeeObj.ChangeReason,
                        CheckDistribution = employeeObj.CheckDistribution,
                        City = employeeObj.City,
                        ComplianceCode = employeeObj.ComplianceCode,
                        DepartmentId = employeeObj.DepartmentId,
                        DirectDepositEmail = employeeObj.DirectDepositEmail,
                        DistrictCode = employeeObj.DistrictCode,
                        DivisionId = employeeObj.DivisionId,
                        Email = employeeObj.Email,
                        EmployeeNo = employeeObj.EmployeeNo,
                        EmploymentDetailId = employeeObj.EmploymentDetailId,
                        EmploymentStatus = employeeObj.EmploymentStatus,
                        EmploymentType = employeeObj.EmploymentType,
                        FLSAStatus = employeeObj.FLSAStatus,
                        Gender = employeeObj.Gender,
                        HireDate = employeeObj.HireDate,
                        HomeEmail = employeeObj.HomeEmail,
                        HomePhone = employeeObj.HomePhone,
                        JobProfileId = employeeObj.JobProfileId,
                        LastPaidDate = employeeObj.LastPaidDate,
                        LastPayRise = employeeObj.LastPayRise,
                        LastPromotionDate = employeeObj.LastPromotionDate,
                        LastReviewDate = employeeObj.LastReviewDate,
                        LocationId = employeeObj.LocationId,
                        ManagerId = employeeObj.ManagerId,
                        MiddleName = employeeObj.MiddleName,
                        NewHireReportDate = employeeObj.NewHireReportDate,
                        NextReviewDate = employeeObj.NextReviewDate,
                        OriginalHireDate = employeeObj.OriginalHireDate,
                        PayGroup = employeeObj.PayGroup,
                        PositionId = employeeObj.PositionId,
                        Salutation = employeeObj.Salutation,
                        SeniorityDate = employeeObj.SeniorityDate,
                        SSN = employeeObj.SSN,
                        StartDate = employeeObj.StartDate,
                        StateId = employeeObj.StateId,
                        Suffix = employeeObj.Suffix,
                        TerminationDate = employeeObj.TerminationDate,
                        TerminationReason = employeeObj.TerminationReason,
                        Union = employeeObj.Union,
                        UserId = employeeObj.UserId,
                        WCJobClassCode = employeeObj.WCJobClassCode,
                        WCStatus = employeeObj.WCStatus,
                        WCType = employeeObj.WCType,
                        WorkEmail = employeeObj.WorkEmail,
                        WorkPhone = employeeObj.WorkPhone,
                        ZIP = employeeObj.ZIP
                    }).ToList();
                    return employeeList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
