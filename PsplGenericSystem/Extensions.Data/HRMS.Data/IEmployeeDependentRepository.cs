using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
   public interface IEmployeeDependentRepository
   {
       bool AddDependentDetail(EmployeeDependentDetail employeeDependentDetailobj);

       List<EmployeeDependentDetail> SelectAllEmployeeDependentDetail(int userId, int companyId);

       List<EmployeeDependentDetail> SelectEmployeeDependentDetailByDependentId(int employeeDependentId, int companyId);

       bool UpdateEmployeeDependentDetail(EmployeeDependentDetail employeeDependentDetailobj);

       bool DeleteDependentDetail(int employeeDependentDetailId,int companyId);
    }
}
