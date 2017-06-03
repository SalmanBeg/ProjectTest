using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;


namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(JobComplianceCodeMetaData))]
    public partial class JobComplianceCode
    {
    }
    public partial class JobComplianceCodeMetaData
    {
        public JobComplianceCodeMetaData()
        {

        }
        public int ComplainceID { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }

        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        #region Date Properties
        public DateTime? CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        #endregion
    }
}
