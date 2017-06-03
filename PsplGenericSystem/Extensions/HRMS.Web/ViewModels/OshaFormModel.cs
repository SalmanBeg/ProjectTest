using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;

namespace HRMS.Web.ViewModels
{
    public class OshaFormModel
    {
        public OshaFormModel()
        {
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
            EmployeeOSHA = new EmployeeOSHA();
        }
        public EmployeeOSHA EmployeeOSHA { get; set; }
        public bool IsNotReported
        {
            get
            {
                if (EmployeeOSHA != null && EmployeeOSHA.IsNotReported != null)
                    return Convert.ToBoolean(EmployeeOSHA.IsNotReported);
                else
                    return false;
            }
            set
            {
                EmployeeOSHA.IsNotReported = value;
            }
        }
        public bool IsEmployeeinEmergency
        {
            get
            {
                if (EmployeeOSHA != null && EmployeeOSHA.IsEmployeeinEmergency != null)
                    return Convert.ToBoolean(EmployeeOSHA.IsEmployeeinEmergency);
                else
                    return false;
            }
            set
            {
                EmployeeOSHA.IsEmployeeinEmergency = value;
            }
        }
        public bool IsEmployeeInPatient
        {
            get
            {
                if (EmployeeOSHA != null && EmployeeOSHA.IsEmployeeInPatient != null)
                    return Convert.ToBoolean(EmployeeOSHA.IsEmployeeInPatient);
                else
                    return false;
            }
            set
            {
                EmployeeOSHA.IsEmployeeInPatient = value;

            }
        }

        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }
        public List<LookUpDataEntity> ClaimTypeList { get; set; }
        public List<LookUpDataEntity> OutComeList { get; set; }
    }
}