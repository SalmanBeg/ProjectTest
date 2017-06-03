using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using HRMS.Web.Areas.HireWizard.Models;
using HRMS.Service.Interfaces;
using System.Web.UI;
using HRMS.Common.Helpers;

namespace HRMS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPayRepository _payRepository;
        private readonly IUtilityRepository _utilrepo;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IJobProfileRepository _jobProfileRepository;
        public EmployeeController(IEmployeeRepository employeeRepository, IUtilityRepository utilityRepository, IPayRepository payRepository
            , IRegisteredUsersRepository registeredUsersRepository, IJobProfileRepository jobProfileRepository)
        {
            _employeeRepository = employeeRepository;
            _registeredUsersRepository = registeredUsersRepository;
            _utilrepo = utilityRepository;
            _payRepository = payRepository;
            _jobProfileRepository = jobProfileRepository;
        }

        #endregion
        /// <summary>
        /// View to update employee record
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateEmployee()
        {
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilrepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var employeeobj = new EmployeeFormModel();
            employeeobj.Employee = _employeeRepository.SelectEmployeeById(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            employeeobj.ChangeReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.ChangeReason).ToList();
            employeeobj.ChangeReasonList.Insert(0, lookUpDataEntityobj);
            employeeobj.EmploymentStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentStatus).ToList();
            employeeobj.EmploymentStatusList.Insert(0, lookUpDataEntityobj);
            employeeobj.EmploymentTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentTypes).ToList();
            employeeobj.EmploymentTypeList.Insert(0, lookUpDataEntityobj);
            employeeobj.LocationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Location).ToList();
            employeeobj.LocationList.Insert(0, lookUpDataEntityobj);
            employeeobj.PositionList = lstlookup.Where(j => j.TableName == LocalizedStrings.Position).ToList();
            employeeobj.PositionList.Insert(0, lookUpDataEntityobj);
            employeeobj.JobProfileList = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var jobProfileObj = new JobProfile { Title = LocalizedStrings.AddNew, JobProfileId = 0 };
            employeeobj.JobProfileList.Insert(0, jobProfileObj);
            employeeobj.TerminationReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.TerminationReason).ToList();
            employeeobj.TerminationReasonList.Insert(0, lookUpDataEntityobj);
            employeeobj.DivisionList = lstlookup.Where(j => j.TableName == LocalizedStrings.Division).ToList();
            employeeobj.DivisionList.Insert(0, lookUpDataEntityobj);
            employeeobj.DepartmentList = lstlookup.Where(j => j.TableName == LocalizedStrings.Department).ToList();
            employeeobj.DepartmentList.Insert(0, lookUpDataEntityobj);
            employeeobj.FLSAStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.FLSAStatus).ToList();
            employeeobj.FLSAStatusList.Insert(0, lookUpDataEntityobj);
            employeeobj.UnionList = lstlookup.Where(j => j.TableName == LocalizedStrings.UnionType).ToList();
            employeeobj.UnionList.Insert(0, lookUpDataEntityobj);

            employeeobj.CountryList = _utilrepo.GetCountry();

            if (employeeobj.Employee.CountryId != 0)
                employeeobj.StateList = _utilrepo.GetStateProvince(employeeobj.Employee.CountryId);

            else
                employeeobj.StateList = _utilrepo.GetStateProvince(employeeobj.Employee.CountryId);
            employeeobj.GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList();
            employeeobj.GenderList.Insert(0, lookUpDataEntityobj);
            employeeobj.MaritalStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.MaritalStatus).ToList();
            employeeobj.MaritalStatusList.Insert(0, lookUpDataEntityobj);
            employeeobj.SalutationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Salutation).ToList();
            employeeobj.SalutationList.Insert(0, lookUpDataEntityobj);
            employeeobj.SuffixList = lstlookup.Where(j => j.TableName == LocalizedStrings.Suffix).ToList();
            employeeobj.SuffixList.Insert(0, lookUpDataEntityobj);
            employeeobj.ManagerList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.CurrentUserId)).ToList();

            employeeobj.Employee = employeeobj.Employee;
            return View(employeeobj);
        }
        /// <summary>
        /// View to update employee record
        /// </summary>
        /// <param name="employeeFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult CreateEmployee(EmployeeFormModel employeeFormModelobj)
        {

            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            employeeFormModelobj.Employee.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            employeeFormModelobj.Employee.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);

            List<LookUpDataEntity> lstlookup = _utilrepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            bool success = _employeeRepository.CreateEmployee(employeeFormModelobj.Employee);
            employeeFormModelobj.ChangeReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.ChangeReason).ToList();
            employeeFormModelobj.ChangeReasonList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.EmploymentStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentStatus).ToList();
            employeeFormModelobj.EmploymentStatusList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.EmploymentTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentTypes).ToList();
            employeeFormModelobj.EmploymentTypeList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.LocationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Location).ToList();
            employeeFormModelobj.LocationList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.PositionList = lstlookup.Where(j => j.TableName == LocalizedStrings.Position).ToList();
            employeeFormModelobj.PositionList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.JobProfileList = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            employeeFormModelobj.TerminationReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.TerminationReason).ToList();
            employeeFormModelobj.TerminationReasonList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.DivisionList = lstlookup.Where(j => j.TableName == LocalizedStrings.Division).ToList();
            employeeFormModelobj.DivisionList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.DepartmentList = lstlookup.Where(j => j.TableName == LocalizedStrings.Department).ToList();
            employeeFormModelobj.DepartmentList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.FLSAStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.FLSAStatus).ToList();
            employeeFormModelobj.FLSAStatusList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.UnionList = lstlookup.Where(j => j.TableName == LocalizedStrings.UnionType).ToList();
            employeeFormModelobj.UnionList.Insert(0, lookUpDataEntityobj);

            employeeFormModelobj.CountryList = _utilrepo.GetCountry();
            if (employeeFormModelobj.Employee.CountryId != 0)
                employeeFormModelobj.StateList = _utilrepo.GetStateProvince(employeeFormModelobj.Employee.CountryId);

            employeeFormModelobj.GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList();
            employeeFormModelobj.GenderList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.MaritalStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.MaritalStatus).ToList();
            employeeFormModelobj.MaritalStatusList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.SalutationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Salutation).ToList();
            employeeFormModelobj.SalutationList.Insert(0, lookUpDataEntityobj);
            employeeFormModelobj.SuffixList = lstlookup.Where(j => j.TableName == LocalizedStrings.Suffix).ToList();
            employeeFormModelobj.SuffixList.Insert(0, lookUpDataEntityobj);

            ViewBag.Message = "Employee saved successfully";
            if (success)
                return View(employeeFormModelobj);
            else
                return View(employeeFormModelobj);
        }
        /// <summary>
        /// Partial view used in hire wizard to update employee record
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _EmploymentView()
        {
            EmployeeFormModel employeeFormModelobj = new EmployeeFormModel();
            employeeFormModelobj.Employee = _employeeRepository.SelectEmployeeById(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            EmployeePay emppayobj = _payRepository.SelectPay(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(GlobalsVariables.SelectedUserId));
            EmployeeFormModel employmentFormModelobj = new EmployeeFormModel();
            List<LookUpDataEntity> lstlookup = _utilrepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            employeeFormModelobj.ChangeReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.ChangeReason).ToList();
            employeeFormModelobj.EmploymentStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentStatus).ToList();
            employeeFormModelobj.EmploymentTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentTypes).ToList();
            employeeFormModelobj.LocationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Location).ToList();
            employeeFormModelobj.PositionList = lstlookup.Where(j => j.TableName == LocalizedStrings.Position).ToList();
            employeeFormModelobj.JobProfileList = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeFormModelobj.TerminationReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.TerminationReason).ToList();
            employeeFormModelobj.DivisionList = lstlookup.Where(j => j.TableName == LocalizedStrings.Division).ToList();
            employeeFormModelobj.DepartmentList = lstlookup.Where(j => j.TableName == LocalizedStrings.Department).ToList();
            employeeFormModelobj.FLSAStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.FLSAStatus).ToList();
            employeeFormModelobj.UnionList = lstlookup.Where(j => j.TableName == LocalizedStrings.UnionType).ToList();
            employeeFormModelobj.ManagerList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.CurrentUserId)).ToList();
            employeeFormModelobj.PayGradeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayGrade).ToList();
            employeeFormModelobj.PayTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayType).ToList();
            return PartialView(employeeFormModelobj);
        }
        /// <summary>
        /// Partial view used in hire wizard to update employee record
        /// </summary>
        /// <param name="employeeFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool _EmploymentView(EmployeeFormModel employeeFormModelobj)
        {
            if (employeeFormModelobj.Employee.UserId == 0)
                employeeFormModelobj.Employee.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            employeeFormModelobj.Employee.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            employeeFormModelobj.EmployeePay.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            employeeFormModelobj.EmployeePay.Reason = (int)employeeFormModelobj.Employee.ChangeReason;
            List<LookUpDataEntity> lstlookup = _utilrepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            bool success = _employeeRepository.CreateEmployee(employeeFormModelobj.Employee);
            bool paysuccess = false;
            if (employeeFormModelobj.EmployeePay.UserId == 0)
            {
                employeeFormModelobj.EmployeePay.UserId = employeeFormModelobj.Employee.UserId;
                paysuccess = _payRepository.AddPay(employeeFormModelobj.EmployeePay);
            }
            else
                paysuccess = _payRepository.UpdatePay(employeeFormModelobj.EmployeePay);
            if (GlobalsVariables.IsHireWizard != "true" && paysuccess == true)
                _registeredUsersRepository.UpdateHireApprovalSetup("Employment", Convert.ToInt32(GlobalsVariables.SelectedUserId));
            employeeFormModelobj.ChangeReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.ChangeReason).ToList();
            employeeFormModelobj.EmploymentStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentStatus).ToList();
            employeeFormModelobj.EmploymentTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.EmploymentTypes).ToList();
            employeeFormModelobj.LocationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Location).ToList();
            employeeFormModelobj.PositionList = lstlookup.Where(j => j.TableName == LocalizedStrings.Position).ToList();
            employeeFormModelobj.JobProfileList = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeFormModelobj.TerminationReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.TerminationReason).ToList();
            employeeFormModelobj.DivisionList = lstlookup.Where(j => j.TableName == LocalizedStrings.Division).ToList();
            employeeFormModelobj.DepartmentList = lstlookup.Where(j => j.TableName == LocalizedStrings.Department).ToList();
            employeeFormModelobj.FLSAStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.FLSAStatus).ToList();
            employeeFormModelobj.UnionList = lstlookup.Where(j => j.TableName == LocalizedStrings.UnionType).ToList();
            employeeFormModelobj.ManagerList = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.CurrentUserId)).ToList();
            employeeFormModelobj.PayGradeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayGrade).ToList();
            employeeFormModelobj.PayTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayType).ToList();
            return success;
        }
    }
}
