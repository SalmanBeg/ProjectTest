using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{

    public class OrganizationMenu
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string ModuleName { get; set; }
        public int ModuleOrder { get; set; }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string RouteAttribute { get; set; }
        public int FormOrderNo { get; set; }
        public string DisplayFormName { get; set; }
        public int ModuleOrderNo { get; set; }
        public int ControllerNameList { get; set; }
        public bool IsModuleVisible { get; set; }
        public bool IsFormVisible { get; set; }
        public bool IsModuleEditable { get; set; }
        public bool IsFormEditable { get; set; }

    }
}
