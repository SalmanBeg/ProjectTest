using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class OvertimePolicyFormModel
    {
        public OvertimePolicyFormModel()
        {
            OTPolicyTypeList = new List<OTPolicyType>();
            OTPayTypeList = new List<OTPayType>();
            OverTimePolicyList = new List<OverTimePolicy>();
        }

        public OverTimePolicy OverTimePolicy { get; set; }

        public List<OTPolicyType> OTPolicyTypeList { get; set; }
        public List<OTPayType> OTPayTypeList { get; set; }
        public List<OverTimePolicy> OverTimePolicyList { get; set; }
    }
}