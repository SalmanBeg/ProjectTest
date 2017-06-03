using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
  public interface IPositionRepository
    {
      bool CreatePositionDetails(PositionDetails posdetobj);

      List<PositionDetails> SelectPositionDetailsById(int PositionID, int CompanyID);

     List<PositionDetails> SelectAllPositionDetailsByCompanyId(int CompanyID);

     bool DeletePositionDetail(int PositionID, int CompanyID);
      
    }
}
