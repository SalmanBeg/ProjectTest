using HRSystem.Services.Models;
using System.Collections.Generic;
using System.Data;
namespace HRSystem.Services.Interfaces
{
    public interface IAccounts
    {
        MainEmployee GetUserDetails(string userName, string connectionString);
        MainEmployee GetEmployeePhotoByuserID(string userId, string companyId, string connectionString);
        MainEmployee GetEmployeePersonalInfo(string userId, string connectionString);
        List<Employee> GetRecentHireEmployeeInfo(string companyId, string connectionString);
        List<Employee> GetTerminationEmployeeInfo(string companyId, string connectionString);
        List<Employee> GetOpenEnrollmentEmployeeInfo(string companyId, string connectionString);
    }
}
