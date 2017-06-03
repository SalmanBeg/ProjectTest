using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using HRMS.Data;
//using HRMS.BusinessLayer;
using HRMS.Web.Helper;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.ViewModels;

namespace HRMS.Web.Controllers
{
    public class CompanyController : Controller
    {
        #region Class Level Variables and constructor

        private readonly ICompanyRepository _companyRepository;
        private readonly IUtilityRepository _utilityRepository;
        private readonly IRegisteredUsersRepository _registeredUsersRepository;

        public CompanyController(ICompanyRepository companyRepository, IUtilityRepository utilityRepository, IRegisteredUsersRepository registeredUsersRepository)
        {
            _companyRepository = companyRepository;
            _utilityRepository = utilityRepository;
            _registeredUsersRepository = registeredUsersRepository;
        }

        #endregion
        /// <summary>
        /// To add a new company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ConfigureCompany()
        {
            var companyInfoList = new List<CompanyInfo>();
            companyInfoList = _companyRepository.GetCompanyInfo(Convert.ToInt32(GlobalsVariables.CurrentUserId));
            return View(companyInfoList);
        }
        /// <summary>
        /// View to edit existing company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult EditCompany()
        {
            var companyId = Request.QueryString["CompanyId"];
            var companyFormModelObj = new CompanyFormModel();
            companyFormModelObj.CompanyInfo = _companyRepository.GetEditCompanyInfo(Convert.ToInt32(companyId));
            companyFormModelObj.CountryList = _utilityRepository.GetCountry();
            if (companyFormModelObj.CompanyInfo == null)
                companyFormModelObj.CompanyInfo = new CompanyInfo();
            if (companyFormModelObj.CompanyInfo.CountryId != null)
                companyFormModelObj.StateList = _utilityRepository.GetStateProvince(companyFormModelObj.CompanyInfo.CountryId);
            else
                companyFormModelObj.CompanyInfo.CountryId = 222;
            return View(companyFormModelObj);
        }
        /// <summary>
        /// View to edit existing company
        /// </summary>
        /// <param name="companyFormModelObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult EditCompany(CompanyFormModel companyFormModelObj)
        {
            bool success = false;
            if (companyFormModelObj.CompanyInfo.CompanyId != 0)
                success = _companyRepository.UpdateCompanyById(companyFormModelObj.CompanyInfo);
            else
                success = _companyRepository.CreateCompany(companyFormModelObj.CompanyInfo, Convert.ToInt32(GlobalsVariables.CurrentUserId));
            if (success)
                return RedirectToAction("ConfigureCompany");
            return View();
        }
        /// <summary>
        /// To list all the companies
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllCompanyInfo()
        {
            List<CompanyInfo> companyLinkList = _companyRepository.GetAllCompanyInfo().ToList();
            return View(companyLinkList);
        }
        /// <summary>
        /// To bind the dashboard company dropdown
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public JsonResult SelectAllCompanies()
        {
            List<CompanyInfo> companyLinkList = _companyRepository.GetAllCompanyInfo().ToList();
            return Json(companyLinkList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// To populate individual company details
        /// </summary>
        /// <param name="companyId"></param>
        [Authorize]
        public void SelectCompanyInfo(string companyId)
        {
            GlobalsVariables.CurrentCompanyId = companyId;
            var companyFormModelObj = new CompanyFormModel();
            companyFormModelObj.CompanyInfo = _companyRepository.GetEditCompanyInfo(Convert.ToInt32(companyId));
            GlobalsVariables.CurrentCompanyName = companyFormModelObj.CompanyInfo.CompanyName;

            // here as superadmin logsin and he does not show in employee list of a company we select first employee as default selected employee
            var firstUser = _registeredUsersRepository.SelectAllEmployeesList(
                Int32.Parse(GlobalsVariables.CurrentCompanyId)).FirstOrDefault();
            if (firstUser != null)
            {
                GlobalsVariables.SelectedUserId = Convert.ToString(firstUser.UserId);
                GlobalsVariables.SelectedUserName = firstUser.UserName;
            }
        }

        [HttpGet]
        [ActionName("IsTitleExists")]
        public JsonResult IsTitleExists(CompanyFormModel companyFormModelObj)
        {
            //companyFormModelObj.CompanyInfo.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _companyRepository.IsTitleExists(companyFormModelObj.CompanyInfo);
            if (companyFormModelObj.CompanyInfo.CompanyId.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
