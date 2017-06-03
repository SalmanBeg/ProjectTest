using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Web.Helper;
using System.Web.Mvc;
using System.Web.Routing;

namespace HRMS.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CheckSessionOutAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();

            if (filterContext.ActionDescriptor.ActionName != "LogIn" && !controllerName.Contains("account"))
            {
                HttpSessionStateBase session = filterContext.HttpContext.Session;
                var user = GlobalsVariables.CurrentUserId; 
                if ((string.IsNullOrWhiteSpace(user) && (!session.IsNewSession)) || (session.IsNewSession))
                {
                    //send them off to the login page
                    if (filterContext.HttpContext.Request.IsAjaxRequest() &&  (!controllerName.ToLower().Equals("jobportal")))
                    {
                        filterContext.Result = new JsonResult
                        {
                            Data = new
                            {
                                ErrorMessage = "SystemSessionTimeOut"
                            },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }
                    else
                    {
                        if ((!controllerName.ToLower().Equals("admin")) && (!controllerName.ToLower().Equals("jobportal")) && (!controllerName.ToLower().Equals("recruiting")))
                        {
                            base.OnActionExecuting(filterContext);
                            string loginUrl = System.Configuration.ConfigurationManager.AppSettings["_TimeOuturl"];
                            filterContext.Result = new RedirectResult(loginUrl);
                            //= new RedirectToRouteResult(
                            //new RouteValueDictionary { { "controller", "Account" }, { "action", "TimeoutRedirect" } });
                        }
                    }
                }
            }
            
        }
    }

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    //public class CheckSessionOutAttribute : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        HttpContext ctx = HttpContext.Current;

    //        // If the browser session or authentication session has expired...
    //        if (ctx.Session["UserName"] == null || !filterContext.HttpContext.Request.IsAuthenticated)
    //        {
    //            if (filterContext.HttpContext.Request.IsAjaxRequest())
    //            {
    //                // For AJAX requests, we're overriding the returned JSON result with a simple string,
    //                // indicating to the calling JavaScript code that a redirect should be performed.
    //                filterContext.Result = new JsonResult { Data = "_Logon_" };
    //            }
    //            else
    //            {
    //                // For round-trip posts, we're forcing a redirect to Home/TimeoutRedirect/, which
    //                // simply displays a temporary 5 second notification that they have timed out, and
    //                // will, in turn, redirect to the logon page.
    //                filterContext.Result = new RedirectToRouteResult(
    //                    new RouteValueDictionary {
    //                    { "Controller", "Home" },
    //                    { "Action", "TimeoutRedirect" }
    //            });
    //            }
    //        }

    //        base.OnActionExecuting(filterContext);
    //    }
    //}
}