using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class JobApplicantFormModel
    {
        JobApplicant JobApplicant { get; set; }
        JobApplied JobApplied { get; set; }
        JobProfile JobProfile { get; set; }
        CompanyInfo CompanyInfo { get; set; }
    }
}