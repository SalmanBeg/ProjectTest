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
    public class LunchController : Controller
    {
        #region Class Level Variables and constructor

        private readonly ILunchRepository _lunchRepository;

        public LunchController(ILunchRepository lunchRepository)
        {
            _lunchRepository = lunchRepository;
        }

        protected ILunchRepository LunchRepository
        {
            get { return _lunchRepository; }
        }

        #endregion

        /// <summary>
        /// Returns Lunch List by CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllLunchDetails")]
        public ActionResult SelectAllLunchDetails()
        {
            var lunchList = _lunchRepository.SelectAllLunchDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            for (int i = 0; i < lunchList.Count; i++)
            {
                lunchList[i].MinimumWorkTime = lunchList[i].MinimumWorkTime / 60;
                lunchList[i].LunchMinutes = lunchList[i].LunchMinutes;
            }
            return View(lunchList);
        }


        /// <summary>
        /// AddLunchDetail - Get Method: Returns the LunchInsert View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddLunchDetail")]
        public ActionResult AddLunchDetail()
        {
            return View();
        }


        /// <summary>
        /// InsertLunch - Post Method: Inserts New Lunch.
        /// </summary>
        /// <param name="lunchItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddLunchDetail")]
        public ActionResult AddLunchDetail(Lunch lunchItem)
        {
            bool success = false;

            Guid LunchCode = Guid.NewGuid();
            lunchItem.LunchCode = LunchCode;
            lunchItem.MinimumWorkTime = lunchItem.MinimumWorkTime * 60;
            lunchItem.LunchMinutes = lunchItem.LunchMinutes;
            lunchItem.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            success = _lunchRepository.InsertLunch(lunchItem);

            if (success)
                return RedirectToAction("SelectAllLunchDetails");
            return View();
        }


        /// <summary>
        /// EditLunch - Get Method: Returns the EditLunch View.
        /// </summary>
        /// <param name="LunchId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditLunchDetail")]
        public ActionResult EditLunchDetail(int LunchId)
        {
            //int decrytedlunchId = Convert.ToInt32(Encryption.Decrypt(LunchId));
            var lunchDetailObj = new Lunch();

            lunchDetailObj = _lunchRepository.SelectLunchDetailsByLunchId(LunchId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            lunchDetailObj.MinimumWorkTime = lunchDetailObj.MinimumWorkTime / 60;

            return View(lunchDetailObj);
        }


        /// <summary>
        /// EditLunch - Post Method: Updates the Lunch Information.
        /// </summary>
        /// <param name="lunchItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditLunchDetail")]
        public ActionResult EditLunchDetail(Lunch lunchItem)
        {
            lunchItem.MinimumWorkTime = lunchItem.MinimumWorkTime * 60;
            lunchItem.LunchMinutes = lunchItem.LunchMinutes;

            bool success = _lunchRepository.UpdateLunch(lunchItem);

            if (success)
                return RedirectToAction("SelectAllLunchDetails");
            else
                return View();
        }



        /// <summary>
        /// DeleteLunch - Get Method: Deletes the Lunch Information from TimeRulesIndex View.
        /// </summary>
        /// <param name="lunchId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DeleteLunchDetail")]
        public bool DeleteLunchDetail(string LunchIds)
        {

            if (LunchIds != null)
            {
                foreach (var LunchId in LunchIds.Split(','))
                {
                    var deleteLunchDetail =
                         _lunchRepository.DeleteLunchDetail(Int32.Parse(LunchId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }

	}
}