using HRMS.Service.AOP;
using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Interfaces
{
    public interface IUserRepository
    {
        [Logger]
        [ExceptionLogger]
        List<UserLoginModel> SelectAllUserList(string username);
    }
}
