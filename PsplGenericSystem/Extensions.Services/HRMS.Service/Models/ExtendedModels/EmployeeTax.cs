using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeTaxMetaData))]
    public partial class EmployeeTax
    {
        public string StateTaxesAdditionalWithholdingsPercentage { get; set; }
        public bool IsLocalTaxExempted1
        {
            get
            {
                return (IsLocalTaxExempted != null);
            }
            set
            {
                IsLocalTaxExempted = value;
            }
        }
    }
    public partial class EmployeeTaxMetaData
    {
        public EmployeeTaxMetaData()
        {

        }
        public int EmployeeTaxId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeTaxCode { get; set; }
        [Display(Name = "Live-in Country")]
        [Required(ErrorMessage = "Please select live-in country.")]
        public int StateTaxesLiveinCountryId { get; set; }
 
        [Display(Name = "Live-in State")]
        [Required(ErrorMessage = "Please select live-in state.")]
        public int StateTaxesLiveinStateId { get; set; }

        [Display(Name = "Work-in Country")]
        [Required(ErrorMessage = "Please enter work-in country.")]
        public int StateTaxesWorkinCountryId { get; set; }

        [Display(Name = "Work-in State")]
        [Required(ErrorMessage = "Please enterwork-in state.")]
        public int StateTaxesWorkinStateId { get; set; }
        //[Required]
        [Display(Name = "Exemptions")]
        //[RegularExpression(@"\D{1,40}", ErrorMessage = "Only alphabets allowed")]
        public string FederalExemptions { get; set; }
        [Display(Name = "Withholdings")]
       // [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only alphabets allowed")]
        public string FederalWithholdings { get; set; }
        [Display(Name = "Additional Withholding")]
       // [RegularExpression(@"\D{1,40}", ErrorMessage = "Only alphabets allowed")]
        public string StateTaxesAdditionalWithholding { get; set; }
        [Display(Name = "Exemptions")]
       // [RegularExpression(@"\D{1,40}", ErrorMessage = "Only alphabets allowed")]
        public string StateTaxesExemptions { get; set; }
        [Display(Name = "Allowances or Exemptions")]
       // [RegularExpression(@"\D{1,40}", ErrorMessage = "Only alphabets allowed")]
        public string LocalTaxesAllowancesorExemptions { get; set; }
        [Display(Name = "Additional Withholdings")]
        public string LocalTaxesAdditionalWithholdingsAmount { get; set; }
        public string LocalTaxesAdditionalWithholdingsPercentage { get; set; }
        [Display(Name = "Exempt for this tax. If you select Exempt you may be required to file certain forms. Please consult Human Resources and your tax advisor.")]
        public bool? IsLocalTaxExempted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        #region Dropdown Properties



        [Display(Name = "Withholding Status")]      
        public int? FederalWithholdingStatus { get; set; }

        [Display(Name = "Federal Block")]
        public int? FederalBlock { get; set; }

        [Display(Name = "MedBlock")]
        public int? FederalMedBlock { get; set; }

        [Display(Name = "Withholding Status")]
        public int? StateTaxesWithholdingStatus { get; set; }

        [Display(Name = "Tax Block")]
        public int? StateTaxesTaxBlock { get; set; }

        [Display(Name = "SUI/SDI Block")]
        public int? StateTaxesSUISDIBlock { get; set; }

        [Display(Name = "School District")]
        public int? StateTaxesSchoolDistrict { get; set; }

        [Display(Name = "School Block")]
        public int? StateTaxesSchoolBlock { get; set; }

        [Display(Name = "Withholding Status")]
        public int? LocalTaxesWithholdingStatus { get; set; }

        #endregion
    }
}
