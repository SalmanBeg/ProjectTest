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
    public interface IRatingScaleRepository
    {
        [Logger]
        [ExceptionLogger]
        int AddReviewScore(ReviewScoreDescription reviewScoreobj);

        [Logger]
        [ExceptionLogger]
        bool UpdateReviewScore(ReviewScoreDescription reviewScoreobj);

        [Logger]
        [ExceptionLogger]
        bool InsertReviewScoreContentBulk(DataTable dtReviewScoreContent);
        bool DeleteReviewScoreContent(int reviewScoreId, int companyId);

        //[Logger]
        //[ExceptionLogger]
        //bool InsertReviewScoreContentBulk(DataTable dtReviewScoreContent);


        [Logger]
        [ExceptionLogger]
        bool UpdateReviewScoreContentBulk(DataTable dtReviewScoreContent);

        [Logger]
        [ExceptionLogger]
        List<ReviewScore> SelectAllReviewScore(int companyId);

        [Logger]
        [ExceptionLogger]
        ReviewScoreDescription SelectReviewScoreById(int reviewScoreId);

        [Logger]
        [ExceptionLogger]
        List<ReviewScoreContent> SelectReviewScoreContentByID(int reviewScoreId);



        //[Logger]
        //[ExceptionLogger]
        //bool UpdateReviewScoreContent(ReviewScore reviewScoreContentobj);

        //[Logger]
        //[ExceptionLogger]
        //bool DeleteReviewScoreContent(int Id);
    }
}
