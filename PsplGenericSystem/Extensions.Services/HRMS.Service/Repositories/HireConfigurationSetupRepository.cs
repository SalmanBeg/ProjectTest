using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkExtras.EF6;
using HRMS.Common.Enums;
using HRMS.Service;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtensionProc;

namespace HRMS.Service.Repositories
{
    public class HireConfigurationSetupRepository : IHireConfigurationSetupRepository
    {
        public bool CreateHireConfigurationSetup(HireConfigurationSetup hireConfigurationSetupobj, string currentUserId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_HireConfigurationSetupInsert(hireConfigurationSetupobj.UserId, hireConfigurationSetupobj.CompanyId
                               , hireConfigurationSetupobj.UserCode, hireConfigurationSetupobj.CreatedBy, hireConfigurationSetupobj.IsSubmitted).ToList();
                    return result.Count > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }
        public HireConfigurationSetup NewUserConfigurationSetupSelect(int userId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstNewHireConfigResult = hrmsEntity.usp_NewUserConfigurationSetupSelect(companyId, userId).ToList();
                    var hireconfigurationList = lstNewHireConfigResult.Select(hireconfigsetup => new HireConfigurationSetup
                    {
                        CompanyId = hireconfigsetup.CompanyId,
                        UserId = hireconfigsetup.UserId,
                        UserCode = hireconfigsetup.UserCode
                    }).ToList();
                    return hireconfigurationList.SingleOrDefault(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateHireStatusofEmployee(int userId, bool status)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateHireStatusofEmployee(userId, status);
                    return result > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<HireStepMaster> SelectAllHireSteps()
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstHireStepMasterResult = hrmsEntity.usp_HireStepMasterSelect().ToList();
                    return lstHireStepMasterResult.Select(hireconfigsetup => new HireStepMaster
                    {
                        StepId = hireconfigsetup.StepId,
                        StepName = hireconfigsetup.StepName
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<HireApprovalSetup> SelectAllHireStepsById(int userId)
        {
          
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstHireApprovalResult = hrmsEntity.usp_HireApprovalSetupSelect(userId).ToList();
                    return lstHireApprovalResult.Select(hireapproval => new HireApprovalSetup
                    {
                        UserId = hireapproval.UserId,
                        StepId = hireapproval.StepId,
                        StepName = hireapproval.StepName,
                        IsActive = hireapproval.IsActive,
                        IsApproved = hireapproval.IsApproved
                    }).ToList(); 
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateStepSubmitStatus(int userId, int stepId, bool status)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_HireApprovalSetupIsSubmitUpdate(userId, stepId, status);
                    return result > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CreateEmployeeConfigurationSetup(Employee employeeObj, EmployeePay employeePayObj, RegisteredUsers registeredUsersObj, OnBoarding onBoardingobj, List<HireStepMaster> hireStepMasterList, GeneralEnum.RoleName roleName, int createdBy)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var proc = new ExtendedStoredProcedures.UspCreateEmployeeConfigurationSetup()
                           {
                               firstName = employeeObj.FirstName,
                               lastName = employeeObj.LastName,
                               companyId = employeeObj.CompanyId,
                               createdBy = createdBy,
                               email = employeeObj.Email,
                               errorCode = null,
                               hireDate = employeeObj.HireDate,

                               isApproved = registeredUsersObj.IsApproved,
                               isLockedOut = registeredUsersObj.IsLockedOut,
                               jobProfileId = employeeObj.JobProfileId,
                               passwordQuestion = registeredUsersObj.PasswordQuestion,
                               passwordAnswer = registeredUsersObj.PasswordAnswer,
                               password = registeredUsersObj.Password,
                               userName = registeredUsersObj.UserName,
                               RoleName = roleName.ToString(),
                               EmploymentStatusId = Convert.ToInt32(employeeObj.EmploymentStatus),
                               ManagerId = Convert.ToInt32(employeeObj.ManagerId),
                               Compensation = Convert.ToDouble(employeePayObj.Compensation),
                               CompensationFrequency = Convert.ToInt32(employeePayObj.CompensationFrequency),
                               EmployeeNo = employeeObj.EmployeeNo,
                               UdtStepName = hireStepMasterList.Select(hireStepMaster => new ExtendedStoredProcedures.UdtStepName
                               {
                                   StepId = hireStepMaster.StepId,
                                   StepName = hireStepMaster.StepName,
                                   Active = hireStepMaster.IsSelected
                               }).ToList(),
                               onBoardingId = onBoardingobj.OnBoardingId

                           };

                    hrmsEntity.Database.ExecuteStoredProcedure(proc);
                    return true; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Employee> SelectAllNewHires(int companyId)
        {
          
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstAllNewHireResult = hrmsEntity.usp_SelectNewHires(companyId).ToList();
                    return lstAllNewHireResult.Select(newhireemplpoyee => new Employee
                    {
                        Email = newhireemplpoyee.Email,
                        UserId = newhireemplpoyee.UserID,
                        UserName = newhireemplpoyee.UserName,
                        UserCode = newhireemplpoyee.UserCode,
                        FirstName = newhireemplpoyee.FirstName,
                        LastName = newhireemplpoyee.LastName,
                        CompanyId = newhireemplpoyee.CompanyId,
                        IsApproved = newhireemplpoyee.IsApproved,
                        IsSubmitted = newhireemplpoyee.IsSubmitted

                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
