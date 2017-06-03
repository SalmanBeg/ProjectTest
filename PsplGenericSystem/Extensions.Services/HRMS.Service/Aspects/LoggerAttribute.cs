using Microsoft.Practices.Unity.InterceptionExtension;

namespace HRMS.Service.AOP
{
    internal class LoggerAttribute : HandlerAttribute
    {
        public override ICallHandler CreateHandler(Microsoft.Practices.Unity.IUnityContainer container)
        {
            return new LoggerCallHandler();
        }
    }
}
