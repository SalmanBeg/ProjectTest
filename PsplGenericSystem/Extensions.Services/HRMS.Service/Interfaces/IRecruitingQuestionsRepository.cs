using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IRecruitingQuestionsRepository
    {
        /// <summary>
        /// To list default question types
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        List<LookUpDataEntity> SelectQuestionType(int companyId);
        /// <summary>
        /// To retrieve all recruiting questions in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        List<RecruitingQuestions> SelectAllRecruitingQuestions(int companyId);
        /// <summary>
        /// Will create a new record for creating a recruiting question
        /// </summary>
        /// <param name="recruitingQuestionsObj"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        int CreateRecruitingQuestions(RecruitingQuestions recruitingQuestionsObj);
        /// <summary>
        /// To remove a recruiting question record Id
        /// </summary>
        /// <param name="recruitingQuestionId"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        bool DeleteRecruitingQuestions(int recruitingQuestionId);
        /// <summary>
        /// To select an record based on recruting questionId
        /// </summary>
        /// <param name="recruitingQuestionId"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        RecruitingQuestions SelectRecruitingQuestions(int recruitingQuestionId);
        /// <summary>
        /// Updates a record based on recruiting questionid
        /// </summary>
        /// <param name="recruitingQuestionsObj"></param>
        /// <returns></returns>
        [ExceptionLogger]
        [Logger]
        int UpdateRecruitingQuestions(RecruitingQuestions recruitingQuestionsObj);

        [Logger]
        [ExceptionLogger]
        List<RecruitingQuestions> ListSelectedRecruitingQuestion(int[] recruitingQuestionIds, int companyId);
    }


}
