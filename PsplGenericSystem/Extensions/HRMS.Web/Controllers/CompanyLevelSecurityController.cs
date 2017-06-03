using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using HRMS.BusinessLayer;
//using HRMS.Data;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;
using HRMS.Common.Enums;

namespace HRMS.Web.Controllers
{
    public class CompanyLevelSecurityController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ICompanyLevelSecurityRepository _companyLevelSecurityRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        public CompanyLevelSecurityController(ICompanyLevelSecurityRepository companyLevelSecurityRepository, IUtilityRepository utilityRepository, IRegisteredUsersRepository registeredUsersRepository, IRoleRepository roleRepository)
        {
            _companyLevelSecurityRepository = companyLevelSecurityRepository;
            _utilityRepository = utilityRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _roleRepository = roleRepository;
        }
        #endregion
        // GET: /CompanyLevelSecurity/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CompanyLevelSecurity()
        {
            var companyMenuFormModel = new CompanyMenuFormModel();
            companyMenuFormModel.Modules = _companyLevelSecurityRepository.ListModules(Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(GlobalsVariables.CurrentUserRoleId));
            return View(companyMenuFormModel);
        }
        /// <summary>
        /// Partial view to render html to show menu
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _CompanyMenuView()
        {
            var companyMenuFormModel = new CompanyMenuFormModel
            {
                Modules = _companyLevelSecurityRepository.ListModules(Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(GlobalsVariables.CurrentUserRoleId)),
                Forms = _companyLevelSecurityRepository.ListForms(Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(GlobalsVariables.CurrentUserRoleId))
            };

            return PartialView(companyMenuFormModel);
        }
        /// <summary>
        /// View to handle security management for an role
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ManageSecurity()
        {

            int roleId = Convert.ToInt32(Request.QueryString["RoleId"]);
            var companyLevelSecurityFormModelObj = new CompanyLevelSecurityFormModel
            {
                Modules = _companyLevelSecurityRepository.ListModules(Int32.Parse(GlobalsVariables.CurrentCompanyId), roleId),
                Forms = _companyLevelSecurityRepository.ListForms(Int32.Parse(GlobalsVariables.CurrentCompanyId), roleId),
                RoleId = roleId,
                FilterCriterias = _companyLevelSecurityRepository.DefaultEmployeeFilterCriteria(0),
                CompanyLevelSecurity = _companyLevelSecurityRepository.SelectCompanyLevelSecurities(Int32.Parse(GlobalsVariables.CurrentCompanyId), roleId)
            };
            if (companyLevelSecurityFormModelObj.CompanyLevelSecurity != null)
                companyLevelSecurityFormModelObj.EmployeeCriteriaId =
                    Convert.ToInt32(companyLevelSecurityFormModelObj.CompanyLevelSecurity.EmployeeFilterCriteriaId);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            companyLevelSecurityFormModelObj.ManageSecurityCriteriaList = _utilityRepository.GetManageSecurityCriteria();

            companyLevelSecurityFormModelObj.PositionsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Position).ToList();
            companyLevelSecurityFormModelObj.DivisionsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Division).ToList();
            companyLevelSecurityFormModelObj.DepartmentsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Department).ToList();
            companyLevelSecurityFormModelObj.LocationsList = lstlookup.Where(j => j.TableName == LocalizedStrings.Location).ToList();
            companyLevelSecurityFormModelObj.EmploymentStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentStatus).ToList();
            companyLevelSecurityFormModelObj.EmployeeList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            int companyLevelSecurityId = _companyLevelSecurityRepository.GetCompanyLevelSecurityId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), roleId);
            var employeeCriteriaList = _companyLevelSecurityRepository.GetCompanyLevelSecurityCriteriaById(companyLevelSecurityId);
            var resultObj = from x in employeeCriteriaList where x.CompanyLevelSecurityId == companyLevelSecurityId select x;

            var distinctList = resultObj.GroupBy(test => test.SelectedId)
       .Select(group => group.First());

            var companyLevelSaveLogs = distinctList as IList<CompanyLevelSaveLog> ?? distinctList.ToList();
            foreach (var obj in companyLevelSecurityFormModelObj.DepartmentsList)
            {
                foreach (var a in companyLevelSaveLogs)
                {
                    if (a.EmployeeSendCriteriaId.Equals((int)GeneralEnum.EmployeeSendCriteriaId.Departments))
                        obj.Status = a.SelectedId == obj.Id;
                }
            }

            foreach (var obj in companyLevelSecurityFormModelObj.PositionsList)
            {
                foreach (var a in companyLevelSaveLogs)
                {
                    if (a.EmployeeSendCriteriaId.Equals((int)GeneralEnum.EmployeeSendCriteriaId.Positions))
                    obj.Status = a.SelectedId == obj.Id;
                }
            }

            foreach (var obj in companyLevelSecurityFormModelObj.DivisionsList)
            {
                foreach (var a in companyLevelSaveLogs)
                {
                    if (a.EmployeeSendCriteriaId.Equals((int)GeneralEnum.EmployeeSendCriteriaId.Divisions))
                    obj.Status = a.SelectedId == obj.Id;
                }
            }

            foreach (var obj in companyLevelSecurityFormModelObj.LocationsList)
            {
                foreach (var a in companyLevelSaveLogs)
                {
                    if (a.EmployeeSendCriteriaId.Equals((int)GeneralEnum.EmployeeSendCriteriaId.Locations))
                    obj.Status = a.SelectedId == obj.Id;
                }
            }

            foreach (var obj in companyLevelSecurityFormModelObj.EmploymentStatusList)
            {
                foreach (var a in companyLevelSaveLogs)
                {
                    if (a.EmployeeSendCriteriaId.Equals((int)GeneralEnum.EmployeeSendCriteriaId.EmploymentStatus))
                    obj.Status = a.SelectedId == obj.Id;
                }
            }


            return View(companyLevelSecurityFormModelObj);
        }
        /// <summary>
        /// View to handle security management for an role
        /// </summary>
        /// <param name="formObjCollection"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult ManageSecurity(FormCollection formObjCollection)
        {
            var lstlookup = new List<LookUpDataEntity>();
            int roleId = Convert.ToInt32(formObjCollection["RoleId"]);
            //object intializer for company level security
            var companyLevelSecurityObj = new CompanyLevelSecurity
            {
                RoleId = roleId,
                CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId),
                CanHire = (formObjCollection["CompanyLevelSecurity.CanHire"] == "true,false" ? true : false),
                CanViewHires = (formObjCollection["CompanyLevelSecurity.CanViewHires"] == "true,false" ? true : false),
                CanAccessDashboard = (formObjCollection["CompanyLevelSecurity.CanAccessDashboard"] == "true,false" ? true : false),
                EmployeeFilterCriteriaId = Convert.ToInt32(formObjCollection["EmployeeCriteriaId"]),

                positionIdList = formObjCollection["CompanyLevelSecurity.positionIdList"],
                divisionIdList = formObjCollection["CompanyLevelSecurity.divisionIdList"],
                locationIdList = formObjCollection["CompanyLevelSecurity.locationIdList"],
                departmentIdList = formObjCollection["CompanyLevelSecurity.departmentIdList"],
                employmentstatusIdList = formObjCollection["CompanyLevelSecurity.employmentstatusIdList"],
                EmployeeIdList = formObjCollection["CompanyLevelSecurity.EmployeeList"]
            };
            formObjCollection.Remove("CompanyLevelSecurity.CanHire");
            formObjCollection.Remove("CompanyLevelSecurity.CanViewHires");
            formObjCollection.Remove("CompanyLevelSecurity.CanAccessDashboard");
            formObjCollection.Remove("CompanyLevelSecurity.CanAccessDashboard");
            formObjCollection.Remove("EmployeeCriteriaId");
            formObjCollection.Remove("Save");
            formObjCollection.Remove("Cancel");
            formObjCollection.Remove("CompanyLevelSecurity.ManageSecurityCriteria");
            formObjCollection.Remove("CompanyLevelSecurity.Status1");
            formObjCollection.Remove("CompanyLevelSecurity.EmployeeIdList");
            formObjCollection.Remove("CompanyLevelSecurity.positionIdList");
            formObjCollection.Remove("CompanyLevelSecurity.divisionIdList");
            formObjCollection.Remove("CompanyLevelSecurity.departmentIdList");
            formObjCollection.Remove("CompanyLevelSecurity.locationIdList");
            formObjCollection.Remove("CompanyLevelSecurity.employmentstatusIdList");
            formObjCollection.Remove("departmentlist");
            formObjCollection.Remove("EmployeeStatusList");

            //initializing list collection for forms and modules
            var modules = new List<Module>();
            var forms = new List<Form>();
            /*looping through all the form collection elements using keys, as each entity has 3 properties we
             * are incrementing by 3 and checking for modules and forms and converting the set into a list
            */
            for (int i = 0; i < formObjCollection.AllKeys.Count(); i += 3)
            {
                if (formObjCollection.AllKeys[i].ToLower().Contains("modules"))
                {
                    //object initializer for module
                    var moduleObj = new Module
                    {
                        ModuleId = Convert.ToInt32(formObjCollection[formObjCollection.AllKeys[i]]),
                        IsModuleVisible = (formObjCollection[formObjCollection.AllKeys[i + 1]] == "true,false" ? true : false),
                        IsModuleEditable = (formObjCollection[formObjCollection.AllKeys[i + 2]] == "true,false" ? true : false)


                    };
                    modules.Add(moduleObj);
                }
                if (formObjCollection.AllKeys[i].ToLower().Contains("forms"))
                {
                    //object initializer for form
                    var formObj = new Form
                    {
                        FormId = Convert.ToInt32(formObjCollection[formObjCollection.AllKeys[i]]),
                        IsFormVisible = (formObjCollection[formObjCollection.AllKeys[i + 1]] == "true,false" ? true : false),
                        IsFormEditable = (formObjCollection[formObjCollection.AllKeys[i + 2]] == "true,false" ? true : false)

                    };
                    forms.Add(formObj);
                }

            }
            //repository method where companylevelsecurityobject, list of form entity elements,list of module entity elements are supplied
            bool result = _companyLevelSecurityRepository.CreateCompanyLevelSecurity(
                  companyLevelSecurityObj, forms, modules);

            //supplying after the update operation for rebinding the form with updated values from database
            var companyLevelSecurityFormModelObj = new CompanyLevelSecurityFormModel
            {
                Modules = _companyLevelSecurityRepository.ListModules(Int32.Parse(GlobalsVariables.CurrentCompanyId), roleId),
                Forms = _companyLevelSecurityRepository.ListForms(Int32.Parse(GlobalsVariables.CurrentCompanyId), roleId),
                RoleId = roleId,
                CompanyLevelSecurity = _companyLevelSecurityRepository.SelectCompanyLevelSecurities(Int32.Parse(GlobalsVariables.CurrentCompanyId), roleId),
                FilterCriterias = _companyLevelSecurityRepository.DefaultEmployeeFilterCriteria(0),
            };

            #region save or update employee

            int companyLevelSecurityId = _companyLevelSecurityRepository.GetCompanyLevelSecurityId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), roleId);
            AddCompanyLevelEmployeeByCriteria(companyLevelSecurityObj.positionIdList, companyLevelSecurityObj.divisionIdList, companyLevelSecurityObj.departmentIdList, companyLevelSecurityObj.locationIdList, companyLevelSecurityObj.employmentstatusIdList, companyLevelSecurityId);
            var employeeCriteriaList = _companyLevelSecurityRepository.GetCompanyLevelSecurityCriteriaById(companyLevelSecurityId);
            foreach (var employeeCriteriaObj in employeeCriteriaList)
            {
                var resultObj = from x in employeeCriteriaList where x.CompanyLevelSecurityId == companyLevelSecurityId & x.EmployeeSendCriteriaId == 4 select x.SelectedId;
                var companyLevelSaveLogObj = new CompanyLevelSaveLog();
                companyLevelSaveLogObj.CompanyLevelSaveLogId = employeeCriteriaObj.CompanyLevelSaveLogId;
                companyLevelSaveLogObj.CompanyLevelSecurityId = employeeCriteriaObj.CompanyLevelSecurityId;
                companyLevelSaveLogObj.EmployeeSendCriteriaId = employeeCriteriaObj.EmployeeSendCriteriaId;
                companyLevelSaveLogObj.SelectedId = employeeCriteriaObj.SelectedId;
                companyLevelSecurityFormModelObj.CompanyLevelSaveLogList.Add(companyLevelSaveLogObj);
            }


            #endregion
            // return RedirectToAction("SelectAllCompanyLevelSecurity");
            return View(companyLevelSecurityFormModelObj);
        }
        /// <summary>
        /// A view to handle menu related items and its navigation properties
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ManageMenu()
        {
            var companyMenuFormModel = new CompanyMenuFormModel
            {
                ListOrganizationMenus = _companyLevelSecurityRepository.ListCompanyMenu(Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(GlobalsVariables.CurrentUserRoleId)),
                Modules = _companyLevelSecurityRepository.ListModules(Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(GlobalsVariables.CurrentUserRoleId)),

            };

            return View(companyMenuFormModel);
        }
        /// <summary>
        /// A view to handle menu related items and its navigation properties
        /// </summary>
        /// <param name="formObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool ManageMenu(Form formObj)
        {
            formObj.ModifiedOn = System.DateTime.UtcNow;
            formObj.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            bool success = _companyLevelSecurityRepository.UpdateForms(formObj);
            return success;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyMenuFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult CompanyLevelSecurity(CompanyMenuFormModel companyMenuFormModelobj)
        {
            companyMenuFormModelobj.form.CompanyId = 0;
            companyMenuFormModelobj.form.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            companyMenuFormModelobj.form.CreatedOn = System.DateTime.UtcNow;
            bool result = _companyLevelSecurityRepository.InsertForms(companyMenuFormModelobj.form);
            return RedirectToAction("ManageMenu");
        }
        public void AddCompanyLevelEmployeeByCriteria(string positionIdList, string divisionIdList, string departmentIdList, string locationIdList, string employmentStatusIdList, int companyLevelSecurityId)
        {
            List<Employee> employeeList = new List<Employee>();
            List<ManageSecurityCriteria> companylevelcriteriaList = _utilityRepository.GetManageSecurityCriteria();
            if (!string.IsNullOrEmpty(positionIdList))
            {
                var employeeSendCriteriaId = (from x in companylevelcriteriaList where x.ManageSecurityCriteriaName == "Positions" select x.ManageSecurityCriteriaId).First();
                foreach (var positionId in positionIdList.Split(','))
                {
                    employeeList = _registeredUsersRepository.SelectAllEmployeesByPosition(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(positionId));
                    _companyLevelSecurityRepository.SaveCompanyLevelSecurity(Convert.ToInt32(employeeSendCriteriaId), companyLevelSecurityId, Convert.ToInt32(positionId));

                }
            }
            if (!string.IsNullOrEmpty(divisionIdList))
            {
                var employeeSendCriteriaId = (from x in companylevelcriteriaList where x.ManageSecurityCriteriaName == "Divisions" select x.ManageSecurityCriteriaId).First();
                foreach (var divisionId in divisionIdList.Split(','))
                {
                    employeeList = _registeredUsersRepository.SelectAllEmployeesByDivision(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(divisionId));
                    _companyLevelSecurityRepository.SaveCompanyLevelSecurity(Convert.ToInt32(employeeSendCriteriaId), companyLevelSecurityId, Convert.ToInt32(divisionId));
                }
            }
            if (!string.IsNullOrEmpty(locationIdList))
            {
                foreach (var locationId in locationIdList.Split(','))
                {
                    var employeeSendCriteriaId = (from x in companylevelcriteriaList where x.ManageSecurityCriteriaName == "Locations" select x.ManageSecurityCriteriaId).First();
                    List<Employee> loctionList = _registeredUsersRepository.SelectAllEmployeesByLocation(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(locationId));
                    employeeList.AddRange(loctionList);
                    _companyLevelSecurityRepository.SaveCompanyLevelSecurity(Convert.ToInt32(employeeSendCriteriaId), companyLevelSecurityId, Convert.ToInt32(locationId));
                }
            }
            if (!string.IsNullOrEmpty(departmentIdList))
            {
                foreach (var departmentId in departmentIdList.Split(','))
                {
                    var employeeSendCriteriaId = (from x in companylevelcriteriaList where x.ManageSecurityCriteriaName == "Departments" select x.ManageSecurityCriteriaId).First();
                    List<Employee> departmentList = _registeredUsersRepository.SelectAllEmployeesByDepartment(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(departmentId));
                    employeeList.AddRange(departmentList);
                    _companyLevelSecurityRepository.SaveCompanyLevelSecurity(Convert.ToInt32(employeeSendCriteriaId), companyLevelSecurityId, Convert.ToInt32(departmentId));
                }
            }
            if (!string.IsNullOrEmpty(employmentStatusIdList))
            {
                foreach (var employmentStatusId in employmentStatusIdList.Split(','))
                {
                    var employeeSendCriteriaId = (from x in companylevelcriteriaList where x.ManageSecurityCriteriaName == "EmploymentStatus" select x.ManageSecurityCriteriaId).First();
                    List<Employee> employmentStatusList = _registeredUsersRepository.SelectAllEmployeesByEmploymentStatus(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(employmentStatusId));
                    employeeList.AddRange(employmentStatusList);
                    _companyLevelSecurityRepository.SaveCompanyLevelSecurity(Convert.ToInt32(employeeSendCriteriaId), companyLevelSecurityId, Convert.ToInt32(employmentStatusId));
                }
            }
            var distinctList = employeeList.GroupBy(test => test.UserId)
       .Select(group => group.First());
            if (distinctList != null)
            {
                foreach (var employee in distinctList)
                {
                    if (employee.Email != null)
                        _companyLevelSecurityRepository.AddComanyLevelEmployee(companyLevelSecurityId, employee.UserId, true, employee.Email, employee.FirstName);
                }
            }
        }
                
    }
}