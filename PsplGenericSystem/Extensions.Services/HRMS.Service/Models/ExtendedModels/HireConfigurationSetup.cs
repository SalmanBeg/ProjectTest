using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(HireConfigurationSetupMetaData))]
    public partial  class HireConfigurationSetup
    {
    }
    public partial  class HireConfigurationSetupMetaData
    {
        public HireConfigurationSetupMetaData()
        {

        }
        public int HireConfigurationID { get; set; }
        public int UserID { get; set; }
        public string UserCode { get; set; }
        public int CompanyID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
