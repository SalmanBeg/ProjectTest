using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface ITaxRepository
    {
       [Logger]
       [ExceptionLogger]
       bool CreateEmployeeTax(EmployeeTax employeeTaxobj);

       [Logger]
       [ExceptionLogger]
       bool DeleteEmployeeTax(EmployeeTax employeeTaxobj);

       [Logger]
       [ExceptionLogger]
       bool UpdateEmployeeTax(EmployeeTax employeeTaxobj);

       [Logger]
       [ExceptionLogger]
       EmployeeTax SelectEmployeeTax(int userId, int companyId);


    }
}
