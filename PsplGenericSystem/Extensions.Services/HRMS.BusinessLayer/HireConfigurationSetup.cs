using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HRMS.BusinessLayer
{
    public class HireConfigurationSetup
    {
        public int HireConfigurationID { get; set; }
        public int UserSignUpID { get; set; }
        public string UserSignUpCode { get; set; }
        public int CompanyID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
