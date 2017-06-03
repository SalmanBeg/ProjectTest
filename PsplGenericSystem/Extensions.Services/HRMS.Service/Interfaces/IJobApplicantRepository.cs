using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IJobApplicantRepository
    {
        //[Logger]
        //[ExceptionLogger]
        //bool JobApplicantDetailInsert(ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj,
        //     ApplicantEmploymentHistory applicantEmploymentHistoryObj, ApplicantEducation applicantEducationObj);

        [Logger]
        [ExceptionLogger]
        int JobApplicantEducationInsert( ApplicantEducation applicantEducationObj);

        [Logger]
        [ExceptionLogger]
        bool JobApplicantEmploymentInsert(ApplicantEmploymentHistory applicantEmploymentHistoryObj);

        [Logger]
        [ExceptionLogger]
        bool JobApplicantSkillInsert(ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj);
        /// <summary>
        /// get a list of records for a ApplicantEducation
        /// </summary>
        /// <param name="ApplicantEducationById"></param>
        /// <returns></returns>
        
        [Logger]
        [ExceptionLogger]
        List<ApplicantEducation> SelectApplicantEducationById(int applicantId);
        /// <summary>
        /// get a list of records for a ApplicantAchievementsAndAssociations
        /// </summary>
        /// <param name="AchievementsAndAssociationsById"></param>
        /// <returns></returns>       
        [Logger]
        [ExceptionLogger]
        List<ApplicantAchievementsAndAssociations> SelectApplicantAchievementsAndAssociationsById(int applicantId,int jobId);

        /// <summary>
        /// get a list of records for a ApplicantEmploymentHistory
        /// </summary>
        /// <param name="ApplicantEmploymentHistoryId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<ApplicantEmploymentHistory> SelectApplicantEmploymentHistoryById(int applicantId, int jobId);

        /// <summary>
        /// get a list of records for a JobApplicant
        /// </summary>
        /// <param name="JobApplicantId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        JobApplicant SelectJobApplicantById(int applicantId, int companyId);

        /// <summary>
        /// For registering a new applicant
        /// </summary>
        /// <param name="jobApplicantObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int JobApplicantInsertOrUpdate(JobApplicant jobApplicantObj);

        [Logger]
        [ExceptionLogger]
        int JobApplicantUpdate(JobApplicant jobApplicantObj);


        [Logger]
        [ExceptionLogger]
        bool ApplicantEducationUpdate(ApplicantEducation applicantEducationObj);

        [Logger]
        [ExceptionLogger]
        int ApplicantEmploymentUpdate(ApplicantEmploymentHistory applicantEmploymentHistoryObj);

        [Logger]
        [ExceptionLogger]
        int ApplicantSkillUpdate(ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj);
        /// <summary>
        /// To insert applied jobids to applicant profile
        /// </summary>
        /// <param name="jobAppliedObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int ApplyJob(JobApplied jobAppliedObj);
        /// <summary>
        /// To validate applicant while logging
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        JobApplicant ValidateApplicant(string userName, string password);
        /// <summary>
        /// To list applied job for a applicant
        /// </summary>
        /// <param name="jobApplicantId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobApplied> AppliedJobs(int jobApplicantId);
        /// <summary>
        /// List of applied jobs with no filtering parameter
        /// </summary>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobApplied> AppliedJobsWithNoFilter();
        /// <summary>


        [Logger]
        [ExceptionLogger]
        bool JobApplicantDetailUpdate(JobApplicant jobApplicantobj, ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj,
             ApplicantEmploymentHistory applicantEmploymentHistoryObj, ApplicantEducation applicantEducationObj);


        /// List of Job Applicants by same companyid
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobApplicant> GetJobApplicants(int companyId);

        [Logger]
        [ExceptionLogger]
        bool DeleteApplicantEducation(int applicantEducationId);

        [Logger]
        [ExceptionLogger]
        bool DeleteApplicantEmployment(int applicantEmploymentHistoryId);


        [Logger]
        [ExceptionLogger]
        bool DeleteApplicantSkill(int applicantAchievementsAndAssociationsId);

        [Logger]
        [ExceptionLogger]
        int JobApplicantResumeUpdate(JobApplicant jobApplicantResumeObj);
        /// <summary>
        /// to update participant comments in recruiting of an applicant
        /// </summary>
        /// <param name="candidateHiringCommentsObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int InsertHiringComments(CandidateHiringComments candidateHiringCommentsObj);
        /// <summary>
        /// To retrieve all the comments given to an applicant in hiring process by his participants
        /// </summary>
        /// <param name="applicantId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<CandidateHiringComments> GetHiringCommentsbyCandidate(int applicantId);
        /// <summary>
        /// To update applicant status for an applicant based ono jobId
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="jobProfileId"></param>
        /// <param name="applicantStatus"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int UpdateCandidateStatus(int applicantId, int jobProfileId, int applicantStatus);
        /// <summary>
        /// to updating rating of an applicant
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="jobProfileId"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int UpdateRatingOfApplicant(int applicantId, int jobProfileId, int rating);
        /// <summary>
        /// to update the candidate status to hire
        /// </summary>
        /// <param name="applicantId"></param>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int HireCandidate(int applicantId, int jobProfileId);

    }
}
