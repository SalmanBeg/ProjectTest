using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System.Threading.Tasks;
using HRMS.Service.Models.ExtendedModels;

namespace HRMS.Service.Interfaces
{
    public interface IReviewFormRepository
    {
        [Logger]
        [ExceptionLogger]
        List<ReviewerEmployee> GetReviewFormDetails(int companyId, int reviewerEmployeeId, int ReviewerId);

        [Logger]
        [ExceptionLogger]
        bool AddReviewReviewerScore(ReviewReviewerScoreDetails reviewerScoreDetailobj);

        [Logger]
        [ExceptionLogger]
        bool UpdateReviewReviewerScoreDetails(ReviewReviewerScoreDetails reviewerScoreDetailobj);

        [Logger]
        [ExceptionLogger]
        bool UpdateReviewReviewerEmployee(ReviewerEmployee reviewerEmployeeobj);

        [Logger]
        [ExceptionLogger]
        bool UpdateHRCommentsAndStatus(ReviewerEmployee reviewerEmployeeobj);

        //[Logger]
        //[ExceptionLogger]
        //bool GetReviewFormDetails(EmployeeReviewScore employeeReviewScoreobj);

        //[Logger]
        //[ExceptionLogger]
        //bool CalculateReviewerScore(ReviewerEmployee reviewerEmployeeobj);

        //[Logger]
        //[ExceptionLogger]
        //List<ReviewReviewerOtherEmployee> ReviewReviewerOtherEmployee(int reviewReviewerEmployeeId, int companyId);


        [Logger]
        [ExceptionLogger]
        List<ReviewReviewerScoreDetails> GetReviewReviewerScoreDetails(int reviewReviewerEmployeeId, int companyId);

        [Logger]
        [ExceptionLogger]
        List<RevieewCriteria> GetReviewCriteriaQuestions(int companyId, int reviewReviewerEmployeeId, int ReviewerId);


        [Logger]
        [ExceptionLogger]
        List<ReviewScoreContent> GetReviewScoreContent(int scoreId);

       
        //[Logger]
        //[ExceptionLogger]
        //List<ReviewerEmployee> GetReviewFormDetailsForHR(int companyId, int reviewerEmployeeId, int ReviewerId);
    }
}
