using System.Web;
using System.Web.Mvc;
using HRMS.Filters;

namespace HRMS.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CheckSessionOutAttribute());            
        }
    }
}