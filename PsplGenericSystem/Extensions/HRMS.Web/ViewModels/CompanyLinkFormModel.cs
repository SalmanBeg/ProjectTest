using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class CompanyLinkFormModel
    {
        public CompanyLinkFormModel()
        { }

        public CompanyLink CompanyLink { get; set; }
        #region Dropdown Properties
        #endregion
    }
}