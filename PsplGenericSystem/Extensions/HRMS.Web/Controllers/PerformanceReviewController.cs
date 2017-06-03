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
using HRMS.Service.Repositories;
//using HRMS.Service.Models.ExtendedModels;

namespace HRMS.Web.Controllers
{
    public class PerformanceReviewController : Controller
    {

        #region Class Level Variables and constructor
        private readonly IPerformanceReviewsRepository _performancereviewRepository;
        private readonly IReviewCriteriaRepository _reviewCriteriaRepository;
        private readonly IUtilityRepository _utilityRepository = null;
        private readonly IJobProfileRepository _jobProfileRepository = null;
        private readonly IRegisteredUsersRepository _registeredUsersRepository = null;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMasterRepository _masterRepository;
        public PerformanceReviewController(IPerformanceReviewsRepository performanceReviewsRepository, IReviewCriteriaRepository reviewCriteriaRepository, IUtilityRepository utilityRepository,
            IJobProfileRepository jobProfileRepository, IRegisteredUsersRepository registeredUsersRepository, IEmployeeRepository employeeRepository, IMasterRepository masterRepository)
        {
            this._performancereviewRepository = performanceReviewsRepository;
            this._utilityRepository = utilityRepository;
            this._jobProfileRepository = jobProfileRepository;
            this._registeredUsersRepository = registeredUsersRepository;
            this._reviewCriteriaRepository = reviewCriteriaRepository;
            this._employeeRepository = employeeRepository;
            _masterRepository = masterRepository;
        }
        #endregion


