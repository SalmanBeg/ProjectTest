using HRMS.Service.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Interfaces
{
    public interface IEmployeeAssetRepository
    {
        [Logger]
        [ExceptionLogger]
        bool CreateEmployeeAsset(EmployeeAsset employeeAssetobj);

        [Logger]
        [ExceptionLogger]
        bool UpdateEmployeeAssetById(EmployeeAsset employeeAssetobj);

        [Logger]
        [ExceptionLogger]
        EmployeeAsset GetEmployeeAssetByAssetId(int employeeAssetId);

        [Logger]
        [ExceptionLogger]
        List<EmployeeAsset> GetAllEmployeeAssetByUserId(int userId);

        [Logger]
        [ExceptionLogger]
        bool DeleteEmployeeAssetById(int employeeSignById);
    }
}
