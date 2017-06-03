using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class ManageMenuFormModel
    {
        public ManageMenuFormModel()
        {
            CompanyLevelSecurity = new CompanyLevelSecurity();
        }
        public CompanyLevelSecurity CompanyLevelSecurity { get; set; }
    }
}