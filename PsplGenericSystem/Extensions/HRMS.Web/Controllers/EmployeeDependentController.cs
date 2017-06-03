 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;

namespace HRMS.Web.Controllers
{
    public class EmployeeDependentController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IDependentRepository _dependentRepository;
        private readonly IUtilityRepository _utilityRepository;
        public EmployeeDependentController(IDependentRepository dependentRepository, IUtilityRepository utilityRepository)
        {
            _dependentRepository = dependentRepository;
            _utilityRepository = utilityRepository;
        }

        #endregion
        /// <summary>
        /// View to add a new dependent for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddDependent()
        {
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var employeeDependentFormModelobj = new EmployeeDependentFormModel
            {
                CountryList = _utilityRepository.GetCountry(), 
                RelationShipList = lstlookup.Where(j => j.TableName == LocalizedStrings.Relationship).ToList(),
                SuffixList = lstlookup.Where(j => j.TableName == LocalizedStrings.Suffix).ToList(),
                SalutationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Salutation).ToList(),
                GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList()
            };
            employeeDependentFormModelobj.SalutationList.Insert(0, lookUpDataEntityobj);
            employeeDependentFormModelobj.SuffixList.Insert(0, lookUpDataEntityobj);
            employeeDependentFormModelobj.RelationShipList.Insert(0, lookUpDataEntityobj);
            
            return View(employeeDependentFormModelobj);
        }
        /// <summary>
        /// Action method handling post method to add a new dependent for an employee
        /// </summary>
        /// <param name="employeeDependentFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddDependent(EmployeeDependentFormModel employeeDependentFormModelobj)
        {
            employeeDependentFormModelobj.EmployeeDependent.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            employeeDependentFormModelobj.EmployeeDependent.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            employeeDependentFormModelobj.EmployeeDependent.CreatedBy = GlobalsVariables.CurrentUserId;
          
            bool addDependent = _dependentRepository.AddDependent(employeeDependentFormModelobj.EmployeeDependent);
            if (addDependent)
            {
                ModelState.AddModelError("", "Dependent Detail(s) Created Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Dependent Detail(s) cannot be created, Please try again.");
            }
            return RedirectToAction("SelectAllEmployeeDependent");
        }
        /// <summary>
        /// View to list all dependents for an employee in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllEmployeeDependent()
        {
            int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<EmployeeDependent> employeeDependentList = _dependentRepository.SelectAllEmployeeDependent(userId, companyId);
          return View(employeeDependentList);
        }
        /// <summary>
        /// View to update an existing dependent record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult UpdateEmployeeDependent()
        {
            var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id=0};
            var employeeDependentFormModelobj = new EmployeeDependentFormModel();
            var id = Request.QueryString["EmployeeDependentId"];
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeDependentFormModelobj.EmployeeDependent = _dependentRepository.SelectEmployeeDependentByDependentId(Convert.ToInt32(id), Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).FirstOrDefault();
            if (employeeDependentFormModelobj.EmployeeDependent == null)
                employeeDependentFormModelobj.EmployeeDependent = new EmployeeDependent();
             employeeDependentFormModelobj.CountryList = _utilityRepository.GetCountry();
            if (employeeDependentFormModelobj.EmployeeDependent.CountryId!=0)
                employeeDependentFormModelobj.StateList = _utilityRepository.GetStateProvince(employeeDependentFormModelobj.EmployeeDependent.CountryId);

            employeeDependentFormModelobj.RelationShipList = lstlookup.Where(j => j.TableName == LocalizedStrings.Relationship).ToList();
            employeeDependentFormModelobj.RelationShipList.Insert(0, lookUpDataEntityObj);
            employeeDependentFormModelobj.SuffixList = lstlookup.Where(j => j.TableName == LocalizedStrings.Suffix).ToList();
            employeeDependentFormModelobj.SuffixList.Insert(0, lookUpDataEntityObj);
            employeeDependentFormModelobj.SalutationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Salutation).ToList();
            employeeDependentFormModelobj.SalutationList.Insert(0, lookUpDataEntityObj);
            employeeDependentFormModelobj.GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList();
            employeeDependentFormModelobj.GenderList.Insert(0, lookUpDataEntityObj);
            return View(employeeDependentFormModelobj);
        }
        /// <summary>
        /// View to update an existing dependent record for an employee
        /// </summary>
        /// <param name="employeeDependentFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateEmployeeDependent(EmployeeDependentFormModel employeeDependentFormModelobj)
        {
          

            bool success = _dependentRepository.UpdateEmployeeDependent(employeeDependentFormModelobj.EmployeeDependent);
            if (success)
            {
                ModelState.AddModelError("", "Dependent Detail(s) Updated Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Dependent Detail(s) cannot be updated, Please try again.");
            }
            return RedirectToAction("SelectAllEmployeeDependent");
        }
        /// <summary>
        /// Post Action method to delete dependent records
        /// </summary>
        /// <param name="dependentIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteDependent(string dependentIds)
        {
            if (dependentIds != null)
            {
                foreach (var dependentId in dependentIds.Split(','))
                {
                    var deleteDependentDetail =
                        _dependentRepository.DeleteDependent(Int32.Parse(dependentId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;

        }
    }
}
