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
    public class HolidayGroupController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IHolidayRepository _holidayRepository;
        private readonly IHolidayGroupRepository _holidayGroupRepository;
        private readonly IHolidayMasterRepository _holidayMasterRepository;
        private readonly IPayTypeRepository _payTypeRepository;

        public HolidayGroupController(IHolidayGroupRepository holidayGroupRepository, IHolidayMasterRepository holidayMasterRepository,
                                      IHolidayRepository holidayRepository, IPayTypeRepository payTypeRepository)
        {
            _holidayGroupRepository = holidayGroupRepository;
            _holidayMasterRepository = holidayMasterRepository;
            _payTypeRepository = payTypeRepository;
            _holidayRepository = holidayRepository;
        }

        protected IHolidayGroupRepository HolidayGroupRepository
        {
            get { return _holidayGroupRepository; }
        }
        protected IHolidayMasterRepository HolidayMasterRepository
        {
            get { return _holidayMasterRepository; }
        }

        protected IPayTypeRepository PayTypeRepository
        {
            get { return _payTypeRepository; }
        }

        protected IHolidayRepository HolidayRepository
        {
            get { return _holidayRepository; }
        }

        #endregion


        /// <summary>
        /// Returns HolidayGroup List by CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllHolidayGroupDetails")]
        public ActionResult SelectAllHolidayGroupDetails()
        {
            var holidayGroupList = _holidayGroupRepository.SelectAllHolidayGroupDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            return View(holidayGroupList);
        }


        /// <summary>
        /// AddHolidayGroupDetail - Get Method: Returns the AddHolidayGroup View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddHolidayGroupDetail")]
        public ActionResult AddHolidayGroupDetail()
        {
            HolidayGroupFormModel holidayGroupFormModel = new HolidayGroupFormModel();

            var holidayList = _holidayRepository.SelectAllHolidayDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            holidayGroupFormModel.HolidayList = holidayList;

            return View(holidayGroupFormModel);
        }
        

        /// <summary>
        /// InsertHolidayGroup - Post Method: Inserts New HolidayGroup.
        /// </summary>
        /// <param name="holidayGroupItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddHolidayGroupDetail")]
        public ActionResult AddHolidayGroupDetail(HolidayGroup holidayGroupItem)
        {

            bool success = false;

            if (ModelState.IsValid)
            {
                holidayGroupItem.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                success = _holidayGroupRepository.InsertHolidayGroup(holidayGroupItem);
            }

            if (success)
                return RedirectToAction("SelectAllHolidayGroupDetails");
            return View();
        }
        

        [HttpGet]
        [ActionName("EditHolidayMasterDetail")]
        public ActionResult EditHolidayMasterDetail(int HolidayGroupId, string HolidayGroupName)
        {
            HolidayMasterFromModel holidayMasterFormModelObj = new HolidayMasterFromModel();
            List<PayType> paytypelist = new List<PayType>();
            paytypelist = _payTypeRepository.SelectAllPayTypeDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var holidaymasterList = new List<HolidayMaster>();
            holidaymasterList = _holidayMasterRepository.SelectAllHolidayMasterDetails(HolidayGroupId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            // Storing Holiday Group Name to display in view
            holidaymasterList[0].HolidayGroupName = HolidayGroupName;

            for (int i = 0; i < holidaymasterList.Count; i++)
            {
                holidaymasterList[i].HolidayGroupId = HolidayGroupId;

                // Binding Dropdown from BankFromAccount (While Post, Taking Dropdown values from bankToAccount)
                holidaymasterList[i].BankFromAccount = holidaymasterList[i].BankToAccount;

                // (Based on holidayMasterId we can know whether holiday is asigned or not to Holidaygroup)
                if (holidaymasterList[i].HolidayMasterId != 0)
                    holidaymasterList[i].HolidayChecked = true;
            }
            holidayMasterFormModelObj.PayTypeList = paytypelist;
            holidayMasterFormModelObj.HolidayMasterList = holidaymasterList;

            return View(holidayMasterFormModelObj);
        }

        [HttpPost]
        [ActionName("EditHolidayMasterDetail")]
        public ActionResult EditHolidayMasterDetail(IList<HolidayMaster> holidaymasterobj)
        {
            bool success = false;
            foreach (HolidayMaster item in holidaymasterobj)
            {
                if (item.HolidayMasterId == 0 && item.HolidayChecked == true)
                {
                    item.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                    success = _holidayMasterRepository.InsertHolidayMaster(item);
                }
                else if (item.HolidayMasterId != 0 && item.HolidayChecked == true)
                {
                    success = _holidayMasterRepository.UpdateHolidayMaster(item);
                }
                else if (item.HolidayMasterId != 0 && item.HolidayChecked == false)
                {
                    success = _holidayMasterRepository.DeleteHolidayMasterDetail(item.HolidayMasterId, item.CompanyId);
                }
            }
            //if(success)
            return RedirectToAction("SelectAllHolidayGroupDetails");
            //return View();
        }


        /// <summary>
        /// EditHolidayGroup - Get Method: Returns the EditHolidayGroup View.
        /// </summary>
        /// <param name="HolidayGroupId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditHolidayGroupDetail")]
        public ActionResult EditHolidayGroupDetail(int HolidayGroupId)
        {
            var holidayGroupDetail = new List<HolidayGroup>();

            holidayGroupDetail = _holidayGroupRepository.SelectHolidayGroupDetail(HolidayGroupId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));

            var holidayGroupobj = new HolidayGroup
            {
                HolidayGroupId = holidayGroupDetail[0].HolidayGroupId,
                HolidayGroupCode = holidayGroupDetail[0].HolidayGroupCode,
                HolidayGroupName = holidayGroupDetail[0].HolidayGroupName,
                HolidayDescription = holidayGroupDetail[0].HolidayDescription,
                CompanyId = holidayGroupDetail[0].CompanyId,
            };
            return View(holidayGroupobj);
        }


        /// <summary>
        /// EditHolidayGroupDetail - Post Method: Updates the Holiday Information.
        /// </summary>
        /// <param name="holidayItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditHolidayGroupDetail")]
        public ActionResult EditHolidayGroupDetail(HolidayGroup holidayGroupItem)
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                success = _holidayGroupRepository.UpdateHolidayGroup(holidayGroupItem);
            }

            if (success)
                return RedirectToAction("SelectAllHolidayGroupDetails");
            else
                return View();
        }
        

        /// <summary>
        /// DeleteHolidayGroup - Post Method: Deletes the HolidayGroup Information 
        /// </summary>
        /// <param name="HolidayGroupIds"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DeleteHolidayGroupDetail")]
        public bool DeleteHolidayGroupDetail(string HolidayGroupIds)
        {
            if (HolidayGroupIds != null)
            {
                foreach (var HolidayGroupId in HolidayGroupIds.Split(','))
                {
                    var deleteholidayGroup =
                         _holidayGroupRepository.DeleteHolidayGroupDetail(Int32.Parse(HolidayGroupId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
	}
}