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
    [MetadataType(typeof(ReviewMasterMetaData))]
    public partial class ReviewMaster
    {
    }
    public partial class ReviewMasterMetaData
    {
        public int ReviewMasterId { get; set; }
        public Guid ReviewMasterCode { get; set; }
        public string ReviewMasterName { get; set; }
        public int Level { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        #region dropdownlist
        public int Reviewers { get; set; }
        #endregion
    }
}
