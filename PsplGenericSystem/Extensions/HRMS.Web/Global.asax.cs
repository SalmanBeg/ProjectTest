using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


using System.Reflection;
using System.Web.Security;
using HRMS.Web.Helper;
using HRMS.Web.Controllers;

namespace HRMS.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Removes all the view engine
            ViewEngines.Engines.Clear();// Add View Engine that we are ging to use. Here I am using Razor View Engine
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Enable or Disable Client Side Validation at Application Level
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;

            ////var container = new Container();

            ///Register your types, for instance using the RegisterWebApiRequest
            #region Register repositories here
            //container.Register<IUserRepository, UserRepository>();
            //container.Register<ICompanyRepository, CompanyRepository>();
            //container.Register<IEmployeeDependentRepository, EmployeeDependentRepository>();
            //container.Register<IEmployeeOSHARepository, EmployeeOSHARepository>();
            //container.Register<IDirectDepositRepository,DirectDepositRepository>();
            //container.Register<IEmergencyContactRepository,EmergencyContactRepository>();
            //container.Register<IPayDetailRepository,PayDetailRepository>();
            //container.Register<ITaxDetailRepository,TaxDetailRepository>();
            //container.Register<IEmployeeRepository,EmployeeRepository>();
            //container.Register<IHireConfigurationSetupRepository, HireConfigurationSetupRepository>();
            //container.Register<IUtilityRepository, UtilityRepository>();
            //container.Register<ILookUpDataRepository, LookUpDataRepository>();
            //container.Register<IConsentFormRepository, ConsentFormRepository>();
            //container.Register<IFilesDBRepository, FilesDBRepository>();
            //container.Register<IOnBoardingRepository, OnBoardingRepository>();
            //container.Register<ISubmittedNewHiresRepository, SubmittedNewHiresRepository>();
            //container.Register<II9FormRepository, I9FormRepository>();
            //container.Register<IPositionRepository, PositionRepository>();
            //container.Register<II9WorkAuthorizationRepository, I9WorkAuthorizationRepository>();
            //container.Register<IJobProfileDetailRepository,JobProfileDetailRepository>();
            //container.Register<IJobCompensationRepository, JobCompensationRepository>();
            //container.Register<IJobComplainceCodeRepository, JobComplainceCodeRepository>();
            //container.Register<IJobDutiesDetailRepository, JobDutiesDetailRepository>();
            //container.Register<IJobQualificationDetailRepository, JobQualificationDetailRepository>();
            //container.Register<IJobPMEDetailRepository, JobPMEDetailRepository>();
            //container.Register<IEmployeeW4FormRepository,EmployeeW4FormRepository>();
            //container.Register<IScreenVerbiageRepository, ScreenVerbiageRepository>();
            //container.Register<IRoleRepository,RoleRepository>();
            //container.Register<IAlertTemplateRepository,AlertTemplateRepository>();
            //container.Register<IImportEmployeecsvRepository, ImportEmployeecsvRepository>();
            //container.Register<IMailerRepository, MailerRepository>();
            #endregion


            //// This is an extension method from the integration package.
            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //container.Verify();

            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            
        }
        protected void Session_End(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            //System.Web.Mvc.ActionExecutingContext filterContext = new ActionExecutingContext();
            // filterContext.Result = new RedirectToRouteResult(
            //                new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
           // Response.Redirect("Account/LogIn");
            //if (string.IsNullOrWhiteSpace(Convert.ToString(Session["currentCompanyId"])))
            //{
            //    System.Web.Mvc.ActionExecutingContext filterContext= new ActionExecutingContext();
            //    FormsAuthentication.SignOut();
            //    Session.Clear();
            //    Session.Abandon();
            //    Response.Redirect("Account/LogIn");
            //    // Call target Controller and pass the routeData.
            //   filterContext.Result = new RedirectToRouteResult(
            //                new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" } });
            //}
        }     
    }
}