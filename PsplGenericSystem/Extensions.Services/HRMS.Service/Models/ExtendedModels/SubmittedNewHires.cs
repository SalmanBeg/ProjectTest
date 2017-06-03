using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(SubmittedNewHiresMetaData))]
    public partial class SubmittedNewHires
    {
    }
    public partial class SubmittedNewHiresMetaData
    {
        public SubmittedNewHiresMetaData()
        {

        }
        public string Email { get; set; }
        public int UserID { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string UserCode { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int CompanyID { get; set; }
        public bool IsApproved { get; set; }
        [Display(Name = "Status")]
        public bool IsSubmitted { get; set; }
    }
}
