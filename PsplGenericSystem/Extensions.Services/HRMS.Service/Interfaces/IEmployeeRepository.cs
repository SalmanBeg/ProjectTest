using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IEmployeeRepository
    {
        [Logger]
        [ExceptionLogger]
        bool CreateEmployee(Employee employeeobj);

        [Logger]
        [ExceptionLogger]
        Employee SelectEmployeeById(int userId, int companyId);

        /// <summary>
        /// Returnss Employees By ComanyId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Employee> SelectEmployeeByCompanyId(int companyId);
    }
}
