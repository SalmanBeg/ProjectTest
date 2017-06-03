using HRMS.Service.Models.EDM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class RegisterApplicantFormModel
    {
        public RegisterApplicantFormModel()
        {

            GenderList = new List<LookUpDataEntity>();
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
            EmployeeIds = new List<int>();
        }
   
        public List<JobRecruiter> JobRecruiterList { get; set; }
        public List<int> EmployeeIds { get; set; }

        public JobApplicant JobApplicant { get; set; }
        public List<LookUpDataEntity> GenderList { get; set; }
        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int JobId { get; set; }
        public string RecruiterFullName { get; set; }

    }
}