using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class UserLoginFormModel
    {
        public UserLoginFormModel()
        {
            DashboardCount=new DashboardCount();
            CompanyLevelSecurity = new CompanyLevelSecurity();
        }
        public RegisteredUsers RegisteredUsers { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Boolean IsApproved { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Boolean IsSubmitted { get; set; }
        public DashboardCount DashboardCount { get; set; }
        public CompanyLevelSecurity CompanyLevelSecurity { get; set; }
        public Byte[] EmployeeImage { get; set; }
    }
    public class DashboardCount
    {
        public int NewHireCount { get; set; }
    }
}
