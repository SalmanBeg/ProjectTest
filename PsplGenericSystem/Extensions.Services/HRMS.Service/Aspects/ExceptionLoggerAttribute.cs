using Microsoft.Practices.Unity.InterceptionExtension;

namespace HRMS.Service.AOP
{
    internal class ExceptionLoggerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
        {
            return new ExceptionLoggerCallHandler();
        }
    }
}
