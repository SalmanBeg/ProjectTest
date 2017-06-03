using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.BusinessLayer
{
    public class EmployeeTaxDetail
    {
        public EmployeeTaxDetail()
        {
            StateTaxesLiveinCountryList = new List<CountryRegion>();
            StateTaxesLiveinStateList = new List<StateProvince>();
            StateTaxesWorkinCountryList = new List<CountryRegion>();
            StateTaxesWorkinStateList = new List<StateProvince>();
            FederalWithholdingStatusList = new List<LookUpDataEntity>();
            FederalBlockList = new List<LookUpDataEntity>();
            FederalMedBlockList = new List<LookUpDataEntity>();
            StateTaxesWithholdingStatusList = new List<LookUpDataEntity>();
            StateTaxesTaxBlockList = new List<LookUpDataEntity>();
            StateTaxesSUISDIBlockList = new List<LookUpDataEntity>();
            StateTaxesSchoolDistrictList = new List<LookUpDataEntity>();
            StateTaxesSchoolBlockList = new List<LookUpDataEntity>();
            LocalTaxesWithholdingStatusList = new List<LookUpDataEntity>();
        }
        public int EmployeeTaxDetailId { get; set; }        
        public int UserId { get; set; }       
        public int CompanyId { get; set; }
        public string EmployeeTaxDetailCode { get; set; }
       
        [Display(Name = "Exemptions")]
        public string FederalExemptions { get; set; }
        [Display(Name = "Withholdings")]
        public string FederalWithholdings { get; set; }
        [Display(Name = "Additional Withholding")]
        public string StateTaxesAdditionalWithholding { get; set; }
        [Display(Name = "Exemptions")]
        public string StateTaxesExemptions { get; set; }        
        [Display(Name = "Allowances or Exemptions")]
        public string LocalTaxesAllowancesorExemptions { get; set; }
        [Display(Name = "Additional Withholdings")]
        public string LocalTaxesAdditionalWithholdingsAmount { get; set; }
        public string LocalTaxesAdditionalWithholdingsPercentage { get; set; }
        [Display(Name = "Exempt for this tax. If you select Exempt you may be required to file certain forms. Please consult Human Resources and your tax advisor.")]
        public bool IsLocalTaxExempted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        
        #region Dropdown Properties

        public List<CountryRegion> StateTaxesLiveinCountryList { get; set; }
        [Display(Name = "Live-in Country")]
        [Required(ErrorMessage = "Please select live-in country.")]
        public int StateTaxesLiveinCountry { get; set; }

        public List<StateProvince> StateTaxesLiveinStateList { get; set; }
        [Display(Name = "Live-in State")]
        [Required(ErrorMessage = "Please select live-in state.")]
        public int StateTaxesLiveinState { get; set; }

        public List<CountryRegion> StateTaxesWorkinCountryList { get; set; }
        [Display(Name = "Work-in Country")]
        [Required(ErrorMessage = "Please enter work-in country.")]
        public int StateTaxesWorkinCountry { get; set; }

        public List<StateProvince> StateTaxesWorkinStateList { get; set; }
        [Display(Name = "Work-in State")]
        [Required(ErrorMessage = "Please enterwork-in state.")]
        public int StateTaxesWorkinState { get; set; }

        public List<LookUpDataEntity> FederalWithholdingStatusList { get; set; }
        [Display(Name = "Withholding Status")]
        public int? FederalWithholdingStatus { get; set; }

        public List<LookUpDataEntity> FederalBlockList { get; set; }
        [Display(Name = "Federal Block")]
        public int? FederalBlock { get; set; }

        public List<LookUpDataEntity> FederalMedBlockList { get; set; }
        [Display(Name = "MedBlock")]
        public int? FederalMedBlock { get; set; }

        public List<LookUpDataEntity> StateTaxesWithholdingStatusList { get; set; }
        [Display(Name = "Withholding Status")]
        public int? StateTaxesWithholdingStatus { get; set; }

        public List<LookUpDataEntity> StateTaxesTaxBlockList { get; set; }
        [Display(Name = "Tax Block")]
        public int? StateTaxesTaxBlock { get; set; }

        public List<LookUpDataEntity> StateTaxesSUISDIBlockList { get; set; }
        [Display(Name = "SUI/SDI Block")]
        public int? StateTaxesSUISDIBlock { get; set; }

        public List<LookUpDataEntity> StateTaxesSchoolDistrictList { get; set; }
        [Display(Name = "School District")]
        public int? StateTaxesSchoolDistrict { get; set; }

        public List<LookUpDataEntity> StateTaxesSchoolBlockList { get; set; }
        [Display(Name = "School Block")]
        public int? StateTaxesSchoolBlock { get; set; }

        public List<LookUpDataEntity> LocalTaxesWithholdingStatusList { get; set; }
        [Display(Name = "Withholding Status")]
        public int? LocalTaxesWithholdingStatus { get; set; }

        #endregion
    }
}