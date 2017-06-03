using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class EmployeeFormModel
    {
        public EmployeeFormModel()
        {
            ChangeReasonList = new List<LookUpDataEntity>();
            EmploymentStatusList = new List<LookUpDataEntity>();
            EmploymentTypeList = new List<LookUpDataEntity>();
            PositionList = new List<LookUpDataEntity>();
            JobProfileList = new List<JobProfile>();
            LocationList = new List<LookUpDataEntity>();
            TerminationReasonList = new List<LookUpDataEntity>();
            DivisionList = new List<LookUpDataEntity>();
            DepartmentList = new List<LookUpDataEntity>();
            FLSAStatusList = new List<LookUpDataEntity>();
            UnionList = new List<LookUpDataEntity>();
            ManagerList = new List<UserLoginModel>();
            MaritalStatusList = new List<LookUpDataEntity>();
            GenderList = new List<LookUpDataEntity>();
            SalutationList = new List<LookUpDataEntity>();
            SuffixList = new List<LookUpDataEntity>();
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
            ReasonList = new List<LookUpDataEntity>();
            PayGradeList = new List<LookUpDataEntity>();
            ShiftTypeList = new List<LookUpDataEntity>();
            PayTypeList = new List<LookUpDataEntity>();
            Employee = new Employee();
        }
        public Employee Employee { get; set; }
        public EmployeePay EmployeePay { get; set; }

        public bool OkToRehire
        {

            get
            {
                return (Employee != null && Employee.OkToRehire != null);
            }
        }
        public bool AutoPay
        {

            get
            {
                return (EmployeePay != null && EmployeePay.AutoPay != null);
            }
        }
        public bool Tipped
        {

            get
            {
                return (EmployeePay != null && EmployeePay.Tipped != null);
            }
        }

        #region Dropdown Properties

        public List<LookUpDataEntity> TerminationReasonList { get; set; }
        public List<LookUpDataEntity> EmploymentStatusList { get; set; }
        public List<JobProfile> JobProfileList { get; set; }
        public List<LookUpDataEntity> PositionList { get; set; }
        public List<LookUpDataEntity> LocationList { get; set; }
        public List<LookUpDataEntity> DivisionList { get; set; }
        public List<LookUpDataEntity> DepartmentList { get; set; }
        public List<LookUpDataEntity> FLSAStatusList { get; set; }
        public List<LookUpDataEntity> UnionList { get; set; }
        public List<LookUpDataEntity> EmploymentTypeList { get; set; }
        public List<LookUpDataEntity> ChangeReasonList { get; set; }
        public List<UserLoginModel> ManagerList { get; set; }
        public List<LookUpDataEntity> MaritalStatusList { get; set; }
        public List<LookUpDataEntity> GenderList { get; set; }
        public List<LookUpDataEntity> SalutationList { get; set; }
        public List<LookUpDataEntity> SuffixList { get; set; }
        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }
        public List<LookUpDataEntity> ReasonList { get; set; }
        public List<LookUpDataEntity> PayGradeList { get; set; }
        public List<LookUpDataEntity> ShiftTypeList { get; set; }
        public List<LookUpDataEntity> PayTypeList { get; set; }
        #endregion
    }
}