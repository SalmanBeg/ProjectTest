using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Service.Models.EDM
{
     [MetadataType(typeof(LunchMetaData))]
     public partial  class Lunch
    {

    }

     public partial class LunchMetaData
     {
         public LunchMetaData()
         {

         }

         public int LunchId { get; set; }
         public Guid LunchCode { get; set; }
         [Display(Name = "Lunch Description")]
         [Required(ErrorMessage = "Lunch Description is required")]
         public string LunchDescription { get; set; }
         [Display(Name = "Minimum Work Hours")]
         [Required(ErrorMessage = "Mininmum Work Time")]
         public double MinimumWorkTime { get; set; }
         [Display(Name = "Lunch Minutes")]
         [Required(ErrorMessage = "Lunch Minutes is required")]
         public double LunchMinutes { get; set; }
         [Display(Name = "Lunch Time")]
         [DataType(DataType.Time)]
         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
         [Required(ErrorMessage = "Lunch Time is required")]
         public DateTime? LunchTime { get; set; }
         public int CompanyId { get; set; }
     }
}
