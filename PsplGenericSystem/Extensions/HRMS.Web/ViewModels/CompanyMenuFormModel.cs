using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class CompanyMenuFormModel
    {
        public CompanyMenuFormModel()
        {
            Modules = new List<Module>();
            Forms = new List<Form>();
        }
        public Form form { get; set; }
        public IList<OrganizationMenu> ListOrganizationMenus { get; set; }
        public List<Module> Modules { get; set; }
        public List<Form> Forms { get; set; }
        public bool IsVisible1
        {
            get
            {
                return (form != null && form.IsVisible != null);
            }
            set { form.IsVisible = value; }
        }
    }
}