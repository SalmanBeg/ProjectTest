using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IJobQualificationDetailRepository
    {
        bool CreateJobQualificationDetails(JobQualification jobquaobj);
        JobQualification SelectJobQualificationDetailById(int jobqualificationID, int companyId);
        List<JobQualification> SelectAllJobQualificationByCompanyId(int CompanyId);
    }
}
