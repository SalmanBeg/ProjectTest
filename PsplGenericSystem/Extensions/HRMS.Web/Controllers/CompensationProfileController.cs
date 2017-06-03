using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Repositories;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;

namespace HRMS.Web.Controllers
{
    public class CompensationProfileController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ICompensationProfileRepository _compensationProfileRepository;
        private readonly IUtilityRepository _utilityRepository;
        public CompensationProfileController(ICompensationProfileRepository compensationProfileRepository, IUtilityRepository utilityRepository)
        {
            _compensationProfileRepository = compensationProfileRepository;
            _utilityRepository = utilityRepository;
        }
        #endregion
      
        /// <summary>
        /// View to list all the compensation profile records in a company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllCompensationProfile()
        {
            var objModelList = new List<CompensationProfile>();
            objModelList = _compensationProfileRepository.SelectAllCompensationProfiles(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(objModelList);
        }
        /// <summary>
        /// View to add a new record for a compensation profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult AddCompensationProfile()
        {
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            var objFormModel = new CompensationFormModel();
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            objFormModel.WageTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.WageType).ToList();
            objFormModel.WageTypeList.Insert(0, lookUpDataEntityobj);
            objFormModel.WageUnitList = lstlookup.Where(j => j.TableName == LocalizedStrings.WageUnit).ToList();
            objFormModel.WageUnitList.Insert(0, lookUpDataEntityobj);
            return View(objFormModel);
        }
        /// <summary>
        /// View to add a new record for a compensation profile
        /// </summary>
        /// <param name="objCompensationFormModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddCompensationProfile(CompensationFormModel objCompensationFormModel)
        {
            objCompensationFormModel.CompensationProfileObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            objCompensationFormModel.CompensationProfileObj.Stock = (objCompensationFormModel.CompensationProfileObj.Stock != null) ? objCompensationFormModel.CompensationProfileObj.Stock : string.Empty;
            objCompensationFormModel.CompensationProfileObj.OtherCashComp = (objCompensationFormModel.CompensationProfileObj.OtherCashComp != null) ? objCompensationFormModel.CompensationProfileObj.OtherCashComp : Convert.ToDecimal(0.00);
            objCompensationFormModel.CompensationProfileObj.PTOPlan = (objCompensationFormModel.CompensationProfileObj.PTOPlan != null) ? objCompensationFormModel.CompensationProfileObj.PTOPlan : string.Empty;
            objCompensationFormModel.CompensationProfileObj.OtherBenefits = (objCompensationFormModel.CompensationProfileObj.OtherBenefits != null) ? objCompensationFormModel.CompensationProfileObj.OtherBenefits : string.Empty;

            _compensationProfileRepository.AddCompensationProfile(objCompensationFormModel.CompensationProfileObj);
            return RedirectToAction("SelectAllCompensationProfile");
        }
        /// <summary>
        /// View to update an existing compensation profile record
        /// </summary>
        /// <param name="compensationProfileId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult UpdateCompensationProfile(int compensationProfileId)
        {
            var objFormModel = new CompensationFormModel();
            objFormModel.CompensationProfileObj = _compensationProfileRepository.SelectAllCompensationProfileById(compensationProfileId);
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            objFormModel.WageTypeList = lstlookup.Where(j => j.TableName == LocalizedStrings.WageType).ToList();
            objFormModel.WageUnitList = lstlookup.Where(j => j.TableName == LocalizedStrings.WageUnit).ToList();

            return View(objFormModel);
        }
        /// <summary>
        /// View to update an existing compensation profile record
        /// </summary>
        /// <param name="objCompensateFormModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateCompensationProfileById(CompensationFormModel objCompensateFormModel)
        {
            objCompensateFormModel.CompensationProfileObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            objCompensateFormModel.CompensationProfileObj.Stock = objCompensateFormModel.CompensationProfileObj.Stock ?? string.Empty;
            objCompensateFormModel.CompensationProfileObj.OtherCashComp = (objCompensateFormModel.CompensationProfileObj.OtherCashComp != null) ? objCompensateFormModel.CompensationProfileObj.OtherCashComp : Convert.ToDecimal(0.00);
            objCompensateFormModel.CompensationProfileObj.PTOPlan = objCompensateFormModel.CompensationProfileObj.PTOPlan ?? string.Empty;
            objCompensateFormModel.CompensationProfileObj.OtherBenefits = objCompensateFormModel.CompensationProfileObj.OtherBenefits ?? string.Empty;
            _compensationProfileRepository.UpdateCompensationProfile(objCompensateFormModel.CompensationProfileObj);
            return RedirectToAction("SelectAllCompensationProfile");
        }
        /// <summary>
        /// Function to delete records based on recordIds
        /// </summary>
        /// <param name="compensationprofileIds"></param>
        /// <returns></returns>
        [Authorize]
        public bool DeleteCompensationProfile(string compensationprofileIds)
        {
            if (compensationprofileIds != null)
            {
                //foreach (var CompProfileId in CompensationprofileIds.Split(','))
                //{
                var deleteCompensationprofile = _compensationProfileRepository.DeleteCompensationProfile(compensationprofileIds);
                //}
            }
            return true;
        }
        [HttpGet]
        [ActionName("IsTitleExists")]
        public JsonResult IsTitleExists(CompensationFormModel compensationFormModelObj)
        {
            compensationFormModelObj.CompensationProfileObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _compensationProfileRepository.IsTitleExists(compensationFormModelObj.CompensationProfileObj);
            if (compensationFormModelObj.CompensationProfileObj.CompensationProfileId.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}