using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IPayDetailRepository
    {
        bool AddPayDetail(EmployeePayDetail emppaydet);
        bool UpdatePayDetail(EmployeePayDetail emppaydet);
        bool DeletePayDetail(EmployeePayDetail emppaydet);
        EmployeePayDetail SelectPayDetail(int CompanyId, int UserId);
    }
}
