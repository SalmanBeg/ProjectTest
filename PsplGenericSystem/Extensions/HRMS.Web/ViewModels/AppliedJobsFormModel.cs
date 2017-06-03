using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class AppliedJobsFormModel
    {
        public int JobProfileId { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public int Rating { get; set; }
        public int? JobStatus { get; set; }
        public DateTime JobAppliedOn { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHired { get; set; }
        public int JobApplicantId { get; set; }
    }
}