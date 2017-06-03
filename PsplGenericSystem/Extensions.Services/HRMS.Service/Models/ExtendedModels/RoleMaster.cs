using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using System.Web.Mvc;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(RoleMasterMetaData))]
    public partial class RoleMaster
    {
       
    }
    public partial class RoleMasterMetaData
    {
        public int RoleMasterId { get; set; }
        public int RoleId { get; set; }
        [Display(Name = "Role Name")]
        [Required(ErrorMessage = "Please enter a role name.")]
        [Remote("IsTitleExists", "Role", AdditionalFields = "RoleName,CompanyId,RoleMasterId", ErrorMessage = "Role Name already exists")]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public bool Status { get; set; }
        public bool IsDefault { get; set; }
    }
}
