using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface IOSHARepository
    {
       [Logger]
       [ExceptionLogger]
       bool CreateEmployeeOSHA(EmployeeOSHA employeeoshaobj);

       [Logger]
       [ExceptionLogger]
       bool UpdateEmployeeOSHA(EmployeeOSHA employeeoshaobj);

       [Logger]
       [ExceptionLogger]
       EmployeeOSHA SelectEmployeeOSHAById(int employeeOSHAId,int companyId);

       [Logger]
       [ExceptionLogger]
       List<EmployeeOSHA> SelectEmployeeOSHA( int userId,int companyId);

       [Logger]
       [ExceptionLogger]
       bool DeleteOSHA(int oshaDetailId, int companyId);

       [Logger]
       [ExceptionLogger]
       bool CaseNoExists(EmployeeOSHA employeeoshaobj);
    }
}
