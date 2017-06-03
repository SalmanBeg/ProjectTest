using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.ExtendedModels
{
    public class EmployeeSnapshot
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public string SSN { get; set; }
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Home Email")]
        public string HomeEmail { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
        [Display(Name = "Original Hire Date")]
        public DateTime? OriginalHireDate { get; set; }
        [Display(Name = "Termination Date")]
        public DateTime? TerminationDate { get; set; }
        [Display(Name = " Work Email")]
        public string WorkEmail { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Seniority Date")]
        public DateTime? SeniorityDate { get; set; }
        [Display(Name = "Last Paid Date")]
        public DateTime? LastPaidDate { get; set; }
        [Display(Name = "Last Pay Rise")]
        public DateTime? LastPayRise { get; set; }
        [Display(Name = "Last Review Date")]
        public DateTime? LastReviewDate { get; set; }
        [Display(Name = "Next Review Date")]
        public DateTime? NextReviewDate { get; set; }
        public string Department { get; set; }
        public string Suffix { get; set; }
        public string Salutation { get; set; }
        [Display(Name = "JobProfile")]
        public string JobDescription { get; set; }
        public string Division { get; set; }
        public string Position { get; set; }
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }
         [Display(Name = "Compliance Code")]
        public string ComplianceCode { get; set; }

    }
}
