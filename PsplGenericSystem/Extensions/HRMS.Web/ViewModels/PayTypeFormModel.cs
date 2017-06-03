using HRMS.Service.Models;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class PayTypeFormModel
    {
        public PayTypeFormModel()
        {
            TimeTypeList = new List<TimeType>();
            PayTypeList = new List<PayType>();
        }

        public PayType PayType { get; set; }

        public List<TimeType> TimeTypeList { get; set; }
        public List<PayType> PayTypeList { get; set; }
    }
}