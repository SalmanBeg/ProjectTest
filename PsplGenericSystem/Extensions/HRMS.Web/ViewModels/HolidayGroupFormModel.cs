using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class HolidayGroupFormModel
    {
        public HolidayGroupFormModel()
        {
            HolidayGroupList = new List<HolidayGroup>();
            HolidayList = new List<Holiday>();
        }

        public HolidayGroup HolidayGroup { get; set; }


        public List<HolidayGroup> HolidayGroupList { get; set; }
        public List<Holiday> HolidayList { get; set; }

    }
}