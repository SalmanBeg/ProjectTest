using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Common.Enums;
using System.Web;

namespace HRMS.BusinessLayer
{
    public class AlertTemplate
    {
        public AlertTemplate()
        {
            SendToList = new List<AlertSendType>();
            PositionsList = new List<LookUpDataEntity>();
            SendCriteriaList = new List<AlertSendCriteria>();
            EmployeeList = new List<UserLoginModel>();
            EmployeeAlertList = new List<EmployeeAlert>();
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
        public bool IsAcknowledgementRequired { get; set; }
        public int? SendTo { get; set; }
        public string FromAddress { get; set; }
        public int? AlertSendCriteriaId { get; set; }
        public bool AlertSendCriteria { get; set; }
        public bool Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        [Display(Name = "Acknowledgement Description")]
        [Required(ErrorMessage = "Please enter description.")]
        public string AcknowledgementDescription { get; set; }
        [Display(Name = "External Email")]
        [Required(ErrorMessage = "Please enter email.")]
        public string ExternalEmail { get; set; }
        public string Email { get; set; }
        public int EmployeeId { get; set; }
        public string locationIdList{ get; set; }
        public string departmentIdList { get; set; }
        public string positionIdList { get; set; }
        public string employmentstatusIdList { get; set; }
        public string individualEmployeeIdList { get; set; }

        public HttpPostedFileBase File { get; set; }

        public int Position { get; set; }
        public int Location { get; set; }
        public int Department { get; set; }
        public int EmploymentStatus { get; set; }
        public List<AlertSendType> SendToList { get; set; }
        public List<AlertSendCriteria> SendCriteriaList { get; set; }
        public List<LookUpDataEntity> PositionsList { get; set; }
        public List<LookUpDataEntity> LocationsList { get; set; }
        public List<LookUpDataEntity> DepartmentsList { get; set; }
        public List<LookUpDataEntity> EmploymentStatusList { get; set; }
        public List<UserLoginModel> EmployeesList { get; set; }

        public List<UserLoginModel> EmployeeList { get; set; }
        public List<EmployeeAlert> EmployeeAlertList { get; set; }
    }
}
