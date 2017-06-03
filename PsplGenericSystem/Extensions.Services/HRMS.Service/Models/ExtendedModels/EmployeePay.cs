using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;


namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeePayDetailMetaData))]
    public partial class EmployeePay 
    {
        [Display(Name = "Annualized Pay")]
        public double Annualizedpay { get; set; }
 
        
    }
    public class EmployeePayDetailMetaData
    {
        public EmployeePayDetailMetaData()
        {

           
        }
        public int EmployeePayId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string EmployeePayCode { get; set; }
        [Display(Name = "Change Reason")]
        [Required(ErrorMessage = "Please enter change reason.")]
        public int Reason { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Effective Date")]
        [Required(ErrorMessage = "Please enter effective date.")]
        public DateTime? EffectiveDate { get; set; }

        [Display(Name = "Auto Pay")]
        public bool AutoPay { get ; set; }
        [Required(ErrorMessage = "Please enter compensation.")]
        [Display(Name = "Compensation")]
        [UIHint("Currency")]
        public string Compensation { get; set; }
        [Display(Name = "Compensation Frequency")]
        public int CompensationFrequency { get; set; }
        [Display(Name = "Hourly Rate2")]
        public double HourlyRate2 { get; set; }
        [Display(Name = "Hourly Rate3")]
        public double HourlyRate3 { get; set; }
        [Display(Name = "Pay Frequency")]
        [Required(ErrorMessage = "Please enter pay frequency.")]
        public int PayFrequency { get; set; }
        [Display(Name = "Standard Hours")]
        [Required(ErrorMessage = "Please enter standard hours.")]
        public double StandardHours { get; set; }
        [Display(Name = "Pay Per Check")]
        public double PayPerCheck { get; set; }
        [Display(Name = "Hourly Equivalent")]
        public double HourlyEquivalent { get; set; }
        [Display(Name = "Tipped")]
        public bool Tipped { get; set; }
        [Display(Name = "Pay Status")]
        public int? PayStatus { get; set; }
        [Display(Name = "Pay Grade")]
        public int? PayGrade { get; set; }
        [Display(Name = "Pay Code")]
        public int? PayCode { get; set; }
        [Display(Name = "Pay Period Startdate")]
        public DateTime? PayPeriodStartDate { get; set; }
        [Display(Name = "Pay Period Enddate")]
        public DateTime? PayPeriodEndDate { get; set; }
        [Display(Name = "Payroll EEID")]
        public string PayrollEEId { get; set; }
        [Display(Name = "Weekly Amount")]
        public double WeeklyAmount { get; set; }
        [Display(Name = "First Pay Date")]
        public DateTime? FirstPayDate { get; set; }
        [Display(Name = "Shift Type")]
        public int? ShiftType { get; set; }
        [Display(Name = "Shift Group")]
        public string ShiftGroup { get; set; }
        [Display(Name = "Premium")]
        public string Premium { get; set; }
        [Display(Name = "Job Assignment")]
        public int? JobAssignment { get; set; }
        [Display(Name = "Contract Status")]
        public int? ContractStatus { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
       
        [Display(Name = "Pay Type")]
       // [Required(ErrorMessage = "Please select pay type.")]
        public int? PayType { get; set; }

        [Display(Name = "Pay Period")]
        [Required(ErrorMessage = "Please select pay period.")]
        public int? PayPeriodId { get; set; }


        
    }
}
