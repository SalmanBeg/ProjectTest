using HRSystem.Services.Models;
using System.Collections.Generic;
namespace HRSystem.Services.Interfaces
{
    public interface ICompanyDashboard
    {
        List<CompanyDashboards> GetCompanyDashboard(int CompanyId, string connectionString);
        List<DOB> GetDOBBasedOnCompanyId(int companyId, string connectionString);
        List<CompanyDashboards> GetOpenEnrollmentStatuses(int companyId, string connectionString);
        List<CompanyDashboards> GetEnrollmentsByType(int companyId, string connectionString);
        List<RecentActivity> GetRecentActivityList(int companyId, string connectionString);
        List<Employee> GetEmployeeList(string userId, int companyId, string roleId, bool isPositionEnabled, bool showConcealded,string connectionString);
        List<Plan> GetAllPlanList(int companyId, string connectionString);
        List<CompanyDashboards> OpenEnrollmentStatusesByPlanType(int companyId, string planType, string connectionString);
        List<EnrollmentType> GetAllEnrollmentList();
        List<CompanyDashboards> GetEnrollmentByTypeByEnrollmentType(int companyId, string EnrollType, string connectionString);
        List<MainEmployee> GetOpenEnrollmentEmployeeInfo(int companyId, string connectionString);
        List<MainEmployee> GetNewHireEmployeeInfo(int companyId, string connectionString);
        List<MainEmployee> GetLifeEventEmployeeInfo(int companyId, string connectionString);
        List<BenefitEnrollment> GetBenefitEnrollmentByLoc(int companyId, string connectionString);
    }
}
