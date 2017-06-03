using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class ScreenVerbiage
    {
        public int? ScreenVerbiageId { get; set; }
        public string HireWizardWelcomeText { get; set; }
        public string HireWizardSubmitText { get; set; }
        public string HireWizardApprovalText { get; set; }
        public int? CompanyId { get; set; }
    }
}
