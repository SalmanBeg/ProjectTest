using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.BusinessLayer
{
    public class RoleMaster
    {
        public int RoleMasterId { get; set; }
        public string RoleId { get; set; }
        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Please enter a role name.")]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public bool Status { get; set; }
        public bool IsDefault { get; set; }
    }
}