using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{  
     public  class EmployeeConfigurationSetupModel
     {
         public EmployeeConfigurationSetupModel()
         {
             RegisteredUsers = new RegisteredUsers();
             Employee = new Employee();
             HireConfigurationSetup = new HireConfigurationSetup();
             OnBoardingSetup = new OnBoarding();
             HireApprovalSetup = new HireApprovalSetup();
         }
         public RegisteredUsers RegisteredUsers { get; set; }
         public Employee Employee { get; set; }
         public HireConfigurationSetup HireConfigurationSetup { get; set; }
         public OnBoarding OnBoardingSetup { get; set; }
         public HireApprovalSetup HireApprovalSetup { get; set; }
     }
}
