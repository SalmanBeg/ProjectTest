using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class EmployeeInfoFormModel
    {
        public Employee Employee { get; set; }
        public EmployeeTax EmployeeTax { get; set; }
    }
}