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
    [MetadataType(typeof(ReviewMetaData))]
    public partial class Review
    {
    }
    public partial class ReviewMetaData
    {
        public int ReviewId { get; set; }
        public string ReviewCode { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int HRManagerId { get; set; }
        public string HRComments { get; set; }
        public bool HRStatus { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        #region Dropdown Properties
        public int ReviewSchedules { get; set; }
        public int ReviewScores { get; set; }
        public int Reviewees { get; set; }
        #endregion
    }
}
