using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
  public interface IJobCompensationRepository
    {
      bool CreateJobCompensationDetails(JobCompensationDetail jobcompensationobj);
      JobCompensationDetail SelectJobCompensationDetailById(int compensationID, int companyId);
      List<JobCompensationDetail> SelectAllJobCompensationDetailByCompanyId(int CompanyId);
    }
}
