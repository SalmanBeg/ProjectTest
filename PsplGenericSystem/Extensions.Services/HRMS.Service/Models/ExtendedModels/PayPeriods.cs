using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(PayPeriodMetaData))]
    public partial class PayPeriods
    {

        [Display(Name = "Period Type")]
        public string PayPeriodTypename { get; set; }
        [Display(Name = "Period Days")]
        public int PayPeriodDays { get; set; }

    }

    public partial class PayPeriodMetaData
    {
        public PayPeriodMetaData()
        { }

        public int PayPeriodId { get; set; }
        public Guid PayPeriodCode { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "PayPeriod Description is required")]
        public string PayPeriodDescription { get; set; }
        [Display(Name = "Type")]
        [Required(ErrorMessage = "PayPeriod Type is required")]
        public int PayPeriodTypeId { get; set; }
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime? StartDateTime { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDateTime { get; set; }
        [Display(Name = "Start Day Of Week")]
        public string StartDayOfWeek { get; set; }
        [Display(Name = "Build Next Schedule?")]
        public bool NextSchedule { get; set; }
        public int CompanyId { get; set; }
    }
}
