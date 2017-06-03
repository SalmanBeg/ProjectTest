using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System.Data.SqlClient;
using System.Data;
namespace HRMS.Service.Repositories
{
    public class RecruitingAnswersRepository : IRecruitingAnswersRepository
    {
        public int AddRecruitingAnswers(RecruitingAnswers recruitingAnswersObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("answerId", typeof(int));
                    var result = hrmsEntity.usp_InsertRecruitingAnswers(recruitingAnswersObj.CompanyId, recruitingAnswersObj.QuestionId, recruitingAnswersObj.QuestionTypeId
                        , recruitingAnswersObj.Answers, recruitingAnswersObj.Value, recruitingAnswersObj.KnockOutValue, recruitingAnswersObj.Active, outputParam);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public int AddRecruitingAnswersOrUpdate(RecruitingAnswers recruitingAnswersObj)
        //{
        //    var hrmsEntity = new HRMSEntities1();
        //    try
        //    {
        //        var result = hrmsEntity.usp_RecruitingAnswersInsertORUpdate(recruitingAnswersObj.AnswerId, recruitingAnswersObj.CompanyId, recruitingAnswersObj.QuestionId
        //            , recruitingAnswersObj.QuestionTypeId, recruitingAnswersObj.Answers, recruitingAnswersObj.Value, recruitingAnswersObj.KnockOutValue
        //            , recruitingAnswersObj.Active);
        //        return result.Count();
        //    }
        //    catch(Exception  ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        hrmsEntity.Dispose();
        //    }
        //}
        public int UpdateRecruitingAnswers(RecruitingAnswers recruitingAnswersObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_UpdateRecruitingAnswers(recruitingAnswersObj.QuestionId, recruitingAnswersObj.QuestionTypeId, recruitingAnswersObj.Answers
                               , recruitingAnswersObj.Value, recruitingAnswersObj.KnockOutValue, recruitingAnswersObj.CompanyId, recruitingAnswersObj.Active
                               , recruitingAnswersObj.AnswerId);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<RecruitingAnswers> SelectRecruitingAnswers(int questionId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var recruitingQuestionsResult = hrmsEntity.usp_SelectRecruitingAnswers(questionId, companyId).ToList();
                    var recruitingAnswersList = recruitingQuestionsResult.Select(recruitingAnswers => new RecruitingAnswers
                    {
                        Active = recruitingAnswers.Active,
                        AnswerId = recruitingAnswers.AnswerId,
                        Answers = recruitingAnswers.Answers,
                        CompanyId = recruitingAnswers.CompanyId,
                        KnockOutValue = recruitingAnswers.KnockOutValue,
                        QuestionId = recruitingAnswers.QuestionId,
                        QuestionTypeId = recruitingAnswers.QuestionTypeId,
                        Value = recruitingAnswers.Value
                    }).ToList();
                    return recruitingAnswersList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool InsertRecruitingAnswersBulk(DataTable dtRecruitingAnswer)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {

                    var parameter = new SqlParameter("@tblRecruitingAnswers", SqlDbType.Structured);
                    parameter.Value = dtRecruitingAnswer;
                    parameter.TypeName = "HumanResources.RecruitingAnswers";
                    using (var db = new HRMSEntities1())
                    {
                        int i = db.Database.ExecuteSqlCommand("exec HumanResources.usp_InsertRecruitingAnswersBulk @tblRecruitingAnswers", parameter);
                        return Convert.ToBoolean(i);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateRecruitingAnswersBulk(DataTable dtRecruitingAnswer)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var parameter = new SqlParameter("@tblRecruitingAnswers", SqlDbType.Structured);
                    parameter.Value = dtRecruitingAnswer;
                    parameter.TypeName = "HumanResources.ReviewScoreContent";
                    using (HRMSEntities1 db = new HRMSEntities1())
                    {
                        int i = db.Database.ExecuteSqlCommand("exec HumanResources.usp_UpdateRecruitingAnswersBulk @tblRecruitingAnswers", parameter);
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
