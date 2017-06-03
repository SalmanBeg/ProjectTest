using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using HRMS.Service.Models.EDM;
using System.Threading.Tasks;

namespace HRMS.Service.Models.ExtendedModels
{
    [MetadataType(typeof(EmployeeReviewScoreMetaData))]
    public partial class EmployeeReviewScore
    {

    }
    public partial class EmployeeReviewScoreMetaData
    {
        public Employee Employee { get; set; }
        public Review Review { get; set; }
        public Reviewer Reviewer { get; set; }
        public ReviewerEmployee ReviewerEmployee { get; set; }
    }
}
