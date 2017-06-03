using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class SelectedQualificationsFormModel
    {
        public SelectedQualificationsFormModel()
        { 
        }
        public string Description { get; set; }
        public string Proficiency { get; set; }
        public string SubjectArea { get; set; }
        public bool QualificationsChecked { get; set; }
        public int JobQualificationId { get; set; }
    }
}