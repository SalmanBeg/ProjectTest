using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using HRMS.Common.Helpers;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class OnBoardingFormModel
    {
        public OnBoardingFormModel()
        {
            OnBoarding = new OnBoarding();
            ConsentForm = new List<ConsentForms>();
            FilesDB = new List<FilesDB>();
        }

        public OnBoarding OnBoarding { get; set; }
        public List<ConsentForms> ConsentForm { get; set; }
        public List<FilesDB> FilesDB { get; set; }
    }
}