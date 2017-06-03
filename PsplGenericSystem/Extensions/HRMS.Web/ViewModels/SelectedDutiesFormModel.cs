using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class SelectedDutiesFormModel
    {

        public SelectedDutiesFormModel()
        {   
        }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Priority { get; set; }
        public bool DutiesChecked { get; set; }
        public int JobDutyId { get; set; }
        public JobProfile jobProfile { get; set; }
    }
}