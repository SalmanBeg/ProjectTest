using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;


namespace HRMS.Data
{
   public interface IOnBoardingRepository
    {
       bool CreateOnBoarding(OnBoarding onBoardingobj, DataTable consentFormTable);

       List<OnBoarding> SelectAllOnBoardingByCompanyId(int companyId);

       List<OnBoarding> SelectOnBoardingByOnBoardingId(int onBoardingId);

       bool DeleteOnBoarding(int onBoardingId);
    }
}
