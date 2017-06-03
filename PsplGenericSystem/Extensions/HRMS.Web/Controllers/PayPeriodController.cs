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
    public class PayPeriodController : Controller
    {

        #region Class Level Variables and constructor

        private readonly IPayPeriodRepository _payPeriodRepository;
        private readonly IPayPeriodTypeRepository _payPeriodTypeRepository;

        public PayPeriodController(IPayPeriodRepository payPeriodRepository, IPayPeriodTypeRepository payPeriodTypeRepository)
        {
            _payPeriodRepository = payPeriodRepository;
            _payPeriodTypeRepository = payPeriodTypeRepository;
        }

        protected IPayPeriodRepository PayPeriodRepository
        {
            get { return _payPeriodRepository; }
        }

        protected IPayPeriodTypeRepository PayPeriodTypeRepository
        {
            get { return _payPeriodTypeRepository; }
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
            List<PayPeriodType> payperiodtypeobj = new List<PayPeriodType>();
            payperiodtypeobj = _payPeriodTypeRepository.SelectAllPayPeriodTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();

            var payperiodList = _payPeriodRepository.SelectAllPayPeriodDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            for (int i = 0; i < payperiodList.Count; i++)
            {
                payperiodList[i].PayPeriodTypename = payperiodtypeobj.Where(pt => pt.PayPeriodTypeId == payperiodList[i].PayPeriodTypeId).Select(pt => pt.Name).SingleOrDefault();
                payperiodList[i].PayPeriodDays = (payperiodtypeobj.Where(pt => pt.PayPeriodTypeId == payperiodList[i].PayPeriodTypeId).Select(pt => pt.Days).SingleOrDefault()).GetValueOrDefault();
            }

            PayPeriodFormModel payPeriodFormModelObj = new PayPeriodFormModel();
            payPeriodFormModelObj.PayPeriodList = payperiodList;
            payPeriodFormModelObj.PayPeriodTypeList = payperiodtypeobj;

            return View(payPeriodFormModelObj);
        }


        /// <summary>
        /// AddPayPeriodDetail - Get Method: Returns the PayPeriodDetails View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddPayPeriodDetail")]
        public ActionResult AddPayPeriodDetail()
        {
            var payperiodFormModelObj = new PayPeriodFormModel
            {
                PayPeriodTypeList = _payPeriodTypeRepository.SelectAllPayPeriodTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId))
            };
            //payperiodFormModelObj.PayPeriod.NextSchedule

            return View(payperiodFormModelObj);
        }

        [HttpGet]
        [ActionName("GetPayPeriodDays")]
        public JsonResult GetPayPeriodDays(string PayPeriodTypeId)
        {
            var model = _payPeriodTypeRepository.SelectPayPeriodTypeDetails(Convert.ToInt32(PayPeriodTypeId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// AddPayPeriodDetail - Post Method: Inserts New PayPeriod.
        /// </summary>
        /// <param name="payperiodItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddPayPeriodDetail")]
        public ActionResult AddPayPeriodDetail(PayPeriodFormModel payperiodFormItem)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                payperiodFormItem.PayPeriod.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                success = _payPeriodRepository.InsertPayPeriod(payperiodFormItem.PayPeriod);
            }

            if (success)
                return RedirectToAction("SelectAllPayPeriodDetails");
            return View();
        }


        /// <summary>
        /// EditPayPeriodDetail - Get Method: Returns the EditPayPeriod View.
        /// </summary>
        /// <param name="PayPeriodId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditPayPeriodDetail")]
        public ActionResult EditPayPeriodDetail(int PayPeriodId)
        {
            PayPeriods payperiodDetail = new PayPeriods();

            payperiodDetail = _payPeriodRepository.SelectPayPeriodDetail(PayPeriodId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).SingleOrDefault();

            List<PayPeriodType> PayPeriodTypeObj = _payPeriodTypeRepository.SelectAllPayPeriodTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            payperiodDetail.PayPeriodDays = (PayPeriodTypeObj.Where(pt => pt.PayPeriodTypeId == payperiodDetail.PayPeriodTypeId).Select(pt => pt.Days).SingleOrDefault()).GetValueOrDefault();
          
            PayPeriodFormModel payPeriodFormModel = new PayPeriodFormModel();

            payPeriodFormModel.PayPeriod = payperiodDetail;
            payPeriodFormModel.PayPeriodTypeList = PayPeriodTypeObj;

            return View(payPeriodFormModel);
        }


        /// <summary>
        /// EditPayPeriod - Post Method: Updates the PayPeriod Information.
        /// </summary>
        /// <param name="payperiodItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditPayPeriodDetail")]
        public ActionResult EditPayPeriodDetail(PayPeriodFormModel payperiodFormItem)
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                success = _payPeriodRepository.UpdatePayPeriod(payperiodFormItem.PayPeriod);
            }

            if (success)
                return RedirectToAction("SelectAllPayPeriodDetails");
            return View();
        }


        /// <summary>
        /// DeletePayPeriod - Post Method: Deletes the PayPeriod Information.
        /// </summary>
        /// <param name="PayPeriodIds"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DeletePayPeriodDetail")]
        public bool DeletePayPeriodDetail(string PayPeriodIds)
        {

            if (PayPeriodIds != null)
            {
                foreach (var PayPeriodId in PayPeriodIds.Split(','))
                {
                    var deletePayPeriodDetail =
                         _payPeriodRepository.DeletePayPeriodDetail(Int32.Parse(PayPeriodId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
    }
}