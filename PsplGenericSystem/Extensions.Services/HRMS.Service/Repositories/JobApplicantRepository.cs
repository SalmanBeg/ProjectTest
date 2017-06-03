using System;
using System.Collections.Generic;
using System.Linq;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class JobApplicantRepository : IJobApplicantRepository
    {
        //public bool JobApplicantDetailInsert(ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj,
        //    ApplicantEmploymentHistory applicantEmploymentHistoryObj, ApplicantEducation applicantEducationObj)
        //{
        //    try
        //    {
        //        using (var hrmsEntity = new HRMSEntities1())
        //        {
        //            var outputParam = new System.Data.Entity.Core.Objects.ObjectParameter("ErrorCode", typeof(int));
                    
        //            var applicantId = hrmsEntity.usp_JobApplicantDetailsInsert(applicantEducationObj.ApplicantId, applicantEducationObj.JobId
        //                 , applicantAchievementsAndAssociationsObj.Type, applicantAchievementsAndAssociationsObj.Description, applicantEducationObj.University
        //                 , applicantEducationObj.Degree, applicantEducationObj.FromDate, applicantEducationObj.ToDate, applicantEducationObj.Activities
        //                 , applicantEmploymentHistoryObj.Title, applicantEmploymentHistoryObj.Description, applicantEmploymentHistoryObj.Location
        //                 , applicantEmploymentHistoryObj.EmploymentStartDate, applicantEmploymentHistoryObj.EmploymentEndDate, outputParam);
        //            return true;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public int JobApplicantEducationInsert(ApplicantEducation applicantEducationObj)
        {
            try
            {
                using(var hrmsEntity=new HRMSEntities1())
                {
                    var applicantId = hrmsEntity.usp_JobApplicantEducationInsert(applicantEducationObj.ApplicantEducationId, applicantEducationObj.ApplicantId
                        , applicantEducationObj.JobId, applicantEducationObj.University, applicantEducationObj.Degree, applicantEducationObj.FromDate
                        , applicantEducationObj.ToDate, applicantEducationObj.Activities);
                    return Convert.ToInt32(applicantId);

                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool JobApplicantEmploymentInsert(ApplicantEmploymentHistory applicantEmploymentHistoryObj)
        {
            try
            {
                using(var hrmsEntity=new HRMSEntities1())
                {
                    var applicantId = hrmsEntity.usp_JobApplicantEmploymentInsert(applicantEmploymentHistoryObj.ApplicantEmploymentHistoryId
                        , applicantEmploymentHistoryObj.ApplicantId, applicantEmploymentHistoryObj.JobId, applicantEmploymentHistoryObj.Title
                        , applicantEmploymentHistoryObj.Description, applicantEmploymentHistoryObj.Location, applicantEmploymentHistoryObj.EmploymentStartDate
                        , applicantEmploymentHistoryObj.EmploymentEndDate);
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool JobApplicantSkillInsert(ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj)
        {
            try
            {
                using(var hrmsEntity=new HRMSEntities1())
                {
                    var applicantId = hrmsEntity.usp_JobApplicantSkillInsert(applicantAchievementsAndAssociationsObj.ApplicantAchievementsAndAssociationsId
                        , applicantAchievementsAndAssociationsObj.ApplicantId, applicantAchievementsAndAssociationsObj.JobId, applicantAchievementsAndAssociationsObj.Type
                        , applicantAchievementsAndAssociationsObj.Description);
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ApplicantEducation> SelectApplicantEducationById(int applicantId)
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
        public List<ApplicantAchievementsAndAssociations> SelectApplicantAchievementsAndAssociationsById(int applicantId, int jobId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstApplicantAchievementsAndAssociationsResult = hrmsEntity.usp_ApplicantAchievementsAndAssociationsSelectById(applicantId).ToList();
                    var applicantAchievementsAndAssociationsList = lstApplicantAchievementsAndAssociationsResult.Select(applicantAchievementsAndAssociation => new ApplicantAchievementsAndAssociations
                    {
                        ApplicantAchievementsAndAssociationsId = applicantAchievementsAndAssociation.ApplicantAchievementsAndAssociationsId,
                        Type = applicantAchievementsAndAssociation.Type,
                        Description = applicantAchievementsAndAssociation.Description,
                        ApplicantId = applicantAchievementsAndAssociation.ApplicantId,
                        JobId = applicantAchievementsAndAssociation.JobId
                    }).ToList();
                    return applicantAchievementsAndAssociationsList;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<ApplicantEmploymentHistory> SelectApplicantEmploymentHistoryById(int applicantId, int jobId)
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
        public JobApplicant SelectJobApplicantById(int jobapplicantId, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var lstJobApplicantResult = hrmsEntity.usp_JobApplicantSelectById(jobapplicantId, companyId).ToList();
                    var jobApplicantList = lstJobApplicantResult.Select(jobApplicant => new JobApplicant
                    {
                        JobApplicantId = jobApplicant.JobApplicantId,                    
                        FirstName = jobApplicant.FirstName,
                        LastName = jobApplicant.LastName,
                        Email = jobApplicant.Email,
                        Address = jobApplicant.address,
                        City = jobApplicant.City,
                        CompanyId = jobApplicant.CompanyId,
                        Phone = jobApplicant.Phone,
                        ResumeAttachmentId=jobApplicant.ResumeAttachmentId,
                        CreatedOn = jobApplicant.CreatedOn,
                        CreatedBy = jobApplicant.CreatedBy,
                        ModifiedBy = jobApplicant.ModifiedBy,
                        ModifiedOn = jobApplicant.ModifiedOn

                    }).ToList();
                    return jobApplicantList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int JobApplicantInsertOrUpdate(JobApplicant jobApplicantObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var applicantid = new System.Data.Entity.Core.Objects.ObjectParameter("Applicantid", typeof(int));
                    int result = hrmsEntity.usp_JobApplicantInsertORUpdate(jobApplicantObj.JobApplicantId, jobApplicantObj.FirstName, jobApplicantObj.LastName
                        , jobApplicantObj.City, jobApplicantObj.Address, jobApplicantObj.Email
                        , jobApplicantObj.CompanyId, jobApplicantObj.Phone, jobApplicantObj.ResumeAttachmentId, jobApplicantObj.ResumeText, jobApplicantObj.Status
                        , jobApplicantObj.CreatedBy, jobApplicantObj.ModifiedBy, jobApplicantObj.Password, jobApplicantObj.ApplicantDescription, applicantid);
                    return Convert.ToInt32(applicantid.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int JobApplicantResumeUpdate(JobApplicant jobApplicantobj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var JobApplicantId = new System.Data.Entity.Core.Objects.ObjectParameter("Applicantid", typeof(int));
                    int result = hrmsEntity.usp_JobApplicantResumeAttachmentUpdate(jobApplicantobj.JobApplicantId, jobApplicantobj.ResumeAttachmentId);
                    return Convert.ToInt32(JobApplicantId.Value);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int JobApplicantUpdate(JobApplicant jobApplicantObj)
        {
            try
            {
                using(var hrmsEntity = new HRMSEntities1() )
                {
                    var result = hrmsEntity.usp_JobApplicantUpdate(jobApplicantObj.JobApplicantId,jobApplicantObj.FirstName, jobApplicantObj.LastName, jobApplicantObj.City, jobApplicantObj.Address
                        , jobApplicantObj.Email, jobApplicantObj.CompanyId, jobApplicantObj.Phone, jobApplicantObj.ResumeAttachmentId, jobApplicantObj.ResumeText
                        , jobApplicantObj.Status, jobApplicantObj.CreatedBy, jobApplicantObj.ModifiedBy, jobApplicantObj.Password, jobApplicantObj.ApplicantDescription);
                    return result;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public bool ApplicantEducationUpdate(ApplicantEducation applicantEducationObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ApplicantEducationUpdate(applicantEducationObj.ApplicantEducationId,applicantEducationObj.University
                        ,applicantEducationObj.Degree,applicantEducationObj.FromDate,applicantEducationObj.ToDate,applicantEducationObj.Activities
                        ,applicantEducationObj.ApplicantId,applicantEducationObj.JobId);
                    return result>0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int ApplicantEmploymentUpdate(ApplicantEmploymentHistory applicantEmploymentHistoryObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ApplicantEmploymentUpdate(applicantEmploymentHistoryObj.ApplicantEmploymentHistoryId,applicantEmploymentHistoryObj.Title
                        ,applicantEmploymentHistoryObj.Description,applicantEmploymentHistoryObj.Location,applicantEmploymentHistoryObj.EmploymentStartDate
                        ,applicantEmploymentHistoryObj.EmploymentEndDate,applicantEmploymentHistoryObj.ApplicantId,applicantEmploymentHistoryObj.JobId);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int ApplicantSkillUpdate(ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ApplicantSkillUpdate(applicantAchievementsAndAssociationsObj.ApplicantAchievementsAndAssociationsId
                        ,applicantAchievementsAndAssociationsObj.Type,applicantAchievementsAndAssociationsObj.Description,applicantAchievementsAndAssociationsObj.ApplicantId
                        ,applicantAchievementsAndAssociationsObj.JobId);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public JobApplicant ValidateApplicant(string userName, string password)
        {
            using (var hrmsEntity = new HRMSEntities1())
            {
                var lstJobApplicantResult = hrmsEntity.usp_ValidateApplicant(userName, password);
                var jobApplicantList = lstJobApplicantResult.Select(jobApplicant => new JobApplicant
                {
                    JobApplicantId = jobApplicant.JobApplicantId,
                    JobApplicantCode = jobApplicant.JobApplicantCode,
                    FirstName = jobApplicant.FirstName,
                    LastName = jobApplicant.LastName,
                    Email = jobApplicant.Email,
                    CompanyId = jobApplicant.CompanyId
                }).ToList();
                return jobApplicantList.SingleOrDefault();
            }
        }
        public int ApplyJob(JobApplied jobAppliedObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    hrmsEntity.JobApplied.Add(jobAppliedObj);
                    return hrmsEntity.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<JobApplied> AppliedJobs(int jobApplicantId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var appliedJobsResult = (from jobapplied in hrmsEntity.JobApplied
                                             where jobapplied.JobApplicantId == jobApplicantId
                                             select jobapplied).DefaultIfEmpty();
                    return appliedJobsResult.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool JobApplicantDetailUpdate(JobApplicant jobApplicantobj, ApplicantAchievementsAndAssociations applicantAchievementsAndAssociationsObj,
             ApplicantEmploymentHistory applicantEmploymentHistoryObj, ApplicantEducation applicantEducationObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var applicantid = new System.Data.Entity.Core.Objects.ObjectParameter("Applicantid", typeof(int));
                    var result = hrmsEntity.usp_JobApplicantDetailsUpdate(applicantAchievementsAndAssociationsObj.ApplicantId
                        , applicantAchievementsAndAssociationsObj.ApplicantAchievementsAndAssociationsId, applicantEducationObj.ApplicantEducationId
                        , applicantEmploymentHistoryObj.ApplicantEmploymentHistoryId
                        , applicantEmploymentHistoryObj.JobId, applicantAchievementsAndAssociationsObj.Type, applicantAchievementsAndAssociationsObj.Description
                        , applicantEducationObj.University, applicantEducationObj.Degree, applicantEducationObj.FromDate, applicantEducationObj.ToDate
                        , applicantEducationObj.Activities, applicantEmploymentHistoryObj.Title, applicantEmploymentHistoryObj.Description, applicantEmploymentHistoryObj.Location
                        , applicantEmploymentHistoryObj.EmploymentStartDate, applicantEmploymentHistoryObj.EmploymentEndDate, applicantid);
                    return Convert.ToBoolean(applicantid.Value);
                }
            }
            catch(Exception)
            {
                throw;
            }         
        }

        public List<JobApplied> AppliedJobsWithNoFilter()
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var appliedJobsResult = (from jobapplied in hrmsEntity.JobApplied
                                             select jobapplied).DefaultIfEmpty();
                    return appliedJobsResult.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<JobApplicant> GetJobApplicants(int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    
                    var jobapplicantsList = (from jobapplicants in hrmsEntity.JobApplicant
                                             where jobapplicants.CompanyId == companyId
                                             select jobapplicants).ToList();
                    return jobapplicantsList; 
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool DeleteApplicantEducation(int applicantEducationId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ApplicantEducationDelete(applicantEducationId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteApplicantEmployment(int applicantEmploymentHistoryId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ApplicantEmploymentDelete(applicantEmploymentHistoryId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool DeleteApplicantSkill(int applicantAchievementsAndAssociationsId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_ApplicantSkillDelete(applicantAchievementsAndAssociationsId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int InsertHiringComments(CandidateHiringComments candidateHiringCommentsObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.CandidateHiringComments.Add(candidateHiringCommentsObj);
                    hrmsEntity.SaveChanges();
                    return result.HiringCommentsId;
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public List<CandidateHiringComments> GetHiringCommentsbyCandidate(int applicantId)
        {
            try
            {

                using (var hrmsEntity = new HRMSEntities1())
                {
                    var hiringCommentsList = hrmsEntity.CandidateHiringComments.Where(m => m.ApplicantId == applicantId).ToList();
                    return hiringCommentsList;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int UpdateCandidateStatus(int applicantId,int jobProfileId ,int applicantStatus)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var recordToUpdate = hrmsEntity.JobApplied.Where(j => j.JobApplicantId == applicantId && j.JobProfileId == jobProfileId).ToList();
                    foreach (var recordObj in recordToUpdate)
                    {
                        recordObj.Status = applicantStatus;
                    }
                   return hrmsEntity.SaveChanges();

                }

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int UpdateRatingOfApplicant(int applicantId, int jobProfileId, int rating)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var recordToUpdate =
                        hrmsEntity.JobApplied.Where(
                            j => j.JobApplicantId == applicantId && j.JobProfileId == jobProfileId).ToList();
                    foreach (var recordObj in recordToUpdate)
                    {
                        recordObj.Rating = rating;
                    }
                    return hrmsEntity.SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public int HireCandidate(int applicantId,int jobProfileId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var recordToUpdate = (hrmsEntity.JobApplied.Where(j => j.JobApplicantId == applicantId && j.JobProfileId == jobProfileId )).ToList();
                    foreach (var recordObj in recordToUpdate)
                    {
                        recordObj.IsHired = true;
                    }
                    return hrmsEntity.SaveChanges();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

       
    }
}