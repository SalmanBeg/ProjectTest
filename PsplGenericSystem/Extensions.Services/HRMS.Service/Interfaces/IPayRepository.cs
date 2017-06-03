using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IPayRepository
    {
        [Logger]
        [ExceptionLogger]
        bool AddPay(EmployeePay employeePayobj);

        [Logger]
        [ExceptionLogger]
        bool UpdatePay(EmployeePay employeePayobj);

        [Logger]
        [ExceptionLogger]
        bool DeletePay(EmployeePay employeePayobj);

        [Logger]
        [ExceptionLogger]
        EmployeePay SelectPay(int companyId, int userId);

       [Logger]
        [ExceptionLogger]
        PayPeriods GetEmployeePayPeriodDates(int companyId, int userId);

    }
}
