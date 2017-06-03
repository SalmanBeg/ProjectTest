using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Web.Areas.HireWizard.Models;
using HRMS.Service.Interfaces;
using HRMS.Web.ViewModels;

namespace HRMS.Web.Controllers
{
    public class ScheduleController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IPayPeriodRepository _payPeriodRepository;
        private readonly IPayPeriodTypeRepository _payPeriodTypeRepository;
        private readonly IScheduleEmployeeRepository _ScheduleEmployeeRepository;
        private readonly IUtilityRepository _utilrepo;
        private readonly IUserSignUpRepository _userrepo;

        public ScheduleController(
            IPayPeriodRepository payPeriodRepository,
            IPayPeriodTypeRepository payPeriodTypeRepository,
            IScheduleEmployeeRepository iScheduleEmployeeRepository,
            IUtilityRepository utilrepo,
            IUserSignUpRepository userrepo
            )
        {
            _payPeriodRepository = payPeriodRepository;
            _payPeriodTypeRepository = payPeriodTypeRepository;
            _ScheduleEmployeeRepository = iScheduleEmployeeRepository;
            _utilrepo = utilrepo;
            _userrepo = userrepo;
        }

        protected IScheduleEmployeeRepository ScheduleEmployeeRepository
        {
            get { return _ScheduleEmployeeRepository; }
        }

        protected IUtilityRepository UtilityRepository
        {
            get { return _utilrepo; }
        }

        protected IUserSignUpRepository UserRepository
        {
            get { return _userrepo; }
        }
        #endregion

        /// <summary>
        /// Returns PayPeriod List by CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllPayPeriodDetails")]
        public ActionResult SelectAllPayPeriodDetails()
        {
            List<PayPeriodType> payPeriodTypeObj = new List<PayPeriodType>();
            payPeriodTypeObj = _payPeriodTypeRepository.SelectAllPayPeriodTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();

            var payPeriodList = _payPeriodRepository.SelectAllPayPeriodDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            for (int i = 0; i < payPeriodList.Count; i++)
            {
                payPeriodList[i].PayPeriodTypename = payPeriodTypeObj.Where(pt => pt.PayPeriodTypeId == payPeriodList[i].PayPeriodTypeId).Select(pt => pt.Name).SingleOrDefault();
                payPeriodList[i].PayPeriodDays = (payPeriodTypeObj.Where(pt => pt.PayPeriodTypeId == payPeriodList[i].PayPeriodTypeId).Select(pt => pt.Days).SingleOrDefault()).GetValueOrDefault();
            }

            PayPeriodFormModel payPeriodFormModelObj = new PayPeriodFormModel();
            payPeriodFormModelObj.PayPeriodList = payPeriodList;
            payPeriodFormModelObj.PayPeriodTypeList = payPeriodTypeObj;

            // For Displaying Employees if Payperiod is Click
            if (TempData["PayPeriodId"] != null)
            {
                ViewBag.PayPeriodId = TempData["PayPeriodId"];
            }
            return View(payPeriodFormModelObj);
        }


        #region Schedule Employees
        /// <summary>
        /// Returns the Employees by Pay Period.
        /// </summary>
        /// <param name="PayPeriodId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllPayPeriodEmployeesDetails")]
        public ActionResult SelectAllPayPeriodEmployeesDetails(int PayPeriodId)
        {
            ScheduleEmployeeFormModel scheduleEmployeeFormModelObj = new ScheduleEmployeeFormModel();
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<ScheduleEmployee> scheduleEmpList = _ScheduleEmployeeRepository.SelectAllEmployeesByPayPeriodIdAndCompanyId(PayPeriodId, companyId);

            //Dropdown Lists
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilrepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            //For each Employee
            foreach (ScheduleEmployee item in scheduleEmpList)
            {
                item.TempDepartmentId = item.DepartmentId;
                item.TempJobId = item.JobId;
                item.TempProjectId = item.ProjectId;
                if (item.ScheduleCount > 0)
                    item.ScheduledChecked = true;
                else
                    item.ScheduledChecked = false;
            }
            //List<LookUpDataEntity> DepartmentList = new List<LookUpDataEntity>();
            scheduleEmployeeFormModelObj.DepartmentList = lstlookup.Where(j => j.TableName == "Utility.Department").ToList();
            //List<LookUpDataEntity> JobList = new List<LookUpDataEntity>();
            scheduleEmployeeFormModelObj.JobList = lstlookup.Where(j => j.TableName == "Utility.JobProfile").ToList();
            //List<LookUpDataEntity> ProjectList = new List<LookUpDataEntity>();
            scheduleEmployeeFormModelObj.ProjectList = lstlookup.Where(j => j.TableName == "Utility.Project").ToList();
            scheduleEmployeeFormModelObj.ScheduleEmployeeList = scheduleEmpList;
            return PartialView(scheduleEmployeeFormModelObj);
        }

