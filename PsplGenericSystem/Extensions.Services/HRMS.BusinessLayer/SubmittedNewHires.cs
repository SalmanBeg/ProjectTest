using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class SubmittedNewHires
    {
        public string Email { get; set; }
        public int UserSignUpID { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string UserSignUpCode { get; set; }
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
