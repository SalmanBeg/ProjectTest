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
    [MetadataType(typeof(ReviewerEmployeeMetaData))]
    public partial class ReviewerEmployee
    {
        [Display(Name = "Manager Name:")]
        public string ManagerName { get; set; }
        [Display(Name = "Reviewer Name:")]
        public string ReviewerName { get; set; }
        [Display(Name = "How do you consider him perfect for the job?")]
        public string Description { get; set; }
        public string ReviewTitle { get; set; }
       
    }
    public partial class ReviewerEmployeeMetaData
    {
        //public Review Review { get; set; }
        [Display(Name = "Employee Name:")]
        public int ReviewerEmployeeId { get; set; }
        public Guid ReviewerEmployeeCode { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        [Display(Name = "Manager Name:")]
        public string ManagerName { get; set; }
        [Display(Name = "Review Date:")]
        public DateTime ReviewDate { get; set; }
        [Display(Name = "Status:")]
        public int Status { get; set; }
        [Display(Name = "Review Score:")]
        public decimal ReviewScore { get; set; }
        [Display(Name = "Reviewer Score:")]
        public decimal ReviewerScore { get; set; }
        [Display(Name = "Reviewer Comments")]
        public string ReviewerComments { get; set; }
        public bool IsSubmit { get; set; }
        [Display(Name = "HR Comments")]
        public string HRComments { get; set; }
        public int HRStatus { get; set; }
        public int ReviewerId { get; set; }
        public DateTime ReviewEndDate { get; set; }        
        public int ReviewerMasterId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ReviewTitle { get; set; }
        //[Display(Name = "How do you consider him perfect for the job?")]
        //public string Description { get; set; }
        //public List<LookUpDataEntity> DescriptionList { get; set; }   
    }
}
