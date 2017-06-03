using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using HRMS.Service;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(RecruitingAnswersMetaData))]
    public partial class RecruitingAnswers
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
        public bool IsKnockOutValue
        {
            get
            {
                return KnockOutValue.GetValueOrDefault();
            }
            set
            {
                KnockOutValue = value;
            }
        }
    }
    public partial class RecruitingAnswersMetaData
    {
        public RecruitingAnswersMetaData()
        {

        }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionTypeId { get; set; }
        [Required(ErrorMessage = "Enter Answer")]
        public string Answers { get; set; }
        [Required(ErrorMessage = "Enter Value")]
        public int Value { get; set; }
        public bool? KnockOutValue { get; set; }
        public int CompanyId { get; set; }
        public bool? Active { get; set; }

    }
}
