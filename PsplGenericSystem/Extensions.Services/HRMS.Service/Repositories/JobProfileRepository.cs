using System.Data;
using EntityFrameworkExtras.EF6;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.ExtensionProc;

namespace HRMS.Service.Repositories
{
    public class JobProfileRepository : IJobProfileRepository
    {
        /// <summary>
        /// Method to Create a new Job Profile
        /// </summary>
        /// <param name="jobProfileObj"></param>
        /// <param name="jobDutiesList"></param>
        /// <param name="jobQualificationList"></param>
        /// <param name="jobPmeList"></param>
        /// <param name="recruitingQuestionList"></param>
        /// <returns></returns>
        public int CreateJobProfile(JobProfile jobProfileObj, List<JobDuties> jobDutiesList, List<JobQualification> jobQualificationList, List<JobPME> jobPmeList
            ,List<RecruitingQuestions> recruitingQuestionList)
        {
            
            int i = 0;
            if (jobDutiesList == null && jobQualificationList == null && jobPmeList==null)
            {
                jobDutiesList = new List<JobDuties>();
                jobQualificationList = new List<JobQualification>();
                jobPmeList = new List<JobPME>();
                recruitingQuestionList=new List<RecruitingQuestions>();
            }
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var proc = new ExtendedStoredProcedures.JobProfileInsertORUpdate()
                            {
                                JobProfileId = jobProfileObj.JobProfileId,
                                CompanyId = jobProfileObj.CompanyId,
                                JobCode = jobProfileObj.JobCode,
                                Title = jobProfileObj.Title,
                                CityStateOrZipCode = jobProfileObj.CityStateOrZipCode,
                                JobCategory = jobProfileObj.JobCategory,
                                JobDescription = jobProfileObj.JobDescription,
                                CompanyDescription = jobProfileObj.CompanyDescription,
                                Status = jobProfileObj.Status,
                                IsPosted = jobProfileObj.IsPosted,
                                BasicInfo = jobProfileObj.BasicInfo,
                                Education = jobProfileObj.Education,
                                Employment = jobProfileObj.Employment,
                                Certification = jobProfileObj.Certification,
                                Skill = jobProfileObj.Skill,
                                CreatedBy = jobProfileObj.CreatedBy,
                                ModifiedBy = jobProfileObj.ModifiedBy,
                                HiringManager = jobProfileObj.HiringManager,
                                PostDate = jobProfileObj.PostDate,
                                IsRequisition = jobProfileObj.IsRequisiton,
                                JobId = jobProfileObj.JobProfileId,
                                FullName = jobProfileObj.HiringManagerName,
                                Email = jobProfileObj.HiringManagerEmail,
                                Comments = jobProfileObj.Comments,
                                UdtJobDuties =  jobDutiesList.Select(jobDuty => new ExtendedStoredProcedures.UdtJobDuties
                                {
                                    JobDutyId = jobDuty.JobDutyId
                                }).ToList(),
                                UdtJobQualifications = jobQualificationList.Select(jobQualification => new ExtendedStoredProcedures.UdtJobQualifications
                                {
                                    JobQualificationId = jobQualification.JobQualificationId
                                }).ToList(),
                                UdtJobPMEs = jobPmeList.Select(jobPME => new ExtendedStoredProcedures.UdtJobPMEs
                                {
                                    JobPMEId = jobPME.PMEId
                                }).ToList(),
                                UdtRecruitingQuestions = recruitingQuestionList.Select(recruitingQuestion => new ExtendedStoredProcedures.UdtRecruitingQuestions
                                {
                                    RecruitingQuestionId = recruitingQuestion.RecruitingQuestionId
                                }).ToList(),
                                  
                            };
                    hrmsEntity.Database.ExecuteStoredProcedure(proc);
                    return proc.JobId; 
                }

            }
            catch (Exception)
            {
                throw;
            }
            
        }
        /// <summary>
        /// Method to display all details of the existing JobProfiles using companyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<JobProfile> SelectJobProfile(int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstJobProfileResult = hrmsEntity.usp_JobProfileSelect(companyId).ToList();
                    var jobProfileList = lstJobProfileResult.Select(jobProfile => new JobProfile
                    {
                        JobProfileId = jobProfile.JobProfileID,
                        CompanyId = jobProfile.CompanyID,
                        JobCategory = jobProfile.JobCategory,
                        JobDescription = jobProfile.JobDescription,
                        CompanyDescription = jobProfile.CompanyDescription,
                        CityStateOrZipCode = jobProfile.CityStateOrZipCode,
                        Status = jobProfile.Status,
                        Title = jobProfile.Title,
                        CompanyName = jobProfile.CompanyName,
                        CompanyAddress = jobProfile.Address1 + "," + jobProfile.City,
                        PageVisitorCount = jobProfile.PageVisitorCount,
                        HiringManager = jobProfile.HiringManager,
                        PostDate = jobProfile.PostDate,
                        IsPosted = jobProfile.IsPosted,
                        IsRequisiton = jobProfile.IsRequisiton,
                        HiringManagerEmail = jobProfile.Email,
                        HiringManagerName = jobProfile.FullName
                       
                    }).ToList();
                    return jobProfileList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to Display a single record of JobProfile using JobProfileId
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        public JobProfile SelectJobProfileById(int jobProfileId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    List<usp_JobProfileSelectById_Result> lstJobProfileResult = hrmsEntity.usp_JobProfileSelectById(jobProfileId).ToList();
                    var jobProfileList = lstJobProfileResult.Select(jobProfile => new JobProfile
                    {
                        
                        JobProfileId = jobProfile.JobProfileID,
                        JobCode = jobProfile.JobCode,
                        CompanyId = jobProfile.CompanyID,
                        JobCategory = jobProfile.JobCategory,
                        JobDescription = jobProfile.JobDescription,
                        CompanyDescription = jobProfile.CompanyDescription,
                        CityStateOrZipCode = jobProfile.CityStateOrZipCode,
                        Title = jobProfile.Title,
                        Status = jobProfile.Status.GetValueOrDefault(),
                        CompanyName = jobProfile.CompanyName,
                        CompanyAddress = jobProfile.Address1 + "," + jobProfile.City,
                        PageVisitorCount = jobProfile.PageVisitorCount,
                        HiringManager = jobProfile.HiringManager,
                        PostDate = jobProfile.PostDate,
                        BasicInfo = jobProfile.BasicInfo,
                        Education = jobProfile.Education,
                        Employment = jobProfile.Employment,
                        Certification = jobProfile.Certification,
                        Skill = jobProfile.Skill,
                        CreatedOn = jobProfile.CreatedOn,
                        CreatedBy = jobProfile.CreatedBy,
                        HiringManagerName=jobProfile.HiringManagerName,
                        HiringManagerEmail=jobProfile.HiringManagerEmail,
                        
                    }).ToList();
                    return jobProfileList.SingleOrDefault(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public JobProfile JobProfileGetPreview(int jobProfileId)
        {

            try
            {
                //jobProfileId = 54;
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var lstJobProfileResult = hrmsEntity.usp_JobProfileGetPreview(jobProfileId).ToList();
                    var jobProfileList = lstJobProfileResult.Select(jobProfile => new JobProfile
                    {
                        JobProfileId = jobProfile.JobProfileID,
                        CompanyId = jobProfile.CompanyID,
                        JobCategory = jobProfile.JobCategory,
                        JobCategoryDesc = jobProfile.JobCategoryDesc,
                        JobDescription = jobProfile.JobDescription,
                        CompanyDescription = jobProfile.CompanyDescription,
                        CityStateOrZipCode = jobProfile.CityStateOrZipCode,
                        Title = jobProfile.Title,
                        CompanyName = jobProfile.CompanyName,
                        HiringManagerName = jobProfile.FullName,
                        HiringManagerEmail = jobProfile.HiringManagerEmail,
                        Comments = jobProfile.Comments,
                        ManagerActionFlag = jobProfile.ManagerActionFlag,
                        RecruiterNames = jobProfile.RecruiterNames,
                        PostDate = Convert.ToDateTime(jobProfile.PostDate.ToString())
                    }).ToList();
                    return jobProfileList.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int JobProfileHiringManagerCommentsUpdate(int jobProfileId,string comments)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {

                    var result = hrmsEntity.usp_JobProfileHiringManagerCommentsUpdate(jobProfileId, comments);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to Add a Recruiter to a particular job by passing employeeid and jobid as parameters
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool AddJobRecruiter(int jobId, int employeeId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    int? param;
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_JobRecruiterInsert(jobId, employeeId, output);
                    return Convert.ToBoolean(output.Value); 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        /// <summary>
        /// Method to Delete a record from the existing Recruiters List for a job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool DeleteJobRecruiter(int jobId, int employeeId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_JobRecruiterDelete(jobId, employeeId);
                    return Convert.ToBoolean(result); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to Retrieve Details of a Recruiter for a Particular Job by passing jobId as parameter
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public List<JobRecruiter> SelectJobRecruitersByJobId(int jobId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstJobRecruiterResult = hrmsEntity.usp_JobRecruiterSelectByJobId(jobId).ToList();
                    var jobRecruiterList = lstJobRecruiterResult.Select(jobRecruiter => new JobRecruiter
                    {
                        JobId = jobRecruiter.JobId,
                        EmployeeId = jobRecruiter.EmployeeId
                    }).ToList();
                    return jobRecruiterList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete a Record from the existing JobProfiles
        /// </summary>
        /// <param name="jobprofileId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public bool DeleteJobprofile(int jobprofileId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstJobprofileResult = hrmsEntity.usp_JobProfileDelete(jobprofileId, companyId);
                    return lstJobprofileResult > 0; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="employeeId"></param>
        /// <param name="visitorCount"></param>
        /// <returns></returns>
        public bool UpdateVisitorCount(int jobId, int employeeId, int visitorCount)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    var result = hrmsEntity.usp_JobProfileVisitorCountUpdate(jobId, employeeId, visitorCount, output);
                    return Convert.ToBoolean(output.Value); 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        //public int AddJobApplicant(JobApplicant jobApplicantObj)
        //{
            
        //    try
        //    {
        //        using (var hrmsEntity = new HRMSEntities1())
        //        {
        //            var output = new System.Data.Entity.Core.Objects.ObjectParameter("Applicantid", typeof(int));
        //            var result = hrmsEntity.usp_JobApplicantInsertORUpdate(jobApplicantObj.JobApplicantId, jobApplicantObj.FirstName
        //                , jobApplicantObj.LastName,jobApplicantObj.City, jobApplicantObj.Address, jobApplicantObj.Email, jobApplicantObj.CompanyId, jobApplicantObj.Phone, jobApplicantObj.ResumeAttachmentId,
        //                jobApplicantObj.ResumeText, jobApplicantObj.Status, jobApplicantObj.CreatedBy, jobApplicantObj.ModifiedBy, jobApplicantObj.Password, output);
        //            return Convert.ToInt32(output.Value); 
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
            
        //}
        public bool AddApplication(JobApplied jobAppliedObj)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    hrmsEntity.usp_JobAppliedInsert(jobAppliedObj.JobApplicantId, jobAppliedObj.JobProfileId, 1, jobAppliedObj.Status, jobAppliedObj.IsHired, "", jobAppliedObj.IsApproved, output);
                    return Convert.ToBoolean(output.Value); 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public List<ApplicantEmploymentHistory> GetApplicantEmploymentHistoryById(int applicantId, int jobId) 
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstApplicantEmploymentHistoryResult = hrmsEntity.usp_ApplicantEmploymentHistorySelectById(applicantId).ToList();
                    var applicantEmploymentHistoryList = lstApplicantEmploymentHistoryResult.Select(applicantEmploymentHistory => new ApplicantEmploymentHistory
                    {
                        ApplicantEmploymentHistoryId = applicantEmploymentHistory.ApplicantEmploymentHistoryId,
                        Title = applicantEmploymentHistory.Title,
                        Description = applicantEmploymentHistory.Description,
                        Location = applicantEmploymentHistory.Location,
                        EmploymentStartDate = applicantEmploymentHistory.EmploymentStartDate,
                        EmploymentEndDate = applicantEmploymentHistory.EmploymentEndDate,
                        ApplicantId = applicantEmploymentHistory.ApplicantId,
                        JobId = applicantEmploymentHistory.JobId
                    }).ToList();
                    return applicantEmploymentHistoryList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ApplicantEducation> GetApplicantEducationById(int applicantId, int jobId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstApplicantEducationResult = hrmsEntity.usp_ApplicantEducationSelectById(applicantId).ToList();
                    var applicantEducationList = lstApplicantEducationResult.Select(applicantEducation => new ApplicantEducation
                    {
                        ApplicantEducationId = applicantEducation.ApplicantEducationId,
                        University = applicantEducation.University,
                        Degree = applicantEducation.Degree,
                        FromDate = applicantEducation.FromDate,
                        ToDate = applicantEducation.ToDate,
                        Activities = applicantEducation.Activities,
                        ApplicantId = applicantEducation.ApplicantId,
                        JobId = applicantEducation.JobId
                    }).ToList();
                    return applicantEducationList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ApplicantAchievementsAndAssociations> GetApplicantAchievementsAndAssociationsById(int applicantId, int jobId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstApplicantAchievementsAndAssociationsResult = hrmsEntity.usp_ApplicantAchievementsAndAssociationsSelectById(applicantId).ToList();
                    var applicantAchievementsAndAssociationsList = lstApplicantAchievementsAndAssociationsResult.Select(applicantAchievementsAndAssociations => new ApplicantAchievementsAndAssociations
                    {
                        ApplicantAchievementsAndAssociationsId = applicantAchievementsAndAssociations.ApplicantAchievementsAndAssociationsId,
                        Type = applicantAchievementsAndAssociations.Type,
                        Description = applicantAchievementsAndAssociations.Description,
                        ApplicantId = applicantAchievementsAndAssociations.ApplicantId,
                        JobId = applicantAchievementsAndAssociations.JobId
                    }).ToList();
                    return applicantAchievementsAndAssociationsList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public List<JobApplicant> GetAllCandidates(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstJobApplicantSelectResult = hrmsEntity.usp_JobApplicantSelect(companyId).ToList();
                    var jobApplicantList = lstJobApplicantSelectResult.Select(jobApplicant => jobApplicant.JobProfileId != null ? new JobApplicant
                    {
                        JobApplicantId = jobApplicant.JobApplicantId,
                        FirstName = jobApplicant.FirstName,
                        LastName = jobApplicant.LastName,
                        Email = jobApplicant.Email,
                        CompanyId = jobApplicant.CompanyId,
                        Phone = jobApplicant.Phone,
                        ResumeAttachmentId = jobApplicant.ResumeAttachmentId,
                        ResumeText = jobApplicant.ResumeText,
                        Status = jobApplicant.Status,
                        Title = jobApplicant.Title,
                        AppliedStatus = jobApplicant.AppliedStatus,
                        CompanyDescription = jobApplicant.CompanyDescription,
                        CompanyName = jobApplicant.CompanyName,
                        Address=jobApplicant.Address1,
                        City = jobApplicant.City,
                        Notes = jobApplicant.Notes,
                        Rating = jobApplicant.Rating,
                        JobId = (int)jobApplicant.JobProfileId,
                        CreatedOn = jobApplicant.CreatedOn,
                        CreatedBy = jobApplicant.CreatedBy
                    } : null).ToList();
                    return jobApplicantList; 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public bool AddCandidateDetails(ApplicantEducation applicantEducationObj, ApplicantEmploymentHistory applicantEmploymentHistoryObj, ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var output = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    int result = hrmsEntity.usp_JobApplicantDetailsInsert(applicantEmploymentHistoryObj.ApplicantId, applicantEmploymentHistoryObj.JobId
                        , applicantAchievementsAndAssociationsObj.Type, applicantAchievementsAndAssociationsObj.Description
                        , applicantEducationObj.University, applicantEducationObj.Degree, applicantEducationObj.FromDate, applicantEducationObj.ToDate
                        , applicantEducationObj.Activities, applicantEmploymentHistoryObj.Title, applicantEmploymentHistoryObj.Description
                        , applicantEmploymentHistoryObj.Location, applicantEmploymentHistoryObj.EmploymentStartDate, applicantEmploymentHistoryObj.EmploymentEndDate, output);
                    return Convert.ToBoolean(output.Value); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to Check if the JobProfile Title is already existing
        /// </summary>
        /// <param name="jobProfileObj"></param>
        /// <returns></returns>
        public bool IsTitleExists(JobProfile jobProfileObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var jplist = hrmsEntity.JobProfile.ToList();
                    var jobProfileObj1 = jplist.SingleOrDefault(m => m.CompanyId == jobProfileObj.CompanyId && m.Title.ToLower() == jobProfileObj.Title.ToLower() && m.JobProfileId != jobProfileObj.JobProfileId);
                    if (jobProfileObj1 != null)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to List all the Checked Items in the JobDuties Partial View while creating a new jobprofile
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        public List<JobDuties> ListJobDutiesInJobProfile(int jobProfileId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    return hrmsEntity.JobDuties.Where(j => j.JobProfile.Any(e => e.JobProfileId == jobProfileId)).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to List all the checked items in the JobQualification Partial View while creating a new jobprofile
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        public List<JobQualification> ListJobQualificationsInJobProfile(int jobProfileId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    return hrmsEntity.JobQualification.Where(j => j.JobProfile.Any(e => e.JobProfileId == jobProfileId)).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to List all the checked items in the JobPME Partial View while creating a new jobprofile
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        public List<JobPME> ListJobPMEsInJobProfile(int jobProfileId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    return hrmsEntity.JobPME.Where(j => j.JobProfile.Any(e => e.JobProfileId == jobProfileId)).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to List all the checked items in the Recruiting Questions Partial View while creating a new jobprofile
        /// </summary>
        /// <param name="jobProfileId"></param>
        /// <returns></returns>
        public List<RecruitingQuestions> ListRecQuestionsInJobProfile(int jobProfileId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    return hrmsEntity.RecruitingQuestions.Where(j => j.JobProfile.Any(e => e.JobProfileId == jobProfileId)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Method to List all available jobs of a company in the JobPortal Page
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<JobProfile> ListAvailableJobsForJobPortal(int companyId)
        {
            try
            {
                var allAvailableJobs = SelectJobProfile(companyId);
                var requisitions = (from availableJobObj in allAvailableJobs
                                    where availableJobObj.IsRequisiton == true && availableJobObj.PostDate >= DateTime.Today
                                    select availableJobObj).ToList();
               
                return requisitions;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        
    }
}