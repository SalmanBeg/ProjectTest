using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class RecruitingQuestionsFormModel
    {
        public RecruitingQuestionsFormModel()
        {
            lstRecruitingAnswers = new List<RecruitingAnswers>();
            QuestionTypes = new List<LookUpDataEntity>();
        }
        public RecruitingQuestions RecruitingQuestions { get; set; }
        public List<RecruitingAnswers> lstRecruitingAnswers { get; set; }
        public List<LookUpDataEntity> QuestionTypes { get; set; }
        public RecruitingAnswers RecruitingAnswers { get; set; }
 
    } 
 
}