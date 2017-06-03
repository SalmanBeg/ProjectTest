using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using System.Web.Mvc;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(CompanyDocumentMetaData))]
    public partial class CompanyDocument
    {
        //For bool null value
        public bool IsShowDocumentOnHomePage1
        {
            get
            {
                return (IsShowDocumentOnHomePage != null);
            }
            set
            {
                IsShowDocumentOnHomePage = value;
            }
        }

        public bool Status1
        {
            get
            {
                return (Status != null);
            }
            set
            {
                Status = value;
            }
        }

        public bool CompanyDocumentSendCriteria1
        {
            get
            {
                return (CompanyDocumentSendCriteria != null);
            }
            set
            {
                CompanyDocumentSendCriteria = value;
            }
        }

        //Virtual Columns
        public string File { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        //Select Criteria To send the Attachement Document
        [Display(Name = "External Email")]
        [Required(ErrorMessage = "Please enter email.")]
        public string ExternalEmail { get; set; }
        public string Email { get; set; }
        //Ids for Dropdown Lists
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public int EmploymentStatusId { get; set; }
        public bool CompanyDocumentSendCriteria { get; set; }
    }

    public partial class CompanyDocumentMetaData
    {
        public CompanyDocumentMetaData()
        {
            
        }

        public int CompanyDocumentId { get; set; }
        [Required(ErrorMessage = "title is required")]
        [Display(Name="Title")]
        [Remote("IsTitleExists", "CompanyDocument", AdditionalFields = "CompanyId,CompanyDocumentTitle,CompanyDocumentId", ErrorMessage = "Title already exists")]
        public string CompanyDocumentTitle { get; set; }
        [Display(Name = "Document Text")]
        public string CompanyDocumentText { get; set; }
        public int CompanyId { get; set; }
        [Required(ErrorMessage="Attachment is required")]
        [Display(Name="Attachment")]
        public int AttachmentId { get; set; }
        [Required(ErrorMessage = "category is required")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        [Display(Name = "Show on home page")]
        public bool IsShowDocumentOnHomePage { get; set; }
        [Display(Name = "From Address")]
        public string FromAddress { get; set; }
        public bool Status { get; set; }
        public int SendTo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
