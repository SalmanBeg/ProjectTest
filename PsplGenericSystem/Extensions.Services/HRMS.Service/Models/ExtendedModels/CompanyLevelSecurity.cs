using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Service.Models.EDM
{
     [MetadataType(typeof(CompanyLevelSecurityMetaData))]
    public partial class CompanyLevelSecurity
    {
         public int ModuleId { get; set; }
         public int FormId { get; set; }
         public bool Status { get; set; }

         public bool ManageSecurityCriteria { get; set; }

         public List<ManageSecurityCriteria> ManageSecurityCriteriaList { get; set; }

         public List<LookUpDataEntity> PositionsList { get; set; }
         public List<LookUpDataEntity> DivisionsList { get; set; }
         public List<LookUpDataEntity> LocationsList { get; set; }
         public List<LookUpDataEntity> DepartmentsList { get; set; }
         public List<LookUpDataEntity> EmploymentStatusList { get; set; }
        
         public List<UserLoginModel> EmployeesList { get; set; }
         public List<UserLoginModel> EmployeeList { get; set; }
         //public List<EmployeeAlert> EmployeeAlertList { get; set; }
         public string locationIdList { get; set; }
         public string departmentIdList { get; set; }
         public string positionIdList { get; set; }
         public string divisionIdList { get; set; }
         public string employmentstatusIdList { get; set; }
         public string EmployeeIdList { get; set; }

         
         //public List<UserLoginModel> EmployeeList { get; set; }
         //public string locationIdList { get; set; }
         //public string departmentIdList { get; set; }
         //public string positionIdList { get; set; }
         //public string employmentstatusIdList { get; set; }


         public bool Status1
         {
             get
             {
                 if (Status != null)
                     return Convert.ToBoolean(Status);
                 else
                     return false;
             }
             set
             {
                 Status = value;
             }
         }
    }

    public partial class CompanyLevelSecurityMetaData
    {
      
    }
}
