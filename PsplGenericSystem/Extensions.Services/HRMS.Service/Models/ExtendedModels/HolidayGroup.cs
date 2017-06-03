using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(HolidayGroupMetaData))]
    public partial class HolidayGroup
    {

    }

    public partial class HolidayGroupMetaData
    {
        public int? HolidayGroupId { get; set; }
        public Guid? HolidayGroupCode { get; set; }
        [Display(Name = "Group Name")]
        [Required(ErrorMessage = "Group Name is required")]
        public string HolidayGroupName { get; set; }
        [Display(Name = "Description")]
        public string HolidayDescription { get; set; }
        public int? CompanyId { get; set; }
    }
}
