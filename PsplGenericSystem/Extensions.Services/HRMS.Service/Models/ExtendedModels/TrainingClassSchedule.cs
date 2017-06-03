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
    [MetadataType(typeof(TrainingClassScheduleMetaData))]
    public partial class TrainingClassSchedule
    {
        public string TrainingClassName { get; set; }
    }
    public partial class TrainingClassScheduleMetaData
    {
       
        public int TrainingClassScheduleId { get; set; }      
        public int TrainingClassScheduleCode { get; set; }
        public int CompanyId { get; set; }
        //[Display(Name = "Enroll Start Date")]
        //[DataType(DataType.DateTime)]       
        //public DateTime EnrollmentStartDate { get; set; }


        [Display(Name = "Enroll Start Date")]
        [Required(ErrorMessage = "Please enter Enrollment Start Date.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EnrollmentStartDate { get; set; }


        [Display(Name = "Enroll End Date")]
        [DataType(DataType.DateTime)]
       
        public DateTime EnrollmentEndDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
       
        public int ModifiedBy { get; set; }

    }

}
