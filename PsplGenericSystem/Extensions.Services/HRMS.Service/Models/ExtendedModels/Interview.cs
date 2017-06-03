using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRMS.Service.Models.EDM
{
   
        [MetadataType(typeof(InterviewMetaData))]
        public partial class Interview
        {
            public bool SendInterviewerEmail1
            {
                get
                {
                    return SendInterviewerEmail.GetValueOrDefault();
                }
                set
                {
                    SendInterviewerEmail = value;
                }
            }
            public bool SendCandidateEmail1
            {
                get
                {
                    return SendCandidateEmail.GetValueOrDefault();
                }
                set
                {
                    SendCandidateEmail = value;
                }
            }
            public string InterviewType { get; set; }
            public string Room { get; set; }
            public string InterviewStatus { get; set; }
            [Display(Name="Applicant Name")]
            public string ApplicantName { get; set; }
            [Display(Name = "Job Title")]
            public string JobTitle { get; set; }
            [Display(Name = "InterviewTime")]
            public string ScheduledInterviewTime { get; set; }
        }

        public partial class InterviewMetaData
        {
            public InterviewMetaData()
            { 
                 
            }
            
            [Display(Name= "Interview Type")]
            public int Type { get; set; }
            [Required(ErrorMessage = "Please select the interview date")]
            [Display(Name = "Interview Date")]
            public DateTime InterviewDate { get; set; }
            [Display(Name = "Interview Room")]
            public int InterviewRoom { get; set; }
            //[DisplayFormat(DataFormatString = "{0: hh:mm:ss}")]
            [Required(ErrorMessage = "Please select the interview Time")]
            [Display(Name = "Interview Time")]
            public DateTime InterviewTime { get; set; }
            [Display(Name = "Instructions to Candidates")]
            public string CandidateInstructions { get; set; }
            [Display(Name = "Instructions to Interviewers")]
            public string InterviewerInstructions { get; set; }
            [Display(Name = "Send Interview Schedule Email to Candidate")]
            public bool SendCandidateEmail { get; set; }
            [Display(Name = "Send Interview Schedule and candidate resume to Interviewer")]
            public bool SendInterviewerEmail { get; set; }
            
                  
        }
}

    