using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.Data;

namespace HRMS.Data
{
    public interface IUserRepository
    {
        bool RegisterUser(UserSignUp userSignUpobj, Employee employeeobj, CompanyInfo companyinfoobj);
        UserLoginModel ValidateUser(string email, string password);

        bool CreateEmployeeConfigurationSetup(EmployeeConfigurationSetupModel employeeConfigurationSetupobj,
                                              string createdBy, DataTable hireWizardSteps);

        bool ChangePassword(string oldPassword, String newPassword, int userId);
        List<UserLoginModel> SelectAllEmployeesList(int companyId);
        List<UserLoginModel> ShowAllEmployeesPendingListByCompanyId(int companyId);
        bool ResetPassword(string userEmail, string newPassword);
        bool UpdateHireApprovalSetup(string StepName, int UserId);
        List<HireApprovalSetup> HireApprovalStatusSelect(int UserId);
        bool UpdateNewHireStatus(int userId, bool Status);
        List<UserLoginModel> SelectAllManager(int companyId);
        List<Employee> SelectEmployeesByPosition(int positionId, int companyId);
        List<Employee> SelectEmployeesByLocation(int locationId, int companyId);
        List<Employee> SelectEmployeesByDepartment(int departmentId, int companyId);
        List<Employee> SelectEmployeesByEmploymentStatus(int employmentStatusId, int companyId);
        List<UserLoginModel> SelectAllUserList(string Username);
    }
}