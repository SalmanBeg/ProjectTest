using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtendedModels;

namespace HRMS.Service.Repositories
{
    public class ReviewFormRepository : IReviewFormRepository
    {
        public List<ReviewerEmployee> GetReviewFormDetails(int companyId, int reviewerEmployeeId, int ReviewerId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewFormDetails_Result> lstReviewFormResult = hrmsEntity.usp_GetReviewFormDetails(companyId, ReviewerId).ToList();
                    return lstReviewFormResult.Select(reviewerEmployeeObj => new ReviewerEmployee
                    {

                        ReviewScore = reviewerEmployeeObj.ReviewScore,
                        ReviewerScore = reviewerEmployeeObj.ReviewerScore,
                        ReviewTitle = reviewerEmployeeObj.ReviewTitle,
                        ReviewerEmployeeId = reviewerEmployeeObj.ReviewerEmployeeId,
                        ReviewerName = reviewerEmployeeObj.ReviewerName,
                        ManagerName = reviewerEmployeeObj.ManagerName,
                        ReviewDate = reviewerEmployeeObj.ReviewDate,
                        Status = reviewerEmployeeObj.Status,
                        HRComments = reviewerEmployeeObj.HRComments,
                        ReviewerComments = reviewerEmployeeObj.ReviewerComments,
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // public List<ReviewerEmployee> GetReviewFormDetailsForHR(int companyId, int reviewerEmployeeId, int ReviewerId)
        //{
        //      var hrmsEntity = new HRMSEntities1();
        //    try
        //    {
        //        List<usp_GetReviewFormDetailsForHR_Result> lstReviewFormHRResult = hrmsEntity.usp_GetReviewFormDetailsForHR(companyId, reviewerEmployeeId, ReviewerId);
        //        return lstReviewFormHRResult.Select(reviewerEmployeeObj => new ReviewerEmployee
        //        {

        //        }).ToList();
        //    }
        //}
        public bool AddReviewReviewerScore(ReviewReviewerScoreDetails reviewerScoreDetailobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_InsertReviewReviewerScoreDetails(reviewerScoreDetailobj.CompanyId, reviewerScoreDetailobj.ReviewReviewerEmployeeId,
                                reviewerScoreDetailobj.ReviewCriteriaId, reviewerScoreDetailobj.Answers, reviewerScoreDetailobj.ReviewReviewerId).ToList();
                    return result.Count > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateReviewReviewerScoreDetails(ReviewReviewerScoreDetails reviewerScoreDetailobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateReviewReviewerScoreDetails(reviewerScoreDetailobj.Answers, reviewerScoreDetailobj.ReviewReviewerScoreId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateReviewReviewerEmployee(ReviewerEmployee reviewerEmployeeobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateReviewReviewerEmployee(reviewerEmployeeobj.ReviewerEmployeeId, reviewerEmployeeobj.ReviewerComments,
                               reviewerEmployeeobj.ReviewerScore, reviewerEmployeeobj.Status, reviewerEmployeeobj.ReviewScore);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateHRCommentsAndStatus(ReviewerEmployee reviewerEmployeeobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateHRCommentsAndStatus(reviewerEmployeeobj.ReviewerComments, reviewerEmployeeobj.HRStatus, reviewerEmployeeobj.UserId,
                                reviewerEmployeeobj.ReviewDate);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public bool CalculateReviewerScore(ReviewerEmployee reviewerEmployeeobj)
        //{
        //    var hrmsEntity = new HRMSEntities1();
        //    try
        //    {
        //        var result = hrmsEntity.usp_CalculateReviewerScore(reviewerEmployeeobj.ReviewerId, reviewerEmployeeobj.CompanyId, reviewerEmployeeobj.ReviewerEmployeeId);
        //        return result > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        hrmsEntity.Dispose();
        //    }

        //}

        public List<RevieewCriteria> GetReviewCriteriaQuestions(int companyId, int reviewReviewerEmployeeId, int ReviewerId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewCriteriaQuestions_Result> lstReviewerScoreDetailResult = hrmsEntity.usp_GetReviewCriteriaQuestions(companyId, reviewReviewerEmployeeId, ReviewerId).ToList();
                    return lstReviewerScoreDetailResult.Select(reviewCriteriaObj => new RevieewCriteria
                     {
                         ReviewCriteriaId = reviewCriteriaObj.ReviewCriteriaId,
                         Description = reviewCriteriaObj.Description,
                         CriteriaType = reviewCriteriaObj.CriteriaType,
                         ResponseType = reviewCriteriaObj.ResponseType,
                         Answers = reviewCriteriaObj.Answers,
                         AnswerId = reviewCriteriaObj.AnswerId,
                         ScoreId = reviewCriteriaObj.ScoreID,
                         Question = reviewCriteriaObj.Questions
                     }).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ReviewScoreContent> GetReviewScoreContent(int scoreId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewScoreContent_Result> lstReviewScoreResult = hrmsEntity.usp_GetReviewScoreContent(scoreId).ToList();
                    return lstReviewScoreResult.Select(reviewScoreContentObj => new ReviewScoreContent
                    {
                        ReviewScoreContentId = reviewScoreContentObj.ReviewScoreContentId,
                        ItemName = reviewScoreContentObj.ItemName,
                        ItemValue = reviewScoreContentObj.ItemValue
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ReviewReviewerScoreDetails> GetReviewReviewerScoreDetails(int reviewReviewerEmployeeId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewReviewerScoreDetails_Result> lstReviewerScoreDetailsResult = hrmsEntity.usp_GetReviewReviewerScoreDetails(reviewReviewerEmployeeId, companyId).ToList();
                    return lstReviewerScoreDetailsResult.Select(reviewReviewerScoreDetailsObj => new ReviewReviewerScoreDetails
                    {
                        ReviewReviewerEmployeeId = reviewReviewerScoreDetailsObj.ReviewReviewerEmployeeId,
                        CompanyId = reviewReviewerScoreDetailsObj.CompanyId,
                        ReviewCriteriaId = reviewReviewerScoreDetailsObj.ReviewCriteriaId,
                        Answers = reviewReviewerScoreDetailsObj.Answers,
                        ReviewReviewerId = reviewReviewerScoreDetailsObj.ReviewReviewerId
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
