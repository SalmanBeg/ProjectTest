using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IScreenVerbiageRepository
    {
        ScreenVerbiage SelectScreenVerbiage(int CompanyId);
        bool UpdateScreenVerbiage(ScreenVerbiage ScreenVerbiageObj);
        bool InsertScreenVerbiage(ScreenVerbiage ScreenVerbiageObj);
    }
}
