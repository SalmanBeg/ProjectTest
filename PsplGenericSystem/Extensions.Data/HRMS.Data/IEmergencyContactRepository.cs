using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IEmergencyContactRepository
    {
        bool AddEmergencyContactDetail(EmployeeEmergencyContactDetail employeeEmergencyContactDetailobj);
        bool DeleteEmergencyContactDetail(int EmployeeEmergencyContactDetailID);
        bool UpdateEmergencyContactDetail(EmployeeEmergencyContactDetail employeeEmergencyContactDetailobj);
       List<EmployeeEmergencyContactDetail> SelectAllEmergencyContactDetail(int userId, int companyId);
       List<EmployeeEmergencyContactDetail> SelectEmergencyContactDetailByEmergencyContactId(int emergencyContactId, int companyId);
        
    }
}
