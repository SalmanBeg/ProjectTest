using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;


namespace HRMS.BusinessLayer
{
  public  class HolidayGroupInfo
    {

     public int? HolidayGroupId { get; set; }
     public Guid? HolidayGroupCode { get; set; }
     [Display(Name = "Group Name")]
     [Required(ErrorMessage = "Group Name is required")]
     public string HolidayGroupName { get; set; }
     [Display(Name = "Description")]
     public string HolidayDescription { get; set; }
     public int? CompanyId { get; set; }

    }
}
