using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface IJobQualificationRepository
    {
        [Logger]
        [ExceptionLogger]
        int CreateJobQualification(JobQualification jobQualificationObj);
        [Logger]
        [ExceptionLogger]
        JobQualification SelectJobQualification(int jobQualificationId);
        [Logger]
        [ExceptionLogger]
        List<JobQualification> SelectAllJobQualification(int companyId);
        [Logger]
        [ExceptionLogger]
        int UpdateJobQualification(JobQualification jobQualificationObj);
        [Logger]
        [ExceptionLogger]
        bool DeleteJobQualification(int jobQualificationId, int companyId);

        [Logger]
        [ExceptionLogger]
        List<JobQualification> ListSelectedJobQualifications(int[] jobQualificationIds, int companyId);
    }
}
