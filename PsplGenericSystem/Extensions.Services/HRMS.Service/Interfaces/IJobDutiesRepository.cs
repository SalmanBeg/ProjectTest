using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HRMS.Service.Interfaces
{
    public interface IJobDutiesRepository
    {
        /// <summary>
        /// View to add new job duty related to job profile
        /// </summary>
        /// <param name="jobDutiesObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int CreateJobDuties(JobDuties jobDutiesObj);
        /// <summary>
        /// View to show all Job duties in a company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobDuties> SelectAllJobDuties(int companyId);
        /// <summary>
        ///  To update an Job duties based on record id
        /// </summary>
        /// <param name="jobDutiesObj"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        int UpdateJobDuties(JobDuties jobDutiesObj);
        /// <summary>
        /// View to show  Job duties in a company based on 
        /// </summary>
        /// <param name="jobDutyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        JobDuties SelectJobDuty(int jobDutyId);
        /// <summary>
        /// to delete Job duties based on job dutyId
        /// </summary>
        /// <param name="jobDutyId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        bool DeleteJobDuties(int jobDutyId, int companyId);
        /// <summary>
        /// to show selected job duties based on job dutyId and companyid
        /// </summary>
        /// <param name="jobDutyIds"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [Logger]
        [ExceptionLogger]
        List<JobDuties> ListSelectedJobDuties(int[] jobDutyIds, int companyId);
    }
}
