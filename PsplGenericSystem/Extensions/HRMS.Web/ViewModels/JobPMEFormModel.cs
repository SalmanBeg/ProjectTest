using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class JobPMEFormModel
    {
        public JobPMEFormModel()
        {
            
            EssentialList = new List<LookUpDataEntity>();
            FrequencyList = new List<LookUpDataEntity>();
        }
        public JobPME JobPME { get; set; }
        public List<LookUpDataEntity> EssentialList { get; set; }
        public List<LookUpDataEntity> FrequencyList { get; set; }

    }
}