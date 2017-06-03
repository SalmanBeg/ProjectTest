using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Interfaces
{
    public interface ICompanyLevelSecurityRepository
    {
        /// <summary>
        /// method where companylevelsecurityobject, list of form entity elements,list of module entity elements are supplied
        /// </summary>
        /// <param name="companyLevelSecurityObj"></param>
        /// <param name="forms"></param>
        /// <param name="modules"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool CreateCompanyLevelSecurity(CompanyLevelSecurity companyLevelSecurityObj, List<Form> forms, List<Module> modules);
        /// <summary>
        /// supplying after the update operation for rebinding the form with updated values from database
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        CompanyLevelSecurity SelectCompanyLevelSecurities(int companyId, int roleId);
        /// <summary>
        /// to handle menu related items and its navigation properties
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<OrganizationMenu> ListCompanyMenu(int companyId, int roleId);
        /// <summary>
        /// to handle module related items and its navigation properties
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Module> ListModules(int companyId, int roleId);
        /// <summary>
        /// to handle forms related items and its navigation properties
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Form> ListForms(int companyId, int roleId);
        /// <summary>
        /// To update form based on formId
        /// </summary>
        /// <param name="formObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateForms(Form formObj);
        /// <summary>
        /// To create a new form
        /// </summary>
        /// <param name="formObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool InsertForms(Form formObj);
        /// <summary>
        /// to save company level security based on employeeSendCriteriaId,companyLevelSecurityId and selectedId
        /// </summary>
        /// <param name="employeeSendCriteriaId"></param>
        /// <param name="companyLevelSecurityId"></param>
        /// <param name="selectedId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool SaveCompanyLevelSecurity(int employeeSendCriteriaId, int companyLevelSecurityId, int selectedId);
        /// <summary>
        /// to fileter employee by criteria
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<EmployeeFilterCriteria> DefaultEmployeeFilterCriteria(int CompanyId);
        /// <summary>
        /// to get company level security based on company level security Id
        /// </summary>
        /// <param name="companyLevelSecurityId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CompanyLevelSaveLog> GetCompanyLevelSecurityCriteriaById(int companyLevelSecurityId);
        /// <summary>
        /// to get company level employee based on company level security Id and employee Id
        /// </summary>
        /// <param name="companyLevelSecurityId"></param>
        /// <param name="employeeId"></param>
        /// <param name="status"></param>
        /// <param name="employeeEmail"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool AddComanyLevelEmployee(int companyLevelSecurityId, int employeeId, bool status, string employeeEmail, string employeeName);
        /// <summary>
        /// to get company level security id based on role id and company id
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        int GetCompanyLevelSecurityId(int companyId, int roleId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyLevelSecurityId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        int GetCompanyLevelSendCriteriaId(int companyLevelSecurityId, int roleId);
    }
}
