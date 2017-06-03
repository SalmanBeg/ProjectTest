using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkExtras.EF6;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtensionProc;

namespace HRMS.Service.Repositories
{
    public class CompanyLevelSecurityRepository : ICompanyLevelSecurityRepository
    {


        /// <summary>
        /// Create a record for a role to manage authorization for the employees under the role
        /// </summary>
        /// <param name="companyLevelSecurities"></param>
        /// <returns>bool</returns>
        public bool CreateCompanyLevelSecurity(CompanyLevelSecurity companyLevelSecurityObj, List<Form> forms, List<Module> modules)
        {
            if (forms == null) throw new ArgumentNullException("forms");
            if (modules == null) throw new ArgumentNullException("modules");
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var proc = new ExtendedStoredProcedures.UspManageFormAuthorizationByRole()
                           {
                               companyId = companyLevelSecurityObj.CompanyId,
                               RoleId = companyLevelSecurityObj.RoleId,
                               CanHire = companyLevelSecurityObj.CanHire,
                               CanViewHires = companyLevelSecurityObj.CanViewHires,
                               CanAccessDashBoard = companyLevelSecurityObj.CanAccessDashboard,
                               ModifiedBy = companyLevelSecurityObj.ModifiedBy,
                               EmployeeFilterCriteriaId = companyLevelSecurityObj.EmployeeFilterCriteriaId,

                               UdtFormLevelSecurity = forms.Select(formObj => new ExtendedStoredProcedures.UdtFormLevelSecurity()
                               {
                                   FormId = formObj.FormId,
                                   IsVisible = formObj.IsFormVisible,
                                   IsEditable = formObj.IsFormEditable
                               }).ToList(),
                               UdtModuleLevelSecurity = modules.Select(moduleLevelSecurityObj => new ExtendedStoredProcedures.UdtModuleLevelSecurity()
                               {
                                   ModuleId = moduleLevelSecurityObj.ModuleId,
                                   IsVisible = moduleLevelSecurityObj.IsModuleVisible,
                                   IsEditable = moduleLevelSecurityObj.IsModuleEditable
                               }).ToList(),
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
        /// <summary>
        /// select an individualr record for a role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public CompanyLevelSecurity SelectCompanyLevelSecurities(int companyId, int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var query = (from companylevelsecurity in hrmsEntity.CompanyLevelSecurity
                                 where companylevelsecurity.RoleId == roleId && companylevelsecurity.CompanyId == companyId
                                 select companylevelsecurity).DefaultIfEmpty();

                    CompanyLevelSecurity companyLevelSecurityObj = query.Single();
                    return companyLevelSecurityObj;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// results to a list with forms and its associated modules 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <returns>list</returns>
        public List<OrganizationMenu> ListCompanyMenu(int companyId, int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstCompanyMenuResult = hrmsEntity.usp_ListCompanyMenu(companyId, roleId);

                    return lstCompanyMenuResult.Select(companymenu => new OrganizationMenu()
                    {
                        ModuleId = companymenu.ModuleId,
                        ModuleName = companymenu.ModuleName,
                        ModuleOrder = Convert.ToInt32(companymenu.ModuleOrder),
                        FormId = companymenu.FormId,
                        FormName = companymenu.FormName,
                        ControllerName = companymenu.ControllerName,
                        ActionName = companymenu.ActionName,
                        RouteAttribute = companymenu.RouteAttribute,
                        FormOrderNo = Convert.ToInt32(companymenu.FormOrderNo),
                        DisplayFormName = companymenu.FormDisplayName
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// returns all the master modules for application and with its security for a company and role like IsVisible and IsEditable
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <returns>list</returns>
        public List<Module> ListModules(int companyId, int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var listModuleLevelSecurities = hrmsEntity.usp_ListModuleLevelSecurity(companyId, roleId);
                    //var modules = listModuleLevelSecurities
                    //    .Select(i => new { i.ModuleId, i.ModuleName, i.OrderNo, i.IsVisible, i.IsEditable })
                    //    .Distinct()
                    //    .ToList();

                    return listModuleLevelSecurities.Select(module => new Module()
                    {
                        ModuleId = module.ModuleId,
                        ModuleName = module.ModuleName,
                        OrderNo = Convert.ToInt32(module.OrderNo),
                        IsModuleVisible = Convert.ToBoolean(module.IsVisible),
                        IsModuleEditable = Convert.ToBoolean(module.IsEditable)
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// returns all the master forms for application and with its security for a company and role like IsVisible and IsEditable 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<Form> ListForms(int companyId, int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var listFormLevelSecurities = hrmsEntity.usp_ListFormLevelSecurity(companyId, roleId);
                    return listFormLevelSecurities.Select(form => new Form()
                    {
                        FormId = form.FormId,
                        FormName = form.FormName,
                        OrderNo = form.OrderNo,
                        ModuleId = form.ModuleId,
                        DisplayName = form.DisplayName,
                        ControllerName = form.ControllerName,
                        ActionName = form.ActionName,
                        RouteAttribute = form.RouteAttribute,
                        IsFormVisible = Convert.ToBoolean(form.IsVisible),
                        IsFormEditable = Convert.ToBoolean(form.IsEditable),
                        RoleId = Convert.ToInt32(form.RoleId)

                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        ///Update Form Model Security
        /// </summary>
        /// <param name="formObj"></param>
        /// <returns>bool</returns>
        public bool UpdateForms(Form formObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_FormsUpdate(formObj.FormId, formObj.ModuleId, formObj.ControllerName, formObj.ActionName
                               , formObj.RouteAttribute, formObj.CompanyId, formObj.OrderNo, formObj.ModifiedOn, formObj.ModifiedBy);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// to include an additional form in a module as a master record at application level
        /// </summary>
        /// <param name="formObj"></param>
        /// <returns></returns>
        public bool InsertForms(Form formObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_FormsInsert(formObj.FormName, formObj.DisplayName, formObj.ModuleId, formObj.ControllerName, formObj.ActionName
                               , formObj.RouteAttribute, formObj.CompanyId, formObj.IsVisible, formObj.OrderNo, formObj.CreatedOn, formObj.CreatedBy);
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EmployeeFilterCriteria> DefaultEmployeeFilterCriteria(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var filterCriteriaList = hrmsEntity.usp_GetEmployeeFilterCriteria(companyId);
                    List<EmployeeFilterCriteria> EmployeeFilterCriterialist = new List<EmployeeFilterCriteria>();
                    foreach (var filterCriteriaObj in filterCriteriaList)
                    {
                        EmployeeFilterCriteria obj = new EmployeeFilterCriteria();
                        obj.FilterCriteria = filterCriteriaObj.FilterCriteria;
                        obj.FilterCriteriaId = filterCriteriaObj.FilterCriteriaId;
                        EmployeeFilterCriterialist.Add(obj);

                    }
                    return EmployeeFilterCriterialist;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CompanyLevelSaveLog> GetCompanyLevelSecurityCriteriaById(int companyLevelSecurityId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var employeeCriteriaList = hrmsEntity.usp_GetCompanyLevelSecurityCriteriaById(companyLevelSecurityId);
                    List<CompanyLevelSaveLog> EmployeeFilterCriterialist = new List<CompanyLevelSaveLog>();
                    foreach (var employeeCriteriaObj in employeeCriteriaList)
                    {
                        CompanyLevelSaveLog companyLevelSaveLogObj = new CompanyLevelSaveLog();
                        companyLevelSaveLogObj.CompanyLevelSaveLogId = employeeCriteriaObj.CompanyLevelSaveLogId;
                        companyLevelSaveLogObj.CompanyLevelSecurityId = employeeCriteriaObj.CompanyLevelSecurityId;
                        companyLevelSaveLogObj.EmployeeSendCriteriaId = employeeCriteriaObj.EmployeeSendCriteriaId;
                        companyLevelSaveLogObj.SelectedId = employeeCriteriaObj.SelectedId;
                        EmployeeFilterCriterialist.Add(companyLevelSaveLogObj);
                    }
                    return EmployeeFilterCriterialist;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// based on the search criteria satisfied employee reocrds gets inserted to
        /// an intermediate table from where the service sends email whose status is not sent
        /// </summary>
        /// <param name="companyLevelSecurityId"></param>
        /// <param name="employeeId"></param>
        /// <param name="status"></param>
        /// <param name="employeeEmail"></param>
        /// <param name="employeeName"></param>
        /// <returns>boolean</returns>
        public bool AddComanyLevelEmployee(int companyLevelSecurityId, int employeeId, bool status, string employeeEmail, string employeeName)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_EmployeeCompanyLevelInsert(companyLevelSecurityId, employeeId, status, employeeEmail, employeeName, outputParam);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool SaveCompanyLevelSecurity(int employeeSendCriteriaId, int companyLevelSecurityId, int selectedId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_CompanyLevelCriteriaSaveLogInsert(employeeSendCriteriaId, companyLevelSecurityId, selectedId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GetCompanyLevelSecurityId(int companyId, int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.CompanyLevelSecurity;
                    int companyLevelSecurityId = (from x in result
                                                  where x.RoleId == roleId & x.CompanyId == companyId
                                                  select x.CompanyLevelSecurityId).SingleOrDefault();
                    return companyLevelSecurityId;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int GetCompanyLevelSendCriteriaId(int companyId, int roleId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.CompanyLevelSecurity;
                    int employeeSendCriteriaId = (from x in result
                                                  where x.RoleId == roleId & x.CompanyId == companyId
                                                  select x.CompanyLevelSecurityId).SingleOrDefault();
                    return employeeSendCriteriaId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
