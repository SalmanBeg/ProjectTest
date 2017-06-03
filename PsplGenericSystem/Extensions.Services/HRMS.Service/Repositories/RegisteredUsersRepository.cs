using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class RegisteredUsersRepository : IRegisteredUsersRepository
    {

        public int CreateUserAccount(RegisteredUsers registeredUsersobj, Employee employeeobj, CompanyInfo companyInfoobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_CreateRegisteredUsers(companyInfoobj.CompanyName, companyInfoobj.Address1, companyInfoobj.Address2
                        , companyInfoobj.City, companyInfoobj.ZIP, companyInfoobj.StateId, companyInfoobj.CountryId, companyInfoobj.Phone
                          , employeeobj.FirstName, employeeobj.LastName, registeredUsersobj.Email, registeredUsersobj.Password, registeredUsersobj.UserName
                          , registeredUsersobj.IsApproved, registeredUsersobj.IsLockedOut, registeredUsersobj.PasswordQuestion, registeredUsersobj.PasswordAnswer, output);

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidateEmailForRegistration(string email)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = (from usersignupinfo in hrmsEntity.RegisteredUsers
                                  where usersignupinfo.Email == email
                                  select usersignupinfo).ToList();
                    return result.Count() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidateEmailForRegistrationBasedOnCompany(string email,int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = (from usersignupinfo in hrmsEntity.RegisteredUsers
                                  join usercompanyObj in hrmsEntity.UserCompany on usersignupinfo.UserID equals usercompanyObj.UserId
                                  where usersignupinfo.Email == email && usercompanyObj.CompanyId == companyId
                                  select usersignupinfo).ToList();
                    return result.Count() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ValidateUserName(string userName)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = (from usersignupinfo in hrmsEntity.RegisteredUsers 
                                  where usersignupinfo.UserName == userName 
                                  select usersignupinfo).ToList();
                    return result.Count() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<UserLoginModel> ValidateUser(string email, string password)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstValidateResult = hrmsEntity.usp_ValidateUser(email, password);
                    var userLoginModelList = lstValidateResult.Select(userlogin => new UserLoginModel()
                    {
                        UserId = userlogin.UserID,
                        UserCode = userlogin.UserCode,
                        UserName = userlogin.UserName,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        RoleId = userlogin.RoleId,
                        RoleName = userlogin.RoleName,
                        IsApproved = userlogin.IsApproved,
                        LastLoginDate = userlogin.LastLoginDate,
                        Email = userlogin.Email,
                        CompanyId = userlogin.CompanyId,
                        IsSubmitted = userlogin.IsSubmitted,
                        CompanyName = userlogin.CompanyName,
                        FileId = userlogin.FilesDBId,
                        FileName = userlogin.FirstName
                    }).ToList();
                    return userLoginModelList;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangePassword(string oldPassword, String newPassword, int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var i = hrmsEntity.usp_SetPassword(oldPassword, userId, newPassword);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool ChangeUsername(int userId, String newUsername)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var i = hrmsEntity.usp_SetUsername(userId, newUsername);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool UpdateNewHireStatus(int userId, bool status)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateNewHireStatus(userId, status);
                    //its odd after updating not returning the value 1 check it and remove the condition
                    //return result > 0;
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ResetPassword(string userEmail, string newPassword)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    int result = hrmsEntity.usp_ResetPassword(userEmail, newPassword);

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserLoginModel> SelectAllEmployeesList(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeByCompanyId = hrmsEntity.usp_SelectEmployeesByCompanyId(companyId).ToList();
                    var userloginmodelList = lstEmployeeByCompanyId.Select(userlogin => new UserLoginModel
                    {
                        UserId = userlogin.UserID,
                        UserCode = userlogin.UserCode,
                        UserName = userlogin.UserName,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        RoleId = userlogin.RoleId,
                        RoleName = userlogin.RoleName,
                        IsApproved = userlogin.IsApproved,
                        LastLoginDate = userlogin.LastLoginDate,
                        Email = userlogin.Email
                    }).ToList();
                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserLoginModel> SelectAllEmployeesListByRoleandUser(int companyId, int roleId, int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeByCompanyId = hrmsEntity.usp_SelectEmployeesByRoleId(companyId, roleId, userId).ToList();
                    var userloginmodelList = lstEmployeeByCompanyId.Select(userlogin => new UserLoginModel
                    {
                        UserId = userlogin.UserID,
                        UserCode = userlogin.UserCode,
                        UserName = userlogin.UserName,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        RoleId = userlogin.RoleId,
                        RoleName = userlogin.RoleName,
                        IsApproved = userlogin.IsApproved,
                        LastLoginDate = userlogin.LastLoginDate,
                        Email = userlogin.Email
                    }).ToList();

                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserLoginModel> ShowAllEmployeesPendingListByCompanyId(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_ShowAllEmployeesPendingListByCompanyId_Result> lstPendingEmployees = hrmsEntity.usp_ShowAllEmployeesPendingListByCompanyId(companyId).ToList();
                    var userloginmodelList = lstPendingEmployees.Select(userlogin => new UserLoginModel
                    {
                        UserId = userlogin.UserId,
                        UserCode = userlogin.UserCode,
                        CompanyId = userlogin.CompanyId,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        IsSubmitted = userlogin.IsSubmitted
                    }).ToList();
                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateHireApprovalSetup(string stepName, int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_HireApprovalSetupUpdate(stepName, userId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<HireApprovalSetup> HireApprovalStatusSelect(int userId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_HireApprovalSetupSelect_Result> lstHireApprovalStatus =
                               hrmsEntity.usp_HireApprovalSetupSelect(userId).ToList();
                    var hireapprovalsetupList = lstHireApprovalStatus.Select(hireapproval => new HireApprovalSetup
                    {
                        StepName = hireapproval.StepName,
                        IsActive = hireapproval.IsActive,
                        IsApproved = hireapproval.IsApproved,
                        ApprovedOn = hireapproval.ApprovedOn,
                        ApprovedBy = hireapproval.ApprovedBy,
                        RejectedOn = hireapproval.RejectedOn,
                        RejectedBy = hireapproval.RejectedBy,
                        UserId = hireapproval.UserId,
                        HireConfigurationId = hireapproval.HireConfigurationId,
                        HireApprovalSetupId = hireapproval.HireApprovalSetupId
                    }).ToList();
                    return hireapprovalsetupList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserLoginModel> SelectAllManager(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectAllManagers_Result> lstEmployeeByCompanyId = hrmsEntity.usp_SelectAllManagers(companyId).ToList();
                    var userloginmodelList = lstEmployeeByCompanyId.Select(userlogin => new UserLoginModel
                    {
                        UserId = userlogin.UserId,
                        UserName = userlogin.EmployeeName,
                        RoleId = userlogin.RoleId,
                        RoleName = userlogin.RoleName,
                        Email = userlogin.Email
                    }).ToList();
                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// //Employees by PositionId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="locationId"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public List<Employee> SelectAllEmployeesByPosition(int companyId, int positionId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectEmployeeByPosition_Result> lstEmployeeByPositionId = hrmsEntity.usp_SelectEmployeeByPosition(companyId, positionId).ToList();
                    var userloginmodelList = lstEmployeeByPositionId.Select(userlogin => new Employee
                    {
                        UserId = userlogin.UserId,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        Email = userlogin.Email
                    }).ToList();

                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// //Employees by DivisionId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="divisionId"></param>
        /// <returns></returns>
        public List<Employee> SelectAllEmployeesByDivision(int companyId, int divisionId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectEmployeeByDivision_Result> lstEmployeeByDivisionId = hrmsEntity.usp_SelectEmployeeByDivision(companyId, divisionId).ToList();
                    var userloginmodelList = lstEmployeeByDivisionId.Select(userlogin => new Employee
                    {
                        UserId = userlogin.UserId,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        Email = userlogin.Email
                    }).ToList();

                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// //Employees by LocatonId
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public List<Employee> SelectAllEmployeesByLocation(int companyId, int locationId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectEmployeeByLocation_Result> lstEmployeeByLocationId = hrmsEntity.usp_SelectEmployeeByLocation(companyId, locationId).ToList();
                    var userloginmodelList = lstEmployeeByLocationId.Select(userlogin => new Employee
                    {
                        UserId = userlogin.UserId,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        Email = userlogin.Email
                    }).ToList();

                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns employees by Department
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public List<Employee> SelectAllEmployeesByDepartment(int companyId, int departmentId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectEmployeeByDepartment_Result> lstEmployeeByDepartmentId = hrmsEntity.usp_SelectEmployeeByDepartment(companyId, departmentId).ToList();
                    var userloginmodelList = lstEmployeeByDepartmentId.Select(userlogin => new Employee
                    {
                        UserId = userlogin.UserId,
                        FirstName = userlogin.FirstName,
                        //LastName = userlogin.LastName,
                        Email = userlogin.Email
                    }).ToList();

                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns the employees by EmploymentStatus
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="employmentStatusId"></param>
        /// <returns></returns>
        public List<Employee> SelectAllEmployeesByEmploymentStatus(int companyId, int employmentStatusId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectEmployeeByEmploymentStatus_Result> lstEmployeeByEmploymentStatusId = hrmsEntity.usp_SelectEmployeeByEmploymentStatus(companyId, employmentStatusId).ToList();
                    var userloginmodelList = lstEmployeeByEmploymentStatusId.Select(userlogin => new Employee
                    {
                        UserId = userlogin.UserId,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        Email = userlogin.Email
                    }).ToList();

                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns the empoyees by EmploymentType
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="employmentTypeId"></param>
        /// <returns></returns>
        public List<Employee> SelectAllEmployeesByEmploymentType(int companyId, int employmentTypeId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectEmployeeByEmploymentType_Result> lstEmployeeByEmploymentStatusId = hrmsEntity.usp_SelectEmployeeByEmploymentType(companyId, employmentTypeId).ToList();
                    var userloginmodelList = lstEmployeeByEmploymentStatusId.Select(userlogin => new Employee
                    {
                        UserId = userlogin.UserId,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        Email = userlogin.Email
                    }).ToList();
                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns employees by Job
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public List<Employee> SelectAllEmployeesByJob(int companyId, int jobId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectEmployeeByJob_Result> lstEmployeeByJobId = hrmsEntity.usp_SelectEmployeeByJob(companyId, jobId).ToList();
                    var userloginmodelList = lstEmployeeByJobId.Select(userlogin => new Employee
                    {
                        UserId = userlogin.UserId,
                        FirstName = userlogin.FirstName,
                        //LastName = userlogin.LastName,
                        Email = userlogin.Email
                    }).ToList();
                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Returns superadministrators
        /// </summary>
        /// <returns>List of superadmin</returns>
        public List<UserLoginModel> SelectAllSuperAdmin()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_SelectSuperAdmins_Result> lstSuperAdminsResults = hrmsEntity.usp_SelectSuperAdmins().ToList();
                    var userloginmodelList = lstSuperAdminsResults.Select(userlogin => new UserLoginModel
                    {
                        UserId = userlogin.UserId,
                        UserName = userlogin.UserName,
                        FirstName = userlogin.FirstName,
                        LastName = userlogin.LastName,
                        RoleId = userlogin.RoleMasterId,
                        RoleName = userlogin.RoleName,
                        Email = userlogin.Email
                    }).ToList();
                    return userloginmodelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public bool UpdateSuperAdmin(Employee employeeobj)
        //{
        //    try
        //    {
        //        using(var hrmsEntity=new HRMSEntities1)
        //        {
        //            var result = hrmsEntity.usp_s()
        //        }
        //    }
        //}
      
    }
}
