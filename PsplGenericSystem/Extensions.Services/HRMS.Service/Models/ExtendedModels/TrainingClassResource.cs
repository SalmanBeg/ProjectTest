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
    [MetadataType(typeof(TrainingClassResourceMetaData))]
    public partial class TrainingClassResource
    {

    }
    public partial class TrainingClassResourceMetaData
    {
        public int TrainingClassResourceId { get; set; }
        public Guid TrainingClassResourceCode { get; set; }
        public int TrainingClassId { get; set; }
        [Required(ErrorMessage = "Please select file")]
        public int? Attachment { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        //public int CompanyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
