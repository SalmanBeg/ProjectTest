using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{   
    public partial class UserLoginModel
    {
        public UserLoginModel()
        {
            DashboardCount = new DashboardCount();
        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public Guid UserCode { get; set; }
        public string UserName { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Boolean? IsApproved { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public Boolean? IsSubmitted { get; set; }
        public DashboardCount DashboardCount { get; set; }
        public int? FileId { get; set; }
        public string FileName { get; set; }
    }   
    public class DashboardCount
    {
        public int NewHireCount { get; set; }
    }
}
