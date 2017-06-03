using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;




namespace HRMS.Service.Interfaces
{
    public interface IPerformanceReviewsRepository
    {
        [Logger]
        [ExceptionLogger]
        List<PerformanceReview> SelectReviewAll(int companyId);

        [Logger]
        [ExceptionLogger]
        PerformanceReview SelectReviewById(int reviewId, int companyId);

        [Logger]
        [ExceptionLogger]
        bool UpdateReview(PerformanceReview performanceReviewObj);

        [Logger]
        [ExceptionLogger]
        bool DeleteReview(int reviewId, int companyId);


        [Logger]
        [ExceptionLogger]
        bool AddReview(PerformanceReview performanceReviewObj);

        [Logger]
        [ExceptionLogger]
        List<ReviewCriteriaFill> GetReviewReviewer(int companyId, int reviewId, int reviewerMasterId);

        [Logger]
        [ExceptionLogger]
        bool DeleteReviewReviewer(int reviewReviewerId, int reviewCriteriaId);

        [Logger]
        [ExceptionLogger]
        bool IsTitleExists(PerformanceReview performanceReviewObj);



    }
}
