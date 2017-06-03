using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class EmployeeAlert
    {
        public int AlertTemplateId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeName { get; set; }
        public bool Status { get; set; }
    }
}
