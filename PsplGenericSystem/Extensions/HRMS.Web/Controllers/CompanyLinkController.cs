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
    public class CompanyLinkController : Controller
    {
        #region Class Level Variables and constructor
        private readonly ICompanyLinkRepository _companylinkRepository;
        public CompanyLinkController(ICompanyLinkRepository companylinkRepository)
        {
            _companylinkRepository = companylinkRepository;
        }
        #endregion

        /// <summary>
        /// Returns all Company Links by CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("SelectAllCompanyLink")]
        public ActionResult SelectAllCompanyLink()
        {
            List<CompanyLink> companyLinkList = _companylinkRepository.SelectAllCompanyLink(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
            return View(companyLinkList);
        }

        /// <summary>
        /// Returns employee AddCompanyLink emptry view. And also returns the record for update.
        /// </summary>
        /// <param name="companyLinkobj"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ActionName("AddCompanyLink")]
        public ActionResult AddCompanyLink()
        {
            CompanyLinkFormModel companyLinkFormModelobj = new CompanyLinkFormModel();
            if (Request.QueryString["CompanyLinkId"] != null)
            {
                var companyLinkId = Request.QueryString["CompanyLinkId"];
                companyLinkFormModelobj.CompanyLink = _companylinkRepository.SelectCompanyLinkById(Convert.ToInt32(companyLinkId)).SingleOrDefault();
            }
            return View(companyLinkFormModelobj);
        }

        /// <summary>
        /// Creates and Updates Company Link
        /// </summary>
        /// <param name="companyLinkFormModelobj"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        [Authorize]
        [ActionName("AddCompanyLink")]
        public ActionResult AddCompanyLink(CompanyLinkFormModel companyLinkFormModelobj)
        {
            if (companyLinkFormModelobj.CompanyLink.CompanyLinkId == 0)
            {
                companyLinkFormModelobj.CompanyLink.CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                companyLinkFormModelobj.CompanyLink.CreatedDate = System.DateTime.UtcNow;
                companyLinkFormModelobj.CompanyLink.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                _companylinkRepository.CreateCompanyLink(companyLinkFormModelobj.CompanyLink);
            }
            else
            {
                companyLinkFormModelobj.CompanyLink.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                companyLinkFormModelobj.CompanyLink.ModifiedDate = System.DateTime.UtcNow;
                bool success = _companylinkRepository.UpdateCompanyLink(companyLinkFormModelobj.CompanyLink);
            }
            return RedirectToAction("SelectAllCompanyLink");
        }

        /// <summary>
        /// Deletes the Company Link
        /// </summary>
        /// <param name="companyLinkId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ActionName("DeleteCompanyLink")]
        public bool DeleteCompanyLink(string companyLinkIds)
        {
            if (companyLinkIds != null)
            {
                foreach (var companyLinkId in companyLinkIds.Split(','))
                {
                    var deleteLinkDetail =
                        _companylinkRepository.DeleteCompanyLink(Convert.ToInt32(companyLinkId));
                }
            }
            return true;
        }
    }
}