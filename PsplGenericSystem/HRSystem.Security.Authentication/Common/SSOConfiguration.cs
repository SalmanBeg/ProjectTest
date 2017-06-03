using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Security.Authentication
{
   public class SSOConfiguration
    {
       private SSOType ssoType = SSOType.CrossDomain;
       public void ConfigAuthentication()
       {
           if(ssoType == SSOType.CrossDomain)
           {

           }
       }
    }
}
