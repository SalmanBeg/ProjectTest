using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{

    [MetadataType(typeof(RecruitingQuestionsMetaData))]

    public partial class RecruitingQuestions
    {
        
        public bool IsActive
        {
            get
            {
                return Active.GetValueOrDefault();
            }
            set
            {
                Active = value;
            }
        }
        public bool IsRequired
        {
            get
            {
                return Required.GetValueOrDefault();
            }
            set
            {
                Required = value;
            }
        }
        public int TheSequenceNumber
        {
            get
            {
                return SequenceNumber.GetValueOrDefault();
            }
            set
            {
                SequenceNumber = value;
            }
        
        }

    }
    public partial class RecruitingQuestionsMetaData
    {
        public int RecruitingQuestionId { get; set; }
        public int CompanyID { get; set; }
        public System.Guid RecruitingQuestionCode { get; set; }
        [DisplayName("Question")]
        [Required(ErrorMessage = "Please enter the question")]
        public string QuestionText { get; set; }
        [Required(ErrorMessage = "Please select the question type.")]
        [DisplayName("Question Type")]
        public int QuestionType { get; set; }
        [Required(ErrorMessage = "Please provide the Sequence No")]
        [DisplayName("Sequence Number")]
        public int SequenceNumber { get; set; }

        public bool Active { get; set; }

        public bool Required { get; set; }

        public int TheSequenceNumber { get; set; }
    }
}
