using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
  public interface  IJobComplainceCodeRepository
    {
      bool CreateComplainceCodeDetails(JobComplianceCode jobcomplainceobj);
      JobComplianceCode SelectJobComplainceCodeDetailById(int jobcomplainceID, int companyId);
      List<JobComplianceCode> SelectAllJobComplainceCodeByCompanyId(int CompanyId);

    }
}
