using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;

namespace HRMS.Web.Controllers
{
    public class EmployeePayController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IPayRepository _payRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IPayTypeRepository _payTypeRepository;
        private readonly IPayPeriodRepository _payPeriodRepository;
        public EmployeePayController(IPayRepository payRepository, IUtilityRepository utilityRepository, IPayTypeRepository payTypeRepository, IPayPeriodRepository payPeriodRepository)
        {
            _payRepository = payRepository;
            _utilityRepository = utilityRepository;
            _payTypeRepository = payTypeRepository;
            _payPeriodRepository = payPeriodRepository;
        }


        #endregion
        /// <summary>
        /// View to add a new pay record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddPay()
        {
            var payTypeObj = new PayType { PayTypeId = 0, PayTypeCode = LocalizedStrings.AddNew };

            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            //Get data from GetLookUpData method and filter based on the table name, then pass it to view
            var employeePayFormModelObj = new EmployeePayFormModel();
            employeePayFormModelObj.EmployeePay = _payRepository.SelectPay(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(GlobalsVariables.SelectedUserId));
            if (employeePayFormModelObj.EmployeePay == null)
                employeePayFormModelObj.EmployeePay = new EmployeePay();
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeePayFormModelObj.ReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.ChangeReason).ToList();
            employeePayFormModelObj.ReasonList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.ShiftTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.ShiftPremium).ToList();
            employeePayFormModelObj.ShiftTypeList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.PayGradeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayGrade).ToList();
            employeePayFormModelObj.PayGradeList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.PayFrequencyList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayFrequency).ToList();
            employeePayFormModelObj.PayFrequencyList.Insert(0, lookUpDataEntityobj);

            employeePayFormModelObj.ContractStuatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.ContractStatus).ToList();
            employeePayFormModelObj.ContractStuatusList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.JobAssignmentList = lstlookup.Where(j => j.TableName == LocalizedStrings.JobAssignment).ToList();
            employeePayFormModelObj.JobAssignmentList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.PayStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayStatus).ToList();

            employeePayFormModelObj.PayStatusList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.PayTypeList = _payTypeRepository.SelectAllPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
           // var payTypeObj = new PayType { PayTypeId = 0, PayTypeCode = LocalizedStrings.AddNew };        
            employeePayFormModelObj.PayTypeList.Insert(0, payTypeObj);
            employeePayFormModelObj.PayPeriodList = _payPeriodRepository.SelectAllPayPeriodDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var payPeriodObj = new PayPeriods { PayPeriodId = 0, PayPeriodDescription = LocalizedStrings.AddNew };
            employeePayFormModelObj.PayPeriodList.Insert(0, payPeriodObj);
            return View(employeePayFormModelObj);
            //employeePayFormModelObj.PayCodeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayCode).ToList();
            //employeePayFormModelObj.PayCodeList.Insert(0, lookUpDataEntityobj);
        }
        /// <summary>
        /// View to add a new pay record for an employee
        /// </summary>
        /// <param name="employeePayFormModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddPay(EmployeePayFormModel employeePayFormModel)
        {
            var payTypeObj = new PayType { PayTypeId = 0, PayTypeCode = LocalizedStrings.AddNew };
            var payPeriodObj = new PayPeriods { PayPeriodId = 0, PayPeriodDescription = LocalizedStrings.AddNew };
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            EmployeePay employeePayObj = employeePayFormModel.EmployeePay;
            bool success = false;
            if (employeePayObj.UserId == 0)
            {
                employeePayObj.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                employeePayObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                success = _payRepository.AddPay(employeePayObj);
            }
            else
                success = _payRepository.UpdatePay(employeePayObj);
            var employeePayFormModelObj = new EmployeePayFormModel();
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeePayFormModelObj.ReasonList = lstlookup.Where(j => j.TableName == LocalizedStrings.ChangeReason).ToList();
            employeePayFormModelObj.ReasonList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.ShiftTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.ShiftPremium).ToList();
            employeePayFormModelObj.ShiftTypeList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.PayGradeList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayGrade).ToList();
            employeePayFormModelObj.PayGradeList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.PayFrequencyList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayFrequency).ToList();
            employeePayFormModelObj.PayFrequencyList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.ContractStuatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.ContractStatus).ToList();
            employeePayFormModelObj.ContractStuatusList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.JobAssignmentList = lstlookup.Where(j => j.TableName == LocalizedStrings.JobAssignment).ToList();
            employeePayFormModelObj.JobAssignmentList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.PayStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.PayStatus).ToList();
            employeePayFormModelObj.PayStatusList.Insert(0, lookUpDataEntityobj);
            employeePayFormModelObj.PayTypeList.Insert(0, payTypeObj);
            employeePayFormModelObj.PayTypeList = _payTypeRepository.SelectAllPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeePayFormModelObj.PayPeriodList = _payPeriodRepository.SelectAllPayPeriodDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeePayFormModelObj.PayPeriodList.Insert(0, payPeriodObj);
            employeePayFormModelObj.EmployeePay = employeePayObj;
            ViewBag.Message = "Employee Pay Successfull";
            if (success)
                return View(employeePayFormModelObj);
            else
                return View();
        }
        /// <summary>
        /// View to update existing pay record
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult UpdatePay()
        {
            var selectPay = _payRepository.SelectPay(Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(GlobalsVariables.SelectedUserId));
            return View(selectPay);
        }
        /// <summary>
        /// View to update existing pay record
        /// </summary>
        /// <param name="employeeFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdatePay(EmployeeFormModel employeeFormModelobj)
        {
            bool success = _payRepository.UpdatePay(employeeFormModelobj.EmployeePay);
            if (success)
                return View();
            else
                return View();
        }
        [HttpGet]
        public ActionResult ShowAllPayTypes()
        {

            return View();
        }
        [HttpGet]
        public ActionResult ShowPayPeriods()
        {

            return View();
        }
        /// <summary>
        /// Listing pay period dates for an company and employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public JsonResult GetEmployeePayPeriodDates(int id)
        {
            var model = _payRepository.GetEmployeePayPeriodDates(Int32.Parse(GlobalsVariables.CurrentCompanyId), Int32.Parse(GlobalsVariables.SelectedUserId));
            return Json(model, JsonRequestBehavior.AllowGet);
        }


    }
}