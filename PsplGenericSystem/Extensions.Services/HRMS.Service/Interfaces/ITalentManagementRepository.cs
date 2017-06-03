using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;
using HRMS.Service.AOP;

namespace HRMS.Service.Interfaces
{
    public interface ITalentManagementRepository
    {
        [Logger]
        [ExceptionLogger]
        bool ViewTalentManagements(TalentManagement talentManagementobj);

        [Logger]
        [ExceptionLogger]
        List<TalentManagement> SelectAllTalentManagement(int companyId);

        [Logger]
        [ExceptionLogger]
        List<TalentManagement> SelectTalentManagementById(int companyId, int talentManagementId);

        [Logger]
        [ExceptionLogger]
        bool UpdateTalentManagement(TalentManagement talentManagementobj);

        [Logger]
        [ExceptionLogger]
        bool DeleteTalentManagement(int talentManagementId, int companyId);
    }
}
