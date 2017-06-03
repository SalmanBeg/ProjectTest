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
    [MetadataType(typeof(TrainingEmployeeViewMetaData))]
    public partial class TrainingEmployeeView
    {

    }
    public partial class TrainingEmployeeViewMetaData
    {
        
        [Display(Name = "Class Name")]
        [Required(ErrorMessage = "Enter Class Name.")]
        public string ClassName { get; set; }
        [Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; }
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }
        [Display(Name = "Certificate File")]
        public int CertificateFile { get; set; }
        //public DateTime EnrollmentStartDate { get; set; }
        //public DateTime EnrollmentEndDate { get; set; }

    }
}
