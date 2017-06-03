using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class JobQualificationRepository : IJobQualificationRepository
    {

        public int CreateJobQualification(JobQualification jobQualificationObj)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_JobQualificationInsert(jobQualificationObj.JobQualificationId, jobQualificationObj.CompanyId,
                                jobQualificationObj.Description, jobQualificationObj.Type, jobQualificationObj.SubjectArea, jobQualificationObj.Proficiency, jobQualificationObj.Years,jobQualificationObj.LastUsed, jobQualificationObj.Mandatory, jobQualificationObj.CreatedBy);
                    return result; 
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<JobQualification> SelectAllJobQualification(int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var jobQualificationResult = hrmsEntity.usp_JobQualificationSelectAll(companyId).ToList();
                    return jobQualificationResult.Select(jobQualificationList => new JobQualification
                    {
                        JobQualificationId = jobQualificationList.JobQualificationID,
                        JobQualificationCode = jobQualificationList.JobQualificationCode,
                        Type = jobQualificationList.Type,
                        CompanyId = jobQualificationList.CompanyId,
                        SubjectArea = jobQualificationList.SubjectArea,
                        Proficiency = jobQualificationList.Proficiency,
                        Years = jobQualificationList.Years,
                        LastUsed = jobQualificationList.LastUsed,
                        Mandatory = jobQualificationList.Mandatory,
                        Description = jobQualificationList.Description,
                        CreatedOn = jobQualificationList.CreatedOn,
                        ModifiedOn = jobQualificationList.ModifiedOn,
                        CreatedBy = jobQualificationList.CreatedBy,
                        ModifiedBy = jobQualificationList.ModifiedBy
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public int UpdateJobQualification(JobQualification jobQualificationObj)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_JobQualificationUpdate(jobQualificationObj.JobQualificationId, jobQualificationObj.CompanyId, jobQualificationObj.Type,
                               jobQualificationObj.SubjectArea, jobQualificationObj.Proficiency, jobQualificationObj.Years, jobQualificationObj.LastUsed,
                               jobQualificationObj.Mandatory, jobQualificationObj.Description, jobQualificationObj.ModifiedOn, jobQualificationObj.ModifiedBy);
                    return result; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public JobQualification SelectJobQualification(int jobQualificationId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var jobQualificationResult = hrmsEntity.usp_JobQualificationSelect(jobQualificationId).ToList();
                    var jobQualificationList = jobQualificationResult.Select(jobQualification => new JobQualification
                    {
                        JobQualificationId = jobQualification.JobQualificationID,
                        JobQualificationCode = jobQualification.JobQualificationCode,
                        Type = jobQualification.Type,
                        CompanyId = jobQualification.CompanyId,
                        SubjectArea = jobQualification.SubjectArea,
                        Proficiency = jobQualification.Proficiency,
                        Years = jobQualification.Years,
                        LastUsed = jobQualification.LastUsed,
                        Mandatory = jobQualification.Mandatory,
                        Description = jobQualification.Description,
                        CreatedOn = jobQualification.CreatedOn,
                        ModifiedOn = jobQualification.ModifiedOn,
                        CreatedBy = jobQualification.CreatedBy,
                        ModifiedBy = jobQualification.ModifiedBy
                    }).ToList();
                    return jobQualificationList.SingleOrDefault(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteJobQualification(int jobQualificationId, int companyId)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_JobQualificationDelete(jobQualificationId, companyId);
                    return result > 0; 
                }
            }
            catch (Exception )
            {
                throw ;
            }
           
        }
       /// <summary>
        /// To provide the list of selected job qualifications
       /// </summary>
       /// <param name="jobQualificationIds"></param>
       /// <param name="companyId"></param>
       /// <returns></returns>
        public List<JobQualification> ListSelectedJobQualifications(int[] jobQualificationIds, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var jobQualificationsResult = SelectAllJobQualification(companyId);
                    return jobQualificationsResult.Where(qualification => jobQualificationIds.Contains(qualification.JobQualificationId)).ToList<JobQualification>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}


