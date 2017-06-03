using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;
using HRMS.Web.ViewModels;
using HRMS.Service.Repositories;

namespace HRMS.Web.Controllers
{
    public class PayTypeController : Controller
    {

        #region Class Level Variables and constructor

        private readonly IPayTypeRepository _payTypeRepository;
        private readonly ITimeTypeRepository _timeTypeRepository;
     
        public PayTypeController(IPayTypeRepository payTypeRepository, ITimeTypeRepository timeTypeRepository)
        {
            _payTypeRepository = payTypeRepository;
            _timeTypeRepository = timeTypeRepository;
           
        }

       
        #endregion

        /// <summary>
        /// Returns PayType List by CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllPayTypeDetails")]
        public ActionResult SelectAllPayTypeDetails()
        {
            var PayTypeList = _payTypeRepository.SelectAllPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(PayTypeList);
        }

        /// <summary>
        /// AddPayTypeDetail - Get Method: Returns the AddPayTypeDetail View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddPayTypeDetail")]
        public ActionResult AddPayTypeDetail()
        {
            PayTypeFormModel payTypeFormModel = new PayTypeFormModel();          
            payTypeFormModel.TimeTypeList = _timeTypeRepository.SelectAllTimeTypeDetails(0);
            payTypeFormModel.PayTypeList = _payTypeRepository.SelectAllPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).Where(rw => rw.IsDefault.Equals(true)).ToList();

            return View(payTypeFormModel);
        }

        [HttpGet]
        [ActionName("GetPayCode")]
        public JsonResult GetPayCode(string PayTypeId)
        {
            var model = _payTypeRepository.SelectPayTypeDetailsByPayTypeId(Convert.ToInt32(PayTypeId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            //Verifies whether the records exists with the containing PayCode.
            List<PayType> payTypeSelectAllDetails = _payTypeRepository.SelectAllPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).Where(
                p => p.PayCode.StartsWith(model[0].PayCode)).ToList();
            model[0].PayCode = model[0].PayCode + payTypeSelectAllDetails.Count;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// AddPayTypeeDetail - Post Method: Inserts New PayType.
        /// </summary>
        /// <param name="lunchItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddPayTypeDetail")]
        public ActionResult AddPayTypeDetail(PayTypeFormModel paytypeFormModelObj)
        {
            PayTypeFormModel payTypeFormModel = new PayTypeFormModel();
            var model = _payTypeRepository.SelectPayTypeDetailsByPayTypeId(Convert.ToInt32(paytypeFormModelObj.PayType.PayTypeId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            //Sets other field values by PayTypeId
            paytypeFormModelObj.PayType.PayTypeCode = model[0].PayTypeCode;
            paytypeFormModelObj.PayType.PunchType = model[0].PunchType;
            paytypeFormModelObj.PayType.TimeTypeId = model[0].TimeTypeId;

            bool success = false;
            paytypeFormModelObj.PayType.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            success = _payTypeRepository.InsertPayType(paytypeFormModelObj.PayType);

            if (success)
                return RedirectToAction("SelectAllPayTypeDetails");
            return View(paytypeFormModelObj);
        }


        /// <summary>
        /// EditPayTypeDetail - Get Method: Returns the EditPayTypeDetail View.
        /// </summary>
        /// <param name="LunchId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditPayTypeDetail")]
        public ActionResult EditPayTypeDetail(int PayTypeId)
        {
            PayTypeFormModel payTypeFormModel = new PayTypeFormModel();

            var paytypeDetail = new List<PayType>();
            payTypeFormModel.PayType = _payTypeRepository.SelectPayTypeDetailsByPayTypeId(PayTypeId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).SingleOrDefault();

            //TimeType and PayType DropdownLists
            payTypeFormModel.TimeTypeList = _timeTypeRepository.SelectAllTimeTypeDetails(0);
            payTypeFormModel.PayTypeList = _payTypeRepository.SelectAllPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(payTypeFormModel);
        }


        /// <summary>
        /// EditPayTypeDetail - Post Method: Updates the PayType Information.
        /// </summary>
        /// <param name="lunchItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditPayTypeDetail")]
        public ActionResult EditPayTypeDetail(PayTypeFormModel paytypeInfoObj)
        {
            bool success = false;
            if (ModelState.IsValid)
                success = _payTypeRepository.UpdatePayType(paytypeInfoObj.PayType);

            if (success)
                return RedirectToAction("SelectAllPayTypeDetails");
            return View();
        }

        /// <summary>
        /// DeletePayTypeDetail - Get Method: Deletes the PayType Information from SelectAllPayTypeDetails View.
        /// </summary>
        /// <param name="lunchId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DeletePayTypeDetail")]
        public bool DeletePayTypeDetail(string PayTypeIds)
        {
            if (PayTypeIds != null)
            {
                foreach (var PayTypeId in PayTypeIds.Split(','))
                {
                    var deletePayTypeDetail =
                         _payTypeRepository.DeletePayTypeDetail(Int32.Parse(PayTypeId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
    }
}