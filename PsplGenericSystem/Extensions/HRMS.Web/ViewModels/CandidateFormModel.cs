using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class CandidateFormModel
    {
        public CandidateFormModel()
        {
            JobApplicantsList = new List<JobApplicant>();
            AppliedjobsList = new List<AppliedJobsFormModel>();
        }
        public List<JobApplicant> JobApplicantsList { get; set; }
        public List<AppliedJobsFormModel> AppliedjobsList { get; set; }
    }
}