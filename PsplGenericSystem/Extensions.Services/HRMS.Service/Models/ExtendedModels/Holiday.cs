using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(HolidaysMetaData))]
    public partial class Holidays
    {
    }

    public partial class HolidaysMetaData
    {
        public HolidaysMetaData()
        {

        }

        public int? HolidayId { get; set; }
        [Display(Name = "Holiday Name")]
        public string HolidayName { get; set; }
        [Display(Name = "Date")]
        public DateTime HolidayDate { get; set; }
        public int? CompanyId { get; set; }
    }
}
