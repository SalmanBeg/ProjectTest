using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class EmployeeDirectDepositFormModel
    {
        public EmployeeDirectDepositFormModel()
        {
            AccountTypeList = new List<LookUpDataEntity>();
            EmployeeDirectDeposit = new EmployeeDirectDeposit();
            EmployeeDirectDepositList = new List<EmployeeDirectDeposit>();
        }

        public EmployeeDirectDeposit EmployeeDirectDeposit { get; set; }
        public List<LookUpDataEntity> AccountTypeList { get; set; }
        public List<EmployeeDirectDeposit> EmployeeDirectDepositList { get; set; }
    }
}