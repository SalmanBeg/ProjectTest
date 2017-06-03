using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Common.Enums;
using HRMS.Service;

namespace HRMS.Service.Models.EDM
{

    [MetadataType(typeof(JobApplicantMetaData))]
    public partial class JobApplicant
    {
        public string File { get; set; }     
        public int Gender { get; set; }             
        public string Title { get; set; }
        public int? AppliedStatus { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyName { get; set; }
        
        
          
        public string Notes { get; set; }
        public int? Rating { get; set; }
        public int JobId { get; set; }
    }
    public partial class JobApplicantMetaData
    {
        public JobApplicantMetaData()
        {

        }
        [Required(ErrorMessage = "Please enter First name.")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
       // [Required(ErrorMessage = "Please enter Last name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please select Country.")]
        public int CountryId { get; set; }
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please select State.")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please enter your email address.")]
        [RegularExpression(@"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter the Phoneno.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please attach your Resume.")]
        public Nullable<int> ResumeAttachmentId { get; set; }
        [Required(ErrorMessage = "Describe yourself.")]
        public string ApplicantDescription { get; set; }
     
    }

}
