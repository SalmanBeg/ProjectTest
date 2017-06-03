using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace HRMS.Service.Models.EDM
{
    public partial class ApplicantEducation
    {
        public List<ApplicantEducation> ApplicantEducationList { set; get; }
    }
    public partial class ApplicantEducationMetaData
    {
        public ApplicantEducationMetaData() { }
        [Required(ErrorMessage = "Enter univiersity.")]
        public string University { get; set; }
        [Required(ErrorMessage = "Enter degree.")]
        public string Degree { get; set; }
        //[Required(ErrorMessage = "Enter from date.")]
        //[DataType(DataType.Date)]
        //public Nullable<System.DateTime> FromDate { get; set; }
        //[Required(ErrorMessage = "Enter to date.")]
        //[DataType(DataType.Date)]
        //public Nullable<System.DateTime> ToDate { get; set; }
        [Required(ErrorMessage = "Enter activities.")]
        public string Activities { get; set; }

        [Display(Name = "From  Date")]     
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FromDate { get; set; }
        
        [DisplayName("To Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ToDate { get; set; }



       
    }
}
