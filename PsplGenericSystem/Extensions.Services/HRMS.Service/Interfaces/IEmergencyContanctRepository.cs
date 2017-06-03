using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IEmergencyContanctRepository
    {
        [Logger]
        [ExceptionLogger]
        bool AddEmergencyContact(EmployeeEmergencyContact employeeEmergencyContactobj);

        [Logger]
        [ExceptionLogger]
        bool DeleteEmergencyContact(int EmployeeEmergencyContactId);

        [Logger]
        [ExceptionLogger]
        bool UpdateEmergencyContact(EmployeeEmergencyContact employeeEmergencyContactobj);

        [Logger]
        [ExceptionLogger]
        List<EmployeeEmergencyContact> SelectAllEmergencyContact(int userId, int companyId);

        [Logger]
        [ExceptionLogger]
        List<EmployeeEmergencyContact> SelectEmergencyContactByEmergencyContactId(int emergencyContactId, int companyId);
    }
}
