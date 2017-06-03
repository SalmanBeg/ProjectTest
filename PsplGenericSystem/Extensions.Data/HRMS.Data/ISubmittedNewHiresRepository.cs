using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface ISubmittedNewHiresRepository
    {
        List<SubmittedNewHires> SelectAllNewHires(int companyId);
    }
}
