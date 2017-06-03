using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(TimeTypeMetaData))]
    public partial class TimeType
    {
        
    }

    public class TimeTypeMetaData
    {
        public int TimeTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Boolean Status { get; set; }
    }
}
