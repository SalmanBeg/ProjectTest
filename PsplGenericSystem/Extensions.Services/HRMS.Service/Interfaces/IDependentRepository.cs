using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface IDependentRepository
    {
       [Logger]
       [ExceptionLogger]
       bool AddDependent(EmployeeDependent employeeDependentobj);

       [Logger]
       [ExceptionLogger]
       List<EmployeeDependent> SelectAllEmployeeDependent(int userId, int companyId);

       [Logger]
       [ExceptionLogger]
       List<EmployeeDependent> SelectEmployeeDependentByDependentId(int employeeDependentId, int companyId);

       [Logger]
       [ExceptionLogger]
       bool UpdateEmployeeDependent(EmployeeDependent employeeDependentobj);

       [Logger]
       [ExceptionLogger]
       bool DeleteDependent(int employeeDependentId, int companyId);
    }
}
