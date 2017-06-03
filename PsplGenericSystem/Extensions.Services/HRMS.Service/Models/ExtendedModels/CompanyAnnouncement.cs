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
    [MetadataType(typeof(CompanyAnnouncementMetaData))]
    public partial class CompanyAnnouncement
    {
        public bool AcknowledgementReq1
        {
            get
            {
                return (AcknowledgementReq != null);
            }
            set
            {
                AcknowledgementReq = value;
            }
        }

        public bool IsDraft1
        {
            get
            {
                return (IsDraft != null);
            }
            set
            {
                IsDraft = value;
            }
        }

        public string Author { get; set; }
    }

    public partial class CompanyAnnouncementMetaData
    {
        public CompanyAnnouncementMetaData()
        {

        }

        public int CompanyAnnouncementId { get; set; }
        public int CompanyId { get; set; }
        [Required(ErrorMessage="Title is required")]
        [Remote("IsTitleExists", "CompanyAnnouncement", AdditionalFields = "CompanyId,Title,CompanyAnnouncementId", ErrorMessage = "Title already exists")]
        public string Title { get; set; }
        public string Message { get; set; }
        
        [Display(Name = "Publish Start Date")]
        [Required(ErrorMessage = "Publish Start Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? PublishStartDate { get; set; }
        
        [Display(Name = "Publish End Date")]
        [Required(ErrorMessage = "Publish End Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? PublishEndDate { get; set; }
        
        public bool AcknowledgementReq { get; set; }
        public int AttachmentId { get; set; }
        [Display(Name = "Save As Draft")]
        public bool IsDraft { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
