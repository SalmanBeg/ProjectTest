using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface IW4FormRepository
   {
       /// <summary>
       /// Creates a new record for W4Form
       /// </summary>
       /// <param name="employeeW4Formobj"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool AddEmployeeW4Form(EmployeeW4Form employeeW4Formobj);
       /// <summary>
       /// Retrieves a W4 record based on companyId and userId
       /// </summary>
       /// <param name="companyId"></param>
       /// <param name="userId"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       List<EmployeeW4Form> SelectEmployeeW4FormByUserId(int companyId, int userId);
       /// <summary>
       /// Updates an existing record based on record Id
       /// </summary>
       /// <param name="employeeW4Formobj"></param>
       /// <returns></returns>
       [Logger]
       [ExceptionLogger]
       bool UpdateEmployeeW4Form(EmployeeW4Form employeeW4Formobj);
    }
}
