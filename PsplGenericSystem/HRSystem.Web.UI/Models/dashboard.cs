using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRSystem.Web.UI.Models
{
    public class dashboard
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        public List<HRSystem.Security.Authentication.Application> UserApplications { get; set; }
    }
}