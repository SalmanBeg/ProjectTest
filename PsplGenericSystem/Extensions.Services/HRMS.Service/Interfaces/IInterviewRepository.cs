using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces

{
    public interface IInterviewRepository
    {
        /// <summary>
        /// To create a new interview template
        /// </summary>
        /// <param name="interviewObj"></param>
        /// <param name="interviewerList"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int CreateInterview(Interview interviewObj, List<JobInterviewers> interviewerList);
        /// <summary>
        /// To show all the interview templates in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<Interview> InterviewSelectAll(int companyId);
        /// <summary>
        /// To remove an interview schedule record based on record id
        /// </summary>
        /// <param name="deleteInterviewId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteInterview(int deleteInterviewId, int companyId);
        /// <summary>
        /// To update an interview schedule record based on record id
        /// </summary>
        /// <param name="interviewObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int UpdateInterview(Interview interviewObj);
        /// <summary>
        /// To select an interviewschedule details based on record id
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        Interview InterviewSelect(int interviewId);
        /// <summary>
        /// To pull interviewers associated to an interview template 
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobInterviewers> JobInterviewers(int interviewId);
        /// <summary>
        /// To relate an applicant,job,and interview template saving them in to a table
        /// </summary>
        /// <param name="applicantInterviewObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool ApplicantInterviews(ApplicantInterview applicantInterviewObj);
    }
}
