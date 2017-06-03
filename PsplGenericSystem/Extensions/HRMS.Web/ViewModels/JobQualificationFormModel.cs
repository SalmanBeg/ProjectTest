using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class JobQualificationFormModel
    {
        public JobQualificationFormModel()
        {

         TypeList = new List<LookUpDataEntity>();
        }

        public JobQualification JobQualification { get; set; } 
        public List<LookUpDataEntity> TypeList { get; set; }
    }
    

}