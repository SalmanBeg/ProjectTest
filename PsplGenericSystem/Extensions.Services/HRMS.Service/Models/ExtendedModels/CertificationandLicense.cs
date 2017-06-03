using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using HRMS.Service;
using System.ComponentModel;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(CertificationandLicenseMetaData))]
    public partial class CertificationandLicense
    {
        public string CertificationType { get; set; }
    }
    public partial class CertificationandLicenseMetaData
    {
        public CertificationandLicenseMetaData()
        {

        }
        public int CertificationLicensesId { get; set; }
       
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Type Required")]
        public int Type { get; set; }
        public int Name { get; set; }
        public int Certification { get; set; }
        [Display(Name = "License Number")]
        public string LicenseNumber { get; set; }
        [Display(Name = "License Country")]
        public int LicenseCountry { get; set; }
        [Display(Name = "License State")]
        public int LicenseState { get; set; }
        public string School { get; set; }
        public int Endorsements { get; set; }
        public int Areas { get; set; }
        [DisplayName("First Name")]
        public string FileName { get; set; }
        public int Document { get; set; }
        [Display(Name = "Issue Date")]
        [DataType(DataType.Date)]
        public DateTime? IssueDate { get; set; }
        [Display(Name = "Renewal Date")]
        [DataType(DataType.Date)]
        public DateTime? RenewalDate { get; set; }
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
   

    }
}
