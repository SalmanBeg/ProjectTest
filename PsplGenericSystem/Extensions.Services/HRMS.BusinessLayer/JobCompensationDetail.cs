using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
   public  class JobCompensationDetail
    {
       public JobCompensationDetail()
       {
           PayRangePerList = new List<LookUpDataEntity>();
           VariablePayPerList = new List<LookUpDataEntity>();
           BenfitClassList = new List<LookUpDataEntity>();

       }
       public int CompensationID { get; set; }
       public int CompanyId { get; set; }
       public string PlanDescription { get; set; }
       public string Location { get; set; }
       public int PayRange { get; set; }
       public int PayRangeTo { get; set; }
      
       public int VaraiblePay { get; set; }
       public int VariablePayTo { get; set; }
    
       public string HoursPerWeek { get; set; }
  
       public bool Exempt { get; set; }
       public int CreatedBy { get; set; }
       public int ModifiedBy { get; set; }
        #region Date Properties
       public DateTime? CreatedOn { get; set; }
       public DateTime? ModifiedOn { get; set; }
        #endregion
        #region Drop Down Propertied
       public List<LookUpDataEntity> PayRangePerList { get; set; }
       public int PayRangePer { get; set; }
       public List<LookUpDataEntity> VariablePayPerList { get; set; }
       public int VariablePayPer { get; set; }
       public List<LookUpDataEntity> BenfitClassList { get; set; }
       public int BenfitClass { get; set; }
        #endregion

    }
}
