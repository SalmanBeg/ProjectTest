using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Interfaces;
using HRMS.Service.Models.EDM;

namespace HRMS.Service.Repositories
{
    public class JobPMERepository : IJobPMERepository
    {
        public int CreateJobPME(JobPME jobPMEObj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_JobPMEInsert(jobPMEObj.CompanyId, jobPMEObj.Description, jobPMEObj.Category, jobPMEObj.Frequency, jobPMEObj.Essential, jobPMEObj.CreatedBy);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public JobPME SelectJobPME(int pmeId)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var jobPmeResult = hrmsEntity.usp_JobPMESelect(pmeId).ToList();
                    var jobPMEList = jobPmeResult.Select(jobPME => new JobPME
                    {
                        PMEId = jobPME.PMEId,
                        PMECode = jobPME.PMECode,
                        CompanyId = jobPME.CompanyID,
                        Category = jobPME.Category,
                        Description = jobPME.Description,
                        Frequency = jobPME.Frequency,                        
                        Essential = jobPME.Essential,
                        CreatedOn = jobPME.CreatedOn,
                        ModifiedOn = jobPME.ModifiedOn,
                        CreatedBy = jobPME.CreatedBy,
                        ModifiedBy = jobPME.ModifiedBy
                    }).ToList();
                    return jobPMEList.SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int UpdateJobPME(JobPME jobPMEObj)
        {

            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_JobPMEUpdate(jobPMEObj.PMEId, jobPMEObj.CompanyId, jobPMEObj.Category, jobPMEObj.Description, jobPMEObj.Frequency, jobPMEObj.Essential, jobPMEObj.ModifiedOn, jobPMEObj.ModifiedBy);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }


            //return 1;
        }
        public List<JobPME> SelectAllJobPME(int companyId)
        {

            try
            {

                using (var hrmsEntity = new HRMSEntities1())
                {
                    var jobPmeResult = hrmsEntity.usp_JobPMESelectAll(companyId).ToList();
                    return jobPmeResult.Select(JobPMEList => new JobPME
                    {
                        PMEId = JobPMEList.PMEID,
                        PMECode = JobPMEList.PMECode,
                        CompanyId = JobPMEList.CompanyID,
                        Category = JobPMEList.Category,
                        Description = JobPMEList.Description,
                        Frequency = JobPMEList.Frequency,
                        FrequencyName= JobPMEList.FrequencyName,
                        Essential = JobPMEList.Essential,
                        CreatedOn = JobPMEList.CreatedOn,
                        CreatedBy = JobPMEList.CreatedBy,
                        ModifiedOn = JobPMEList.ModifiedOn,
                        ModifiedBy = JobPMEList.ModifiedBy
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteJobPME(int pmeid, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var result = hrmsEntity.usp_JobPMEDelete(pmeid, companyId);
                    return result > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To provide the list of selected job pme
        /// </summary>
        /// <param name="jobPMEIds"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public List<JobPME> ListSelectedJobPMEs(int[] jobPMEIds, int companyId)
        {
            try
            {
                using (var hrmsEntity = new HRMSEntities1())
                {
                    var jobPMEResult = SelectAllJobPME(companyId);
                    return jobPMEResult.Where(pme => jobPMEIds.Contains(pme.PMEId)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
