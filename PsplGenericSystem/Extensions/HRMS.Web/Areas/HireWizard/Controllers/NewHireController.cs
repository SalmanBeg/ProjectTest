using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Service.Models.EDM;
using HRMS.Web.Areas.HireWizard.Models;
using HRMS.Web.ViewModels;
using HRMS.Service.Interfaces;

namespace HRMS.Web.Areas.HireWizard.Controllers
{
    public class NewHireController : Controller
    {

        #region Class Level Variables and constructor
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        private readonly IHireConfigurationSetupRepository _hireConfigurationSetupRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPayRepository _payRepository;
        private readonly IDirectDepositRepository _directDepositRepository;
        private readonly IFilesDBRepository _filesDBRepository;
        private readonly IJobProfileRepository _jobProfileRepository;
        private readonly IScreenVerbiageRepository _screenVerbiageRepository;
        public const string SetPasswordSuccess = "Password has been changed successfully.";
        public const string SetPasswordFail = "Change password failed.";
        public NewHireController(IRegisteredUsersRepository registeredUsersRepository, IScreenVerbiageRepository screenVerbiageRepository, IHireConfigurationSetupRepository hireConfigurationSetupRepository, IFilesDBRepository filesDBRepository
            , IUtilityRepository utilityRepository, IEmployeeRepository employeeRepository, IPayRepository payRepository
            , IDirectDepositRepository directDepositRepository, IJobProfileRepository jobProfileRepository)
        {
            _registeredUsersRepository = registeredUsersRepository;
            _utilityRepository = utilityRepository;
            _hireConfigurationSetupRepository = hireConfigurationSetupRepository;
            _employeeRepository = employeeRepository;
            _payRepository = payRepository;
            _directDepositRepository = directDepositRepository;
            _filesDBRepository = filesDBRepository;
            _jobProfileRepository = jobProfileRepository;
            _screenVerbiageRepository = screenVerbiageRepository;
        }
       
        #endregion
        
