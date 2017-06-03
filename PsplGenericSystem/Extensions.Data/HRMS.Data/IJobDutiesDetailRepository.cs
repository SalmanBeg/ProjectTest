using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IJobDutiesDetailRepository
    {
        bool CreateJobDutiesDetails(JobDutiesDetail jobdutiesDetailobj);

        List<JobDutiesDetail> SelectAllJobDutiesDetail( int companyId);

        JobDutiesDetail SelectJobDutiesDetailById(int jobdutiesDetailId, int companyId);
    }
}
