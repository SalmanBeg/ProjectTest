using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ModuleSecurityMetaData))]
    public partial class ModuleSecurity
    {
    }
    public partial class ModuleSecurityMetaData
    {
        public ModuleSecurityMetaData()
        {

        }
        public int ModuleId { get; set; }
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
    }
}
