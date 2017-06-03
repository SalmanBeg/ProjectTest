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
    public class OverTimePolicyController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IOverTimePolicyRepository _overTimePolicyRepository;
        private readonly IOTPolicyTypeRepository _otPolicyTypeRepository;
        private readonly IOTPayTypeRepository _otPayTypeRepository;

        public OverTimePolicyController(IOverTimePolicyRepository overTimePolicyRepository,IOTPolicyTypeRepository otPolicyTypeRepository,IOTPayTypeRepository otPayTypeRepository)
        {
            _overTimePolicyRepository = overTimePolicyRepository;
            _otPolicyTypeRepository = otPolicyTypeRepository;
            _otPayTypeRepository = otPayTypeRepository;
        }
        protected IOverTimePolicyRepository OverTimePolicyRepository
        {
            get { return _overTimePolicyRepository; }
        }
        protected IOTPolicyTypeRepository OTPolicyTypeRepository
        {
            get { return _otPolicyTypeRepository; }
        }
        protected IOTPayTypeRepository OTPayTypeRepository
        {
            get { return _otPayTypeRepository; }
        }
        #endregion

        /// <summary>
        /// Returns OverTime List by CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllOverTimePolicyDetails")]
        public ActionResult SelectAllOverTimePolicyDetails()
        {
            var overtimeList = _overTimePolicyRepository.SelectAllOverTimeDetailsByCompanyId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var OTPolicyTypeList = _otPolicyTypeRepository.SelectAllOTPolicyTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var OTPayTypeList = _otPayTypeRepository.SelectAllOTPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            foreach (OverTimePolicy item in overtimeList)
            {
                item.OTPolicytypeName = OTPolicyTypeList.Where(otp => otp.OTPolicyTypeId == item.OTPolicytype).Select(otp => otp.Name).SingleOrDefault();
                item.SatPayTypeName = OTPayTypeList.Where(ot => ot.OTPayTypeId == item.SatPayType).Select(ot => ot.Name).SingleOrDefault();
                item.SunPayTypeName = OTPayTypeList.Where(ot => ot.OTPayTypeId == item.SunPayType).Select(ot => ot.Name).SingleOrDefault();
            }

            OvertimePolicyFormModel overtimeFormModelObj = new OvertimePolicyFormModel();

            overtimeFormModelObj.OTPolicyTypeList = OTPolicyTypeList;
            overtimeFormModelObj.OTPayTypeList = OTPayTypeList;
            overtimeFormModelObj.OverTimePolicyList = overtimeList;
            return View(overtimeFormModelObj);
        }


        /// <summary>
        /// Add OverTimePolicyDetail - Get Method: Returns the OverTimePolicyInsert View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddOverTimePolicyDetail")]
        public ActionResult AddOverTimePolicyDetail()
        {
            OvertimePolicyFormModel overtimePolicyFormModelObj = new OvertimePolicyFormModel();
            //OverTimePolicy overTimePolicyObj = new OverTimePolicy();
            overtimePolicyFormModelObj.OTPolicyTypeList = _otPolicyTypeRepository.SelectAllOTPolicyTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            overtimePolicyFormModelObj.OTPayTypeList = _otPayTypeRepository.SelectAllOTPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(overtimePolicyFormModelObj);
        }


        /// <summary>
        /// Add OverTimePolicyDetail - Post Method: Inserts New OverTimePolicy Details.
        /// </summary>
        /// <param name="overtimeItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddOverTimePolicyDetail")]
        public ActionResult AddRoundingDetail(OvertimePolicyFormModel overtimeFormModelItem)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                overtimeFormModelItem.OverTimePolicy.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                success = _overTimePolicyRepository.InsertOverTimePolicy(overtimeFormModelItem.OverTimePolicy);
            }
            if (success)
                return RedirectToAction("SelectAllOverTimePolicyDetails");
            return View();
        }


        /// <summary>
        /// EditOverTimePolicy - Get Method: Returns the EditOverTimePolicy View.
        /// </summary>
        /// <param name="OverTimeId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditOverTimePolicyDetail")]
        public ActionResult EditOverTimePolicyDetail(int OverTimeId)
        {
            OvertimePolicyFormModel overtimePolicyFormModelObj = new OvertimePolicyFormModel();
            overtimePolicyFormModelObj.OverTimePolicy = _overTimePolicyRepository.SelectOverTimeDetailsByOverTimeId(OverTimeId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            overtimePolicyFormModelObj.OTPolicyTypeList = _otPolicyTypeRepository.SelectAllOTPolicyTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            overtimePolicyFormModelObj.OTPayTypeList = _otPayTypeRepository.SelectAllOTPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(overtimePolicyFormModelObj);
        }


        /// <summary>
        /// EditOverTime - Post Method: Updates the OverTime Information.
        /// </summary>
        /// <param name="overtimeItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditOverTimePolicyDetail")]
        public ActionResult EditOverTimePolicyDetail(OvertimePolicyFormModel overtimeFormModelItem)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                success = _overTimePolicyRepository.UpdateOverTimePolicy(overtimeFormModelItem.OverTimePolicy);
            }
            if (success)
                return RedirectToAction("SelectAllOverTimePolicyDetails");
            return View();
        }



        /// <summary>
        /// DeleteOverTime - Post Method: Deletes the OverTime Policy Information
        /// </summary>
        /// <param name="OverTimeIds"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DeleteOverTimePolicyDetail")]
        public bool DeleteOverTimePolicyDetail(string OverTimeIds)
        {

            if (OverTimeIds != null)
            {
                foreach (var OverTimeId in OverTimeIds.Split(','))
                {
                    var deleteRoundingDetail =
                         _overTimePolicyRepository.DeleteOverTimeDetail(Int32.Parse(OverTimeId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
    }
}