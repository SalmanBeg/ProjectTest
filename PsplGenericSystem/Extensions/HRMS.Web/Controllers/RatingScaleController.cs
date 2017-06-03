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
    public class RatingScaleController : Controller
    {
        #region Class Level Variables and constructor
        private readonly IUtilityRepository _utilityRepository;
        private readonly IRatingScaleRepository _ratingScaleRepository;
        public RatingScaleController(IUtilityRepository utilityRepository, IRatingScaleRepository ratingScaleRepository)
        {
            _ratingScaleRepository = ratingScaleRepository;
            _utilityRepository = utilityRepository;
        }
        #endregion
        /// <summary>
        /// View to add a new rating scale for review reviewers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult AddRatingScale()
        {
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var ratingScaleFormModelobj = new RatingScaleFormModel();
            return View(ratingScaleFormModelobj);
        }
        /// <summary>
        /// View to add a new rating scale for review reviewers
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddRatingScale(FormCollection fc)
        {
            try
            {

                int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
                int currentUserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
                var lstScoreDesc = new ReviewScoreDescription();
                lstScoreDesc.CompanyId = companyId;
                lstScoreDesc.CreatedBy = currentUserId;
                lstScoreDesc.CreatedOn = DateTime.UtcNow;
                lstScoreDesc.Description = fc[0];
                lstScoreDesc.IsChildCompany = Convert.ToBoolean(fc[1]);

                int rtnReviewDescriptionId = _ratingScaleRepository.AddReviewScore(lstScoreDesc);
                if (rtnReviewDescriptionId != -1)
                {
                    string listName = fc[2];
                    string listValue = fc[3];

                    DataTable dt = RatingScoreSchema();

                    //Default row Bind
                    DataRow defaultRow = dt.NewRow();
                    defaultRow["ItemName"] = listName;
                    defaultRow["ItemValue"] = listValue;
                    defaultRow["ReviewScoreDescriptionId"] = rtnReviewDescriptionId;
                    defaultRow["CompanyID"] = companyId;
                    defaultRow["CreatedBy"] = currentUserId;
                    defaultRow["CreatedOn"] = DateTime.UtcNow;
                    dt.Rows.Add(defaultRow);

                    //Loop Grid Logic


                    int i = 0;
                    if (fc.Count > 4)
                    {
                        string[] strSplitName = fc[4].Split(',');
                        string[] strSplitValue = fc[5].Split(',');
                        foreach (var listname in strSplitName)
                        {
                            DataRow row = dt.NewRow();
                            row["ItemName"] = listname;
                            row["ItemValue"] = strSplitValue[i];
                            row["ReviewScoreDescriptionId"] = rtnReviewDescriptionId;
                            row["CompanyID"] = companyId;
                            row["CreatedBy"] = currentUserId;
                            row["CreatedOn"] = DateTime.UtcNow;
                            dt.Rows.Add(row);
                            dt.AcceptChanges();
                            i++;
                        }
                    }


                    //Bulk Insert

                    bool status = _ratingScaleRepository.InsertReviewScoreContentBulk(dt);

                }

            }
            catch (Exception)
            {

            }
            return RedirectToAction("SelectAllRatingScale");
        }

        public DataTable RatingScoreSchema()
        {
            var dt = new DataTable();
            dt.Columns.Add("ItemName", typeof(string));
            dt.Columns.Add("ItemValue", typeof(float));
            dt.Columns.Add("ReviewScoreDescriptionId", typeof(int));
            dt.Columns.Add("CompanyID", typeof(int));
            dt.Columns.Add("CreatedBy", typeof(int));
            dt.Columns.Add("CreatedOn", typeof(DateTime));


            return dt;
        }
        /// <summary>
        /// View to show all the rating scale criterias created for review reviewers
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult SelectAllRatingScale()
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            List<ReviewScore> reviewScoreContentList = _ratingScaleRepository.SelectAllReviewScore(companyId);
            return View(reviewScoreContentList);
        }

        /// <summary>
        /// View to edit existing rating scale based on record Id
        /// </summary>
        /// <param name="reviewScoreId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult EditRatingScale(int reviewScoreId)
        {
            var lstlookup = _utilityRepository.GetLookUpData(Convert.ToInt32(GlobalsVariables.CurrentCompanyId));
            var ratingScaleFormModelobj = new RatingScaleFormModel();
            ratingScaleFormModelobj.ReviewScoreDescription = _ratingScaleRepository.SelectReviewScoreById(reviewScoreId);
            TempData["tmpScoreModel"] = _ratingScaleRepository.SelectReviewScoreContentByID(reviewScoreId);
            return View(ratingScaleFormModelobj);
        }
        /// <summary>
        /// View to edit existing rating scale based on record Id
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult EditRatingScale(FormCollection fc)
        {


            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            int currentUserId = Convert.ToInt32(GlobalsVariables.CurrentUserId);
            int reviewDescriptionId = Convert.ToInt32(fc[0]);
            var lstScoreDesc = new ReviewScoreDescription();
            lstScoreDesc.CompanyId = companyId;
            lstScoreDesc.CreatedBy = currentUserId;
            lstScoreDesc.CreatedOn = DateTime.UtcNow;
            lstScoreDesc.ReviewScoreDescriptionId = reviewDescriptionId;
            lstScoreDesc.Description = fc[1];
            lstScoreDesc.IsChildCompany = Convert.ToBoolean(fc[2]);

            bool rtnStatus = _ratingScaleRepository.UpdateReviewScore(lstScoreDesc);
            if (rtnStatus && fc.Count > 3)
            {
                string listName = fc[3];
                string listValue = fc[4];

                DataTable dt = RatingScoreSchema();

                //Default row Bind
                if (fc["item.ItemName"].Contains(','))
                {
                    int J = 0;
                    string[] strSplitName = fc[3].Split(',');
                    string[] strSplitValue = fc[4].Split(',');
                    foreach (var listname in strSplitName)
                    {
                        DataRow row = dt.NewRow();
                        row["ItemName"] = listname;
                        row["ItemValue"] = strSplitValue[J];
                        row["ReviewScoreDescriptionId"] = reviewDescriptionId;
                        row["CompanyID"] = companyId;
                        row["CreatedBy"] = currentUserId;
                        row["CreatedOn"] = DateTime.UtcNow;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                        J++;
                    }
                }
                else
                {
                    DataRow defaultRow = dt.NewRow();
                    defaultRow["ItemName"] = listName;
                    defaultRow["ItemValue"] = listValue;
                    defaultRow["ReviewScoreDescriptionId"] = reviewDescriptionId;
                    defaultRow["CompanyID"] = companyId;
                    defaultRow["CreatedBy"] = currentUserId;
                    defaultRow["CreatedOn"] = DateTime.UtcNow;
                    dt.Rows.Add(defaultRow);
                }
                //Loop Grid Logic


                int i = 0;
                if (fc.Count > 5)
                {
                    string[] strSplitName = fc[5].Split(',');
                    string[] strSplitValue = fc[6].Split(',');
                    foreach (var listname in strSplitName)
                    {
                        DataRow row = dt.NewRow();
                        row["ItemName"] = listname;
                        row["ItemValue"] = strSplitValue[i];
                        row["ReviewScoreDescriptionId"] = reviewDescriptionId;
                        row["CompanyID"] = companyId;
                        row["CreatedBy"] = currentUserId;
                        row["CreatedOn"] = DateTime.UtcNow;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                        i++;
                    }
                }
                //Bulk Update
                bool addReviewScoreC = _ratingScaleRepository.UpdateReviewScoreContentBulk(dt);
            }


            return RedirectToAction("SelectAllRatingScale");
        }
        /// <summary>
        /// Function to delete rating scale based on recordId
        /// </summary>
        /// <param name="scoreIds"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool DeleteRatingScale(string scoreIds)
        {
            int companyId = Convert.ToInt32(GlobalsVariables.CurrentCompanyId);
            if (scoreIds != null)
            {
                foreach (var scoreId in scoreIds.Split(','))
                {
                    var deleteReviewDetail = _ratingScaleRepository.DeleteReviewScoreContent(Convert.ToInt32(scoreId), companyId);
                }
            }
            return true;

        }
    }
}