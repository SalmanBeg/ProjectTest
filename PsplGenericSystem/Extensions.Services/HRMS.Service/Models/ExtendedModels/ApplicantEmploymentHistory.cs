using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(ApplicantEmploymentHistoryMetaData))]
    public partial class ApplicantEmploymentHistory
    {
        public List<ApplicantEmploymentHistory> ApplicantEmploymentHistoryList { set; get; }
    }
    public partial class ApplicantEmploymentHistoryMetaData
    {
        public ApplicantEmploymentHistoryMetaData()
        { }
        [Required(ErrorMessage="Enter title.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EmploymentStartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public Nullable<System.DateTime> EmploymentEndDate { get; set; }
    }
}
