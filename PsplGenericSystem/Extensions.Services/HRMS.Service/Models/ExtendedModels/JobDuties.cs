using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{

    [MetadataType(typeof(JobDutiesMetaData))]
    public partial class JobDuties
    {
        public string PriorityName { get; set; }
    }
    public partial class JobDutiesMetaData
    {

        public JobDutiesMetaData()
        {

        }
        [Required(ErrorMessage = "Please enter the Description of the JobDuty.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the JobDuty Category.")]
        public string Category { get; set; }
        //[Required(ErrorMessage = "Please Select the Priority.")]
        public Nullable<int> Priority { get; set; }
        //[Required(ErrorMessage = "Please enter the PercentageofTime.")]
        public Nullable<decimal> PercentageOfTime { get; set; }
        //[Required(ErrorMessage = "Please Select the Frequency.")]
        public Nullable<int> Frequency { get; set; }
        //[Required(ErrorMessage = "Please enter the Essential.")]
        public Nullable<int> Essential { get; set; }
        //[Required(ErrorMessage = "Please enter the other.")]
        public Nullable<int> Other { get; set; }
     }
}
