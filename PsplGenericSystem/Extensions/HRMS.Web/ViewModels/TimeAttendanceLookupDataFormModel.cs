using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class TimeAttendanceLookupDataFormModel
    {

        public TimeAttendanceLookupDataFormModel()
        {
            TAMasterTableList = new List<TimeAttendanceLookupData>();
        }
        public string TableName { get; set; }

        public List<TimeAttendanceLookupData> TAMasterTableList { get; set; }

    }
}