using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HRMS.Common.Enums;
using HRMS.Common.Helpers;

namespace HRMS.BusinessLayer
{
    public class EmployeeDependentDetail
    {
        public EmployeeDependentDetail()
        {
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
            RelationShipList = new List<LookUpDataEntity>();
            SuffixList = new List<LookUpDataEntity>();
            SalutationList = new List<LookUpDataEntity>();
            GenderList = new List<LookUpDataEntity>();

        }
        public int EmployeeDependentDetailId { set; get; }
        public int CompanyId { set; get; }
        public int UserId { set; get; }
        public string EmployeeDependentDetailCode { set; get; }
        [Display(Name="First Name")]
        [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName {  get;set;}
        [Display(Name="Last Name")]
        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }      
        [Display(Name = "Alias")]
        public string Alias { get; set; }       
        [Display(Name = "Street1")]
        public string Street1 { get; set; }
        [Display(Name = "Street2")]
        public string Street2 { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please select Country.")]
        public int CountryId { get; set; }
        [Display(Name = "State Name")]
        [Required(ErrorMessage = "Please select State.")]
        public int StateId { get; set; }
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }
        [Display(Name = "Home Email")]
        public string HomeEmail { get; set; }
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Display(Name = "SSN")]
        public string SSN { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Birth Date") ]
        [Required(ErrorMessage = "Please enter Birth Date.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "1/1/1753", "1/1/2020", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? BirthDate { get; set; }        
        [Display(Name = "Imputed Income")]
        public bool ImputedIncome { get; set; }
        [Display(Name = "Disabled")]
        public bool Disabled { get; set; }
        [Display(Name = "Smoker")]
        public bool Smoker { get; set; }
        [Display(Name = "Student")]
        public bool Student { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public string Age { get; set; }

        #region Dropdown Properties

        [Display(Name = "Country/Region")]
        public List<CountryRegion> CountryList { get; set; }

        [Display(Name = "State")]
        public List<StateProvince> StateList { get; set; }

        public List<LookUpDataEntity> RelationShipList { get; set; }
        [Display(Name = "Relationship")]
        [Required(ErrorMessage = "Please select Relationship.")]
        public int RelationShip { get; set; }
        public string RelationShipName { get; set; }

        public List<LookUpDataEntity> SuffixList { get; set; }
        [Display(Name = "Suffix")]
        public int Suffix { get; set; }

        public List<LookUpDataEntity> SalutationList { get; set; }
        [Display(Name = "Salutation")]
        public int Salutation { get; set; }

        
        public List<LookUpDataEntity> GenderList { get; set; }
        [Display(Name = "Gender")]
     //   [Required(ErrorMessage = "Please select Gender.")]        
        public int Gender { get; set; }

        #endregion

        }    
}