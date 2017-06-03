using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class HolidayMasterFromModel
    {
        public HolidayMasterFromModel()
        {
            PayTypeList = new List<PayType>();
            HolidayMasterList = new List<HolidayMaster>();
        }

        public HolidayGroup HolidayGroup { get; set; }
        public Holiday Holiday { get; set; }
        public HolidayMaster HolidayMaster { get; set; }

        #region Dropdown Properties
        public List<PayType> PayTypeList { get; set; }
        public List<HolidayMaster> HolidayMasterList { get; set; }
        #endregion
    }
}