using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ModuleMetaData))]
    public partial class Module
    {
        public bool IsModuleVisible { get; set; }
        public bool IsModuleEditable { get; set; }
    }

    public partial class ModuleMetaData
    {
    }
}
