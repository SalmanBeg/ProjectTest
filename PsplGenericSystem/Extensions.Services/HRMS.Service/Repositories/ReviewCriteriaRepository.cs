using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System.Data;
using System.Data.SqlClient;

namespace HRMS.Service.Repositories
{
    public class ReviewCriteriaRepository : IReviewCriteriaRepository
    {
        public bool AddRevieewCriteria(ReviewCriteria revieewCriteriaobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_InsertReviewCriteria(revieewCriteriaobj.CompanyId, revieewCriteriaobj.JobTitleId, revieewCriteriaobj.PositionId
                                , revieewCriteriaobj.CriteriaTypeId, revieewCriteriaobj.Description, revieewCriteriaobj.CategoryId, revieewCriteriaobj.ResponseTypeId,
                                revieewCriteriaobj.ScoreId, revieewCriteriaobj.CreatedBy, revieewCriteriaobj.CreatedOn);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Review GetHrManagerReview(int ReviewId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    Review review = new Review();
                    var result = hrmsEntity.usp_GetHRManagerForReview(ReviewId, companyId).ToList();
                    review.HRManagerId = result[0];
                    return review;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<RevieewCriteria> SelectAllRevieewCriteria(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetAllReviewCriteria_Result> lstRevieewCriteriaResult = hrmsEntity.usp_GetAllReviewCriteria(companyId).ToList();
                    return lstRevieewCriteriaResult.Select(revieewCriteriaObj => new RevieewCriteria
                    {
                        ResponseId = revieewCriteriaObj.Response,
                        CriteriaTypeId = revieewCriteriaObj.CriteriaTypeId,
                        Description = revieewCriteriaObj.Description,
                        CriteriaType = revieewCriteriaObj.CriteriaType,
                        Question = revieewCriteriaObj.Question,
                        ReviewCriteriaId = revieewCriteriaObj.ReviewCriteriaId,
                        JobTitleId = revieewCriteriaObj.JobTitle,
                        PositionId = revieewCriteriaObj.Position,
                        CategoryId = revieewCriteriaObj.Category,
                        ResponseTypeId = revieewCriteriaObj.ReviewResponseTypeId,
                        CreatedOn = revieewCriteriaObj.CreatedOn,
                        ModifiedOn = revieewCriteriaObj.ModifiedOn,
                        CreatedBy = revieewCriteriaObj.CreatedBy,
                        ModifiedBy = revieewCriteriaObj.ModifiedBy
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<RevieewCriteria> SelectAllRevieewCriteriaById(int companyId, string CriteriaIds)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetAllReviewCriteriaById_Result> lstRevieewCriteriaResult = hrmsEntity.usp_GetAllReviewCriteriaById(companyId, CriteriaIds).ToList();
                    return lstRevieewCriteriaResult.Select(revieewCriteriaObj => new RevieewCriteria
                    {
                        ResponseId = revieewCriteriaObj.Response,
                        CriteriaTypeId = revieewCriteriaObj.CriteriaTypeId,
                        Description = revieewCriteriaObj.Description,
                        CriteriaType = revieewCriteriaObj.CriteriaType,
                        Question = revieewCriteriaObj.Question,
                        ReviewCriteriaId = revieewCriteriaObj.ReviewCriteriaId,
                        JobTitleId = revieewCriteriaObj.JobTitle,
                        PositionId = revieewCriteriaObj.Position,
                        CategoryId = revieewCriteriaObj.Category,
                        ResponseTypeId = revieewCriteriaObj.ReviewResponseTypeId,
                        CreatedOn = revieewCriteriaObj.CreatedOn,
                        ModifiedOn = revieewCriteriaObj.ModifiedOn,
                        CreatedBy = revieewCriteriaObj.CreatedBy,
                        ModifiedBy = revieewCriteriaObj.ModifiedBy

                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<RevieewCriteria> GetReviewCriteriaTypes(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewCriteriaTypes_Result> lstRevieewCriteriaResult = hrmsEntity.usp_GetReviewCriteriaTypes(companyId).ToList();
                    return lstRevieewCriteriaResult.Select(revieewCriteriaObj => new RevieewCriteria
                    {
                        ReviewCriteriaTypeId = revieewCriteriaObj.ReviewCriteriaTypeId,
                        Description = revieewCriteriaObj.Description
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<ReviewScoreDescription> GetReviewScores(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewScore_Result> lstRevieewCriteriaResult = hrmsEntity.usp_GetReviewScore(companyId).ToList();
                    return lstRevieewCriteriaResult.Select(revieewCriteriaObj => new ReviewScoreDescription
                    {
                        ReviewScoreDescriptionId = revieewCriteriaObj.ReviewScoreDescriptionId,
                        Description = revieewCriteriaObj.Description,

                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateRevieewCriteria(ReviewCriteria revieewCriteriaobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateReviewCriteria(revieewCriteriaobj.CompanyId, revieewCriteriaobj.JobTitleId, revieewCriteriaobj.PositionId
                               , revieewCriteriaobj.CriteriaTypeId, revieewCriteriaobj.Description, revieewCriteriaobj.CategoryId, revieewCriteriaobj.ResponseTypeId
                               , revieewCriteriaobj.ScoreId, revieewCriteriaobj.ReviewCriteriaId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateReviewForHR(Review reviewobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var Result = hrmsEntity.usp_UpdateReviewForHR(reviewobj.ReviewId, reviewobj.CompanyId, reviewobj.HRManagerId);
                    return Result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteRevieewCriteria(int reviewCriteriaId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstRevieewCriteriaResult = hrmsEntity.usp_DeleteReviewCriteria(reviewCriteriaId, companyId);
                    return lstRevieewCriteriaResult > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ReviewCriteria> SelectReviewCriteriaId(int reviewCriteriaId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetReviewCriteriaById_Result> lstReviewCriteriaResult = hrmsEntity.usp_GetReviewCriteriaById(companyId, reviewCriteriaId).ToList();
                    return lstReviewCriteriaResult.Select(revieewCriteriaObj => new ReviewCriteria
                    {

                        CriteriaTypeId = revieewCriteriaObj.CriteriaTypeId,
                        Description = revieewCriteriaObj.Description,
                        ReviewCriteriaId = revieewCriteriaObj.ReviewCriteriaId,
                        JobTitleId = revieewCriteriaObj.JobTitleId,
                        PositionId = revieewCriteriaObj.PositionId,
                        CategoryId = revieewCriteriaObj.CategoryId,
                        ResponseTypeId = revieewCriteriaObj.ResponseTypeId,
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<ReviewReviewerOtherEmployee> GetReviewerOtherEmployeeSelect(int reviewId, int companyId, int reviewerMasterId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_GetOtherSelectedEmployee_Result> lstReviewOtherEmployeeResult = hrmsEntity.usp_GetOtherSelectedEmployee(reviewId, companyId, reviewerMasterId).ToList();
                    return lstReviewOtherEmployeeResult.Select(reviewotherObj => new ReviewReviewerOtherEmployee
                    {
                        OtherEmployeeId = reviewotherObj.OtherEmployeeId,
                        EmployeeName = reviewotherObj.EmployeeName
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddReviewReviewerCriteria(int CompanyId, int ReviewId, int ReviewerMasterId, int CreatedBy, System.Data.DataTable dtReviewCriteria, System.Data.DataTable dtOtherEmployee)
        {

            try
            {
                var parameter1 = new SqlParameter("@CompanyId", SqlDbType.Int);
                parameter1.Value = CompanyId;

                var parameter2 = new SqlParameter("@ReviewId", SqlDbType.Int);
                parameter2.Value = ReviewId;

                var parameter3 = new SqlParameter("@ReviewerMasterId", SqlDbType.Int);
                parameter3.Value = ReviewerMasterId;

                var parameter4 = new SqlParameter("@CreatedBy", SqlDbType.Int);
                parameter4.Value = CreatedBy;

                var parameter5 = new SqlParameter("@ReviewCriteria", SqlDbType.Structured);
                parameter5.Value = dtReviewCriteria;
                parameter5.TypeName = "HumanResources.typeReviewCriteria";


                var parameter6 = new SqlParameter("@ReviewReviewerOtherEmployee", SqlDbType.Structured);
                parameter6.Value = dtOtherEmployee;
                parameter6.TypeName = "HumanResources.typeReviewReviewerOtherEmployee";



                using (HRMSEntities1 db = new HRMSEntities1())
                {
                    db.Database.ExecuteSqlCommand("exec HumanResources.usp_InsertReviewReviewer @CompanyId,@ReviewId,@ReviewerMasterId,@CreatedBy,@ReviewCriteria,@ReviewReviewerOtherEmployee", parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetReviewCriteriaId(int companyId, int ReviewId, int ReviewerMasterId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    string strIds = string.Empty;
                    var result = hrmsEntity.usp_GetReviewReviewerIdByReviewId(companyId, ReviewId, ReviewerMasterId).ToList();
                    if (result.Count > 0)
                    {
                        string lastItem = result[result.Count - 1].ToString();
                        foreach (var r in result)
                        {
                            if (r.ToString() != lastItem)
                            {
                                strIds = strIds + r.ToString() + ",";
                            }
                            else
                            {
                                strIds = strIds + r.ToString();
                            }
                        }
                    }
                    return strIds; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
