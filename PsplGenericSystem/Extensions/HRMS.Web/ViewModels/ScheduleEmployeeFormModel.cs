using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.BusinessLayer;
using System.ComponentModel.DataAnnotations;
namespace HRMS.Web.ViewModels
{
    public class ScheduleEmployeeFormModel : UserLoginModel
    {
        public ScheduleEmployeeFormModel()
        {
            //UserLoginModelInfo = new List<UserLoginModel>();
            DepartmentList = new List<LookUpDataEntity>();
            JobList = new List<LookUpDataEntity>();
            ProjectList = new List<LookUpDataEntity>();
        }

        //public int CompanyId { get; set; }
        //public string CompanyName { get; set; }
        //public string Email { get; set; }
        //public int UserSignUpId { get; set; }
        //public string UserSignUpCode { get; set; }
        //public string UserName { get; set; }
        //[Display(Name = "First Name")]
        //public string FirstName { get; set; }
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }
        //public int RoleId { get; set; }
        //public string RoleName { get; set; }
        //public Boolean IsApproved { get; set; }
        //public DateTime LastLoginDate { get; set; }
        //public Boolean IsSubmitted { get; set; }
        
        //public List<UserLoginModel> UserLoginModelInfo { get; set; }
        public List<LookUpDataEntity> DepartmentList { get; set; }
        [Display(Name="Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Job")]
        public List<LookUpDataEntity> JobList { get; set; }
        public int JobProfileId { get; set; }
        [Display(Name = "Project")]
        public List<LookUpDataEntity> ProjectList { get; set; }
        public int ProjectID { get; set; }
    }

    //public class Employee : UserLoginModel
    //{

    //}
}