        public ActionResult HireMaster()
        {
            string layout = Convert.ToString(Request.QueryString["pagelayout"]);
            int registereduserId = Convert.ToInt32(Request.QueryString["UserId"]);

            string hireMode = Request.QueryString["HireMode"];
            if (hireMode == "approval")
            {
                GlobalsVariables.IsHireWizard = "false";
                GlobalsVariables.SelectedUserId = Convert.ToString(registereduserId);
            }

            //fetching user info 
            #region Personal Data
            var newHireModelobj = new NewHireModel();
            var userId = registereduserId != 0 ? registereduserId : Convert.ToInt32(GlobalsVariables.CurrentUserId);
            GlobalsVariables.SelectedUserId = Convert.ToString(userId);
            var employeeobj = _employeeRepository.SelectEmployeeById(userId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var lstemployeelookupdata = new List<LookUpDataEntity>();
            if (lstemployeelookupdata == null)
            {
                throw new ArgumentNullException("lstemployeelookupdata");
            }
            lstemployeelookupdata = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            newHireModelobj.EmployeeFormModel.CountryList = _utilityRepository.GetCountry();
            newHireModelobj.EmployeeFormModel.StateList = employeeobj.CountryId != 0 ? _utilityRepository.GetStateProvince(employeeobj.CountryId) : _utilityRepository.GetStateProvince(0);
            newHireModelobj.EmployeeFormModel.GenderList = lstemployeelookupdata.Where(j => j.TableName == LocalizedStrings.Gender).ToList();
            newHireModelobj.EmployeeFormModel.MaritalStatusList = lstemployeelookupdata.Where(j => j.TableName == LocalizedStrings.MaritalStatus).ToList();
            newHireModelobj.EmployeeFormModel.SalutationList = lstemployeelookupdata.Where(j => j.TableName == LocalizedStrings.Salutation).ToList();
            newHireModelobj.EmployeeFormModel.SuffixList = lstemployeelookupdata.Where(j => j.TableName == LocalizedStrings.Suffix).ToList();
            #endregion

            #region Employment
            var employeePayFormModelObj = new EmployeePayFormModel
            {
                EmployeePay = _payRepository.SelectPay(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), userId)
            };
            if(employeePayFormModelObj.EmployeePay==null)
                employeePayFormModelObj.EmployeePay=new EmployeePay();

            newHireModelobj.EmployeeFormModel.ChangeReasonList = lstemployeelookupdata.Where(j => j.TableName == "Utility.ChangeReason").ToList();
            newHireModelobj.EmployeeFormModel.EmploymentStatusList = lstemployeelookupdata.Where(j => j.TableName == "Utility.EmploymentStatus").ToList();
            newHireModelobj.EmployeeFormModel.EmploymentTypeList = lstemployeelookupdata.Where(j => j.TableName == "Utility.EmploymentTypes").ToList();
            newHireModelobj.EmployeeFormModel.LocationList = lstemployeelookupdata.Where(j => j.TableName == "Utility.Location").ToList();
            newHireModelobj.EmployeeFormModel.PositionList = lstemployeelookupdata.Where(j => j.TableName == "Utility.Position").ToList();
            newHireModelobj.EmployeeFormModel.JobProfileList = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            newHireModelobj.EmployeeFormModel.TerminationReasonList = lstemployeelookupdata.Where(j => j.TableName == "Utility.TerminationReason").ToList();
            newHireModelobj.EmployeeFormModel.DivisionList = lstemployeelookupdata.Where(j => j.TableName == "Utility.Division").ToList();
            newHireModelobj.EmployeeFormModel.DepartmentList = lstemployeelookupdata.Where(j => j.TableName == "Utility.Department").ToList();
            newHireModelobj.EmployeeFormModel.FLSAStatusList = lstemployeelookupdata.Where(j => j.TableName == "Utility.FLSAStatus").ToList();
            newHireModelobj.EmployeeFormModel.UnionList = lstemployeelookupdata.Where(j => j.TableName == "Utility.UnionType").ToList();
            newHireModelobj.EmployeeFormModel.ManagerList = SelectEmployeeListByCompanyId();
            employeeobj.UserId = userId;
            employeePayFormModelObj.EmployeePay.UserId = userId;
            newHireModelobj.EmployeeFormModel.PayGradeList = lstemployeelookupdata.Where(j => j.TableName == "Utility.PayGrade").ToList();
            newHireModelobj.EmployeeFormModel.PayTypeList = lstemployeelookupdata.Where(j => j.TableName == "Utility.PayType").ToList();          
            newHireModelobj.EmployeeFormModel.EmployeePay = employeePayFormModelObj.EmployeePay;
            #endregion
           
            newHireModelobj.HireConfigurationSetup = _hireConfigurationSetupRepository.NewUserConfigurationSetupSelect(userId,Int32.Parse(GlobalsVariables.CurrentCompanyId));
            newHireModelobj.HireActiveStepList = _hireConfigurationSetupRepository.SelectAllHireStepsById(userId);
            newHireModelobj.EmployeeFormModel.Employee = employeeobj;
            newHireModelobj.EmployeeDirectDepositList = _directDepositRepository.SelectDirectDeposit(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(GlobalsVariables.SelectedUserId));
            newHireModelobj.ScreenVerbiage= _screenVerbiageRepository.SelectScreenVerbiage(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            //Employee view

            if (layout != null)
                newHireModelobj.PageLayout = layout;

            #region Remove Manadatory for Self Hire
            ModelState.Remove("ChangeReason");
            ModelState.Remove("ChangeReasonList");
            #endregion
            return View(newHireModelobj);
        }

        public List<UserLoginModel> SelectEmployeeListByCompanyId()
        {
            return _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        }
        [HttpPost]
        public ActionResult HireWizardSubmitted()
        {
            return RedirectToAction("Login", "Account");
        }
        public List<HireApprovalSetup> SelectHireApprovalSetup()
        {
            return _registeredUsersRepository.HireApprovalStatusSelect(Convert.ToInt32(GlobalsVariables.SelectedUserId));
        }

        [HttpPost]
        public bool UpdateHireStatusofEmployee()
        {
            int userId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            return _hireConfigurationSetupRepository.UpdateHireStatusofEmployee(userId, true);
        }

        [HttpPost]
        public bool UpdateApprovalforNewHireEmployee()
        {
            int userId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            return _registeredUsersRepository.UpdateNewHireStatus(userId, true);
        }
        [HttpPost]
        public bool UpdateStepSubmitStatus(int stepId)
        {
            int userId = Convert.ToInt32(GlobalsVariables.CurrentUserId);

            return _hireConfigurationSetupRepository.UpdateStepSubmitStatus(userId, stepId, true);
        }

        [HttpPost]
        public bool _EmployeeView(EmployeeFormModel employeeFormModelobj)
        {
            if (employeeFormModelobj.Employee.UserId == 0)
                employeeFormModelobj.Employee.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);

            employeeFormModelobj.Employee.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            employeeFormModelobj.EmployeePay.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            //employeeFormModelobj.EmployeePay.Reason = (int)(employeeFormModelobj.Employee.ChangeReason);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeFormModelobj.CountryList = _utilityRepository.GetCountry();

            employeeFormModelobj.StateList = employeeFormModelobj.Employee.CountryId != 0 ? _utilityRepository.GetStateProvince(employeeFormModelobj.Employee.CountryId) : _utilityRepository.GetStateProvince(0);
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }

            #region update employment,pay details
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
            {
                _registeredUsersRepository.UpdateHireApprovalSetup("Employment", Convert.ToInt32(GlobalsVariables.SelectedUserId));
                _registeredUsersRepository.UpdateHireApprovalSetup("Personal", Convert.ToInt32(GlobalsVariables.SelectedUserId));
            }
            #endregion
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
            employeeFormModelobj.ManagerList = SelectEmployeeListByCompanyId().Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.SelectedUserId)).ToList();
            employeeFormModelobj.PayGradeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayGrade).ToList();
            employeeFormModelobj.PayTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayType).ToList();
            employeeFormModelobj.GenderList = lstlookup.Where(j => j.TableName == LocalizedStrings.Gender).ToList();
            employeeFormModelobj.MaritalStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.MaritalStatus).ToList();
            employeeFormModelobj.SalutationList = lstlookup.Where(j => j.TableName == LocalizedStrings.Salutation).ToList();
            employeeFormModelobj.SuffixList = lstlookup.Where(j => j.TableName == LocalizedStrings.Suffix).ToList();
            return success;
        }

       
       
    }
}
