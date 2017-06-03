using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(StateProvinceMetaData))]
    public partial class StateProvince
    {
    }
    public partial class StateProvinceMetaData
    {
      
       public int StateProvinceId { get; set; }
       public string StateProvinceCode { get; set; }
       public string CountryRegionCode { get; set; }
       public bool IsOnlyStateProvinceFlag { get; set; }
       public string StateName { get; set; }
    }
}
