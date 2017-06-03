using System;
using HRMS.Service.Models.EDM;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace HRMS.Service.AOP
{
    internal class ExceptionLoggerCallHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn result = getNext()(input, getNext);
            if (result.Exception != null)
            {
                var hrmsEnitity = new HRMSEntities1();
               
                var exceptionLogObj = new HRMS.Service.Models.EDM.ExceptionLog
                {
                    TimeStamp = DateTime.UtcNow,
                    Message =Convert.ToString(result.Exception.InnerException),
                    StackTrace = result.Exception.StackTrace,
                    ExceptionSource = Convert.ToString(result.Exception.TargetSite),
                    CallStack = result.Exception.Source
                };
                hrmsEnitity.ExceptionLog.Add(exceptionLogObj);
                int saveChanges = hrmsEnitity.SaveChanges();
            }

            return result;
        }

        public int Order { get; set; }
    }
}
