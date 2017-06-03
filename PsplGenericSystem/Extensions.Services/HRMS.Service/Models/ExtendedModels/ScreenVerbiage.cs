using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ScreenVerbiageMetaData))]
    public partial class ScreenVerbiage
    {
    }
    public partial class ScreenVerbiageMetaData
    {
        public ScreenVerbiageMetaData()
        {

        }
        public int? ScreenVerbiageId { get; set; }
        [Required]
        public string HireWizardWelcomeText { get; set; }
        public string HireWizardSubmitText { get; set; }
        public string HireWizardApprovalText { get; set; }
        public int? CompanyId { get; set; }
    }
}
