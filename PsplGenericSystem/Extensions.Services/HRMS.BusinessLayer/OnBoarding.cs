using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class OnBoarding
    {
        public int OnBoardingId { get; set; }
        public string OnBoardingCode { get; set; }
          [Display(Name = "On Boarding Name")]
          [Required(ErrorMessage = "Please enter a on boarding name.")]
        public string OnBoardingName { get; set; }
        public int CompanyId { get; set; }
        public bool Active { get; set; }
    }
}
