using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class EmployeeDependentFormModel
    {
        public EmployeeDependentFormModel()
        {
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
            RelationShipList = new List<LookUpDataEntity>();
            SuffixList = new List<LookUpDataEntity>();
            SalutationList = new List<LookUpDataEntity>();
            GenderList = new List<LookUpDataEntity>();
            EmployeeDependent = new EmployeeDependent();
        }
        public EmployeeDependent EmployeeDependent { get; set; }
        //public bool ImputedIncome 
        //{

        //    get
        //    {
        //        return (EmployeeDependent != null && EmployeeDependent.ImputedIncome != null);
        //    }
        //}
        //public bool Disabled
        //{
        //    get
        //    {
        //        return (EmployeeDependent != null && EmployeeDependent.Disabled != null);
        //    }
        //}
        //public bool Smoker
        //{
        //    get
        //    {
        //        return (EmployeeDependent != null && EmployeeDependent.Smoker != null);
        //    }
        //}
        //public bool Student
        //{
        //    get
        //    {
        //        return (EmployeeDependent != null && EmployeeDependent.Student != null);
        //    }
        //}
        public List<CountryRegion> CountryList { get; set; }       
        public List<StateProvince> StateList { get; set; }
        public List<LookUpDataEntity> RelationShipList { get; set; } 
        public List<LookUpDataEntity> SuffixList { get; set; }
        public List<LookUpDataEntity> SalutationList { get; set; }  
        public List<LookUpDataEntity> GenderList { get; set; }
    }
}