using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class SelectedPMEFormModel
    {
        public SelectedPMEFormModel()
        {
        
        }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Frequency { get; set; }
        public int PMEId { get; set; }
        public bool PMEChecked { get; set; }


    }

}