using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
   public class JobDutiesDetail
    {
       public JobDutiesDetail()
       {
           CategoryList = new List<LookUpDataEntity>();
           PriorityList = new List<LookUpDataEntity>();
           FrequencyList = new List<LookUpDataEntity>();
           EssentialList = new List<LookUpDataEntity>();
           OtherList = new List<LookUpDataEntity>();

         
       }
       public int JobDutyID { get; set; }
       public int CompanyId { get; set; }       
       public string JobDutyCode { get; set; }
       public string Description { get; set; }
      // public string Category { get; set; }
       //public int Priority { get; set; }
       public string PercentageOfTime { get; set; }
       //public int Frequency { get; set; }
       //public int Essential { get; set; }
       //public bool Other { get; set; }
       public int CreatedBy { get; set; }
       public int ModifiedBy { get; set; }

       #region Date Properties      
       public DateTime? CreatedOn { get; set; }
       public DateTime? ModifiedOn { get; set; }
       #endregion
        #region Dropdown Properties
       public List<LookUpDataEntity> CategoryList { get; set; }
       public int Category { get; set; }
       public List<LookUpDataEntity> PriorityList { get; set; }
       public int Priority { get; set; }
       public List<LookUpDataEntity> FrequencyList { get; set; }
       public int Frequency { get; set; }
       public List<LookUpDataEntity> EssentialList { get; set; }
       public int Essential { get; set; }
       public List<LookUpDataEntity> OtherList { get; set; }
       public int Other { get; set; }

        #endregion

    }
}
