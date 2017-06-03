using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class CompensationFormModel
    {
        public CompensationFormModel()
        {
            WageTypeList= new  List<LookUpDataEntity>();
            WageUnitList = new List<LookUpDataEntity>();
            
        }

        public CompensationProfile CompensationProfileObj { get; set; }


       public List<LookUpDataEntity> WageTypeList { get; set; }
       public List<LookUpDataEntity> WageUnitList { get; set; }

       public List<LookUpDataEntity> BenefitClassList { get; set; }


    }
}