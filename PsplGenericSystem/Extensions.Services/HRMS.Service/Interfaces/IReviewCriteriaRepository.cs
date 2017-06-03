using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;
using System.Data;

namespace HRMS.Service.Interfaces
{
    public interface IReviewCriteriaRepository
    {
        [Logger]
        [ExceptionLogger]
        bool AddRevieewCriteria(ReviewCriteria revieewCriteriaobj);

        [Logger]
        [ExceptionLogger]
        Review GetHrManagerReview(int ReviewId,int companyId);

        [Logger]
        [ExceptionLogger]
        List<RevieewCriteria> SelectAllRevieewCriteria(int companyId);

        [Logger]
        [ExceptionLogger]
        bool UpdateRevieewCriteria(ReviewCriteria revieewCriteriaobj);

        [Logger]
        [ExceptionLogger]
        bool UpdateReviewForHR(Review reviewobj);

        [Logger]
        [ExceptionLogger]
        List<ReviewReviewerOtherEmployee> GetReviewerOtherEmployeeSelect(int reviewId, int companyId, int ReviewerOtherEmployeeId);


        [Logger]
        [ExceptionLogger]
        bool DeleteRevieewCriteria(int reviewCriteriaId, int companyId);

        [Logger]
        [ExceptionLogger]
        List<RevieewCriteria> GetReviewCriteriaTypes(int companyId);




        [Logger]
        [ExceptionLogger]
        List<ReviewScoreDescription> GetReviewScores(int companyId);


        [Logger]
        [ExceptionLogger]
        List<ReviewCriteria> SelectReviewCriteriaId(int reviewCriteriaId, int companyId);

        //[Logger]
        //[ExceptionLogger]
        //List<RevieewCriteria> SelectAllReviewCriteria(int companyId);


        [Logger]
        [ExceptionLogger]
        bool AddReviewReviewerCriteria(int CompanyId, int ReviewId, int ReviewerMasterId, int CreatedBy, DataTable dtReviewCriteria, DataTable dtOtherEmployee);

        [Logger]
        [ExceptionLogger]
        string GetReviewCriteriaId(int companyId, int ReviewId, int ReviewerMasterId);

        List<RevieewCriteria> SelectAllRevieewCriteriaById(int companyId, string CriteriaIds);
    }
}
