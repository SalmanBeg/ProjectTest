using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.BusinessLayer
{
    public class JobQualification
    {
        public JobQualification()
        {
            TypeList = new List<LookUpDataEntity>();
            MandatoryList = new List<LookUpDataEntity>();
        }
        public int JobQualificationID { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        
        public string SubjectArea { get; set; }
        public string Proficiency { get; set; }
        public decimal Years { get; set; }
        public string LastUsed { get; set; }
       
       
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

        #region Date Properties
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        #endregion
        #region DropDownProperties
        public List<LookUpDataEntity> TypeList { get; set; }
        public int Type { get; set; }
        public List<LookUpDataEntity> MandatoryList { get; set; }
        public int Mandatory { get; set; }
        #endregion


    }
}
