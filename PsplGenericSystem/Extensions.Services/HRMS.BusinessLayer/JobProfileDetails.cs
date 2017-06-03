using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;


namespace HRMS.BusinessLayer
{
  public  class JobProfileDetails
    {
      public JobProfileDetails()
      {
         

      }
    
      public int JobProfileID { get; set; }
      public int CompanyId { get; set; }
      public string JobCode { get; set; }
      public string JobTitle { get; set; }
      public string JobDescription { get; set; }
      public int CreatedBy { get; set; }
    
      public int ModifiedBy { get; set; }
        #region date Properties
    
     
      public DateTime? CreatedOn { get; set; }
    
      public DateTime? ModifiedOn { get; set; }
        #endregion 

   


    }
}
