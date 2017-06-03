using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(RoundMinuteMetaData))]
   public partial class RoundMinute
    {
    }

    public partial class RoundMinuteMetaData
    {
        public RoundMinuteMetaData()
        {

        }

        public int RoundMinutesId { get; set; }
        [Required(ErrorMessage = "Round Minutes is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Round Value is Required")]
        public int Value { get; set; }
        public int CompanyId { get; set; }
        public Boolean Status { get; set; }
    }
}
