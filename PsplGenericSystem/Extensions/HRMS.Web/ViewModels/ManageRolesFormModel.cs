using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;


namespace HRMS.Web.ViewModels
{
    public class ManageRolesFormModel
    {
        public ManageRolesFormModel()
        {
            RoleList = new List<RoleMaster>();

        }
        public bool IsDefault1
        {
            get
            {
                return (RoleMaster != null && RoleMaster.IsDefault != null);
            }
            set
            { RoleMaster.IsDefault = value; }
        }

        public RoleMaster RoleMaster { get; set; }
        public List<RoleMaster> RoleList { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
         [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public int? RoleMasterId { get; set; }
        public bool? Status { get; set; }
        public string Email { get; set; }       
        public int? CompanyId { get; set; }
        public int UserId { get; set; }
        public bool? IsDefault { get; set; }
        public string Description { get; set; }
    }
}