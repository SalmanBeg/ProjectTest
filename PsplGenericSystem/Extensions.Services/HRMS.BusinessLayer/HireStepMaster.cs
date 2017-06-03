using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class HireStepMaster
    {
        public int StepId { get; set; }
        public string StepCode { get; set; }
        public string StepName { get; set; }
        public bool IsSelected { get; set; }
    }
}
