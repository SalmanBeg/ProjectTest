
namespace HRSystem.Services.Models
{
    public partial class CompanyDashboards
    {
        public int Count { get; set; }
        public string label { get; set; }
    }

    public class BenefitEnrollment
    {
        public string StateName { get; set; }
        public int PlanType { get; set; }
    }
}
