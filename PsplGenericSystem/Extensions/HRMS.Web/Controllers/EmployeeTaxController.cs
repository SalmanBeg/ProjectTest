using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;

namespace HRMS.Web.Controllers
{
    public class EmployeeTaxController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ITaxRepository _taxRepository;
        private readonly IFilesDBRepository _filesDbRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeSignRepository _employeeSignRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IW4FormRepository _w4FormRepository;
        public EmployeeTaxController(ITaxRepository taxRepository, IFilesDBRepository filesDbRepository, IEmployeeSignRepository employeeSignRepository, IUtilityRepository utilityRepository, IW4FormRepository w4FormRepository, IEmployeeRepository employeeRepository)
        {
            _taxRepository = taxRepository;
            _utilityRepository = utilityRepository;
            _w4FormRepository = w4FormRepository;
            _employeeRepository = employeeRepository;
            _employeeSignRepository = employeeSignRepository;
            _filesDbRepository = filesDbRepository;
        }

       
        #endregion
        /// <summary>
        /// View to add tax information of an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult CreateEmployeeTax()
        {
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var employeeTaxW4Modelobj = new EmployeeTaxW4FormModel();
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeTaxW4Modelobj.FederalWithholdingStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.FederalWithholdingStatusList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.FederalBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.FederalBlock).ToList();
            employeeTaxW4Modelobj.FederalBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.FederalMedBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.SSMedBlock).ToList();
            employeeTaxW4Modelobj.FederalMedBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesWithholdingStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.StateTaxesWithholdingStatusList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesTaxBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.TaxBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesTaxBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesSUISDIBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.SUISDIBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesSUISDIBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesSchoolDistrictList = lstlookup.Where(j => j.TableName == LocalizedStrings.SchoolDistrict).ToList();
            employeeTaxW4Modelobj.StateTaxesSchoolDistrictList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesSchoolBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.SchoolBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesSchoolBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.LocalTaxesWithholdingStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.LocalTaxesWithholdingStatusList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesLiveinCountryList = _utilityRepository.GetCountry();
            employeeTaxW4Modelobj.StateTaxesWorkinCountryList = _utilityRepository.GetCountry();
            #region EmployeeTax

            var employeeTaxobj = new EmployeeTax();
            employeeTaxW4Modelobj.EmployeeTax = _taxRepository.SelectEmployeeTax(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (employeeTaxW4Modelobj.EmployeeTax == null)
                employeeTaxW4Modelobj.EmployeeTax = new EmployeeTax();
            if (employeeTaxW4Modelobj.EmployeeTax.StateTaxesLiveinCountryId != 0)
                employeeTaxW4Modelobj.StateTaxesLiveinStateList = _utilityRepository.GetStateProvince(employeeTaxW4Modelobj.EmployeeTax.StateTaxesLiveinCountryId);
            else
                employeeTaxW4Modelobj.StateTaxesLiveinStateList = _utilityRepository.GetStateProvince(0);

            if (employeeTaxW4Modelobj.EmployeeTax.StateTaxesWorkinCountryId != 0)
                employeeTaxW4Modelobj.StateTaxesWorkinStateList = _utilityRepository.GetStateProvince(employeeTaxW4Modelobj.EmployeeTax.StateTaxesWorkinCountryId);
            else
                employeeTaxW4Modelobj.StateTaxesWorkinStateList = _utilityRepository.GetStateProvince(0);
            #endregion

            #region EmployeeW4Form

            employeeTaxW4Modelobj.EmployeeW4Form = _w4FormRepository.SelectEmployeeW4FormByUserId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), Convert.ToInt32(GlobalsVariables.SelectedUserId)).FirstOrDefault();
            if (employeeTaxW4Modelobj.EmployeeW4Form == null)
                employeeTaxW4Modelobj.EmployeeW4Form = new EmployeeW4Form();
            var employeeobj = _employeeRepository.SelectEmployeeById(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeTaxW4Modelobj.FirstName = employeeobj.FirstName;
            employeeTaxW4Modelobj.LastName = employeeobj.LastName;
            employeeTaxW4Modelobj.MiddleName = employeeobj.MiddleName;
            #endregion
            return View(employeeTaxW4Modelobj);
        }
        /// <summary>
        /// View to add tax information of an employee
        /// </summary>
        /// <param name="employeeTaxW4Modelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult CreateEmployeeTax(EmployeeTaxW4FormModel employeeTaxW4Modelobj)
        {

            
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            bool success = false;

            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            employeeTaxW4Modelobj.StateTaxesLiveinCountryList = _utilityRepository.GetCountry();
            if (employeeTaxW4Modelobj.EmployeeTax.StateTaxesLiveinCountryId != 0)
                employeeTaxW4Modelobj.StateTaxesLiveinStateList =
                    _utilityRepository.GetStateProvince(employeeTaxW4Modelobj.EmployeeTax.StateTaxesLiveinCountryId);
            else
                employeeTaxW4Modelobj.StateTaxesLiveinStateList = _utilityRepository.GetStateProvince(0);
            employeeTaxW4Modelobj.StateTaxesWorkinCountryList = _utilityRepository.GetCountry();
            if (employeeTaxW4Modelobj.EmployeeTax.StateTaxesWorkinCountryId != 0)
                employeeTaxW4Modelobj.StateTaxesWorkinStateList =
                    _utilityRepository.GetStateProvince(employeeTaxW4Modelobj.EmployeeTax.StateTaxesWorkinCountryId);
            else
                employeeTaxW4Modelobj.StateTaxesWorkinStateList = _utilityRepository.GetStateProvince(0);
            employeeTaxW4Modelobj.FederalWithholdingStatusList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.FederalWithholdingStatusList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.FederalBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.FederalBlock).ToList();
            employeeTaxW4Modelobj.FederalBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.FederalMedBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.SSMedBlock).ToList();
            employeeTaxW4Modelobj.FederalMedBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesWithholdingStatusList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.StateTaxesWithholdingStatusList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesTaxBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.TaxBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesTaxBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesSUISDIBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.SUISDIBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesSUISDIBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesSchoolDistrictList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.SchoolDistrict).ToList();
            employeeTaxW4Modelobj.StateTaxesSchoolDistrictList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.StateTaxesSchoolBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.SchoolBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesSchoolBlockList.Insert(0, lookUpDataEntityobj);
            employeeTaxW4Modelobj.LocalTaxesWithholdingStatusList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.LocalTaxesWithholdingStatusList.Insert(0, lookUpDataEntityobj);

            if (ModelState.IsValid)
            {
                if (employeeTaxW4Modelobj.EmployeeTax.UserId == 0)
                {
                    employeeTaxW4Modelobj.EmployeeTax.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                    employeeTaxW4Modelobj.EmployeeTax.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                    success = _taxRepository.CreateEmployeeTax(employeeTaxW4Modelobj.EmployeeTax);
                }
                else
                    success = _taxRepository.UpdateEmployeeTax(employeeTaxW4Modelobj.EmployeeTax);
            }

            if (success)
                return View(employeeTaxW4Modelobj);
            else
                return View();
        }
        /// <summary>
        /// Partial view to add tax information in hire wizard for an employee
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult _EmployeeTaxView()
        {
            var employeeTaxW4Modelobj = new EmployeeTaxW4FormModel();
             var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeTaxW4Modelobj.FederalWithholdingStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.FederalBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.FederalBlock).ToList();
            employeeTaxW4Modelobj.FederalMedBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.SSMedBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesWithholdingStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.StateTaxesTaxBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.TaxBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesSUISDIBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.SUISDIBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesSchoolDistrictList = lstlookup.Where(j => j.TableName ==LocalizedStrings.SchoolDistrict).ToList();
            employeeTaxW4Modelobj.StateTaxesSchoolBlockList = lstlookup.Where(j => j.TableName == LocalizedStrings.SchoolBlock).ToList();
            employeeTaxW4Modelobj.LocalTaxesWithholdingStatusList = lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.StateTaxesLiveinCountryList = _utilityRepository.GetCountry();
            employeeTaxW4Modelobj.StateTaxesWorkinCountryList = _utilityRepository.GetCountry();
            #region EmployeeTax
            
            var employeeTaxobj = new EmployeeTax();
            employeeTaxW4Modelobj.EmployeeTax = _taxRepository.SelectEmployeeTax(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (employeeTaxW4Modelobj.EmployeeTax == null)
                employeeTaxW4Modelobj.EmployeeTax = new EmployeeTax();
            if (employeeTaxW4Modelobj.EmployeeTax.StateTaxesLiveinCountryId != 0)
                employeeTaxW4Modelobj.StateTaxesLiveinStateList = _utilityRepository.GetStateProvince(employeeTaxW4Modelobj.EmployeeTax.StateTaxesLiveinCountryId);
            else
                employeeTaxW4Modelobj.StateTaxesLiveinStateList = _utilityRepository.GetStateProvince(0);

            if (employeeTaxW4Modelobj.EmployeeTax.StateTaxesWorkinCountryId != 0)
                employeeTaxW4Modelobj.StateTaxesWorkinStateList = _utilityRepository.GetStateProvince(employeeTaxW4Modelobj.EmployeeTax.StateTaxesWorkinCountryId);
            else
                employeeTaxW4Modelobj.StateTaxesWorkinStateList = _utilityRepository.GetStateProvince(0);
            #endregion

            #region EmployeeW4Form
           
            employeeTaxW4Modelobj.EmployeeW4Form = _w4FormRepository.SelectEmployeeW4FormByUserId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId),Convert.ToInt32(GlobalsVariables.SelectedUserId)).FirstOrDefault();
            if (employeeTaxW4Modelobj.EmployeeW4Form == null)
                employeeTaxW4Modelobj.EmployeeW4Form = new EmployeeW4Form();
            var employeeobj = _employeeRepository.SelectEmployeeById(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            employeeTaxW4Modelobj.FirstName = employeeobj.FirstName;
            employeeTaxW4Modelobj.LastName = employeeobj.LastName;
            employeeTaxW4Modelobj.MiddleName = employeeobj.MiddleName;
            employeeTaxW4Modelobj.EmployeeSignList = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
            if (employeeTaxW4Modelobj.EmployeeW4Form.EmployeeSignId > 0)
            {
                TempData["signId"] = employeeTaxW4Modelobj.EmployeeW4Form.EmployeeSignId;
                int signId =Convert.ToInt32(employeeTaxW4Modelobj.EmployeeW4Form.EmployeeSignId);
                employeeTaxW4Modelobj.EmployeeSign = (from signDetails in employeeTaxW4Modelobj.EmployeeSignList
                                               where signDetails.EmployeeSignFileId == signId
                                               select signDetails).FirstOrDefault();
            }
            else
                employeeTaxW4Modelobj.EmployeeSign = new EmployeeSign();
            #endregion

            return PartialView(employeeTaxW4Modelobj);
        }
        /// <summary>
        /// Partial view to add tax information for an employee(POST Method)
        /// </summary>
        /// <param name="employeeTaxW4Modelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool _EmployeeTaxView(EmployeeTaxW4FormModel employeeTaxW4Modelobj)
        {
            int signId = 0;
            if (TempData["signId"] != null)
                signId = Convert.ToInt32(TempData["signId"]);
            bool success = false;
          
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            employeeTaxW4Modelobj.StateTaxesLiveinCountryList = _utilityRepository.GetCountry();
            if (employeeTaxW4Modelobj.EmployeeTax.StateTaxesLiveinCountryId != 0)
                employeeTaxW4Modelobj.StateTaxesLiveinStateList =
                    _utilityRepository.GetStateProvince(employeeTaxW4Modelobj.EmployeeTax.StateTaxesLiveinCountryId);
            else
                employeeTaxW4Modelobj.StateTaxesLiveinStateList = _utilityRepository.GetStateProvince(0);
            employeeTaxW4Modelobj.StateTaxesWorkinCountryList = _utilityRepository.GetCountry();
            if (employeeTaxW4Modelobj.EmployeeTax.StateTaxesWorkinCountryId != 0)
                employeeTaxW4Modelobj.StateTaxesWorkinStateList =
                    _utilityRepository.GetStateProvince(employeeTaxW4Modelobj.EmployeeTax.StateTaxesWorkinCountryId);
            else
                employeeTaxW4Modelobj.StateTaxesWorkinStateList = _utilityRepository.GetStateProvince(0);
            employeeTaxW4Modelobj.FederalWithholdingStatusList =
                lstlookup.Where(j => j.TableName ==LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.FederalBlockList =
                lstlookup.Where(j => j.TableName ==LocalizedStrings.FederalBlock).ToList();
            employeeTaxW4Modelobj.FederalMedBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.SSMedBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesWithholdingStatusList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
            employeeTaxW4Modelobj.StateTaxesTaxBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.TaxBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesSUISDIBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.SUISDIBlock).ToList();
            employeeTaxW4Modelobj.StateTaxesSchoolDistrictList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.SchoolDistrict).ToList();
            employeeTaxW4Modelobj.StateTaxesSchoolBlockList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.SchoolBlock).ToList();
            employeeTaxW4Modelobj.LocalTaxesWithholdingStatusList =
                lstlookup.Where(j => j.TableName == LocalizedStrings.WithholdingStatus).ToList();
          
            if (ModelState.IsValid)
            {
                if (employeeTaxW4Modelobj.EmployeeTax.UserId == 0)
                {
                    employeeTaxW4Modelobj.EmployeeTax.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                    employeeTaxW4Modelobj.EmployeeTax.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                    success = _taxRepository.CreateEmployeeTax(employeeTaxW4Modelobj.EmployeeTax);
                }
                else
                    success = _taxRepository.UpdateEmployeeTax(employeeTaxW4Modelobj.EmployeeTax);        
            }
            return success;
        }
        /// <summary>
        /// Partial view for taxes form in hire wizard
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult _EmployeeW4FormView()
        {
            var employeeTaxW4Modelobj = new EmployeeTaxW4FormModel();
            employeeTaxW4Modelobj.EmployeeW4Form = _w4FormRepository.SelectEmployeeW4FormByUserId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId),Convert.ToInt32(GlobalsVariables.SelectedUserId)).FirstOrDefault();
            if (employeeTaxW4Modelobj.EmployeeW4Form != null)
            {
                employeeTaxW4Modelobj.EmployeeW4Form.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                employeeTaxW4Modelobj.EmployeeW4Form.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            }
            employeeTaxW4Modelobj.EmployeeSignList = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.SelectedUserId));
            return PartialView(employeeTaxW4Modelobj);
        }
        /// <summary>
        /// Partial view for taxes form in hire wizard
        /// </summary>
        /// <param name="employeeTaxW4Modelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool _EmployeeW4FormView(EmployeeTaxW4FormModel employeeTaxW4Modelobj)
        {
            bool success = false;
            var employeeW4Formobj = employeeTaxW4Modelobj.EmployeeW4Form;
            employeeW4Formobj.EmployeeSignId = 0;
            if (TempData["signId"] != null)
            { 
                employeeW4Formobj.EmployeeSignId = Convert.ToInt32(TempData["signId"]);
                employeeW4Formobj.SignDate = DateTime.UtcNow;
            }
            if (employeeW4Formobj != null)
            {               
                if (ModelState.IsValid)
                {
                    if (employeeW4Formobj.UserId == 0)
                    {
                        employeeW4Formobj.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
                        employeeW4Formobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                        success = _w4FormRepository.AddEmployeeW4Form(employeeW4Formobj);
                    }
                    else
                        success = _w4FormRepository.UpdateEmployeeW4Form(employeeW4Formobj);
                }
            }
            return success;
        }
        /// <summary>
        /// function to show esign for W4 form
        /// </summary>
        /// <returns></returns>
        public string GetSign()
        {
            var employeeSign = _employeeSignRepository.GetAllEmployeeSignByUserId(Convert.ToInt32(GlobalsVariables.CurrentUserId));
            //var signFileId = (from es in employeeSign
            //                  where es.IsDefault == true
            //                  select es.EmployeeSignFileId);
            //var fileDetails = _filesDBRepository.SelectFileByFileDBId(Convert.ToInt32(signFileId));
            var signFileId = employeeSign[0].EmployeeSignFileId;
            var filebytes = employeeSign[0].SignFileBytes;

            return "data:image/jpg;base64," + Convert.ToBase64String(filebytes);
        }
        public void SetTempData(int signId)
        {
            TempData["signId"] = signId;
        }
    }
}
