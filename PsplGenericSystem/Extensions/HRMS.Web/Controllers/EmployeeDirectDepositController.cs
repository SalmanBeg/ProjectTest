using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using System.Data;
using System.Data.SqlClient;
using HRMS.Service.Interfaces;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;


namespace HRMS.Web.Controllers
{
    public class EmployeeDirectDepositController : Controller
    {

        #region Class Level Variables and constructor
        private readonly IDirectDepositRepository _directDepositRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;
        public EmployeeDirectDepositController(IDirectDepositRepository directDepositRepository, IUtilityRepository utilityRepository, IRegisteredUsersRepository registeredUsersRepository)
        {
            _directDepositRepository = directDepositRepository;
            _utilityRepository = utilityRepository;
            _registeredUsersRepository = registeredUsersRepository;
        }      
        #endregion
        /// <summary>
        /// View to add a new direct deposit record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddDirectDeposit()
        {
           // var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0};
            var employeeDirectDepositFormModelObj = new EmployeeDirectDepositFormModel();
            var lookUpDataList = new List<LookUpDataEntity>();
            lookUpDataList = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeDirectDepositFormModelObj.AccountTypeList = lookUpDataList.Where(j => j.TableName == LocalizedStrings.DirectDepositAccountType).ToList();
            //employeeDirectDepositFormModelObj.AccountTypeList.Insert(0, lookUpDataEntityObj);
            employeeDirectDepositFormModelObj.EmployeeDirectDeposit.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            employeeDirectDepositFormModelObj.EmployeeDirectDeposit.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            return View(employeeDirectDepositFormModelObj);
        }
        /// <summary>
        /// View to add a new direct deposit record for an employee
        /// </summary>
        /// <param name="employeeDirectDepositFormModelObj"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddDirectDeposit(EmployeeDirectDepositFormModel employeeDirectDepositFormModelObj,FormCollection fc)
        {

            try
            {
                //var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
                int CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                int CurrentUserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                var empdirectdepositobj = _directDepositRepository.AddDirectDeposit(employeeDirectDepositFormModelObj.EmployeeDirectDeposit);

                int EmployeeDirectDepositId = empdirectdepositobj == null ? 0 : empdirectdepositobj.EmployeeDirectDepositId;
             
                var lookUpDataList = new List<LookUpDataEntity>();
                lookUpDataList = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                employeeDirectDepositFormModelObj.AccountTypeList = lookUpDataList.Where(j => j.TableName == "Utility.DirectDepositAccountType").ToList();
               // employeeDirectDepositFormModelObj.AccountTypeList.Insert(0, lookUpDataEntityObj);

                employeeDirectDepositFormModelObj.EmployeeDirectDeposit.EmployeeDirectDepositId = EmployeeDirectDepositId;

                // Default row bind......
                if (EmployeeDirectDepositId != -1)
                {

                    string AccountType = fc[0].ToString();
                    string TransitorABANumber = fc[1].ToString();
                    string AccountNumber = fc[2].ToString();
                    string Amount = fc[3].ToString();

                    DataTable dt = EmployeeDirectSchema();

                    //Default row Bind

                    DataRow defaultRow = dt.NewRow();
                    defaultRow["AccountType"] = AccountType;
                    defaultRow["TransitorABANumber"] = TransitorABANumber;
                    defaultRow["AccountNumber"] = AccountNumber;
                    defaultRow["Amount"] = Amount.ToString();
                    defaultRow["EmployeeDirectDepositId"] = EmployeeDirectDepositId;
                    defaultRow["CompanyId"] = CompanyId;
                    defaultRow["CreatedBy"] = CurrentUserId;
                    defaultRow["CreatedOn"] = DateTime.UtcNow; 
                    dt.Rows.Add(defaultRow);

                    int i = 0;
                    if (fc.Count > 4)
                    {
                        string[] strSplitAccountType = fc[4].Split(',');
                        string[] strSplitTransitorABANumber = fc[5].Split(',');
                        string[] strSplitAccountNumber = fc[6].Split(',');
                        string[] strSplitAmount = fc[7].Split(',');
                        foreach (var accountType in strSplitAccountType)
                        {
                            DataRow row = dt.NewRow();
                            row["AccountType"] = accountType;
                            row["TransitorABANumber"] = strSplitTransitorABANumber[i].ToString();
                            row["AccountNumber"] = strSplitAccountNumber[i].ToString(); ;
                            row["Amount"] = strSplitAmount[i].ToString();
                            row["EmployeeDirectDepositId"] = EmployeeDirectDepositId;
                            row["CompanyId"] = CompanyId;
                            row["CreatedBy"] = CurrentUserId;
                            row["CreatedOn"] = DateTime.UtcNow;
                            dt.Rows.Add(row);
                            dt.AcceptChanges();
                            i++;
                        }
                    }
                    bool status = _directDepositRepository.InsertEmployeeDirectDepositBulk(dt);
                }
            }

            
            catch (Exception )
            {

            }
                return RedirectToAction("SelectAllEmployeeDirectDeposit");           
        }
        /// <summary>
        /// View to show all the direct deposit records for an employee 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllEmployeeDirectDeposit()
        {
            var directDepositDetailList = new List<EmployeeDirectDeposit>();
            directDepositDetailList = _directDepositRepository.SelectDirectDeposit(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(GlobalsVariables.SelectedUserId));
            return View(directDepositDetailList);
        }
        /// <summary>
        /// View to update existing direct deposit record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult EditEmployeeDirectDeposit()
        {
            //var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var employeeDirectDepositFormModelObj = new EmployeeDirectDepositFormModel();
            int directDepositDetailid = Convert.ToInt32(Request.QueryString["DirectDepositId"]);
            employeeDirectDepositFormModelObj.EmployeeDirectDeposit = _directDepositRepository.SelectDirectDepositById(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(GlobalsVariables.SelectedUserId), directDepositDetailid);
            var lookUpDataList = new List<LookUpDataEntity>();
            lookUpDataList = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeDirectDepositFormModelObj.AccountTypeList = lookUpDataList.Where(j => j.TableName == LocalizedStrings.DirectDepositAccountType).ToList();
           // employeeDirectDepositFormModelObj.AccountTypeList.Insert(0, lookUpDataEntityObj);
            return View(employeeDirectDepositFormModelObj);
        }
        /// <summary>
        /// View to update existing direct deposit record for an employee
        /// </summary>
        /// <param name="employeeDirectDepositFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult EditEmployeeDirectDeposit(EmployeeDirectDepositFormModel employeeDirectDepositFormModelObj)
        {
            bool success = _directDepositRepository.UpdateDirectDeposit(employeeDirectDepositFormModelObj.EmployeeDirectDeposit);
            if (success)
                return RedirectToAction("SelectAllEmployeeDirectDeposit");
            return View();
        }
        /// <summary>
        /// Partial view for hire wizard to show all the direct deposit record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _DirectDepositView()
        {           
            var directDepositDetailList = _directDepositRepository.SelectDirectDeposit(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(GlobalsVariables.SelectedUserId));
            if (directDepositDetailList != null)
            {
                if (GlobalsVariables.IsHireWizard != "true")
                    _registeredUsersRepository.UpdateHireApprovalSetup("DirectDeposit", Convert.ToInt32(GlobalsVariables.SelectedUserId));
                return PartialView(directDepositDetailList);
            }
            else
                return PartialView();
        }
        /// <summary>
        /// Partial view to add a new direct deposit record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _AddDirectDepositView()
        {
            //var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var employeeDirectDepositFormModelObj = new EmployeeDirectDepositFormModel();
            var lookUpDataList = new List<LookUpDataEntity>();
            lookUpDataList = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeDirectDepositFormModelObj.AccountTypeList = lookUpDataList.Where(j => j.TableName == "Utility.DirectDepositAccountType").ToList();
            //employeeDirectDepositFormModelObj.AccountTypeList.Insert(0, lookUpDataEntityObj);
            employeeDirectDepositFormModelObj.EmployeeDirectDeposit.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            employeeDirectDepositFormModelObj.EmployeeDirectDeposit.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            return PartialView(employeeDirectDepositFormModelObj);
        }
        /// <summary>
        /// Partial view to add a new direct deposit record for an employee
        /// </summary>
        /// <param name="employeeDirectDepositFormModelObj"></param>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool _AddDirectDepositView(EmployeeDirectDepositFormModel employeeDirectDepositFormModelObj,FormCollection fc)
        {
           // var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var employeeDirectDepositObj = _directDepositRepository.AddDirectDeposit(employeeDirectDepositFormModelObj.EmployeeDirectDeposit);
            var lookUpDataList = new List<LookUpDataEntity>();
            lookUpDataList = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeDirectDepositFormModelObj.AccountTypeList = lookUpDataList.Where(j => j.TableName == "Utility.DirectDepositAccountType").ToList();
           // employeeDirectDepositFormModelObj.AccountTypeList.Insert(0, lookUpDataEntityobj);

            return true;
        }
        /// <summary>
        /// View to update existing direct deposit record for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _EditDirectDepositView(FormCollection fc)
        {
            //var lookUpDataEntityObj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var employeeDirectDepositFormModelObj = new EmployeeDirectDepositFormModel();
            employeeDirectDepositFormModelObj.EmployeeDirectDeposit = new EmployeeDirectDeposit();
            var id = Request.QueryString["employeeDirectDepositId"];
            int directDepositDetailid = 159;
            employeeDirectDepositFormModelObj.EmployeeDirectDeposit = _directDepositRepository.SelectDirectDepositById(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(GlobalsVariables.SelectedUserId), directDepositDetailid);
            var lookUpDataList = new List<LookUpDataEntity>();
            lookUpDataList = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeDirectDepositFormModelObj.AccountTypeList = lookUpDataList.Where(j => j.TableName == LocalizedStrings.DirectDepositAccountType).ToList();
            // employeeDirectDepositFormModelObj.AccountTypeList.Insert(0, lookUpDataEntityObj);
            return PartialView(employeeDirectDepositFormModelObj);
        }
        /// <summary>
        /// Partial view to edit existing record in hirewizard for an employee
        /// </summary>
        /// <param name="employeeDirectDepositDetailobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool _EditDirectDepositView(EmployeeDirectDepositFormModel employeeDirectDepositDetailobj)
        {
            bool success=_directDepositRepository.UpdateDirectDeposit(employeeDirectDepositDetailobj.EmployeeDirectDeposit);
            if (GlobalsVariables.IsHireWizard != "true" && success==true)
                _registeredUsersRepository.UpdateHireApprovalSetup("DirectDeposit",Convert.ToInt32(GlobalsVariables.SelectedUserId));
            //return success;     
            return true;
        }
        /// <summary>
        /// Action method to delete direct deposit records
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteDirectDeposit(string employeeDirectDepositIds)
        {
            if (employeeDirectDepositIds != null)
            {
                foreach (var employeeDirectDepositId in employeeDirectDepositIds.Split(','))
                {
                 bool   success = _directDepositRepository.DeleteDirectDeposit(Convert.ToInt32(employeeDirectDepositId));
                }
            }
            return true;
        }
        /// <summary>
        /// data table to populate direct deposit schema
        /// </summary>
        /// <returns></returns>
        public DataTable EmployeeDirectSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AccountType",typeof(int));
            dt.Columns.Add("TransitorABANumber",typeof(string));
            dt.Columns.Add("AccountNumber", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("EmployeeDirectDepositId", typeof(int));
            dt.Columns.Add("CompanyId", typeof(int));
            dt.Columns.Add("CreatedBy", typeof(int));
            dt.Columns.Add("CreatedOn", typeof(DateTime));
            return dt;
        }
    }
}
