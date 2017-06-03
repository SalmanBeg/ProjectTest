using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.Interfaces;
using HRMS.Web.ViewModels;

namespace HRMS.Service.Repositories
{
    public class PerformanceReviewRepository : IPerformanceReviewsRepository
    {

        public bool DeleteReview(int reviewId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_DeleteReviewById(companyId, reviewId);
                    return result > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteReviewReviewer(int reviewReviewerId, int reviewCriteriaId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_DeleteReviewReviewerCriteria(reviewReviewerId, reviewCriteriaId);
                    return result > 0; 
                }
            }
            catch (Exception )
            {
                throw ;
            }

        }


        public List<PerformanceReview> SelectReviewAll(int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstReviewResult = hrmsEntity.usp_GetAllReviewDetails(companyId).ToList();
                    var reviewList = lstReviewResult.Select(performancereviewObj => new PerformanceReview
                    {
                        ReviewId = performancereviewObj.ReviewId,
                        Name = performancereviewObj.Name,
                        OpenReviews = performancereviewObj.OpenReviews,
                        ClosedReviews = performancereviewObj.ClosedReviews,
                        Status = performancereviewObj.Status
                    }).ToList();
                    return reviewList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateReview(PerformanceReview performanceReviewObj)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateReviewByCompanyId(performanceReviewObj.ReviewId, performanceReviewObj.CompanyId, performanceReviewObj.Name,
                                                                                Convert.ToInt32(performanceReviewObj.Status), performanceReviewObj.DepartmentId, performanceReviewObj.PositionId,
                                                                               performanceReviewObj.JobTitleId, performanceReviewObj.EmployeeId, performanceReviewObj.Type,
                                                                               performanceReviewObj.DaysToComplete, performanceReviewObj.FromDate, performanceReviewObj.FromSchedule,
                                                                               performanceReviewObj.IntervalType, performanceReviewObj.ScheduleValue, performanceReviewObj.Accountability,
                                                                               performanceReviewObj.Competency, performanceReviewObj.Goal, performanceReviewObj.Question,
                                                                               performanceReviewObj.WeightedAverage, performanceReviewObj.ModifiedBy, performanceReviewObj.ModifiedOn);
                    return result > 0; 
                }
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public bool AddReview(PerformanceReview performanceReviewObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_InsertReviewByCompanyId(performanceReviewObj.CompanyId, performanceReviewObj.Name, Convert.ToInt32(performanceReviewObj.Status), performanceReviewObj.DepartmentId
                                                                               , performanceReviewObj.PositionId, performanceReviewObj.JobTitleId, performanceReviewObj.EmployeeId
                                                                               , performanceReviewObj.Type, performanceReviewObj.DaysToComplete, performanceReviewObj.FromDate,
                                                                               performanceReviewObj.FromSchedule, performanceReviewObj.IntervalType, performanceReviewObj.ScheduleValue,
                                                                               performanceReviewObj.Accountability, performanceReviewObj.Competency, performanceReviewObj.Goal
                                                                               , performanceReviewObj.Question, performanceReviewObj.WeightedAverage, performanceReviewObj.CreatedBy
                                                                               , performanceReviewObj.CreatedOn);
                    return result > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public PerformanceReview SelectReviewById(int reviewId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstReviewsResult = hrmsEntity.usp_GetReviewsById(reviewId, companyId).ToList();
                    return lstReviewsResult.Select(performancereview => new PerformanceReview
                    {
                        ReviewId = performancereview.ReviewId,
                        Name = performancereview.Name,
                        CompanyId = string.IsNullOrEmpty(performancereview.CompanyId.ToString()) ? 0 : Convert.ToInt32(performancereview.CompanyId),
                        Status = performancereview.Status.ToString(),
                        DepartmentId = string.IsNullOrEmpty(performancereview.DepartmentId.ToString()) ? 0 : Convert.ToInt32(performancereview.DepartmentId),
                        JobTitleId = string.IsNullOrEmpty(performancereview.JobTitleId.ToString()) ? 0 : Convert.ToInt32(performancereview.JobTitleId),
                        DaysToComplete = string.IsNullOrEmpty(performancereview.DaysToComplete.ToString()) ? 0 : Convert.ToInt32(performancereview.DaysToComplete),
                        ScheduleValue = string.IsNullOrEmpty(performancereview.ScheduleValue.ToString()) ? 0 : Convert.ToInt32(performancereview.ScheduleValue),
                        FromDate = string.IsNullOrEmpty(performancereview.FromDate.ToString()) ? default(DateTime) : Convert.ToDateTime(performancereview.FromDate),
                        FromSchedule = performancereview.FromSchedule,
                        IntervalType = string.IsNullOrEmpty(performancereview.IntervalType.ToString()) ? 0 : Convert.ToInt32(performancereview.IntervalType),
                        Accountability = string.IsNullOrEmpty(performancereview.Accountability.ToString()) ? 0 : Convert.ToInt32(performancereview.Accountability),
                        Competency = string.IsNullOrEmpty(performancereview.Competency.ToString()) ? 0 : Convert.ToInt32(performancereview.Competency),
                        Question = string.IsNullOrEmpty(performancereview.Question.ToString()) ? 0 : Convert.ToInt32(performancereview.Question),
                        Goal = string.IsNullOrEmpty(performancereview.Goal.ToString()) ? 0 : Convert.ToInt32(performancereview.Goal),
                        WeightedAverage = string.IsNullOrEmpty(performancereview.WeightedAverage.ToString()) ? false : Convert.ToBoolean(performancereview.WeightedAverage),
                        RevieweeType = string.IsNullOrEmpty(performancereview.Type.ToString()) ? 0 : Convert.ToInt32(performancereview.Type),
                        PositionId = string.IsNullOrEmpty(performancereview.PositionId.ToString()) ? 0 : Convert.ToInt32(performancereview.PositionId),
                        EmployeeId = string.IsNullOrEmpty(performancereview.EmployeeId.ToString()) ? 0 : Convert.ToInt32(performancereview.EmployeeId),
                        DateType = string.IsNullOrEmpty(performancereview.FromSchedule.ToString()) ? 0 : Convert.ToInt32(performancereview.FromSchedule),
                        CustomDate = string.IsNullOrEmpty(performancereview.FromDate.ToString()) ? default(DateTime) : Convert.ToDateTime(performancereview.FromDate),


                    }).FirstOrDefault(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ReviewCriteriaFill> GetReviewReviewer(int companyId, int reviewId, int reviewerMasterId)
        {

            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstReviewReviewerResult = hrmsEntity.usp_GetReviewReviewerDetails(reviewId, companyId, reviewerMasterId).ToList();
                    var reviewReviewerList = lstReviewReviewerResult.Select(reviewReviewerObj => new ReviewCriteriaFill
                    {
                        ReviewReviewerId = reviewReviewerObj.ReviewreviewerId,
                        Type = reviewReviewerObj.TYPE,
                        JobTitleId = reviewReviewerObj.JobTitle,
                        CategoryId = reviewReviewerObj.CATEGORY,
                        ResponseTypeId = reviewReviewerObj.RESPONSETYPE,
                        Description = reviewReviewerObj.DESCRIPTION,
                        ReviewCriteriaId = reviewReviewerObj.ReviewCriteriaId

                    }).ToList();
                    return reviewReviewerList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public bool IsTitleExists(PerformanceReview performanceReviewObj)
        {
            using (var hrmsEntity = new HRMSEntities1())
            {
                var reviewList = hrmsEntity.Reviews.ToList();
                var reviewObj1 = reviewList.Where(m => m.CompanyId == performanceReviewObj.CompanyId && m.Name.ToLower() == performanceReviewObj.Name.ToLower() && m.ReviewId != performanceReviewObj.ReviewId).FirstOrDefault();
                if (reviewObj1 != null)
                    return false;
                else
                    return true; 
            }
        }
    }
}
