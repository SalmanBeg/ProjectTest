using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(PayTypeMetaData))]
    public partial class PayType
    {
    }


    public class PayTypeMetaData
    {
        [Required(ErrorMessage = "Pay Type Code is required")]
        [Display(Name = "Pay Type Code")]
        public int PayTypeId { get; set; }
        [Display(Name = "Pay Code")]
        [Required(ErrorMessage = "Pay Code is required")]
        public string PayCode { get; set; }
        [Display(Name = "Pay Type Code")]
        public string PayTypeCode { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Punch Type")]
        public string PunchType { get; set; }
        [Display(Name = "Time Type")]
        public int? TimeTypeId { get; set; }
        [Display(Name = "Exclude from Overtime")]
        public Boolean AccrueToOT { get; set; }
        [Display(Name = "Map to HR")]
        public string MapToHR { get; set; }
        [Display(Name = "Map to Payroll")]
        public string MapToPayroll { get; set; }
        [Display(Name = "Display")]
        public Boolean Display { get; set; }
        [Display(Name = "Rate Factor")]
        public decimal? RateFactor { get; set; }
        [Display(Name = "GL Code")]
        public string GLCode { get; set; }
        [Display(Name = "Is default?")]
        public Boolean IsDefault { get; set; }
        [Display(Name = "Payroll Code")]
        public string PayrollCode { get; set; }
        [Display(Name = "Bypass Rule?")]
        public Boolean BypassBRM { get; set; }
        public int? CompanyId { get; set; }
    }
}
