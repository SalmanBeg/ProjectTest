using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface IMasterRepository
    {
        [Logger]
        [ExceptionLogger]
        List<Reviewee> SelectReviewNotification(int employeeId, int companyId);

        [Logger]
        [ExceptionLogger]
        bool ResetAllData();
    }
}
