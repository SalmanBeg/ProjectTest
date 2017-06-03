using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;


namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(OnBoardingMetaData))]
    public partial class OnBoarding
    {
    }
    public partial class OnBoardingMetaData
    {
        public OnBoardingMetaData()
        {
        }
        public int OnBoardingId { get; set; }
        public string OnBoardingCode { get; set; }
        [Display(Name = "On Boarding Name")]
        [Required(ErrorMessage = "Please enter a on boarding name.")]
        public string OnBoardingName { get; set; }
        public int CompanyId { get; set; }
        public bool Active { get; set; }
    }
}
