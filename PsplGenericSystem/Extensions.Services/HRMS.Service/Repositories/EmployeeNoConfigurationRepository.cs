using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;



namespace HRMS.Service.Repositories
{
    public class EmployeeNoConfigurationRepository : IEmployeeNoConfigurationRepository
    {
        /// <summary>
        /// To Create EmployeeNoConfiguration
        /// </summary>
        /// <param name="employeeNoConfigurationObj"></param>
        /// <returns></returns>
        public int CreateEmployeeNoConfiguration(EmployeeNoConfiguration employeeNoConfigurationObj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("EmployeeNoId", typeof(int));

                    var res = hrmsEntity.usp_CreateEmployeeNoConfiguration(output, employeeNoConfigurationObj.CompanyId, employeeNoConfigurationObj.Prefix, employeeNoConfigurationObj.StartValue, employeeNoConfigurationObj.IncrementValue, employeeNoConfigurationObj.CreatedBy);
                    return res;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// selecting EmpNoConfiguration details based on companyid
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public EmployeeNoConfiguration SelectEmployeeNoConfigurationbyCompanyId(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstEmployeeNoConfiguration = hrmsEntity.usp_SelectEmployeeNoConfigurationbyCompanyId(companyId).ToList();
                    var employeeNoConfigurationList = lstEmployeeNoConfiguration.Select(employeeNoConfigurationObj => new EmployeeNoConfiguration
                    {
                        EmployeeNoId = employeeNoConfigurationObj.EmployeeNoId,
                        IncrementValue = employeeNoConfigurationObj.IncrementValue,
                        Prefix = employeeNoConfigurationObj.Prefix,
                        StartValue = employeeNoConfigurationObj.StartValue,

                    }).ToList();
                    return employeeNoConfigurationList.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// updating empno configurations based on EmployeeNoid
        /// </summary>
        /// <param name="employeeNoConfigurationObj"></param>
        /// <returns></returns>
        public int UpdateEmployeeNoConfiguration(EmployeeNoConfiguration employeeNoConfigurationObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateEmployeeNoConfiguration(employeeNoConfigurationObj.EmployeeNoId, employeeNoConfigurationObj.Prefix, employeeNoConfigurationObj.StartValue, employeeNoConfigurationObj.IncrementValue, employeeNoConfigurationObj.ModifiedBy);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public string GenerateEmployeeNo(int companyId)
        {
            try
            {
                using ( var hrmsEntity = new HRMSEntities1())
                {
                    var res = hrmsEntity.usp_GenerateNewEmployeeNoByCompany(companyId);
                    return res.FirstOrDefault(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
