using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class CompanyDocumentFormModel
    {
        public CompanyDocumentFormModel()
        {
            FilesDBList = new List<FilesDB>();
            SendToList = new List<DocumentSendType>();
            SendCriteriaList = new List<DocumentSendCriteria>();         

            EmployeeList = new List<UserLoginModel>();
            EmployeeByCriteriaList = new List<Employee>(); //For EployeesByLocaltion, Department, Job, EmployeeStatus and EmployeeType
            RoleList = new List<RoleMaster>();
            CompanyList = new List<CompanyInfo>();
            JobList = new List<LookUpDataEntity>();
            LocationsList = new List<LookUpDataEntity>();
            DepartmentsList = new List<LookUpDataEntity>();
            EmploymentStatusList = new List<LookUpDataEntity>();
            EmploymentTypeList = new List<LookUpDataEntity>();
            DocumentCategoryList = new List<LookUpDataEntity>();
        }

        public CompanyDocument CompanyDocument { get; set; }

        #region Dropdown Properties
        public List<DocumentSendType> SendToList { get; set; }
        public List<DocumentSendCriteria> SendCriteriaList { get; set; }

        //Dropdown Lists
        public List<FilesDB> FilesDBList { get; set; }

        public List<UserLoginModel> EmployeeList { get; set; }
        public List<Employee> EmployeeByCriteriaList { get; set; } //For EmployeesByLocaltion, Department, Job, EmployeeStatus and EmployeeType
        public List<RoleMaster> RoleList { get; set; } 
        public List<CompanyInfo> CompanyList { get; set; } 
        public List<LookUpDataEntity> JobList { get; set; } 
        public List<LookUpDataEntity> LocationsList { get; set; }
        public List<LookUpDataEntity> DepartmentsList { get; set; }
        public List<LookUpDataEntity> EmploymentStatusList { get; set; }
        public List<LookUpDataEntity> EmploymentTypeList { get; set; }
        public List<LookUpDataEntity> DocumentCategoryList { get; set; }
       
        public string roleIdList { get; set; }
        public string companyIdList { get; set; }
        public string jobIdList { get; set; }
        public string locationIdList { get; set; }
        public string departmentIdList { get; set; }
        public string employmentstatusIdList { get; set; }
        public string employmenttypeIdList { get; set; }
        #endregion
    }
}