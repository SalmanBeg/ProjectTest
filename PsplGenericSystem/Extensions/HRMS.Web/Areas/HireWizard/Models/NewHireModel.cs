using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using HRMS.Web.ViewModels;

namespace HRMS.Web.Areas.HireWizard.Models
{
    public class NewHireModel
    {
        public NewHireModel()
        {
            EmployeeDirectDepositList= new List<EmployeeDirectDeposit>();
            ConsentForm = new List<ConsentForms>();
            HireActiveStepList = new List<HireApprovalSetup>();
            EmployeeFormModel = new EmployeeFormModel();
            EmployeeTaxW4Model = new EmployeeTaxW4FormModel();
            I9FormModel = new I9FormModel();
            ScreenVerbiage = new ScreenVerbiage();
        }

        public HireConfigurationSetup HireConfigurationSetup { get; set; }
        public List<EmployeeDirectDeposit> EmployeeDirectDepositList { get; set; }
        public Employee Employee { get; set; }
        public string PageLayout { get; set; }
        public List<ConsentForms> ConsentForm { get; set; }
        public List<HireApprovalSetup> HireActiveStepList { get; set; }
        public EmployeeFormModel EmployeeFormModel { get; set; }
        public EmployeeTaxW4FormModel EmployeeTaxW4Model { get; set; }
        public I9FormModel I9FormModel { get; set; }
        public ScreenVerbiage ScreenVerbiage { get; set; }

    }
}