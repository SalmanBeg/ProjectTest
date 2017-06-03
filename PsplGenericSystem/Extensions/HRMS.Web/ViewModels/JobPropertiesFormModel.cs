using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class JobPropertiesFormModel
    {
        public JobPropertiesFormModel()
        {
            JobDuties = new List<JobDuties>();
            JobQualifications= new List<JobQualification>();
            JobPME = new List<JobPME>();

        }

        public bool IsChecked { get; set; }
        public string PropertyName { get; set; }
        public int PropertyId { get; set; }
        public List<JobDuties> JobDuties { get; set; }
        public List<JobQualification> JobQualifications { get; set; }
        public List<JobPME> JobPME { get; set; }
    }
}