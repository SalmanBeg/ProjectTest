using HRMS.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Data
{
   public interface IUtilityRepository
    {
       List<CountryRegion> GetCountry();
       List<StateProvince> GetState(int countryRegionId);
       List<StateProvince> GetState();
       List<LookUpDataEntity> GetLookUpData(int CompanyID);
       List<AlertSendType> GetAlertSendType();      
       List<AlertSendCriteria> GetAlertSendCriteria();
    }
}
