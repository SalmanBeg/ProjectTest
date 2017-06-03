using System.Web.Mvc;

namespace HRMS.Web.Areas.HireWizard
{
    public class HireWizardAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HireWizard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HireWizard_default",
                "HireWizard/{controller}/{action}/{id}",
                new { controller = "NewHire", action = "HireMaster", id = UrlParameter.Optional }
            );
        }
    }
}
