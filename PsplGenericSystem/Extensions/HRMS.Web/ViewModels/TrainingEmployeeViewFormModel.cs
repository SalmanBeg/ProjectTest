using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class TrainingEmployeeViewFormModel
    {
        public TrainingEmployeeViewFormModel()
        {
            
        }
        public TrainingEmployeeView TrainingEmployeeView { get; set; }
        public TrainingClassScheduleDate TrainingClassScheduleDate { get; set; }
        
        [Display(Name = "Class Name")]
        [Required(ErrorMessage = "Enter Class Name.")]
        public string ClassName { get; set; }
        [Display(Name = "Completion Date")]
        public DateTime? CompletionDate { get; set; }
        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; set; }
        [Display(Name = "Certificate File")]
        public int CertificateFile { get; set; }
        [Display(Name = "Attachment")]
        public string File { get; set; }
        
    }
}