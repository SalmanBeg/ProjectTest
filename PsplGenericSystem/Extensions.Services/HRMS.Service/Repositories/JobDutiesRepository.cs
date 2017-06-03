using HRMS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class JobDutiesRepository : IJobDutiesRepository
    {
        public int CreateJobDuties(JobDuties jobDutiesObj)
        {
            
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_JobDutiesInsert(jobDutiesObj.JobDutyId, jobDutiesObj.CompanyId,
                               jobDutiesObj.Description, jobDutiesObj.Category, jobDutiesObj.Priority, jobDutiesObj.PercentageOfTime,
                               jobDutiesObj.Frequency, jobDutiesObj.Essential, jobDutiesObj.Other, jobDutiesObj.CreatedBy);
                    return result; 
                }
            }
            catch (Exception)
            {
                throw;
            }
            

        }
        public List<JobDuties> SelectAllJobDuties(int companyId)
        {
            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var jobDutiesResult = hrmsentity.usp_JobDutiesSelectAll(companyId).ToList();
                    return jobDutiesResult.Select(jobDutiesList => new JobDuties
                    {
                        JobDutyId = jobDutiesList.JobDutyID,
                        CompanyId = jobDutiesList.CompanyID,
                        Description = jobDutiesList.Description,
                        Category = jobDutiesList.Category,
                        Priority = jobDutiesList.Priority,
                        PriorityName = jobDutiesList.PriorityName,
                        PercentageOfTime = jobDutiesList.PercentageOfTime,
                        Frequency = jobDutiesList.Frequency,
                        Essential = jobDutiesList.Essential,
                        Other = jobDutiesList.Other
                    }).ToList(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        

        public int UpdateJobDuties(JobDuties jobDutiesObj)
        {
            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var result = hrmsentity.usp_JobDutiesUpdate(jobDutiesObj.JobDutyId, jobDutiesObj.CompanyId,
                               jobDutiesObj.Description, jobDutiesObj.Category, jobDutiesObj.Priority, jobDutiesObj.PercentageOfTime,
                               jobDutiesObj.Frequency, jobDutiesObj.Essential, jobDutiesObj.Other, jobDutiesObj.ModifiedBy);
                    return result; 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JobDuties SelectJobDuty(int jobDutyId)
        {
            
            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var jobDutyResult = hrmsentity.usp_JobDutiesSelect(jobDutyId).ToList();
                    var jobDutiesList = jobDutyResult.Select(jobDuties => new JobDuties
                    {
                        JobDutyId = jobDuties.JobDutyID,
                        Description = jobDuties.Description,
                        Category = jobDuties.Category,
                        Priority = jobDuties.Priority,
                        PercentageOfTime = jobDuties.PercentageOfTime,
                        Frequency = jobDuties.Frequency,
                        Essential = jobDuties.Essential,
                        Other = jobDuties.Other,
                        CreatedOn = jobDuties.CreatedOn,
                        ModifiedOn = jobDuties.ModifiedOn,
                        CreatedBy = jobDuties.CreatedBy,
                        ModifiedBy = jobDuties.ModifiedBy
                    }).ToList();
                    return jobDutiesList.SingleOrDefault(); 
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteJobDuties(int jobDutyId, int companyId)
        {

            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var result = hrmsentity.usp_JobDutiesDelete(jobDutyId, companyId);
                    return result > 0; 
                }
            }
            catch (Exception )
            {
                throw ;
            }
        }
        /// <summary>
        /// To provide the list of selected job duties
        /// </summary>
        /// <param name="jobDutyIds"></param>
        /// <returns></returns>
        public List<JobDuties> ListSelectedJobDuties(int[] jobDutyIds, int companyId)
        {
            try
            {
                using (var hrmsentity = new HRMSEntities1())
                {
                    var jobDutiesResult = SelectAllJobDuties(companyId);
                    return jobDutiesResult.Where(duty => jobDutyIds.Contains(duty.JobDutyId)).ToList<JobDuties>();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

     
    }
}

