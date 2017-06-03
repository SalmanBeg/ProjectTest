using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeDirectDepositDetailMetaData))]
    public partial class EmployeeDirectDeposit
    {
        public string AccountTypeName { get; set; }
        public List<EmployeeDirectDeposit> employeeDirectDepositModel { get; set; }
    }
    public partial class EmployeeDirectDepositDetailMetaData
    {
        public EmployeeDirectDepositDetailMetaData()
        {
            
        }
        public int EmployeeDirectDepositId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string EmployeeDirectDepositCode { get; set; }
        [Required(ErrorMessage = "Please enter account type.")]
        [Display(Name = "Account Type")]
        public int AccountType { get; set; }
        public string AccountTypeName { get; set; }
        [StringLength(10)]
        [Required(ErrorMessage = "Please enter Transit/ABA Number.")]
        [Display(Name = "Transit/ABA Number")]
        public string TransitorABANumber { get; set; }
        [Required(ErrorMessage = "Please enter account number.")]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Please enter amount.")]
        [Display(Name = "Amount")]
        public string Amount { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        
    }
}
