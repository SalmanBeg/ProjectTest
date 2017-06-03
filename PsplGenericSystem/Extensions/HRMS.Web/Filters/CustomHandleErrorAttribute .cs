using System.Web;
using System.Web.Mvc;

namespace HRMS.Web.Filters
{
    /// <summary>
    /// exception handling filter attribute
    /// </summary>
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            // if the request is AJAX return JSON else view.
            if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                       // error = true,
                        message = "Internal error has occured in calling url."
                        // filterContext.Exception.Message
                    }
                };
            }
            else
            {
              

                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };

               
            }

            //ErrorLog objExceptionClass = new ErrorLog();
            //objExceptionClass.TimeStamp = DateTime.Now;
            //objExceptionClass.Message = filterContext.Exception.Message;
            //objExceptionClass.StackTrace = filterContext.Exception.StackTrace;
            //objExceptionClass.ExceptionSource = filterContext.Exception.Source;
            //objExceptionClass.MachineName = Environment.MachineName;
            //objExceptionClass.CallStack = Environment.StackTrace;
            //objExceptionClass.AppDomainName = AppDomain.CurrentDomain.FriendlyName;
            //objExceptionClass.ThreadUser = System.Threading.Thread.CurrentPrincipal.ToString();
            //objExceptionClass.ControllerName = controllerName;
            //objExceptionClass.ActionName = actionName;
            //objExceptionClass.ModelName = model.GetDescription();
            //objExceptionClass.CompanyId = GlobalVariables.CurrentUserCompanyId;
            //HappyFilesWeb.Data.Services.ExceptionService.LogException(objExceptionClass);


            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;

            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}