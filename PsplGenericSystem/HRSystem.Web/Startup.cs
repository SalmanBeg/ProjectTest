using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRSystem.Web.Startup))]
namespace HRSystem.Web
{
    public partial class Startup
    {
        private string AuthorizationType = "identity";
        public void Configuration(IAppBuilder app)
        {
            if (AuthorizationType == "oauth")
            {
                ConfigureOAuth(app);
            }
            else
            {
                ConfigureAuth(app);
            }
          
        }
    }
}
