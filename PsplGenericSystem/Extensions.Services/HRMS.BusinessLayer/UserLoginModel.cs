using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class UserLoginModel
    {
        public UserLoginModel()
        {
            DashboardCount=new DashboardCount();
        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int UserSignUpId { get; set; }
        public string UserSignUpCode { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Boolean IsApproved { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Boolean IsSubmitted { get; set; }
        public DashboardCount DashboardCount { get; set; }
        public string TableName { get; set; }

    }
    public class DashboardCount
    {
        public int NewHireCount { get; set; }
    }
}
