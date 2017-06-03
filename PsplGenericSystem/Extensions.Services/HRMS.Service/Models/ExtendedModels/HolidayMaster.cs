using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(HolidayMasterMetaData))]
    public partial class HolidayMaster
    {
        [Display(Name = "Holiday Group Name")]
        public string HolidayGroupName { get; set; }
        [Display(Name = "Holiday Description")]
        public string HolidayDescription { get; set; }
        [Display(Name = "Holiday")]
        public string HolidayName { get; set; }
        [Display(Name = "Holiday Checked")]
        public Boolean HolidayChecked { get; set; }
        public string BankFromAccount { get; set; } 
    }

    public partial class HolidayMasterMetaData
    {
        public int HolidayMasterId { get; set; }
        public int HolidayGroupId { get; set; }
        public int HolidayId { get; set; }
        [Display(Name = "Hours")]
        public Double? HoursBenefit { get; set; }
        [Display(Name = "Work")]
        public Boolean WorkBenefit { get; set; }
        [Display(Name = "Overtime")]
        public Boolean OverTimeBenefit { get; set; }
        [Display(Name = "Doubletime")]
        public Boolean DoubleTimeBenefit { get; set; }
        [Display(Name = "Days Before")]
        public int? DaysBefore { get; set; }
        [Display(Name = "Days After")]
        public int? DaysAfter { get; set; }
        [Display(Name = "Dollar per Hour")]
        public Decimal? DollarPerHour { get; set; }
        public Boolean BankHoursIfWorked { get; set; }
        public string BankToAccount { get; set; }
        public int CompanyId { get; set; }

        
    }
}
