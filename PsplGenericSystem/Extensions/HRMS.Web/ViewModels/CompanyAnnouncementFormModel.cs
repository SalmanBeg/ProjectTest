using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class CompanyAnnouncementFormModel
    {
        public CompanyAnnouncementFormModel()
        {

        }

        public CompanyAnnouncement CompanyAnnouncement { get; set; }
        #region Dropdown Properties
        #endregion
    }
}