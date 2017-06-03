using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;
using HRMS.Common.Helpers;
using HRMS.Web.Helper;
using HRMS.Service.Interfaces;
using HRMS.Common.Enums;
using System.Configuration;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.Controllers
{
    public class CompanyAnnouncementController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ICompanyAnnouncementRepository _companyAnnouncementRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public CompanyAnnouncementController(
            ICompanyAnnouncementRepository companyAnnouncementRepository,
            IEmployeeRepository employeeRepository
            )
        {
            _companyAnnouncementRepository = companyAnnouncementRepository;
            _employeeRepository = employeeRepository;
        }
        #endregion

        /// <summary>
        /// Returns all Company Announcements List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("SelectAllCompanyAnnouncement")]
        public ActionResult SelectAllCompanyAnnouncement()
        {
            CompanyAnnouncementFormModel companyAnnouncementFormModelObj = new CompanyAnnouncementFormModel();
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<CompanyAnnouncement> companyAnnouncementList = _companyAnnouncementRepository.SelectAllCompanyAnnouncementByCompanyId(companyId).ToList();
            return View(companyAnnouncementList);
        }

        /// <summary>
        /// Returns the Empty view for Insert as well returns the selected Company Announcement
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("AddCompanyAnnouncement")]
        public ActionResult AddCompanyAnnouncement()
        {
            CompanyAnnouncementFormModel companyAnnouncementFormModelObj = new CompanyAnnouncementFormModel();
            if (Request.QueryString["CompanyAnnouncementId"] != null)
            {
                var companyAnnouncementId = Request.QueryString["CompanyAnnouncementId"];
                companyAnnouncementFormModelObj.CompanyAnnouncement = _companyAnnouncementRepository.SelectCompanyAnnouncementById(Convert.ToInt32(companyAnnouncementId)).SingleOrDefault();
            }
            return View(companyAnnouncementFormModelObj);
        }

        /// <summary>
        /// Inserts and Updates the Company Announcement
        /// </summary>
        /// <param name="companyAnnouncementFormModelObj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        [ActionName("AddCompanyAnnouncement")]
        public ActionResult AddCompanyAnnouncement(CompanyAnnouncementFormModel companyAnnouncementFormModelObj)
        {
            if (companyAnnouncementFormModelObj.CompanyAnnouncement.CompanyAnnouncementId == 0)
            {
                companyAnnouncementFormModelObj.CompanyAnnouncement.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                companyAnnouncementFormModelObj.CompanyAnnouncement.CreatedDate = System.DateTime.UtcNow;
                companyAnnouncementFormModelObj.CompanyAnnouncement.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                _companyAnnouncementRepository.CreateCompanyAnnouncement(companyAnnouncementFormModelObj.CompanyAnnouncement);
            }
            else
            {
                companyAnnouncementFormModelObj.CompanyAnnouncement.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                companyAnnouncementFormModelObj.CompanyAnnouncement.ModifiedDate = System.DateTime.UtcNow;
                bool success = _companyAnnouncementRepository.UpdateCompanyAnnouncement(companyAnnouncementFormModelObj.CompanyAnnouncement);
            }
            return RedirectToAction("SelectAllCompanyAnnouncement");
        }


        /// <summary>
        /// Deletes the selected Company Announcements
        /// </summary>
        /// <param name="companyAnnouncementIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ActionName("DeleteCompanyAnnouncement")]
        public bool DeleteCompanyAnnouncement(string companyAnnouncementIds)
        {
            if (companyAnnouncementIds != null)
            {
                foreach (var companyAnnouncementId in companyAnnouncementIds.Split(','))
                {
                    var deleteCompanyAnnouncementDetail =
                        _companyAnnouncementRepository.DeleteCompanyAnnouncement(Convert.ToInt32(companyAnnouncementId));
                }
            }
            return true;
        }

        #region Application Header
        /// <summary>
        /// Returns all Company Announcements List for Application Header Quick List in JSON format.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("SelectAllQuickCompanyAnnouncement")]
        public JsonResult SelectAllQuickCompanyAnnouncement()
        {
            CompanyAnnouncementFormModel companyAnnouncementFormModelObj = new CompanyAnnouncementFormModel();
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<CompanyAnnouncement> companyQuickAnnouncementList = _companyAnnouncementRepository.SelectAllCompanyAnnouncementByCompanyId(companyId).ToList();
            return Json(companyQuickAnnouncementList, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Returns the Company Announcement Information in JSON format.
        /// </summary>
        /// <param name="companyAnnouncementId"></param>
        
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("SelectQuickCompanyAnnouncement")]
        public JsonResult SelectQuickCompanyAnnouncement(int companyAnnouncementId)
        {
            CompanyAnnouncementFormModel companyAnnouncementFormModelObj = new CompanyAnnouncementFormModel();
            List<CompanyAnnouncement> companyQuickAnnouncementList = _companyAnnouncementRepository.SelectCompanyAnnouncementById(Convert.ToInt32(companyAnnouncementId)).ToList();
            return Json(companyQuickAnnouncementList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpGet]
        [Authorize]
        [ActionName("IsTitleExists")]
        public JsonResult IsTitleExists(CompanyAnnouncementFormModel companyAnnouncementFormModelObj)
        {
            companyAnnouncementFormModelObj.CompanyAnnouncement.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _companyAnnouncementRepository.IsTitleExists(companyAnnouncementFormModelObj.CompanyAnnouncement);
            if (companyAnnouncementFormModelObj.CompanyAnnouncement.CompanyId.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}