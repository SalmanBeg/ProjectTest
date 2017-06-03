using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.BusinessLayer
{
    public class EmployeeOSHADetail
    {
        public EmployeeOSHADetail()
        {
            CountryIdList = new List<CountryRegion>();
            StateIdList = new List<StateProvince>();
        }
        public int EmployeeOSHADetailId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeOSHADetailCode { get; set; }
        [Display(Name = "Case Number")]
        [Required(ErrorMessage = "Please enter case number.")]
        public int CaseNumber { get; set; }
        [Required(ErrorMessage = "Please enter incident date.")]
        [Display(Name = "Incident Date")]
        public DateTime? IncidentDate { get; set; }
        [Display(Name = "Incident Time")]
        public string IncidentTime { get; set; }
        [Display(Name = "Not Reported")]
        public bool IsNotReported { get; set; }
        [Display(Name = "Medical Costs")]
        public string MedicalCosts { get; set; }
        [Display(Name = "Advisor")]
        public string Advisor { get; set; }
        [Display(Name = "Case Closed On")]
        public DateTime? CaseClosedOn { get; set; }
        [Display(Name = "Completed By")]
        public string CompletedBy { get; set; }
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Display(Name = "Filed On")]
        public DateTime? FiledOn { get; set; }
        [Display(Name = "Claim Type")]
        public string ClaimType { get; set; }
        [Display(Name = "Outcome")]
        public string OutCome { get; set; }
        [Display(Name = "Employee treated in an emergency room")]
        public bool IsEmployeeinEmergency { get; set; }
        [Display(Name = "Employee hospitalized overnight as an in-patient")]
        public bool IsEmployeeInPatient { get; set; }
        [Display(Name = "Physician")]
        public string Physician { get; set; }
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "Facility")]
        public string Facility { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Display(Name = "Zip")]
        [Required(ErrorMessage = "Please enter a valid ZIP Code.")]
        public string Zip { get; set; }
        [Display(Name = "1. Name the Worksite location where the incident occurred.")]
        public string IncidentDetailsMisc1 { get; set; }
        [Display(Name = "2. What was the employee doing just before the incident occurred? Describe the activity, as well as the tools, equipment or material the employee was using prior to the incident.")]
        public string IncidentDetailsMisc2 { get; set; }
        [Display(Name = "3. Tell us how the incident occurred.")]
        public string IncidentDetailsMisc3 { get; set; }
        [Display(Name = "1. Describe the part of the body the was affected, be specific.")]
        public string InjuryDetailsMisc1 { get; set; }
        [Display(Name = "2. What object or substance directly harmed the employee.")]
        public string InjuryDetailsMisc2 { get; set; }
        [Display(Name = "3. Internal Notes(Not included on the OSHA report).")]
        public string InjuryDetailsMisc3 { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Job_Tran_Restrict_Days { get; set; }
        public int Days_Away_From_Work { get; set; }

        [Display(Name = "Job Title")]
        public int JobTitle { get; set; }
        public List<CountryRegion> CountryIdList { get; set; }
        public List<StateProvince> StateIdList { get; set; }
        public List<LookUpDataEntity> ClaimTypeList { get; set; }
        public List<LookUpDataEntity>  OutComeList { get; set; }
    }
}