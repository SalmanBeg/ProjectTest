using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Web.Helper;
using HRMS.Web.ViewModels;

namespace HRMS.Web.Controllers
{
    public class ReviewFormController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IReviewFormRepository _reviewFormRepository;
        private readonly IReviewCriteriaRepository _reviewCriteriaRepository;
        private readonly IUtilityRepository _utilityRepository;
        public ReviewFormController(IReviewFormRepository reviewFormRepository, IUtilityRepository utilityRepository, IReviewCriteriaRepository reviewCriteriaRepository)
        {
            _reviewFormRepository = reviewFormRepository;
            _utilityRepository = utilityRepository;
            _reviewCriteriaRepository = reviewCriteriaRepository;
        }
        #endregion
        /// <summary>
        /// View to show review form to add a new record
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult ReviewForm(int reviewId)
        {                       
            var lstlookup = new List<LookUpDataEntity>();
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var scoreId=1;
    
            var ReviewerId = 42;
            ReviewFormFormModel reviewFormFormModelobj = new ReviewFormFormModel();
            List<ReviewerEmployee> addReviewForm = _reviewFormRepository.GetReviewFormDetails(Convert.ToInt32(GlobalsVariables.CurrentCompanyId), reviewId, ReviewerId);
            reviewFormFormModelobj.ReviewerEmployee = addReviewForm.SingleOrDefault();
            reviewFormFormModelobj.lstReviewCriteria = _reviewCriteriaRepository.SelectAllRevieewCriteria(companyId);
            List<RevieewCriteria> addResponseType = _reviewFormRepository.GetReviewCriteriaQuestions(companyId, reviewId, ReviewerId).ToList();
            reviewFormFormModelobj.ReviewScoreContentList = _reviewFormRepository.GetReviewScoreContent(scoreId).ToList();          
            return View(reviewFormFormModelobj);
        }
        /// <summary>
        /// View to show review form to add a new record
        /// </summary>
        /// <param name="reviewFormFormModelobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult ReviewForm(ReviewFormFormModel reviewFormFormModelobj)
        {
            int scoreId=1;
            reviewFormFormModelobj.ReviewerEmployee.UserId = Convert.ToInt32(GlobalsVariables.SelectedUserId);
            reviewFormFormModelobj.ReviewerEmployee.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            reviewFormFormModelobj.ReviewScoreContentList = _reviewFormRepository.GetReviewScoreContent(scoreId).ToList();
            reviewFormFormModelobj.ReviewerEmployee.HRComments = _reviewFormRepository.UpdateHRCommentsAndStatus(reviewFormFormModelobj.ReviewerEmployee).ToString();
            reviewFormFormModelobj.ReviewerEmployee.ReviewerComments = _reviewFormRepository.UpdateReviewReviewerEmployee(reviewFormFormModelobj.ReviewerEmployee).ToString();          
            return View(reviewFormFormModelobj);

        }
    }
}