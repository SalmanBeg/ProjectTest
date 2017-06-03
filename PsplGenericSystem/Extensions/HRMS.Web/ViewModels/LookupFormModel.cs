using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using HRMS.BusinessLayer;
using System.ComponentModel.DataAnnotations;
using HRMS.Service.Models.EDM;


namespace HRMS.Web.ViewModels
{
    public class LookupFormModel
    {
        public LookupFormModel()
        {
            LookUpDataEntitylist = new List<LookUpDataEntity>();
        }
        public string TableName { get; set; }
        public int CompanyId { get; set; }
        public List<LookUpDataEntity> LookUpDataEntitylist { get; set; }
    }
}