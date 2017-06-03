using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using HRMS.Service;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ReviewerMetaData))]
    public partial class Reviewer
    {
    }
    public partial class ReviewerMetaData
    {
        public ReviewMaster ReviewMaster { get; set; }

        public int ReviewerId { get; set; }
        public Guid ReviewerCode { get; set; }
        public int ReviewerMasterId { get; set; }
        public int CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        //#region dropdownlist
        //public int ReviewMaster { get; set; }
        //#endregion
    }
}
