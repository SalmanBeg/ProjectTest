using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Web.Mvc;
namespace HRMS.Service.Models.EDM
{


    [MetadataType(typeof(CompensationProfileMetaData))]
    public partial class CompensationProfile
    {

       

    }

    public partial class CompensationProfileMetaData
    {

        public CompensationProfileMetaData()
        { 
        
        }

        public int CompensationProfileId { get; set; }

        public Nullable<System.Guid> CompensationProfileCode { get; set; }

        public string SalaryGrade { get; set; }

         [DisplayName("Benefit Group")]
         [Required]
        public Nullable<int> BenefitGroup { get; set; }

        public string Stock { get; set; }

           [DisplayName("Other Cash Comp")]
        public decimal OtherCashComp { get; set; }

          [DisplayName("PTO Plan")]
        public string PTOPlan { get; set; }

           [DisplayName("Other Benefits")]
        public string OtherBenefits { get; set; }
        
        public int CompanyId { get; set; }

        [DisplayName("Wage Type")]
        [Required]
        public Nullable<int> WageType { get; set; }

         [DisplayName("Wage Unit")]
         [Required]
        public Nullable<int> WageUnit { get; set; }

         [DisplayName("Wage Amount")]
         [Required]
        public Nullable<decimal> WageAmount { get; set; }
        
        public Nullable<decimal> Commissions { get; set; }
        
        public Nullable<decimal> Bonus { get; set; }
        
        public Nullable<decimal> Amount { get; set; }
        
        public string Type { get; set; }
        
        public Nullable<decimal> AnnualizedPay { get; set; }
        
        [Required]
        [Remote("IsTitleExists", "CompensationProfile", AdditionalFields = "Title,CompanyId,CompensationProfileId", ErrorMessage = "Title already exists")]
        public string Title { get; set; }
    }

}
