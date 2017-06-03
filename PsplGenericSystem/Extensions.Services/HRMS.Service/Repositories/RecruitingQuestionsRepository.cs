using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class RecruitingQuestionsRepository : IRecruitingQuestionsRepository
    {
        public List<LookUpDataEntity> SelectQuestionType(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var questionTypeListResult = hrmsEntity.usp_SelectQuestionType(companyId);
                    return questionTypeListResult.Select(questionType => new LookUpDataEntity
                      {
                          Name = questionType.Name,
                          Description = questionType.Description,
                          Id = questionType.QuestionTypeId
                      }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public int CreateRecruitingQuestions(RecruitingQuestions recruitingQuestionsObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_RecruitingQuestionsInsertORUpdate(recruitingQuestionsObj.RecruitingQuestionId, recruitingQuestionsObj.CompanyID, recruitingQuestionsObj.QuestionText, recruitingQuestionsObj.QuestionType, recruitingQuestionsObj.SequenceNumber, recruitingQuestionsObj.Active, recruitingQuestionsObj.Required);

                    return result.Count();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RecruitingQuestions> SelectAllRecruitingQuestions(int companyId)
        {
            try
            {

                using (var hrmsEntity = new HRMSEntities1())
                {
                    var recruitingQuestionsResult = hrmsEntity.usp_RecruitingQuestionsSelectAll(companyId).ToList();
                    return recruitingQuestionsResult.Select(recruitingQuestionList => new RecruitingQuestions
                    {
                        RecruitingQuestionId = recruitingQuestionList.RecruitingQuestionID,
                        CompanyID = recruitingQuestionList.CompanyID,
                        QuestionText = recruitingQuestionList.QuestionText,
                        QuestionType = recruitingQuestionList.QuestionType,
                        SequenceNumber = recruitingQuestionList.SequenceNumber,
                        Active = recruitingQuestionList.Active,
                        Required = recruitingQuestionList.Required

                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To Delete a Record from the SelectRecruitingQuestions Grid basing on string recruitingquestionsIds from view
        /// </summary>
        /// <param name="recruitingQuestionId"></param>
        /// <returns></returns>
        public bool DeleteRecruitingQuestions(int recruitingQuestionId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_RecruitingQuestionsDelete(recruitingQuestionId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RecruitingQuestions SelectRecruitingQuestions(int recruitingQuestionId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var recruitingQuestionsResult = hrmsEntity.usp_RecruitingQuestionsSelect(recruitingQuestionId).ToList();
                    var recruitingQuestionsList = recruitingQuestionsResult.Select(recruitingQuestions => new RecruitingQuestions
                    {
                        RecruitingQuestionId = recruitingQuestions.RecruitingQuestionId,
                        QuestionText = recruitingQuestions.QuestionText,
                        QuestionType = recruitingQuestions.QuestionType,
                        SequenceNumber = recruitingQuestions.SequenceNumber,
                        Active = recruitingQuestions.Active,
                        Required = recruitingQuestions.Required,
                        CreatedOn = recruitingQuestions.CreatedOn,
                        ModifiedOn = recruitingQuestions.ModifiedOn,
                        CreatedBy = recruitingQuestions.CreatedBy,
                        ModifiedBy = recruitingQuestions.ModifiedBy
                    }).ToList();
                    return recruitingQuestionsList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int UpdateRecruitingQuestions(RecruitingQuestions recruitingQuestionsObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_RecruitingQuestionsUpdate(recruitingQuestionsObj.RecruitingQuestionId, recruitingQuestionsObj.CompanyID,
                        recruitingQuestionsObj.QuestionText, recruitingQuestionsObj.QuestionType, recruitingQuestionsObj.SequenceNumber, recruitingQuestionsObj.Active,
                        recruitingQuestionsObj.Required, recruitingQuestionsObj.ModifiedBy);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// To provide the list of selected recruiting question
        /// </summary>
        /// <param name="recruitingQuestionIds"></param>
        /// <returns></returns>
        public List<RecruitingQuestions> ListSelectedRecruitingQuestion(int[] recruitingQuestionIds, int companyId)
        {
            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var recruitingQuestionResult = SelectAllRecruitingQuestions(companyId);
                    return recruitingQuestionResult.Where(recruitingquestion => recruitingQuestionIds.Contains(recruitingquestion.RecruitingQuestionId)).ToList<RecruitingQuestions>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
