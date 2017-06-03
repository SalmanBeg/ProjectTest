using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(TrainingClassMetaData))]
     public partial class TrainingClass
    {
        public string File { get; set; }
        public bool hasSchedule { get; set; }
        public bool hasResource { get; set; }
    }
    public class TrainingClassMetaData
    {
        [Display(Name="Class Name")]
    [Required(ErrorMessage="Enter class name.")]
        public string TrainingClassName { get; set; }
        [Display(Name="Description")]
        public string TrainingClassDescription { get; set; }
        [Display(Name="Cost")]
        [Required(ErrorMessage="Enter cost.")]
        public Nullable<decimal> TrainingClassCost { get; set; }
        [Display(Name="Hours")]
        public Nullable<decimal> TrainingClassHours { get; set; }
        [Display(Name="Image")]
        public Nullable<int> TrainingClassImage { get; set; }
    }
}