        /// <summary>
        /// Stores the Selected Pay Period in TempData.
        /// </summary>
        /// <param name="PayPeriodId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectedPayPeriod")]
        public ActionResult SelectedPayPeriod(int PayPeriodId)
        {
            TempData["PayPeriodId"] = PayPeriodId;
            return RedirectToAction("SelectAllPayPeriodDetails");
        }
        
        /// <summary>
        /// Builds the Schedule for Employee according to the Pay Period Date Rage and stores into ScheduleEmployee Table.
        /// </summary>
        /// <param name="scheduleObj"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("BuildEmployeeSchedule")]
        public ActionResult BuildEmployeeSchedule(IList<ScheduleEmployee> scheduleObj)
        {
            List<PayPeriod> payperiodInfo = new List<PayPeriod>();
            payperiodInfo = _payPeriodRepository.SelectPayPeriodDetail(scheduleObj[0].PayPeriodId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            List<PayPeriodType> payperiodType = new List<PayPeriodType>();
            int PayPerodTypeId = Convert.ToInt32(payperiodInfo[0].PayPeriodTypeId);
            int CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            payperiodType = _payPeriodTypeRepository.SelectPayPeriodTypeDetails(PayPerodTypeId, CompanyId).ToList();

            int? payperiodDays = payperiodType[0].Days;
            DateTime startdate = payperiodInfo[0].StartDateTime;
            bool Success = false;
            foreach (ScheduleEmployee item in scheduleObj)
            {
                //If schedule is not built then inserting new records based on payperiod 
                if (item.ScheduledChecked && item.ScheduleCount == 0)
                {
                    for (int i = 0; i < payperiodDays; i++)
                    {
                        item.ScheduleDate = startdate.AddDays(i);
                        item.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                        item.IsScheduleActive = true;
                        Success = _ScheduleEmployeeRepository.InsertScheduleEmployee(item);
                    }
                }
                else if (item.ScheduledChecked == false && item.ScheduleCount > 0)
                {
                    Success = _ScheduleEmployeeRepository.DeleteScheduleEmployee(item.UserId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return RedirectToAction("SelectAllPayPeriodDetails");
        }
        
        /// <summary>
        /// Returns EditScheduleEmployeeDetail List by UserId and CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditScheduleEmployeeList")]
        public ActionResult EditScheduleEmployeeList(int UserId)
        {
            ScheduleEmployeeFormModel scheduleEmployeeFormModelObj = new ScheduleEmployeeFormModel();
            List<ScheduleEmployee> scheduleEmpList = new List<ScheduleEmployee>();
            scheduleEmpList = _ScheduleEmployeeRepository.SelectScheduleEmployeeDetailsByScheduleUserId(UserId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            //Dropdown Lists
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilrepo.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            foreach (ScheduleEmployee item in scheduleEmpList)
            {
                //List<LookUpDataEntity> DepartmentList = new List<LookUpDataEntity>();
                scheduleEmployeeFormModelObj.DepartmentList = lstlookup.Where(j => j.TableName == "Utility.Department").ToList();
                //List<LookUpDataEntity> JobList = new List<LookUpDataEntity>();
                scheduleEmployeeFormModelObj.JobList = lstlookup.Where(j => j.TableName == "Utility.JobProfile").ToList();
                //List<LookUpDataEntity> ProjectList = new List<LookUpDataEntity>();
                scheduleEmployeeFormModelObj.ProjectList = lstlookup.Where(j => j.TableName == "Utility.Project").ToList();

                item.TempDepartmentId = item.DepartmentId;
                item.TempJobId = item.JobId;
                item.TempProjectId = item.ProjectId;
            }
            return View(scheduleEmpList);
        }

        /// <summary>
        /// Updates the EditScheduleEmployeeDetails
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditScheduleEmployeeList")]
        public ActionResult EditScheduleEmployeeList(IList<ScheduleEmployee> scheduleEmpList)
        {
            bool Success = false;
            foreach (ScheduleEmployee item in scheduleEmpList)
            {
                item.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                Success = _ScheduleEmployeeRepository.UpdateScheduleEmployee(item);
            }
            return RedirectToAction("SelectAllPayPeriodDetails");
            //return View();
        }
        #endregion
	}
}