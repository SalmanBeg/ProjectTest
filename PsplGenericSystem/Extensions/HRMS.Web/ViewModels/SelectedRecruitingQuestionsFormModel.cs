using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class SelectedRecruitingQuestionsFormModel
    {

        public SelectedRecruitingQuestionsFormModel()
        {
        }
        public int RecruitingQuestionId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionType { get; set; }
        public int SequenceNumber { get; set; }
        public bool IsRequired { get; set; }
        public bool IsActive { get; set; }
        public bool RecruitingQuestionsChecked { get; set; }


    }
}