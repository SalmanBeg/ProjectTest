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
    public interface IRecruitingAnswersRepository
    {
        /// <summary>
        /// Will create a new record for creating a recruiting answers
        /// </summary>
        /// <param name="recruitingAnswersObj"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        int AddRecruitingAnswers(RecruitingAnswers recruitingAnswersObj);
        /// <summary>
        /// Updates a record based on recruiting answerid
        /// </summary>
        /// <param name="recruitingAnswersObj"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        int UpdateRecruitingAnswers(RecruitingAnswers recruitingAnswersObj);
        /// <summary>
        /// To select an record based on recruting questionId and companyId
        /// </summary>
        /// <param name="recruitingQuestionId"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        List<RecruitingAnswers> SelectRecruitingAnswers(int questionId, int companyId);

        //[Logger]
        //[ExceptionLogger]
        //bool UpdateRecruitingAnswersBulk(DataTable dtRecruitingAnswer);

        //[Logger]
        //[ExceptionLogger]
        //bool InsertRecruitingAnswersBulk(DataTable dtRecruitingAnswer);

        //[ExceptionLogger]
        //[Logger]
        //int AddRecruitingAnswersOrUpdate(RecruitingAnswers recruitingAnswersObj);

    }
}
