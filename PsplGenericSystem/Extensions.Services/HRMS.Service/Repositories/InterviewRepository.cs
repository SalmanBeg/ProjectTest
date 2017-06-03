using HRMS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.Models.ExtensionProc;
using EntityFrameworkExtras.EF6;

namespace HRMS.Service.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        /// <summary>
        /// Method Inserts Interview Details
        /// </summary>
        /// <param name="interviewObj"></param>
        /// <returns></returns>
        public int CreateInterview(Interview interviewObj, List<JobInterviewers> interviewerList)
        {
            int i = 0;
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var proc = new ExtendedStoredProcedures.InterviewInsert()
                            {
                                JobProfileId = interviewObj.JobProfileId,
                                CompanyId = interviewObj.CompanyId,
                                UserId = interviewObj.UserId,
                                Type = interviewObj.Type,
                                InterviewRoom = interviewObj.InterviewRoom,
                                CandidateId = interviewObj.CandidateId,
                                Status = interviewObj.Status,
                                InterviewerId = interviewObj.InterviewerId,
                                InterviewDate = interviewObj.InterviewDate,
                                InterviewTime = interviewObj.InterviewTime,
                                CandidateInstructions = interviewObj.CandidateInstructions,
                                InterviewerInstructions = interviewObj.InterviewerInstructions,
                                SendInterviewerEmail = interviewObj.SendInterviewerEmail,
                                SendCandidateEmail = interviewObj.SendCandidateEmail,
                                Feedback = interviewObj.Feedback,
                                CreatedBy = interviewObj.CreatedBy,

                                UdtJobInterviewers = interviewerList.Select(interviewobj => new ExtendedStoredProcedures.UdtJobInterviewers
                                {
                                    InterviewerId = interviewobj.InterviewerId
                                }).ToList(),

                            };

                    hrmsEntity.Database.ExecuteStoredProcedure(proc);
                    return proc.InterviewId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to Display all Added Interview Records in a grid
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>

        public List<Interview> InterviewSelectAll(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var interviewresult = hrmsEntity.usp_InterviewSelectAll(companyId).ToList();
                    return interviewresult.Select(interview => new Interview
                    {
                        ApplicantName = interview.ApplicantName,
                        JobTitle = interview.JobTitle,
                        JobProfileId = interview.JobProfileId,
                        InterviewId = interview.InterviewId,
                        CompanyId = interview.CompanyId,
                        UserId = interview.UserId,
                        Type = interview.Type,
                        InterviewType = interview.InterviewType,
                        InterviewRoom = interview.InterviewRoom,
                        Room = interview.Room,
                        InterviewStatus = interview.InterviewStatus,
                        CandidateId = interview.CandidateId,
                        Status = interview.Status,
                        InterviewerId = interview.InterviewerId,
                        InterviewDate = interview.InterviewDate,
                        InterviewTime = interview.InterviewTime,
                        CandidateInstructions = interview.CandidateInstructions,
                        InterviewerInstructions = interview.InterviewerInstructions,
                        SendInterviewerEmail = interview.SendInterviewerEmail,
                        SendCandidateEmail = interview.SendCandidateEmail,
                        Feedback = interview.Feedback,
                        CreatedBy = interview.CreatedBy
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to Display a Single Record of Interview using parameter interviewid
        /// </summary>
        /// <param name="interviewId"></param>
        /// <returns></returns>
        public Interview InterviewSelect(int interviewId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var interviewresult = hrmsEntity.usp_InterviewSelect(interviewId).ToList();
                    var interviewList = interviewresult.Select(interview => new Interview
                    {
                        ApplicantName = interview.ApplicantName,
                        JobTitle = interview.JobTitle,
                        JobProfileId = interview.JobProfileId,
                        InterviewId = interview.InterviewId,
                        CompanyId = interview.CompanyId,
                        UserId = interview.UserId,
                        Type = interview.Type,
                        InterviewRoom = interview.InterviewRoom,
                        CandidateId = interview.CandidateId,
                        Status = interview.Status,
                        InterviewerId = interview.InterviewerId,
                        InterviewDate = interview.InterviewDate,
                        InterviewTime = interview.InterviewTime,
                        CandidateInstructions = interview.CandidateInstructions,
                        InterviewerInstructions = interview.InterviewerInstructions,
                        SendInterviewerEmail = interview.SendInterviewerEmail,
                        SendCandidateEmail = interview.SendCandidateEmail,
                        Feedback = interview.Feedback,
                        CreatedBy = interview.CreatedBy
                    }).ToList();
                    return interviewList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to Update an existing Interview Record
        /// </summary>
        /// <param name="interviewObj"></param>
        /// <returns></returns>
        public int UpdateInterview(Interview interviewObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_InterviewUpdate(interviewObj.InterviewId, interviewObj.JobProfileId, interviewObj.CompanyId, interviewObj.UserId,
                               interviewObj.Type, interviewObj.InterviewRoom, interviewObj.CandidateId, interviewObj.Status, interviewObj.InterviewerId, interviewObj.InterviewDate,
                               interviewObj.InterviewTime, interviewObj.CandidateInstructions, interviewObj.InterviewerInstructions, interviewObj.SendInterviewerEmail,
                               interviewObj.SendCandidateEmail, interviewObj.Feedback, interviewObj.CreatedBy);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to Delete a interview Record
        /// </summary>
        /// <param name="deleteInterviewId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteInterview(int deleteInterviewId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_InterviewDelete(deleteInterviewId, companyId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<JobInterviewers> JobInterviewers(int interviewId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    return (from interviewer in hrmsEntity.JobInterviewers where interviewer.InterviewId == interviewId select interviewer).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool ApplicantInterviews(ApplicantInterview applicantInterviewObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.ApplicantInterview.Add(applicantInterviewObj);
                    int i = hrmsEntity.SaveChanges();
                    return i > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
