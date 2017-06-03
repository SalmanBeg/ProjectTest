using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class EmployeeTaxW4FormModel
    {
        public  EmployeeTaxW4FormModel()
        {
            StateTaxesLiveinCountryList = new List<CountryRegion>();
            StateTaxesLiveinStateList = new List<StateProvince>();
            StateTaxesWorkinCountryList = new List<CountryRegion>();
            StateTaxesWorkinStateList = new List<StateProvince>();
            FederalWithholdingStatusList = new List<LookUpDataEntity>();
            FederalBlockList = new List<LookUpDataEntity>();
            FederalMedBlockList = new List<LookUpDataEntity>();
            StateTaxesWithholdingStatusList = new List<LookUpDataEntity>();
            StateTaxesTaxBlockList = new List<LookUpDataEntity>();
            StateTaxesSUISDIBlockList = new List<LookUpDataEntity>();
            StateTaxesSchoolDistrictList = new List<LookUpDataEntity>();
            StateTaxesSchoolBlockList = new List<LookUpDataEntity>();
            LocalTaxesWithholdingStatusList = new List<LookUpDataEntity>();
            EmployeeSignList = new List<EmployeeSign>();
        }

        public EmployeeTax EmployeeTax { get; set; }
        public EmployeeW4Form EmployeeW4Form { get; set; }
        public EmployeeSign EmployeeSign { get; set; }
        public string FirstName { get; set; }       
        public string MiddleName { get; set; }      
        public string LastName { get; set; }
        public List<CountryRegion> StateTaxesLiveinCountryList { get; set; }
        public List<StateProvince> StateTaxesLiveinStateList { get; set; }
        public List<CountryRegion> StateTaxesWorkinCountryList { get; set; }
        public List<StateProvince> StateTaxesWorkinStateList { get; set; }
        public List<LookUpDataEntity> FederalWithholdingStatusList { get; set; }
        public List<LookUpDataEntity> FederalBlockList { get; set; }
        public List<LookUpDataEntity> FederalMedBlockList { get; set; }
        public List<LookUpDataEntity> StateTaxesWithholdingStatusList { get; set; }
        public List<LookUpDataEntity> StateTaxesTaxBlockList { get; set; }
        public List<LookUpDataEntity> StateTaxesSUISDIBlockList { get; set; }
        public List<LookUpDataEntity> StateTaxesSchoolDistrictList { get; set; }
        public List<LookUpDataEntity> StateTaxesSchoolBlockList { get; set; }
        public List<LookUpDataEntity> LocalTaxesWithholdingStatusList { get; set; }

        public List<EmployeeSign> EmployeeSignList { get; set; }
    }
}