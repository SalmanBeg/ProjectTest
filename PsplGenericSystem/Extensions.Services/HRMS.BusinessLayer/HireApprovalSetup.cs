using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class HireApprovalSetup
    {
        public int HireApprovalSetupId { get; set; }
        public int HireConfigurationId { get; set; }
        public int UserId { get; set; }
        public string StepName { get; set; }
        public int StepId { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime? RejectedOn { get; set; }
        public int RejectedBy { get; set; }
    }
}
