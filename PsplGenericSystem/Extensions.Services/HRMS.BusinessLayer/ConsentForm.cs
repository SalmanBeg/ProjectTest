using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
   public class ConsentForm
    {
        public int ConsentFormId { get; set; }
        public string ConsentCode { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public int ConsentType { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int AttachmentFileId { get; set; }
        public bool DisplayDocInConsent { get; set; }
        public bool EnableUploadLink { get; set; }
      //  public string OnBoardingProfileName { get; set; }
        public int OnBoardingProfileId { get; set; }
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }
        public DateTime UploadedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
