using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Interfaces
{
    public interface IChat
    {
        string GetSync(string call);
        HttpResponseMessage PostSync(string call, string jsonData);
    }
}
