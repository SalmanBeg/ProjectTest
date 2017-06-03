using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IJobProfileRepository
    {
        /// <summary>
        /// List of all job profiles in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobProfile> SelectJobProfile(int companyId);
        /// <summary>
        /// Retrieves an individual record based on job profileId
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        JobProfile SelectJobProfileById(int jobProfileId);
        /// <summary>
        /// Retrieves recruiters based on jobprofileId
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobRecruiter> SelectJobRecruitersByJobId(int jobId);
        /// <summary>
        /// Creates a new job profile record for portal screen
        /// </summary>
        /// <param name="jobProfileObj"></param>
        /// <param name="jobDutiesList"></param>
        /// <param name="jobQualificationList"></param>
        /// <param name="jobPmeList"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int CreateJobProfile(JobProfile jobProfileObj, List<JobDuties> jobDutiesList,
            List<JobQualification> jobQualificationList, List<JobPME> jobPmeList, List<RecruitingQuestions> recruitingQuestionList);
        /// <summary>
        /// Associating job profileId and employees as recruiters
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool AddJobRecruiter(int jobId, int employeeId);
        /// <summary>
        /// Method to delete job profile record
        /// </summary>
        /// <param name="jobprofileId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteJobprofile(int jobprofileId, int companyId);
        /// <summary>
        /// To remove recruiters associated to job profile
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteJobRecruiter(int jobId, int employeeId);
        /// <summary>
        /// Updating the list of users who visited the job on job portal
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="employeeId"></param>
        /// <param name="visitorCount"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool UpdateVisitorCount(int jobId, int employeeId, int visitorCount);
        /// <summary>
        /// To save applicant details for the job
        /// </summary>
        /// <param name="jobApplicantObj"></param>
        /// <returns></returns>
        //[Logger]
        //[ExceptionLogger]
        //int AddJobApplicant(JobApplicant jobApplicantObj);
        /// <summary>
        /// To associate the applicant to job
        /// </summary>
        /// <param name="jobAppliedObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool AddApplication(JobApplied jobAppliedObj);

        [Logger]
        [ExceptionLogger]
        bool AddCandidateDetails(ApplicantEducation applicantEducationObj, ApplicantEmploymentHistory applicantEmploymentHistoryObj, ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj);

        [Logger]
        [ExceptionLogger]
        List<ApplicantEducation> GetApplicantEducationById(int applicantId, int jobId);

        [Logger]
        [ExceptionLogger]
        List<ApplicantEmploymentHistory> GetApplicantEmploymentHistoryById(int applicantId, int jobId);

        [Logger]
        [ExceptionLogger]
        List<ApplicantAchievementsAndAssociations> GetApplicantAchievementsAndAssociationsById(int applicantId, int jobId);

        [Logger]
        [ExceptionLogger]
        List<JobApplicant> GetAllCandidates(int companyId);
        /// <summary>
        /// To check for duplication of job profile on creation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool IsTitleExists(JobProfile obj);
        /// <summary>
        /// To retrieve job duties associated to job profile
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobDuties> ListJobDutiesInJobProfile(int jobProfileId);
        /// <summary>
        /// To retrieve job qualifications associated to job profile
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobQualification> ListJobQualificationsInJobProfile(int jobProfileId);
        /// <summary>
        /// To retrieve job pmes associated to job profile
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobPME> ListJobPMEsInJobProfile(int jobProfileId);
        /// <summary>
        /// To retrieve recruiting questions associated to job profile
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<RecruitingQuestions> ListRecQuestionsInJobProfile(int jobProfileId);
        /// <summary>
        /// To retrieve all the filtered jobs for job portal
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobProfile> ListAvailableJobsForJobPortal(int companyId);

        [Logger]
        [ExceptionLogger]
        JobProfile JobProfileGetPreview(int jobProfileId);

        [Logger]
        [ExceptionLogger]
        int JobProfileHiringManagerCommentsUpdate(int jobProfileId,string comments);
    }
}
