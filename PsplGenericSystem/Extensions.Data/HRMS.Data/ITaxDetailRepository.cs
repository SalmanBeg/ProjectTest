using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface ITaxDetailRepository
    {
        bool CreateEmployeeTaxDetails(EmployeeTaxDetail emptaxdet);
        bool DeleteEmployeeTaxDetails(EmployeeTaxDetail emptaxdet);
        bool UpdateEmployeeTaxDetails(EmployeeTaxDetail employeeTaxDetailobj);
        EmployeeTaxDetail SelectEmployeeTaxDetails(int UserId, int CompanyId);
       
    }
}
