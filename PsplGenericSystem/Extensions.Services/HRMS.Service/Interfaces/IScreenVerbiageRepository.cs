using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
   public interface IScreenVerbiageRepository
   {
       [Logger]
       [ExceptionLogger]
       ScreenVerbiage SelectScreenVerbiage(int companyId);

       [Logger]
       [ExceptionLogger]
       bool InsertScreenVerbiage(ScreenVerbiage screenVerbiageObj);

       [Logger]
       [ExceptionLogger]
       bool UpdateScreenVerbiage(ScreenVerbiage screenVerbiageObj);
    }
}