        /// <summary>
        /// View to show all the performace reviews in a company
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult SelectReviewAll()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var performancereviewList = _performancereviewRepository.SelectReviewAll(companyId);
            return View(performancereviewList);
        }
        /// <summary>
        /// View to add a new review in a company
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("AddReview")]
        [Authorize]
        public ActionResult AddReview()
        {
            var li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "Department", Value = "1" });
            li.Add(new SelectListItem { Text = "Position", Value = "2" });
            li.Add(new SelectListItem { Text = "Job Title", Value = "3", Disabled = false });
            li.Add(new SelectListItem { Text = "Employee", Value = "4" });
            ViewData["drpReviews"] = li;


            var lstIntervalType = new List<SelectListItem>();
            lstIntervalType.Add(new SelectListItem { Text = "--Select--", Value = "-1" });
            lstIntervalType.Add(new SelectListItem { Text = "Days", Value = "1" });
            lstIntervalType.Add(new SelectListItem { Text = "Weeks", Value = "2" });
            lstIntervalType.Add(new SelectListItem { Text = "Months", Value = "3" });
            ViewData["drpIntervalType"] = lstIntervalType;

            var lstDateType = new List<SelectListItem>();
            lstDateType.Add(new SelectListItem { Text = "--Select--", Value = "-1" });
            lstDateType.Add(new SelectListItem { Text = "Hire Date", Value = "1" });
            lstDateType.Add(new SelectListItem { Text = "Custom Date", Value = "2" });
            ViewData["drpDateType"] = lstDateType;

            return View();
        }
        /// <summary>
        /// View to add a new review in a company
        /// </summary>
        /// <param name="performanceReviewobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddReview(PerformanceReview performanceReviewobj)
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            performanceReviewobj.CompanyId = companyId;
            int intRevieweeType = Convert.ToInt32(performanceReviewobj.RevieweeType);

            if (performanceReviewobj.FromSchedule == null)
            {
                performanceReviewobj.FromSchedule = performanceReviewobj.DateType.ToString();
            }

            if (performanceReviewobj.DateType.ToString() == "1")
            {
                performanceReviewobj.FromDate = System.DateTime.Now;
            }
            else if (performanceReviewobj.DateType.ToString() == "2")
            {
                performanceReviewobj.FromDate = Convert.ToDateTime(performanceReviewobj.CustomDate);
            }

            if (performanceReviewobj.Status == null)
            {
                performanceReviewobj.Status = "0";
            }
            if (intRevieweeType == 1)
            {
                performanceReviewobj.Type = performanceReviewobj.RevieweeType.ToString();
                performanceReviewobj.DepartmentId = Convert.ToInt32(performanceReviewobj.DepartmentId);
                performanceReviewobj.PositionId = 0;
                performanceReviewobj.JobTitleId = 0;
                performanceReviewobj.EmployeeId = 0;
            }
            else if (intRevieweeType == 2)
            {
                performanceReviewobj.Type = performanceReviewobj.RevieweeType.ToString();
                performanceReviewobj.PositionId = Convert.ToInt32(performanceReviewobj.DepartmentId);
                performanceReviewobj.DepartmentId = 0;
                performanceReviewobj.JobTitleId = 0;
                performanceReviewobj.EmployeeId = 0;
            }
            else if (intRevieweeType == 3)
            {
                performanceReviewobj.Type = performanceReviewobj.RevieweeType.ToString();
                performanceReviewobj.JobTitleId = Convert.ToInt32(performanceReviewobj.DepartmentId);
                performanceReviewobj.PositionId = 0;
                performanceReviewobj.DepartmentId = 0;
                performanceReviewobj.EmployeeId = 0;
            }
            else if (intRevieweeType == 4)
            {
                performanceReviewobj.Type = performanceReviewobj.RevieweeType.ToString();
                performanceReviewobj.EmployeeId = Convert.ToInt32(performanceReviewobj.DepartmentId);
                performanceReviewobj.DepartmentId = 0;
                performanceReviewobj.PositionId = 0;
                performanceReviewobj.JobTitleId = 0;

            }
            var success = _performancereviewRepository.AddReview(performanceReviewobj);
            return RedirectToAction("SelectReviewAll");
        }
        /// <summary>
        /// Method to bind the filter critieria in performance review
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        public JsonResult BindReviewFilter(string id)
        {
            var lstlookup = new List<LookUpDataEntity>();
            lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var performanceReviewlobj = new PerformanceReview();
            var filterList = new List<SelectListItem>();

            try
            {
                switch (id)
                {
                    case "1":

                        performanceReviewlobj.DepartmentList = lstlookup.Where(j => j.TableName == "Utility.Department").ToList();
                        filterList = performanceReviewlobj.DepartmentList.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }).ToList();
                        break;

                    case "2":

                        List<JobProfile> lstJobProfile = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                        filterList = lstJobProfile.Select(c => new SelectListItem { Text = c.Title, Value = c.JobProfileId.ToString() }).ToList();
                        break;
                    case "3":

                        List<JobProfile> lstJobProfile1 = _jobProfileRepository.SelectJobProfile(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                        filterList = lstJobProfile1.Select(c => new SelectListItem { Text = c.Title, Value = c.JobProfileId.ToString() }).ToList();
                        break;

                    case "4":
                        List<UserLoginModel> lstEmployee = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                        filterList = lstEmployee.Select(c => new SelectListItem { Text = (c.FirstName + " " + c.LastName), Value = c.UserId.ToString() }).ToList();
                        break;

                }
            }
            catch (Exception)
            {
                throw;
            }

            return Json(new SelectList(filterList, "Value", "Text"));
        }
        /// <summary>
        /// View to edit existing performance review record based on record id
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult EditReview(int reviewId)
        {

            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var performanceReviewobj = _performancereviewRepository.SelectReviewById(reviewId, companyId);

            var li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "Department", Value = "1" });
            li.Add(new SelectListItem { Text = "Position", Value = "2" });
            li.Add(new SelectListItem { Text = "Job Title", Value = "3", Disabled = false });
            li.Add(new SelectListItem { Text = "Employee", Value = "4" });
            ViewData["drpReviews"] = li;




            var lstIntervalType = new List<SelectListItem>();
            lstIntervalType.Add(new SelectListItem { Text = "--Select--", Value = "-1" });
            lstIntervalType.Add(new SelectListItem { Text = "Days", Value = "1" });
            lstIntervalType.Add(new SelectListItem { Text = "Weeks", Value = "2" });
            lstIntervalType.Add(new SelectListItem { Text = "Months", Value = "3" });
            ViewData["drpIntervalType"] = lstIntervalType;

            var lstDateType = new List<SelectListItem>();
            lstDateType.Add(new SelectListItem { Text = "--Select--", Value = "-1" });
            lstDateType.Add(new SelectListItem { Text = "Hire Date", Value = "1" });
            lstDateType.Add(new SelectListItem { Text = "Custom Date", Value = "2" });
            ViewData["drpDateType"] = lstDateType;


            return View(performanceReviewobj);

        }
        /// <summary>
        /// View to edit existing performance review record based on record id
        /// </summary>
        /// <param name="performanceReviewobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult EditReview(PerformanceReview performanceReviewobj)
        {

            bool success = false;

            //if (ModelState.IsValid)
            //{

            performanceReviewobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            performanceReviewobj.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            performanceReviewobj.ModifiedOn = DateTime.UtcNow;
            performanceReviewobj.Status = "0";
            int intRevieweeType = Convert.ToInt32(performanceReviewobj.RevieweeType);

            if (performanceReviewobj.FromSchedule == null)
            {
                performanceReviewobj.FromSchedule = performanceReviewobj.DateType.ToString();
            }

            if (performanceReviewobj.DateType.ToString() == "1")
            {
                performanceReviewobj.FromDate = System.DateTime.Now;
            }
            else if (performanceReviewobj.DateType.ToString() == "2")
            {
                performanceReviewobj.FromDate = Convert.ToDateTime(performanceReviewobj.CustomDate);
            }

            if (performanceReviewobj.Status == null)
            {
                performanceReviewobj.Status = "0";
            }
            if (intRevieweeType == 1)
            {
                performanceReviewobj.Type = performanceReviewobj.RevieweeType.ToString();
                performanceReviewobj.DepartmentId = Convert.ToInt32(performanceReviewobj.DepartmentId);
                performanceReviewobj.PositionId = 0;
                performanceReviewobj.JobTitleId = 0;
                performanceReviewobj.EmployeeId = 0;
            }
            else if (intRevieweeType == 2)
            {
                performanceReviewobj.Type = performanceReviewobj.RevieweeType.ToString();
                performanceReviewobj.PositionId = Convert.ToInt32(performanceReviewobj.DepartmentId);
                performanceReviewobj.DepartmentId = 0;
                performanceReviewobj.JobTitleId = 0;
                performanceReviewobj.EmployeeId = 0;
            }
            else if (intRevieweeType == 3)
            {
                performanceReviewobj.Type = performanceReviewobj.RevieweeType.ToString();
                performanceReviewobj.JobTitleId = Convert.ToInt32(performanceReviewobj.DepartmentId);
                performanceReviewobj.PositionId = 0;
                performanceReviewobj.DepartmentId = 0;
                performanceReviewobj.EmployeeId = 0;
            }
            else if (intRevieweeType == 4)
            {
                performanceReviewobj.Type = performanceReviewobj.RevieweeType.ToString();
                performanceReviewobj.EmployeeId = Convert.ToInt32(performanceReviewobj.DepartmentId);
                performanceReviewobj.DepartmentId = 0;
                performanceReviewobj.PositionId = 0;
                performanceReviewobj.JobTitleId = 0;

            }
            success = _performancereviewRepository.UpdateReview(performanceReviewobj);
            //}

            //if (success)
            return RedirectToAction("SelectReviewAll");
            //return View();
        }
        /// <summary>
        /// Method to delete an performance review based on record Id
        /// </summary>
        /// <param name="reviewIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteReview(string reviewIds)
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            if (reviewIds != null)
            {
                foreach (var reviewId in reviewIds.Split(','))
                {
                    var deleteReviewDetail = _performancereviewRepository.DeleteReview(Convert.ToInt32(reviewId), companyId);
                }
            }
            return true;

        }
        /// <summary>
        /// View to add review reviewer for an review 
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddReviewReviewer(int reviewId)
        {
            var li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select", Value = "0" });
            li.Add(new SelectListItem { Text = "Department", Value = "1" });
            li.Add(new SelectListItem { Text = "Position", Value = "2" });
            li.Add(new SelectListItem { Text = "Job Title", Value = "3", Disabled = false });
            li.Add(new SelectListItem { Text = "Employee", Value = "4" });
            ViewData["chkReviews"] = li;

            var companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var performanceReviewobj = _performancereviewRepository.SelectReviewById(reviewId, companyId);
            return View(performanceReviewobj);
        }
        /// <summary>
        /// View to add review reviewer for an review 
        /// </summary>
        /// <param name="performanceReviewobj"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddReviewReviewer(PerformanceReview performanceReviewobj)
        {

            bool success = false;

            if (ModelState.IsValid)
            {

                performanceReviewobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                performanceReviewobj.ModifiedBy = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                performanceReviewobj.ModifiedOn = DateTime.UtcNow;
                success = _performancereviewRepository.UpdateReview(performanceReviewobj);
            }

            //if (success)
            return RedirectToAction("SelectAllEmployeeAsset");
            //return View();
        }
        /// <summary>
        /// Function to bind filter criteria in review reviewer
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public JsonResult BindReviewReviewerFilter()
        {
            var filterList = new List<SelectListItem>();
            try
            {
                List<UserLoginModel> lstEmployee = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
                filterList = lstEmployee.Select(c => new SelectListItem { Text = (c.FirstName + " " + c.LastName), Value = c.UserId.ToString() }).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            return Json(new SelectList(filterList, "Value", "Text"));
        }

        /// <summary>
        /// View to list all the review reviewers based on review id
        /// </summary>
        /// <param name="reviewId"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ReviewReviewer(int reviewId)
        {

            var reviewReviewerFormModelobj = new ReviewReviewerFormModel();

            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            reviewReviewerFormModelobj.ManagerList = SelectEmployeeListByCompanyId().Where(j => j.UserId != Convert.ToInt32(GlobalsVariables.SelectedUserId)).ToList();
            ViewData["ReviewId"] = reviewId;

            reviewReviewerFormModelobj.Review = _reviewCriteriaRepository.GetHrManagerReview(reviewId, companyId);
            reviewReviewerFormModelobj.lstReviewer1 = _performancereviewRepository.GetReviewReviewer(companyId, reviewId, 1).ToList();
            reviewReviewerFormModelobj.lstReviewer2 = _performancereviewRepository.GetReviewReviewer(companyId, reviewId, 2).ToList();
            reviewReviewerFormModelobj.lstReviewer3 = _performancereviewRepository.GetReviewReviewer(companyId, reviewId, 3).ToList();

            //  reviewReviewerFormModelobj.lstOtherEmployee3 = _reviewCriteriaRepository.GetReviewerOtherEmployeeSelect(ReviewId, companyId, 3);
            //   int ReviewerOtherEmployeeId = 3;
            //  ViewData["ReviewerOtherEmployeeId"] = ReviewerOtherEmployeeId;
            var filterList = new List<SelectListItem>();


            var reviewerOtherEmployeeId = _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            filterList = reviewerOtherEmployeeId.Select(c => new SelectListItem { Text = (c.FirstName + " " + c.LastName), Value = c.UserId.ToString() }).ToList();
            reviewReviewerFormModelobj.lstOtherEmployee3 = _reviewCriteriaRepository.GetReviewerOtherEmployeeSelect(reviewId, companyId, 3);


            reviewReviewerFormModelobj.lstReviewer3 = _performancereviewRepository.GetReviewReviewer(companyId, reviewId, 3).ToList();
            //reviewReviewerFormModelobj.lstOtherEmployeeSelect = _reviewCriteriaRepository.GetReviewerOtherEmployeeSelect(ReviewId, companyId, 3).ToList();

            return View(reviewReviewerFormModelobj);
        }
        /// <summary>
        /// Action method to return all the employees by company
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public List<UserLoginModel> SelectEmployeeListByCompanyId()
        {
            return _registeredUsersRepository.SelectAllEmployeesList(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
        }
        /// <summary>
        /// Function to remove review reviewer based on record Id
        /// </summary>
        /// <param name="reviewReviewerId"></param>
        /// <param name="reviewCriteriaId"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteReviewReviewer(int reviewReviewerId, int reviewCriteriaId)
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            {
                var deleteReviewDetail = _performancereviewRepository.DeleteReviewReviewer(reviewReviewerId, reviewCriteriaId);
            }
            return true;
        }

        /// <summary>
        /// View to show different 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult PerformanceDashboard()
        {
            return View();
        }
        /// <summary>
        /// Action method to update HR manager for a review
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult UpdateReviewHR(FormCollection fc)
        {

            var reviewobj = new Review
            {
                HRManagerId = Convert.ToInt32(fc[1].ToString()),
                CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId),
                ReviewId = Convert.ToInt32(fc[0].ToString())
            };
            var isStatus = _reviewCriteriaRepository.UpdateReviewForHR(reviewobj);
            return RedirectToAction("SelectReviewAll");
        }

        [HttpGet]
        [ActionName("IsTitleExists")]
        [Authorize]
        public JsonResult IsTitleExists(PerformanceReview performanceReviewObj)
        {
            performanceReviewObj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var result = _performancereviewRepository.IsTitleExists(performanceReviewObj);
            if (performanceReviewObj.ReviewId.Equals(0))
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// To list all the review notifications on assigning to an employee
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 60, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Server)]
        [Authorize]
        public JsonResult GetReviewNotifications()
        {
            var reviewobj = new Reviewee();
            reviewobj.CompanyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            var reviewmasterList = _masterRepository.SelectReviewNotification(Convert.ToInt32(GlobalsVariables.SelectedUserId), Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            return Json(reviewmasterList);

        }


    }
}