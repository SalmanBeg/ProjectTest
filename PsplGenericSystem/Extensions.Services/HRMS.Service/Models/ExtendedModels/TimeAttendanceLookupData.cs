using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(TimeAttendanceLookupDataMetaData))]
   public partial class TimeAttendanceLookupData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Value is Required")]
        public int Value { get; set; }
        public int CompanyId { get; set; }
        public bool? Status { get; set; }
        public string TableName { get; set; }
        public bool RowChecked { get; set; }
    }

    public partial class TimeAttendanceLookupDataMetaData
    {
        public TimeAttendanceLookupDataMetaData()
        {
        }

    
    }
}
