using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;
using System.Data;

namespace HRMS.Service.Interfaces
{
    public interface IDirectDepositRepository
    {
        [Logger]
        [ExceptionLogger]
        EmployeeDirectDeposit AddDirectDeposit(EmployeeDirectDeposit employeeDirectDepositobj);

        [Logger]
        [ExceptionLogger]
        bool InsertEmployeeDirectDepositBulk(DataTable dtReviewScoreContent);
        bool DeleteDirectDeposit(int employeeDirectDepositId);

        [Logger]
        [ExceptionLogger]
        bool UpdateDirectDeposit(EmployeeDirectDeposit employeeDirectDepositobj);

        [Logger]
        [ExceptionLogger]
        List<EmployeeDirectDeposit> SelectDirectDeposit(int CompanyId, int UserId);

        [Logger]
        [ExceptionLogger]
        EmployeeDirectDeposit SelectDirectDepositById(int CompanyId, int UserId, int DirectDepositId);


        [Logger]
        [ExceptionLogger]
        bool UpdateEmployeeDirectDepositBulk(DataTable dtEmployeeDirectDeposit);
    }
}
