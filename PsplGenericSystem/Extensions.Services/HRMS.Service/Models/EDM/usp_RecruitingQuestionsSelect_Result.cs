//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS.Service.Models.EDM
{
    using System;
    
    public partial class usp_RecruitingQuestionsSelect_Result
    {
        public int RecruitingQuestionId { get; set; }
        public System.Guid CompanyId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionType { get; set; }
        public Nullable<int> SequenceNumber { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Required { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
    }
}