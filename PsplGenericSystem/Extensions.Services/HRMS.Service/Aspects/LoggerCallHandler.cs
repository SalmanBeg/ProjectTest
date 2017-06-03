using System;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace HRMS.Service.AOP
{
    internal class LoggerCallHandler : ICallHandler
    {
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn result = getNext()(input, getNext);

            Console.WriteLine("Parameters:");
            foreach (var parameter in input.Arguments)
            {
                Console.WriteLine(parameter);
            }

            Console.WriteLine();

            return result;
        }

        public int Order { get; set; }
    }
}
