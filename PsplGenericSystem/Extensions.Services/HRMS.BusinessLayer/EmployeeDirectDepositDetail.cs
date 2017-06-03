using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.BusinessLayer
{   
    public class EmployeeDirectDepositDetail
    {
        public EmployeeDirectDepositDetail()
        {
            AccountTypeList = new List<LookUpDataEntity>();
        }
        public int EmployeeDirectDepositDetailId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string EmployeeDirectDepositDetailCode { get; set; }
        [Required(ErrorMessage = "Please enter account type.")]
        [Display(Name="Account Type")]
        public int AccountType { get; set; }
        public string AccountTypeName { get; set; }
        [Required(ErrorMessage = "Please enter Transit/ABA number.")]
        [Display(Name="Transit/ABA Number")]
        public string TransitorABANumber { get; set; }
        [Required(ErrorMessage = "Please enter account number.")]
        [Display(Name="Account Number")]
        public string AccountNumber { get; set; }
        [Required(ErrorMessage = "Please enter amount.")]
        [Display(Name="Amount")]
        public string Amount { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<LookUpDataEntity> AccountTypeList { get; set; }
       
    }
}