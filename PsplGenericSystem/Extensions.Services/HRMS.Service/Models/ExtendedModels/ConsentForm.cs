using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ConsentFormsMetaData))]
    public partial class ConsentForms
    {
        public int UserId { get; set; }
        public int OnBoardingProfileId { get; set; }
        public bool Active1
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
        public bool DisplayDocInConsent1
        {
            get
            {
                return DisplayDocInConsent.GetValueOrDefault();
            }
            set 
            { 
                DisplayDocInConsent = value;
            }
        }
        public bool EnableUploadLink1
        {
            get
            {
                return EnableUploadLink.GetValueOrDefault();
            }
            set { EnableUploadLink = value; }
        }
    }
    public partial class ConsentFormsMetaData
    {
        public int ConsentFormId { get; set; }
        public System.Guid ConsentCode { get; set; }
      
        public int CompanyId { get; set; }
        public int ConsentType { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public int AttachmentFileId { get; set; }
        public Nullable<bool> DisplayDocInConsent { get; set; }
        public Nullable<bool> EnableUploadLink { get; set; }
      //  public string OnBoardingProfileName { get; set; }
      
        [Display(Name = "Document Name")]
        public string DocumentName { get; set; }
        public DateTime UploadedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
   
   
    }
}
