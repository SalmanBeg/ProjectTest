using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class ReviewFormModel
    {
        public ReviewFormModel()
        {

        }
        public Review Review { get; set; }
        public Reviewee Reviewee { get; set; }
        public Reviewer Reviewer { get; set; }
        public ReviewerEmployee ReviewerEmployee { get; set; }
        public ReviewMaster ReviewMaster { get; set; }
        public ReviewSchedule ReviewSchedule { get; set; }
        public ReviewScore ReviewScore { get; set; }
        public int Reviewee1 { get; set; }
        public int Reviewee2 { get; set; }
        public int Scheduler1 { get; set; }
        public int Scheduler2 { get; set; }


        public List<LookUpDataEntity> RevieweeList1 { get; set; }
        public List<LookUpDataEntity> RevieweeList2 { get; set; }
        public List<LookUpDataEntity> SchedulerList1 { get; set; }
        public List<LookUpDataEntity> SchedulerList2 { get; set; }

     

    }
}