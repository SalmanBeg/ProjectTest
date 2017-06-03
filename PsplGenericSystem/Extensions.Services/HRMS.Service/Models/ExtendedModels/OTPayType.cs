using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(OTPayTypeMetaData))]
    public partial class OTPayType
    {
    }

    public partial class OTPayTypeMetaData
    {
        public OTPayTypeMetaData()
        { }

        public int OTPayTypeId { get; set; }
        [Required(ErrorMessage = "OTPayType Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "OTPayType Value is Required")]
        public int Value { get; set; }
        public int CompanyId { get; set; }
        public Boolean Status { get; set; }
    }
}
