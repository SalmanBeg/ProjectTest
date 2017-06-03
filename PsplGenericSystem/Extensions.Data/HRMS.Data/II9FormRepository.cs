using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface II9FormRepository
    {
        I9Form GetI9FormInfo(int userId);
        List<LookUpDataEntity> GetI9AcceptableDocumentsInfo(int CompanyId);
    }
}
