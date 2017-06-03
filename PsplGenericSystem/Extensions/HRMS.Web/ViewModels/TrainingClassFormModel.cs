using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class TrainingClassFormModel
    {
        public TrainingClassFormModel()
        {
           
        }
        public TrainingClassScheduleDate TrainingClassScheduleDate { get; set; }
        public TrainingClassSchedule TrainingClassSchedule { get; set; }
        public TrainingClass TrainingClass { get; set; }

      
    }
}