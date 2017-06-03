using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;


namespace HRMS.Web.ViewModels
{
    public class InterviewFormModel
    {
        public InterviewFormModel()
        {  

            InterviewType = new List<LookUpDataEntity>();
            InterviewRoom = new List<LookUpDataEntity>();
            InterviewStatus = new List<LookUpDataEntity>();
            InterviewersList = new List<Interviewers>();
            
        }
        public Interview Interview { get; set; }
        public List<UserLoginModel> EmployeeList { get; set; }
        public List<LookUpDataEntity> InterviewType { get; set; }
        public List<LookUpDataEntity> InterviewRoom { get; set; }
        public List<LookUpDataEntity> InterviewStatus { get; set; }      
        public string InterviewersIdList { get; set; }
        public List<Interviewers> InterviewersList { get; set; }
        //public int ApplicantId { get; set; }
        //public string ApplicantName { get; set; }
        //public int JobProfileId { get; set; }
        //public string JobTitle { get; set; }

    }
    public class Interviewers
    {
        public int InterviewerId { get; set; }
        public string InterviewerName { get; set; }
        public bool InterviewerStatus { get; set; }
        

    }
}