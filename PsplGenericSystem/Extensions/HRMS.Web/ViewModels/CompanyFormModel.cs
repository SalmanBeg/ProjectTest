using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using System.Web.Mvc;

namespace HRMS.Web.ViewModels
{
    public class CompanyFormModel
    {
        public CompanyFormModel()
        {
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
        }
        public CompanyInfo CompanyInfo { get; set; }
        public GeneralEnum.Status statusList { get; set; }
        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }
    }
}