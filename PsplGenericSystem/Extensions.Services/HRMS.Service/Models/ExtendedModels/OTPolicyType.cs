using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(OTPolicyTypeMetaData))]
    public partial class OTPolicyType
    {
    }

    public partial class OTPolicyTypeMetaData
    {
        public OTPolicyTypeMetaData()
        { }

        public int OTPolicyTypeId { get; set; }
        [Required(ErrorMessage = "OTPolicyType Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "OTPolicyType Value is Required")]
        public int Value { get; set; }
        public int CompanyId { get; set; }
        public Boolean Status { get; set; }
    }
}
