using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRMS.Service.Models.EDM;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.ViewModels
{
    public class CertificationandLicenseFormModel
    {
        public CertificationandLicenseFormModel()
        {
            TypeList = new List<LookUpDataEntity>();
            CertificationList=new List<LookUpDataEntity>();
            LicenseCountryList=new List<CountryRegion>();
            LicenseStateList=new List<StateProvince>();
            SchoolList=new List<LookUpDataEntity>();
            EndorsementsList=new List<LookUpDataEntity>();
            AreasList = new List<LookUpDataEntity>();
            CertificationandLicense = new CertificationandLicense();
        }
        public CertificationandLicense CertificationandLicense { get; set; }
        [Required(ErrorMessage = "Level Required")]
        public List<LookUpDataEntity> TypeList { get; set; }
        public List<LookUpDataEntity> CertificationList { get; set; }
        public List<CountryRegion> LicenseCountryList { get; set; }
        public List<StateProvince> LicenseStateList { get; set; }
        public List<LookUpDataEntity> SchoolList { get; set; }
        public List<LookUpDataEntity> EndorsementsList { get; set; }
        public List<LookUpDataEntity> AreasList { get; set; }
        [Display(Name = "Attachment")]
        public string File { get; set; }



        
    }
}