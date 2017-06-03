using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
     [MetadataType(typeof(RoundingMetaData))]
     public partial class Rounding
     {
        [Display(Name = "Work Start Type")]
        public string WorkStartTypeName { get; set; }
        [Display(Name = "Work End Type")]
        public string WorkEndTypeName { get; set; }
        [Display(Name = "Lunch Start Type")]
        public string LunchStartTypeName { get; set; }
        [Display(Name = "Lunch End Type")]
        public string LunchEndTypeName { get; set; }
        [Display(Name = "Break Start Type")]
        public string BreakStartTypeName { get; set; }
        [Display(Name = "Break End Type")]
        public string BreakEndTypeName { get; set; }
     }
    public partial class RoundingMetaData
    {
        public RoundingMetaData()
        {


        }


        public int RoundingId { get; set; }
        public Guid RoundingPolicyCode { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Rounding Description is required")]
        public string RoundingDescription { get; set; }
        [Display(Name = "Start Type")]
        [Required(ErrorMessage = "Work Start Type is required")]
        public Int16 StartRoundType { get; set; }
        [Display(Name = "Start Minutes")]
        [Required(ErrorMessage = "Work Start Minutes is required")]
        public Int16 StartRoundMinutes { get; set; }
        [Display(Name = "End Type")]
        [Required(ErrorMessage = "Work End Type is required")]
        public Int16? EndRoundType { get; set; }
        [Display(Name = "End  Minutes")]
        [Required(ErrorMessage = "Work End Minutes is required")]
        public Int16? EndPunchMinutes { get; set; }
        [Display(Name = "Start Type")]
        public Int16? LunchStartRoundType { get; set; }
        [Display(Name = "Start Minutes")]
        public Int16? LunchStartRoundMinutes { get; set; }
        [Display(Name = "End Type")]
        public Int16 LunchEndRoundType { get; set; }
        [Display(Name = "End  Minutes")]
        public Int16 LunchEndRoundTMinutes { get; set; }
        [Display(Name = "Start Type")]
        public Int16 BreakStartRoundType { get; set; }
        [Display(Name = "Start Minutes")]
        public Int16 BreakStartRoundMinutes { get; set; }
        [Display(Name = "End Type")]
        public Int16 BreakEndRoundType { get; set; }
        [Display(Name = "End Minutes")]
        public Int16 BreakEndRoundTMinutes { get; set; }
        [Display(Name = "Rounding Method")]
        public string RoundingMethod { get; set; }
        [Display(Name = "Report Exceptions")]
        public bool RptExceptions { get; set; }
        [Display(Name = "Early In")]
        public Int16? ReportEarlyIn { get; set; }
        [Display(Name = "Early Out")]
        public Int16? ReportEarlyOut { get; set; }
        [Display(Name = "Late In")]
        public Int16 ReportLateIn { get; set; }
        [Display(Name = "Late Out")]
        public Int16 ReportLateOut { get; set; }
        [Display(Name = "Lunch Under")]
        public Int16? ReportLunchUnder { get; set; }
        [Display(Name = "Lunch Over")]
        public Int16? ReportLunchOver { get; set; }
        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }


    }
}
