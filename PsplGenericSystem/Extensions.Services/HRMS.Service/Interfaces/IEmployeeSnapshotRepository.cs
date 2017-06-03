using HRMS.Service.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.ExtendedModels;

namespace HRMS.Service.Interfaces
{
    public interface IEmployeeSnapshotRepository
    {
        [Logger]
        [ExceptionLogger]
        EmployeeSnapshot SelectEmployeeSnapshotById(int UserId, int CompanyId);
    }
}
