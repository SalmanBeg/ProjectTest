using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;


namespace HRMS.Service.Interfaces
{
    public interface IRegisteredUsersRepository
    {
        [Logger]
        [ExceptionLogger]
        int CreateUserAccount(RegisteredUsers registeredUsersobj, Employee employeeobj, CompanyInfo companyInfoobj);
        
        [Logger]
        [ExceptionLogger]
        List<UserLoginModel> ValidateUser(string Email, string Password);
        
        [Logger]
        [ExceptionLogger]
        bool ChangePassword(string oldPassword, String newPassword, int userId);

        [Logger]
        [ExceptionLogger]
        bool UpdateNewHireStatus(int userId, bool status);

        [Logger]
        [ExceptionLogger]
        bool ResetPassword(string userEmail, string newPassword);

        [Logger]
        [ExceptionLogger]
        List<UserLoginModel> SelectAllEmployeesList(int companyId);

        [Logger]
        [ExceptionLogger]
        List<UserLoginModel> ShowAllEmployeesPendingListByCompanyId(int companyId);

        [Logger]
        [ExceptionLogger]
        bool UpdateHireApprovalSetup(string stepName, int userId);

        [Logger]
        [ExceptionLogger]
        List<HireApprovalSetup> HireApprovalStatusSelect(int userId);

        [Logger]
        [ExceptionLogger]
        List<UserLoginModel> SelectAllManager(int companyId);

        /// <summary>
        /// Employees by PositionId
        /// </summary>
        /// <param name="comapanyId"></param>
        /// <param name="positionID"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Employee> SelectAllEmployeesByPosition(int comapanyId, int positionId);
          /// <summary>
        /// Employees by DivisionId
        /// </summary>
        /// <param name="comapanyId"></param>
        /// <param name="divisionId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Employee> SelectAllEmployeesByDivision(int comapanyId, int divisionId);
        /// <summary>
        /// Employees by LocatonId
        /// </summary>
        /// <param name="comapanyId"></param>
        /// <param name="locationID"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Employee> SelectAllEmployeesByLocation(int comapanyId, int locationID);

        /// <summary>
        /// Returns employees by Department
        /// </summary>
        /// <param name="comapanyId"></param>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Employee> SelectAllEmployeesByDepartment(int comapanyId, int departmentID);

        /// <summary>
        /// Retursn the employees by EmploymentStatus
        /// </summary>
        /// <param name="comapanyId"></param>
        /// <param name="employmentStatusID"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Employee> SelectAllEmployeesByEmploymentStatus(int comapanyId, int employmentStatusID);

        /// <summary>
        /// Returns the empoyees by EmploymentType
        /// </summary>
        /// <param name="comapanyId"></param>
        /// <param name="employmentTypeId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Employee> SelectAllEmployeesByEmploymentType(int comapanyId, int employmentTypeId);

        /// <summary>
        /// Returns employees by Job
        /// </summary>
        /// <param name="comapanyId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Employee> SelectAllEmployeesByJob(int comapanyId, int jobId);

        /// <summary>
        /// Returns superadministrators
        /// </summary>
        /// <returns>List of superadmin</returns>
        /// [Logger]
        [ExceptionLogger]
        List<UserLoginModel> SelectAllSuperAdmin();

        /// <summary>
        /// to validate email while registration
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// [Logger]
        [ExceptionLogger]
        bool ValidateEmailForRegistration(string email);
        
       /// <summary>
       /// To validate UserName while Registration
       /// </summary>
       /// <param name="UserName"></param>
       /// <returns></returns>
        [ExceptionLogger]
        bool ValidateUserName(string UserName);

        [Logger]
        [ExceptionLogger]
        bool ChangeUsername(int userId, String newUserName);

        /// <summary>
        /// To filter employee based on role,user and companyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<UserLoginModel> SelectAllEmployeesListByRoleandUser(int companyId, int roleId, int userId);

        /// <summary>
        /// To validate email based on company
        /// </summary>
        /// <param name="email"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [ExceptionLogger]
        bool ValidateEmailForRegistrationBasedOnCompany(string email, int companyId);


        //[Logger]
        //[ExceptionLogger]
        //bool UpdateSuperAdmin(Employee employeeobj);

    }
}
