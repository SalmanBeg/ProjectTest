using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class JobDutiesFormModel
    {

        public JobDutiesFormModel()
        {
            CategoryList = new List<LookUpDataEntity>();
            PriorityList = new List<LookUpDataEntity>();
            FrequencyList = new List<LookUpDataEntity>();
            EssentialList = new List<LookUpDataEntity>();
            OtherList = new List<LookUpDataEntity>();

        }

        public JobDuties JobDuties { get; set; }

        public List<LookUpDataEntity> CategoryList { get; set; }
        public List<LookUpDataEntity> PriorityList { get; set; }
        public List<LookUpDataEntity> FrequencyList { get; set; }
        public List<LookUpDataEntity> EssentialList { get; set; }
        public List<LookUpDataEntity> OtherList { get; set; }
        
    }


}