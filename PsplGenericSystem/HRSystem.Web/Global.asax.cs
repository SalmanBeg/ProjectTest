using HRSystem.Web.App_Start;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HRSystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {       
            AreaRegistration.RegisterAllAreas();
            //MefConfig.RegisterMef();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IocConfigurator.ConfigureIocUnityContainer();        
        }

        protected void Compose()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);

            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException cEx)
            {
                System.Diagnostics.Trace.WriteLine(cEx.ToString());
            }

            //GlobalConfiguration.Configuration.DependencyResolver = new MefDependencyResolver(container);
        }
    }
}
