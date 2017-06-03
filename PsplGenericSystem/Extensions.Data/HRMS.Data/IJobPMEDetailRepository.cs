using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IJobPMEDetailRepository
    {
        bool CreateJobPMEDetails(JobPMEDetails jobpmeobj);
       JobPMEDetails SelectJobPMEDetailById(int jobpmeID, int companyId);
        List<JobPMEDetails> SelectAllJobPMEDetailByCompanyId(int CompanyId);
    }
}
