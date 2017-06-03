using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
namespace HRMS.BusinessLayer
{
    public class CompanyInfo
    {
         public CompanyInfo()
         {
             CountryList =new List<CountryRegion>();
             StateList = new List<StateProvince>();
         }
         public GeneralEnum.Status statusList { get; set; }

        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
         [Display(Name = "Company Name")]
        [Required(ErrorMessage="Please enter a company name.")]
        public string CompanyName { get; set; }
        [Display(Name = "Address1")]
        [Required(ErrorMessage="Please enter address.")]
        public string Address1 { get; set; }
        [Display(Name = "Address2")]
        public string Address2 { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage="Please enter city.")]
        public string City { get; set; }
        [Display(Name = "ZIP")]
        [Required(ErrorMessage="Please enter zip")]
        public string ZIP { get; set; }
        [Display(Name = "Country")]
        public int CountryId{ get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage="Please enter phone.")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }
        public int ControlType { get; set; }
        public string ConnectionString { get; set; }
        public string PrimaryControlId { get; set; }
        public string ControlId { get; set; }
        public int CorporateStructureId { get; set; }
        public int LegalStructureId { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
        public string FEIN { get; set; }
        public string Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Activity { get; set; }
        [DataType(DataType.Url)]
        [Display(Name = "Website")]
        public string Website { get; set; }
        public DateTime? FISCYear { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public string Association { get; set; }
        public string SubscriptionCode { get; set; }
        public string Type { get; set; }
        public string Database { get; set; }
        public string ServerName { get; set; }
        public bool IsPositionManaged { get; set; }
        public string TimeProvider { get; set; }
        public string PayrollProvider { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }
    }
}