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
using System.Data;

namespace HRMS.Web.Controllers
{
    public class ReviewCriteriaController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly IReviewCriteriaRepository _reviewCriteriaRepository;
        public ReviewCriteriaController(IUtilityRepository utilityRepository, IReviewCriteriaRepository reviewCriteriaRepository)
        {
            _utilityRepository = utilityRepository;
            _reviewCriteriaRepository = reviewCriteriaRepository;
        }
        #endregion
        [HttpGet]
        public ActionResult AddReviewCriteria()
        {


            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var reviewCriteriaFormModelobj = new ReviewCriteriaFormModel();
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            reviewCriteriaFormModelobj.JobTitleList = lstlookup.Where(j => j.TableName == "Utility.JobCategory").ToList();
            reviewCriteriaFormModelobj.JobTitleList.Insert(0, lookUpDataEntityobj);
            reviewCriteriaFormModelobj.CategoryList = _reviewCriteriaRepository.GetReviewCriteriaTypes(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
          //  reviewCriteriaFormModelobj.CategoryList.Insert(0, lookUpDataEntityobj);
            //reviewCriteriaFormModelobj.DescriptionList = lstlookup.Where(j => j.TableName == "Utility.Description").ToList();
            reviewCriteriaFormModelobj.ItemValueList = _reviewCriteriaRepository.GetReviewScores(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
            return View(reviewCriteriaFormModelobj);
        }
        [HttpPost]
        public ActionResult AddReviewCriteria(ReviewCriteriaFormModel reviewCriteriaFormModelobj, FormCollection f)
        {
            //ModelState.Remove("CategoryType");
            string s = f["ResponseTypeId"];
            int respId = 0;

            switch (s)
            {
                case "List":
                    respId = 1;

                    break;
                case "Text":
                    respId = 2;
                    break;
                default:
                    respId = 3;
                    break;
            }
            reviewCriteriaFormModelobj.ReviewCriteria.ResponseTypeId = respId;
            // ViewData["drpReviews"] = respId;
            reviewCriteriaFormModelobj.ReviewCriteria.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var lookUpDataEntityobj = new LookUpDataEntity { Name = LocalizedStrings.AddNew, Id = 0 };
            if (lstlookup == null)
            {
                throw new ArgumentNullException("lstlookup");
            }
            bool success = _reviewCriteriaRepository.AddRevieewCriteria(reviewCriteriaFormModelobj.ReviewCriteria);
            reviewCriteriaFormModelobj.JobTitleList = lstlookup.Where(j => j.TableName == "Utility.JobCategory").ToList();
            reviewCriteriaFormModelobj.JobTitleList.Insert(0, lookUpDataEntityobj);
            reviewCriteriaFormModelobj.CategoryList = _reviewCriteriaRepository.GetReviewCriteriaTypes(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
            
            reviewCriteriaFormModelobj.ItemValueList = _reviewCriteriaRepository.GetReviewScores(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
            if (success)
            {
                ModelState.AddModelError("", "Revieew Criteria Created Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Revieew Criteria cannot be created, Please try again.");
            }

            return RedirectToAction("SelectAllReviewCriteria");
        }
        public ActionResult SelectAllReviewCriteria()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<RevieewCriteria> revieewCriteriaList = _reviewCriteriaRepository.SelectAllRevieewCriteria(companyId);
            return View(revieewCriteriaList);
        }
        public ActionResult SelectReviewerCriteria(int ReviewId, int ReviewMasterId)
        {
            ViewData["ReviewId"] = ReviewId;
            ViewData["ReviewMasterId"] = ReviewMasterId;
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            string strCriteriaIds = _reviewCriteriaRepository.GetReviewCriteriaId(companyId, ReviewId, ReviewMasterId);
            List<RevieewCriteria> revieewCriteriaList;
            if (strCriteriaIds != string.Empty)
            {
                  revieewCriteriaList = _reviewCriteriaRepository.SelectAllRevieewCriteriaById(companyId, strCriteriaIds);
            }
            else
            {
                revieewCriteriaList = _reviewCriteriaRepository.SelectAllRevieewCriteria(companyId);
            }
            return View(revieewCriteriaList);
        }

        [HttpPost]
        public bool SaveReviewReviewerCriteria(string reviewCriteriaIds, int ReviewId, int ReviewMasterId)
        {
            int CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            int CreatedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);

            if (reviewCriteriaIds != null)
            {
                DataTable dtReviewCriteria = new DataTable();
                dtReviewCriteria.Columns.Add("ReviewCriteriaId", typeof(int));


                DataTable dtOtherEmployees = new DataTable();
                dtOtherEmployees.Columns.Add("OtherEmployeeId", typeof(int));

                if (ReviewMasterId == 1)
                {
                    foreach (var reviewCriteriaId in reviewCriteriaIds.Split(','))
                    {
                        DataRow row = dtReviewCriteria.NewRow();
                        row["ReviewCriteriaId"] = reviewCriteriaId;
                        dtReviewCriteria.Rows.Add(row);
                        dtReviewCriteria.AcceptChanges();
                    }
                }

                else if (ReviewMasterId == 2)
                {
                    foreach (var reviewCriteriaId in reviewCriteriaIds.Split(','))
                    {
                        DataRow row = dtReviewCriteria.NewRow();
                        row["ReviewCriteriaId"] = reviewCriteriaId;
                        dtReviewCriteria.Rows.Add(row);
                        dtReviewCriteria.AcceptChanges();
                    }
                }
                else if (ReviewMasterId == 3)
                {
                    foreach (var reviewCriteriaId in reviewCriteriaIds.Split(','))
                    {
                        DataRow row = dtOtherEmployees.NewRow();
                        row["OtherEmployeeId"] = reviewCriteriaId;

                        dtOtherEmployees.Rows.Add(row);
                        dtOtherEmployees.AcceptChanges();
                    }
                }

                bool IsStatus = _reviewCriteriaRepository.AddReviewReviewerCriteria(CompanyId, ReviewId, ReviewMasterId, CreatedBy, dtReviewCriteria, dtOtherEmployees);
            }
            return true;

        }

        [HttpGet]
        public ActionResult UpdateReviewCriteria()
        {
            var reviewCriteriaFormModelobj = new ReviewCriteriaFormModel();
            var id = Request.QueryString["ReviewCriteriaId"];
            List<LookUpDataEntity> lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            reviewCriteriaFormModelobj.ReviewCriteria = _reviewCriteriaRepository.SelectReviewCriteriaId(Convert.ToInt32(id), Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).FirstOrDefault();
            reviewCriteriaFormModelobj.JobTitleList = lstlookup.Where(j => j.TableName == "Utility.JobCategory").ToList();
            reviewCriteriaFormModelobj.CategoryList = _reviewCriteriaRepository.GetReviewCriteriaTypes(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
            reviewCriteriaFormModelobj.ItemValueList = _reviewCriteriaRepository.GetReviewScores(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
            return View(reviewCriteriaFormModelobj);
        }
        [HttpPost]
        public ActionResult UpdateReviewCriteria(ReviewCriteriaFormModel revieewCriteriaobj, FormCollection f)
        {
            string s = f["ResponseTypeId"];
            int respId = 0;
            switch (s)
            {
                case "List":
                    respId = 1;
                    break;
                case "Text":
                    respId = 2;
                    break;
                default:
                    respId = 3;
                    break;
            }
            int intCompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            revieewCriteriaobj.ReviewCriteria.CompanyId = intCompanyId;
            revieewCriteriaobj.ReviewCriteria.ResponseTypeId = respId;
            revieewCriteriaobj.ItemValueList = _reviewCriteriaRepository.GetReviewScores(Convert.ToInt32(GlobalsVariables.CurrentCompanyId)).ToList();
            bool success = _reviewCriteriaRepository.UpdateRevieewCriteria(revieewCriteriaobj.ReviewCriteria);
            if (success)
            {
                ModelState.AddModelError("", "Review Criteria Updated Successfully.");
            }
            else
            {
                ModelState.AddModelError("", "Review Criteria cannot be updated, Please try again.");
            }
            return RedirectToAction("SelectAllReviewCriteria");
        }
        public bool DeleteReviewCriteria(string reviewCriteriaIds)
        {
            if (reviewCriteriaIds != null)
            {
                foreach (var reviewCriteriaId in reviewCriteriaIds.Split(','))
                {
                    var deleteRevieewCriteria =
                        _reviewCriteriaRepository.DeleteRevieewCriteria(Int32.Parse(reviewCriteriaId), Int32.Parse(GlobalsVariables.CurrentCompanyId));
                }
            }
            return true;
        }

        [HttpPost]
        public ActionResult UpdateReviewHR(ReviewFormFormModel reviewFormFormModelobj)
        {
            bool success = _reviewCriteriaRepository.UpdateReviewForHR(reviewFormFormModelobj.Review);
            if (success)
            {
                ModelState.AddModelError("", "Updated Review HR Details");
            }
            else
            {
                ModelState.AddModelError("", "can not Updated Review HR Details");
            }
            return RedirectToAction("ReviewReviewer");
        }
    }
}