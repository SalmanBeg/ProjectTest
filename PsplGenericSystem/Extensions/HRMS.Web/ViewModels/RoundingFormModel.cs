using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class RoundingFormModel
    {

        public RoundingFormModel()
        {
            RoundTypeList = new List<RoundType>();
            RoundMinuteList = new List<RoundMinute>();
        }

        public Rounding Rounding { get; set; }
        public List<Rounding> RoundingList { get; set; }

        #region Dropdown Properties

        public List<RoundType> RoundTypeList { get; set; }
        public List<RoundMinute> RoundMinuteList { get; set; }

        #endregion

    }

    
}