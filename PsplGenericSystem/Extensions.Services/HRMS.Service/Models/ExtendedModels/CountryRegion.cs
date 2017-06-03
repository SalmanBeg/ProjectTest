using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(CountryRegioMetaData))]
    public partial class CountryRegion
    {
    }
     public partial class CountryRegioMetaData
     {
         //public CountryRegioMetaData()
         //{

         //}
         public int CountryRegionId { get; set; }
         public string CountryRegionCode { get; set; }
         public string Name { get; set; }
     }

}
