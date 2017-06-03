using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(FormMetaData))]
    public partial class Form
    {
        public bool IsFormVisible { get; set; }
        public bool IsFormEditable { get; set; }
        public int RoleId { get; set; }
    }
    public partial class FormMetaData
    {
        public FormMetaData()
        {
          //  ModuleList = new List<ModuleSecurity>();

        }
        public int FormId { get; set; }
        public string FormCode { get; set; }
        [Display(Name = "Form Name")]
        [Required(ErrorMessage = "Please enter a form name.")]
        public string FormName { get; set; }
        [Display(Name = "Controller Name")]
        [Required(ErrorMessage = "Please enter a controller name.")]
        public string ControllerName { get; set; }
        [Display(Name = "Action Name")]
        [Required(ErrorMessage = "Please enter a action name.")]
        public string ActionName { get; set; }
        [Display(Name = "Route Attribute")]        
        public string RouteAttribute { get; set; }
        public int CompanyId { get; set; }

        #region DropDown Loading
        [Display(Name = "Module")]
        [Required(ErrorMessage = "Please select module.")]
        public int ModuleId { get; set; }
      //  public List<ModuleSecurity> ModuleList { get; set; }

        #endregion
    }
}

