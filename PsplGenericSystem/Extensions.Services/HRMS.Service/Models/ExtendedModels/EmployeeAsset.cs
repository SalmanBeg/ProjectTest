using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeAssetDetailMetaData))]
    public partial class EmployeeAsset
    {
    }

    public class EmployeeAssetDetailMetaData
    {
        public EmployeeAssetDetailMetaData()
        {
        }

        public int EmployeeAssetId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeAssetCode { get; set; }
        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please enter a Asset.")]
        public string Asset { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        [Display(Name = "Asset Cost")]
        public decimal AssetCost { get; set; }
        [Required(ErrorMessage = "Please enter Date Purchased.")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Purchased Date")]
        public DateTime PurchasedDate { get; set; }
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Out On")]
        public DateTime OutOn { get; set; }
         [Display(Name = "Due Back")]
         [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DueBack { get; set; }
       // [Display(Name = "Checked Out")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Returned { get; set; }
        public string Comment { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }


    }
}
