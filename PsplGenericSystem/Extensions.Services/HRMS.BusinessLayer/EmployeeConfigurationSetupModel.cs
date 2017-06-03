using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class EmployeeConfigurationSetupModel
    {
        public EmployeeConfigurationSetupModel()
        {
            UserSignUp = new UserSignUp();
            Employee = new Employee();
            HireConfigurationSetup = new HireConfigurationSetup();
            OnBoardingSetup = new OnBoarding();
            HireApprovalSetup = new HireApprovalSetup();
        }
        public UserSignUp UserSignUp { get; set; }
        public Employee Employee { get; set; }
        public HireConfigurationSetup HireConfigurationSetup { get; set; }
        public OnBoarding OnBoardingSetup { get; set; }
        public HireApprovalSetup HireApprovalSetup { get; set; }
    }
}
