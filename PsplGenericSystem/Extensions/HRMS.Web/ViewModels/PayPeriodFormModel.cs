using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class PayPeriodFormModel
    {

        public PayPeriodFormModel()
        {
            PayPeriodList = new List<PayPeriods>();
            PayPeriodTypeList = new List<PayPeriodType>();
        }

        public PayPeriods PayPeriod { get; set; }

        public List<PayPeriods> PayPeriodList { get; set; }
        public List<PayPeriodType> PayPeriodTypeList { get; set; }
    }
}