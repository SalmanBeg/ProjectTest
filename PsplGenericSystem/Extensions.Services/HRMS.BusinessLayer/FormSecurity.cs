using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace HRMS.BusinessLayer
{
   public class FormSecurity
    {
       public FormSecurity()
       {
           ModuleList = new List<ModuleSecurity>();
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
        [Required(ErrorMessage = "Please enter a routeattribute.")]
        public string RouteAttribute { get; set; }
        public int CompanyId { get; set; }

        #region DropDown Loading
        [Display(Name = "Module")]
        [Required(ErrorMessage = "Please select module.")]
        public int ModuleId { get; set; }
        public List<ModuleSecurity> ModuleList { get; set; }

        #endregion
    }
}
