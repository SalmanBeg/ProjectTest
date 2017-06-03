using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Common.Enums;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IHireConfigurationSetupRepository
    {
        [Logger]
        [ExceptionLogger]
        bool CreateHireConfigurationSetup(HireConfigurationSetup hireConfigurationSetupobj, string currentUserId);

        [Logger]
        [ExceptionLogger]
        HireConfigurationSetup NewUserConfigurationSetupSelect(int userId, int companyId);

        [Logger]
        [ExceptionLogger]
        bool UpdateHireStatusofEmployee(int userId, bool status);

        [Logger]
        [ExceptionLogger]
        List<HireStepMaster> SelectAllHireSteps();

        [Logger]
        [ExceptionLogger]
        List<HireApprovalSetup> SelectAllHireStepsById(int userId);

        [Logger]
        [ExceptionLogger]
        bool UpdateStepSubmitStatus(int userId, int stepId, bool status);

        [Logger]
        [ExceptionLogger]
        bool CreateEmployeeConfigurationSetup(Employee employeeObj, EmployeePay employeePayObj, RegisteredUsers registeredUsersObj, OnBoarding onBoardingobj,
            List<HireStepMaster> hireStepMasterList,GeneralEnum.RoleName roleName, int createdBy);

        [Logger]
        [ExceptionLogger]
        List<Employee> SelectAllNewHires(int companyId);
    }
}
