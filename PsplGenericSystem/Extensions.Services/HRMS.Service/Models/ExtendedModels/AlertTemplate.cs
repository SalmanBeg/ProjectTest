using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HRMS.Service.Models.EDM
{
     [MetadataType(typeof(AlertTemplateMetaData))]
    public partial class AlertTemplate
    {   
        [Display(Name = "External Email")]
        [Required(ErrorMessage = "Please enter email.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]  
        public string ExternalEmail { get; set; }
        public string Email { get; set; }
        public int EmployeeId { get; set; }
        public int Position { get; set; }
        public int Location { get; set; }
        public int Department { get; set; }
        public int EmploymentStatus { get; set; }

        public List<SendingAlertSchedule> ScheduleValueList { get; set; }
        //public int CriteriaValue { get; set; }
        public List<SendingAlertDuration> CriteriaDurationList { get; set; }
        public List<SendingAlertTiming> CriteriaTimingList { get; set; }
        public List<SendingAlertCondition> CriteriaConditionList { get; set; }
        //public int CountToSend { get; set; }
        public List<SendingAlertVia> SendViaList { get; set; }

     
        public bool AlertSendCriteria { get; set; }
        public string File { get; set; }
        public List<AlertSendType> SendToList { get; set; }
        public List<AlertSendCriteria> SendCriteriaList { get; set; }
        public List<LookUpDataEntity> PositionsList { get; set; }
        public List<LookUpDataEntity> LocationsList { get; set; }
        public List<LookUpDataEntity> DepartmentsList { get; set; }
        public List<LookUpDataEntity> EmploymentStatusList { get; set; }
        public List<UserLoginModel> EmployeesList { get; set; }
        public List<UserLoginModel> EmployeeList { get; set; }
        public List<EmployeeAlert> EmployeeAlertList { get; set; }
        public string locationIdList { get; set; }
        public string departmentIdList { get; set; }
        public string positionIdList { get; set; }
        public string employmentstatusIdList { get; set; }
        public string individualEmployeeIdList { get; set; }
        public bool IsAcknowledgementRequired1
        {
            get
            {
                if (IsAcknowledgementRequired != null)
                    return Convert.ToBoolean(IsAcknowledgementRequired);
                else
                    return false;
            }
            set
            {
                IsAcknowledgementRequired = value;
            }
        }
        public bool Status1
        {
            get
            {
                if (Status != null)
                    return Convert.ToBoolean(Status);
                else
                    return false;
            }
            set
            {
                Status = value;
            }
        }
        public bool AlertSendCriteria1
        {
            get
            {
                return (AlertSendCriteria);
            }
            set
            {
                AlertSendCriteria = value;
            }
        }
    }
     public partial class AlertTemplateMetaData
     {
         public AlertTemplateMetaData()
         {

         }
         public int? AlertTemplateId { get; set; }
         public Guid? AlertTemplateCode { get; set; }
         [Display(Name = "Template Name")]
         [Required(ErrorMessage = "Please enter template name.")]
         public string AlertTemplateName { get; set; }
         [Display(Name = "Template Subject")]
         [Required(ErrorMessage = "Please enter template subject.")]
         public string AlertTemplateSubject { get; set; }
         [Display(Name = "Message")]
         [Required(ErrorMessage = "Please enter message.")]
         public string AlertTemplateBody { get; set; }
         public int? CompanyId { get; set; }
         [Display(Name = "Attachment")]
         public int? AttachmentId { get; set; }
         [Display(Name = "Acknowledgement Required")]
         public bool? IsAcknowledgementRequired { get; set; }
       
         public int? SendTo { get; set; }
         public string FromAddress { get; set; }
         public int? AlertSendCriteriaId { get; set; }
         public bool Status { get; set; }
         [Display(Name = "Acknowledgement Description")]
         [Required(ErrorMessage = "Please enter description.")]
         public string AcknowledgementDescription { get; set; }
         public int? CreatedBy { get; set; }
         public int? ModifiedBy { get; set; }
         public string CreatedOn { get; set; }
         public string ModifiedOn { get; set; }

         [Display(Name = "Schedule")]
         public Nullable<int> ScheduleValue { get; set; }
          [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a number")]
          [Required(ErrorMessage = "Please enter number of days.")]
          public Nullable<int> CriteriaValue { get; set; }

         [Required(ErrorMessage = "Please enter alert schedule type.")]
          public Nullable<int> CriteriaDuration { get; set; }
          public Nullable<int> CriteriaTiming { get; set; }
         [Required(ErrorMessage = "Please enter alert schedule criteria.")]
          public Nullable<int> CriteriaCondition { get; set; }
         [Display(Name = "How many times this alert should be sent")]
         [Required(ErrorMessage = "Please enter how many times alert to be sent.")]
          [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a number")]
          public Nullable<int> CountToSend { get; set; }
         [Display(Name = "Send this alert to")]
         [Required(ErrorMessage = "Please select send this alert to.")]
          public Nullable<int> SendVia { get; set; }
       
     }  
}
