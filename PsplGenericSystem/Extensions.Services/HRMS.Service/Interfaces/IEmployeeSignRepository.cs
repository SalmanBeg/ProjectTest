using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface IEmployeeSignRepository
   {
       [Logger]
       [ExceptionLogger]
       bool CreateEmployeeSign(EmployeeSign employeeSignobj);
       
       [Logger]
       [ExceptionLogger]
       bool UpdateEmployeeSignById(EmployeeSign employeeSignobj);

       [Logger]
       [ExceptionLogger]
       EmployeeSign GetEmployeeSign(int employeeSignId);

       [Logger]
       [ExceptionLogger]
       List<EmployeeSign> GetAllEmployeeSignByUserId(int userId);

       [Logger]
       [ExceptionLogger]
       bool DeleteEmployeeSignById(int employeeSignById);

       [Logger]
       [ExceptionLogger]
       bool UpdateEmployeeDefaultSign(int userId, int companyId, int signId);

       [Logger]
       [ExceptionLogger]
       bool DeleteEmployeeSign(int employeeSignId);
    }
}
