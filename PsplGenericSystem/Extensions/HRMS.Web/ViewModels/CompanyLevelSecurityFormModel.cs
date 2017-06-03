using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class CompanyLevelSecurityFormModel
    {
       
        public CompanyLevelSecurityFormModel()
        {
            Forms = new List<Form>();
            Modules=new List<Module>();

            PositionsList = new List<LookUpDataEntity>();
            DivisionsList = new List<LookUpDataEntity>();          
            EmployeeList = new List<UserLoginModel>();           
            LocationsList = new List<LookUpDataEntity>();
            DepartmentsList = new List<LookUpDataEntity>();
            EmploymentStatusList = new List<LookUpDataEntity>();
            ManageSecurityCriteriaList = new List<ManageSecurityCriteria>();
            CompanyLevelSaveLogList = new List<CompanyLevelSaveLog>();
           
        }


        public CompanyLevelSecurity CompanyLevelSecurity { get; set; }
        public CompanyLevelSaveLog CompanyLevelSaveLog { get; set; }
        public List<Module> Modules { get; set; }
        public List<Form> Forms { get; set; }
        public int RoleId { get; set; }
        public List<EmployeeFilterCriteria> FilterCriterias { get; set; }
        public int EmployeeCriteriaId { get; set; }

        public List<CompanyLevelSaveLog> CompanyLevelSaveLogList { get; set; }
        public List<LookUpDataEntity> PositionsList { get; set; }
        public List<LookUpDataEntity> DivisionsList { get; set; }
        public List<LookUpDataEntity> LocationsList { get; set; }
        public List<LookUpDataEntity> DepartmentsList { get; set; }
        public List<LookUpDataEntity> EmploymentStatusList { get; set; }     
        public List<UserLoginModel> EmployeeList { get; set; }
       
        public List<ManageSecurityCriteria> ManageSecurityCriteriaList { get; set; }
       
        

    }

    
}