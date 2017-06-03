using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeNoConfigurationMetaData))]
    public partial class EmployeeNoConfiguration
    {
       
    }

    public partial class EmployeeNoConfigurationMetaData
    {
        public EmployeeNoConfigurationMetaData()
        {
        }        
       
        [Required(ErrorMessage = "Please enter prefix.")]
        public string Prefix { get; set; }
        [Required(ErrorMessage = "Please enter Start Value.")]
        public int StartValue { get; set; }
        [Required(ErrorMessage = "Please enter increment value")]
        public int IncrementValue { get; set; }
    }
}
