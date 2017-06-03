using HRMS.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Data
{
   public interface IDirectDepositRepository
    {
       bool AddDirectDepositDetail(EmployeeDirectDepositDetail empdirdetobj);
       bool DeleteDirectDepositDetail(int employeeDirectDepositDetailId);
       bool UpdateDirectDepositDetail(EmployeeDirectDepositDetail employeeDirectDepositDetailobj);
       List<EmployeeDirectDepositDetail> SelectDirectDepositDetail(int CompanyId,int UserId);
       EmployeeDirectDepositDetail SelectDirectDepositDetailById(int CompanyId, int UserId, int DirectDepositDetailId);
    }
}
