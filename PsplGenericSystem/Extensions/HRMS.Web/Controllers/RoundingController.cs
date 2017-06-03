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
    public class RoundingController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IRoundingRepository _roundingRepository;
        private readonly IRoundTypeRepository _roundTypeRepository;
        private readonly IRoundMinuteRepository _roundMinuteRepository;

        public RoundingController(IRoundingRepository roundingRepository, IRoundTypeRepository roundTypeRepository, IRoundMinuteRepository roundMinuteRepository)
        {
            _roundingRepository = roundingRepository;
            _roundTypeRepository = roundTypeRepository;
            _roundMinuteRepository = roundMinuteRepository;
        }

        protected IRoundingRepository RoundingRepository
        {
            get { return _roundingRepository; }
        }
        protected IRoundTypeRepository RoundTypeRepository
        {
            get { return _roundTypeRepository; }
        }
        protected IRoundMinuteRepository RoundMinuteRepository
        {
            get { return _roundMinuteRepository; }
        }

        #endregion


        /// <summary>
        /// Returns Rounding List by CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllRoundingDetails")]
        public ActionResult SelectAllRoundingDetails()
        {
            RoundingFormModel roundingFormModelObj = new RoundingFormModel();
            List<Rounding> roundingInfoList = _roundingRepository.SelectAllRoundingDetailsByCompanyId(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var RoundTypeList = _roundTypeRepository.SelectAllRoundTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            for (int i = 0; i < roundingInfoList.Count; i++)
            {
                roundingInfoList[i].WorkStartTypeName = RoundTypeList.Where(rt => rt.RoundTypeId == roundingInfoList[i].StartRoundType).Select(rt => rt.Name).SingleOrDefault();
                roundingInfoList[i].WorkEndTypeName = RoundTypeList.Where(rt => rt.RoundTypeId == roundingInfoList[i].EndRoundType).Select(rt => rt.Name).SingleOrDefault();
                roundingInfoList[i].LunchStartTypeName = RoundTypeList.Where(rt => rt.RoundTypeId == roundingInfoList[i].LunchStartRoundType).Select(rt => rt.Name).SingleOrDefault();
                roundingInfoList[i].LunchEndTypeName = RoundTypeList.Where(rt => rt.RoundTypeId == roundingInfoList[i].LunchEndRoundType).Select(rt => rt.Name).SingleOrDefault();
                roundingInfoList[i].BreakStartTypeName = RoundTypeList.Where(rt => rt.RoundTypeId == roundingInfoList[i].BreakStartRoundType).Select(rt => rt.Name).SingleOrDefault();
                roundingInfoList[i].BreakEndTypeName = RoundTypeList.Where(rt => rt.RoundTypeId == roundingInfoList[i].BreakEndRoundType).Select(rt => rt.Name).SingleOrDefault();
            }

            roundingFormModelObj.RoundingList = roundingInfoList;

            return View(roundingFormModelObj);
        }


        /// <summary>
        /// AddRoundngDetail - Get Method: Returns the RoundingInsert View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddRoundingDetail")]
        public ActionResult AddRoundingDetail()
        {
            RoundingFormModel roundingFormModelObj = new RoundingFormModel();

            roundingFormModelObj.RoundTypeList = _roundTypeRepository.SelectAllRoundTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            roundingFormModelObj.RoundMinuteList = _roundMinuteRepository.SelectAllRoundMinuteDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            return View(roundingFormModelObj);
        }


        /// <summary>
        /// AddRoundngDetail - Post Method: Inserts New Rounding Details.
        /// </summary>
        /// <param name="lunchItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddRoundingDetail")]
        public ActionResult AddRoundingDetail(RoundingFormModel roundingItem)
        {

            bool success = false;
            if (ModelState.IsValid)
            {
                roundingItem.Rounding.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                success = _roundingRepository.InsertRounding(roundingItem.Rounding);
            }

            if (success)
                return RedirectToAction("SelectAllRoundingDetails");
            return View();
        }


        /// <summary>
        /// EditRounding - Get Method: Returns the EditRounding View.
        /// </summary>
        /// <param name="LunchId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditRoundingDetail")]
        public ActionResult EditRoundingDetail(int RoundingId)
        {
            //  int decrytedRoundingId = Convert.ToInt32(Encryption.Decrypt(RoundingId));

            RoundingFormModel RoundingFormModelObj = new RoundingFormModel();


           Rounding RoundingDetailObj = _roundingRepository.SelectRoundingDetailsByRoundingId(RoundingId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
           List<RoundType> roundTypeList = _roundTypeRepository.SelectAllRoundTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
           List<RoundMinute> RoundMinutesList = _roundMinuteRepository.SelectAllRoundMinuteDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

           RoundingFormModelObj.Rounding = RoundingDetailObj;
           RoundingFormModelObj.RoundTypeList = roundTypeList;
           RoundingFormModelObj.RoundMinuteList = RoundMinutesList;

           return View(RoundingFormModelObj);
        }


        /// <summary>
        /// EditRounding - Post Method: Updates the Rounding Information.
        /// </summary>
        /// <param name="lunchItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditRoundingDetail")]
        public ActionResult EditRoundingDetail(RoundingFormModel roundingItem)
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                success = _roundingRepository.UpdateRounding(roundingItem.Rounding);
            }

            if (success)
                return RedirectToAction("SelectAllRoundingDetails");
            return View();
        }



        /// <summary>
        /// DeleteRounding - Get Method: Deletes the Rounding Information
        /// </summary>
        /// <param name="RoundingId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DeleteRoundingDetail")]
        public bool DeleteRoundingDetail(string RoundingIds)
        {

            if (RoundingIds != null)
            {
                foreach (var RoundingId in RoundingIds.Split(','))
                {
                    var deleteRoundingDetail =
                         _roundingRepository.DeleteroundingDetail(Int32.Parse(RoundingId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
	}
}