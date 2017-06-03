using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IEmployeeW4FormRepository
    {
        bool AddEmployeeW4Form(EmployeeW4Form employeeW4formobj);
        EmployeeW4Form SelectEmployeeW4FormDetailByUserId(int userId, int companyId);
        bool UpdateEmployeeW4FormDetail(EmployeeW4Form employeeW4formobj);
    }
}
