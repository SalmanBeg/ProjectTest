using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Web.Areas.HireWizard.Models;
using HRMS.Service.Interfaces;

namespace HRMS.Web.Controllers
{
    public class HolidayController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IHolidayRepository _holidayRepository;

        public HolidayController(IHolidayRepository holidayRepository)
        {
            _holidayRepository = holidayRepository;
        }

        protected IHolidayRepository HolidayRepository
        {
            get { return _holidayRepository; }
        }

        #endregion


        /// <summary>
        /// Returns Holiday List by CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllHolidayDetails")]
        public ActionResult SelectAllHolidayDetails()
        {
            var holidayList = _holidayRepository.SelectAllHolidayDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            return View(holidayList);
        }


        /// <summary>
        /// AddHolidayDetail - Get Method: Returns the HolidayInsert View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddHolidayDetail")]
        public ActionResult AddHolidayDetail()
        {
            return View();
        }


        /// <summary>
        /// InsertHoliday - Post Method: Inserts New Holiday.
        /// </summary>
        /// <param name="holidayItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddHolidayDetail")]
        public ActionResult AddHolidayDetail(Holiday holidayItem)
        {

            bool success = false;

            if (ModelState.IsValid)
            {
                holidayItem.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                success = _holidayRepository.InsertHoliday(holidayItem);
            }

            if (success)
                return RedirectToAction("SelectAllHolidayDetails");
            return View();
        }


        /// <summary>
        /// EditHoliday - Get Method: Returns the EditHoliday View.
        /// </summary>
        /// <param name="HolidayId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditHolidayDetail")]
        public ActionResult EditHolidayDetail(int HolidayId)
        {
            var holidayDetail = new List<Holiday>();

            holidayDetail = _holidayRepository.SelectHolidayDetail(HolidayId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            var holidayDetailobj = new Holiday
            {
                HolidayId = holidayDetail[0].HolidayId,
                HolidayName = holidayDetail[0].HolidayName,
                HolidayDate = holidayDetail[0].HolidayDate,
                CompanyId = holidayDetail[0].CompanyId,
            };
            return View(holidayDetailobj);
        }


        /// <summary>
        /// EditHoliday - Post Method: Updates the Holiday Information.
        /// </summary>
        /// <param name="holidayItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditHolidayDetail")]
        public ActionResult EditHolidayDetail(Holiday holidayItem)
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                success = _holidayRepository.UpdateHoliday(holidayItem);
            }

            if (success)
                return RedirectToAction("SelectAllHolidayDetails");
            else
                return View();
        }



        /// <summary>
        /// DeleteHoliday - Post Method: Deletes the Holiday Information 
        /// </summary>
        /// <param name="HolidayIds"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DeleteHolidayDetail")]
        public bool DeleteHolidayDetail(string HolidayIds)
        {
            if (HolidayIds != null)
            {
                foreach (var HolidayId in HolidayIds.Split(','))
                {
                    var deleteLunchDetail =
                         _holidayRepository.DeleteHolidayDetail(Int32.Parse(HolidayId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
	}
}