using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HRMS.Service.Models.EDM
{
    public class PerformanceReview
    {
        public int RevieweeType { get; set; }
        public int ReviewId { get; set; }
        [Display(Name = "Review Name")]
        [Remote("IsTitleExists", "PerformanceReview", AdditionalFields = "Name,CompanyId,ReviewId", ErrorMessage = "Review Name Already Exists")]
        [Required(ErrorMessage = "Please Enter Review Name ")]
        public string Name { get; set; }
        public string Status { get; set; }
        [Display(Name = "Open Reviews")]
        public int OpenReviews { get; set; }
        [Display(Name = "Closed Reviews")]
        public int ClosedReviews { get; set; }
        public int CompanyId { get; set; }

        public int DepartmentId { get; set; }
        public int JobTitleId { get; set; }
        public string EmployeeIdType { get; set; }
        [Display(Name = "Days To Complete")]
        [Required(ErrorMessage = "Please Enter Days ToComplete ")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int DaysToComplete { get; set; }
        public DateTime FromDate { get; set; }
        public string FromSchedule { get; set; }
        [Display(Name = "Interval Type")]
        [Required(ErrorMessage = "Please Select Interval Type ")]
        public int IntervalType { get; set; }

        [Required(ErrorMessage = "Please Enter weightage for Accountability")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public float Accountability { get; set; }
        [Required(ErrorMessage = "Please Enter weightage for Competency ")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public float Competency { get; set; }
        [Required(ErrorMessage = "Please Enter weightage for Goal ")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public float Goal { get; set; }
        [Required(ErrorMessage = "Please Enter weightage for Question ")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Count must be a natural number")]
        public int Question { get; set; }
        public bool WeightedAverage { get; set; }
        [Required(ErrorMessage = "Please Enter ScheduleValue ")]
        public int ScheduleValue { get; set; }

        public string Type { get; set; }
        [Display(Name = "Reviewee")]
        [Required(ErrorMessage = "Please Select Review ")]
        public string Reviewee { get; set; }
        public int PositionId { get; set; }
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public int DateType { get; set; }
        public DateTime CustomDate { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int ResponseTypeId { get; set; }
        public bool Manager { get; set; }
        public int CriteriaTypeId { get; set; }
        public int ReviewCriteriaId { get; set; }

        public List<bool> ManagerType { get; set; }

        public int OtherEmployee { get; set; }

       

        public List<LookUpDataEntity> DepartmentList { get; set; }
        public List<LookUpDataEntity> EmployeeList { get; set; }
        public List<LookUpDataEntity> JobTitleList { get; set; }

    }
}
