using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.ExtendedModels;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class EmployeeSnapshotRepository : IEmployeeSnapshotRepository
    {
        public EmployeeSnapshot SelectEmployeeSnapshotById(int userId, int companyId)
        {
            
            
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeResult = hrmsEntity.usp_EmployeeSnapshotSelectAll(userId, companyId).ToList();
                    var employeeList = lstEmployeeResult.Select(employeeObj => new EmployeeSnapshot
                    {
                        UserId = employeeObj.UserId,
                        CompanyId = employeeObj.CompanyId,
                        FirstName = employeeObj.FirstName,
                        LastName = employeeObj.LastName,
                        MiddleName = employeeObj.MiddleName,
                        Email = employeeObj.Email,
                        Address1 = employeeObj.Address1,
                        Address2 = employeeObj.Address2,
                        City = employeeObj.City,
                        ZIP = employeeObj.ZIP,
                        SSN = employeeObj.SSN,
                        WorkPhone = employeeObj.WorkPhone,
                        HomePhone = employeeObj.HomePhone,
                        BirthDate = Convert.ToDateTime(employeeObj.BirthDate),
                        HomeEmail = employeeObj.HomeEmail,
                        HireDate = Convert.ToDateTime(employeeObj.HireDate),
                        OriginalHireDate = Convert.ToDateTime(employeeObj.OriginalHireDate),
                        TerminationDate = Convert.ToDateTime(employeeObj.TerminationDate),
                        WorkEmail = employeeObj.WorkEmail,
                        StartDate = Convert.ToDateTime(employeeObj.StartDate),
                        SeniorityDate = Convert.ToDateTime(employeeObj.SeniorityDate),
                        LastPaidDate = Convert.ToDateTime(employeeObj.LastPaidDate),
                        LastPayRise = Convert.ToDateTime(employeeObj.LastPayRise),
                        LastReviewDate = Convert.ToDateTime(employeeObj.LastReviewDate),
                        NextReviewDate = Convert.ToDateTime(employeeObj.NextReviewDate),
                        Department = employeeObj.Department,
                        Suffix = employeeObj.Suffix,
                        Salutation = employeeObj.Salutation,
                        JobDescription = employeeObj.JobDescription,
                        Division = employeeObj.Division,
                        Position = employeeObj.Position,
                        MaritalStatus = employeeObj.MaritalStatus,
                    }).ToList();
                    return employeeList.SingleOrDefault(); 
                }
            }
            catch (Exception )
            {
                throw ;
            }
           
        }
    }
}
