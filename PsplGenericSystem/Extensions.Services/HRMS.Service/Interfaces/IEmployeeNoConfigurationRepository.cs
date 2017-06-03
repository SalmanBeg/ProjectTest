using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IEmployeeNoConfigurationRepository
    {
        int CreateEmployeeNoConfiguration(EmployeeNoConfiguration employeeNoConfigurationObj);
        EmployeeNoConfiguration SelectEmployeeNoConfigurationbyCompanyId(int companyId);
        int UpdateEmployeeNoConfiguration(EmployeeNoConfiguration employeeNoConfigurationObj);
        string GenerateEmployeeNo(int companyId);
    }
}
