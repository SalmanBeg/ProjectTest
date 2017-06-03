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
    public class ScheduleGroupController : Controller
    {
        #region Class Level Variables and constructor

        private readonly IScheduleGroupRepository _iScheduleGroupRepository;
        private readonly IScheduleEmployeeRepository _iScheduleEmployeeRepository;
        public ScheduleGroupController(
            IScheduleGroupRepository iScheduleGroupRepository,
            IScheduleEmployeeRepository iScheduleEmployeeRepository
            )
        {
            _iScheduleGroupRepository = iScheduleGroupRepository;
            _iScheduleEmployeeRepository = iScheduleEmployeeRepository;
        }

        protected IScheduleGroupRepository ScheduleGroupRepository
        {
            get { return _iScheduleGroupRepository; }
        }

        protected IScheduleEmployeeRepository ScheduleEmployeeRepository
        {
            get { return _iScheduleEmployeeRepository; }
        }
        #endregion

        #region Schedule Groups
        /// <summary>
        /// Returns ScheduleGroups List by CompanyId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("SelectAllScheduleGroupDetails")]
        public ActionResult SelectAllScheduleGroupDetails()
        {
            var scheduleGroupLsit = _iScheduleGroupRepository.SelectAllScheduleGroupDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return View(scheduleGroupLsit);
        }

        /// <summary>
        /// AddScheduleGroupDetail - Get Method: Returns the AddScheduleGroupDetail View.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddScheduleGroupDetail")]
        public ActionResult AddScheduleGroupDetail()
        {
            return View();
        }
        
        /// <summary>
        /// AddScheduleGroupDetail - Post Method: Inserts New ScheduleGroup.
        /// </summary>
        /// <param name="scheduleGroupInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddScheduleGroupDetail")]
        public ActionResult AddScheduleGroupDetail(ScheduleGroup scheduleGroupInfoobj)
        {
            bool success = false;
            //Guid ScheduleGroupCode = Guid.NewGuid();
            //scheduleGroupInfoobj.ScheduleGroupCode = ScheduleGroupCode;
            scheduleGroupInfoobj.ScheduleGroupName = scheduleGroupInfoobj.ScheduleGroupName;
            scheduleGroupInfoobj.Description = scheduleGroupInfoobj.Description;
            scheduleGroupInfoobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            success = _iScheduleGroupRepository.InsertSheduleGroup(scheduleGroupInfoobj);

            if (success)
                return RedirectToAction("SelectAllScheduleGroupDetails");
            return View();
        }
        
        /// <summary>
        /// EditScheduleGroupDetail - Get Method: Returns the EditScheduleGroupDetail View.
        /// </summary>
        /// <param name="LunchId"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("EditScheduleGroupDetail")]
        public ActionResult EditScheduleGroupDetail(int ScheduleGroupId)
        {
            var scheduleGroupDetail = new List<ScheduleGroup>();
            scheduleGroupDetail = _iScheduleGroupRepository.SelectScheduleGroupDetailsByScheduleGroupId(ScheduleGroupId, Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var scheduleGroupDetailobj = new ScheduleGroup
            {
                ScheduleGroupId = scheduleGroupDetail[0].ScheduleGroupId,
                ScheduleGroupName = scheduleGroupDetail[0].ScheduleGroupName,
                Description = scheduleGroupDetail[0].Description,
                CompanyId = scheduleGroupDetail[0].CompanyId,
            };
            return View(scheduleGroupDetailobj);
        }
        
        /// <summary>
        /// EditScheduleGroupDetail - Post Method: Updates the ScheduleGroup Information.
        /// </summary>
        /// <param name="lunchItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EditScheduleGroupDetail")]
        public ActionResult EditScheduleGroupDetail(ScheduleGroup scheduleGroupInfoobj)
        {
            scheduleGroupInfoobj.ScheduleGroupId = scheduleGroupInfoobj.ScheduleGroupId;
            scheduleGroupInfoobj.ScheduleGroupName = scheduleGroupInfoobj.ScheduleGroupName;
            scheduleGroupInfoobj.Description = scheduleGroupInfoobj.Description;
            scheduleGroupInfoobj.CompanyId = scheduleGroupInfoobj.CompanyId;
            bool success = _iScheduleGroupRepository.UpdateScheduleGroup(scheduleGroupInfoobj);

            if (success)
                return RedirectToAction("SelectAllScheduleGroupDetails");
            else
                return View();
        }

        /// <summary>
        /// DeleteScheduleGroupDetail - Get Method: Deletes the ScheduleGroup Information from SelectAllScheduleGroupDetails View.
        /// </summary>
        /// <param name="lunchId"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DeleteScheduleGroupDetail")]
        public bool DeleteScheduleGroupDetail(string ScheduleGroupIds)
        {
            if (ScheduleGroupIds != null)
            {
                foreach (var ScheduleGroupId in ScheduleGroupIds.Split(','))
                {
                    var deleteScheduleGroupDetail =
                         _iScheduleGroupRepository.DeleteScheduleGroupDetail(Int32.Parse(ScheduleGroupId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }
        #endregion
	}
}