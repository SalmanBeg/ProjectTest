using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface IJobPMERepository
    {
        [Logger]
        [ExceptionLogger]
        int CreateJobPME(JobPME jobPMEObj);
        [Logger]
        [ExceptionLogger]
        int UpdateJobPME(JobPME jobPMEObj);
        [Logger]
        [ExceptionLogger]
        List<JobPME> SelectAllJobPME(int companyId);
        [Logger]
        [ExceptionLogger]
        JobPME SelectJobPME(int pmeId);
        [Logger]
        [ExceptionLogger]
        bool DeleteJobPME(int pmeid, int companyId);
        [Logger]
        [ExceptionLogger]
        List<JobPME> ListSelectedJobPMEs(int[] jobPMEIds, int companyId);
    }
}
