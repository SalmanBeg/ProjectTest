using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IEmployeeRepository
    {
         bool CreateEmployee(Employee employeeobj);

         Employee SelectEmployeeById(int employmentDetailId, int companyId);
    }
}
