using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IEmployeeOSHARepository
    {
        bool CreateEmployeeOSHADetails(EmployeeOSHADetail employeeoshadetailobj);
        bool UpdateEmployeeOSHADetails(EmployeeOSHADetail employeeoshadetailobj);
        List<EmployeeOSHADetail> SelectEmployeeOSHADetail(int companyId, int userId);
        EmployeeOSHADetail SelectEmployeeOSHADetailById(int employeeOSHADetailId,int companyId);
        bool DeleteOSHADetail(int OSHADetailId, int companyId);
    }
}
