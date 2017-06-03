using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class ImportEmployeeFormModel 
    {
        public ImportEmployeeFormModel()
        {
            Employee = new Employee();
            EmployeeDependent = new EmployeeDependent();
        }
        public Employee Employee { get; set; }
        public EmployeeDependent EmployeeDependent { get; set; }
        public IEnumerable<System.Data.DataRow> Rows { get; set; }

        public int Csvslno { get; set; }
    }
}