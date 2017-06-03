using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
   public class JobPMEDetails
    {
       public JobPMEDetails()
       {
           CategoryList = new List<LookUpDataEntity>();
           EssentialList = new List<LookUpDataEntity>();
           FrequencyList = new List<LookUpDataEntity>();

       }
       public int PMEID { get; set; }
       public int CompanyId { get; set; } 
       public string Description { get; set; }
       //public string Category { get; set; }
       //public string Frequency { get; set; }
       //public int Essential { get; set; }
       public int CreatedBy { get; set; }
       public int ModifiedBy { get; set; }
       #region Date Properties
       public DateTime CreatedOn { get; set; }
       public DateTime ModifiedOn { get; set; }
       #endregion
        #region DropDown Propreties
       public List<LookUpDataEntity> CategoryList { get; set; }
       public int Category { get; set; }
       public List<LookUpDataEntity> FrequencyList { get; set; }
       public int Frequency { get; set; }
       public List<LookUpDataEntity> EssentialList { get; set; }
       public int Essential { get; set; }

        #endregion

    }
}
