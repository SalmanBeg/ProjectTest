using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;

namespace HRMS.Data
{
    public interface IHireConfigurationSetupRepository
    {
        bool CreateHireConfigurationSetup(HireConfigurationSetup hireConfigurationSetupobj, string currentUserId);
        HireConfigurationSetup NewUserConfigurationSetupSelect(string userId, string companyId);
        bool UpdateHireStatusofEmployee(int userId, bool status);
        bool UpdateStepSubmitStatus(int userId, int stepId, bool status);
        List<HireStepMaster> SelectAllHireSteps();
        List<HireApprovalSetup> SelectAllHireStepsById(int userId);
    }
}
