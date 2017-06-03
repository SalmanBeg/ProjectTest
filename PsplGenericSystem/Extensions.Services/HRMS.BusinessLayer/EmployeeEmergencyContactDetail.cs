using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.BusinessLayer
{
    public class EmployeeEmergencyContactDetail
    {
        public EmployeeEmergencyContactDetail()
        {
            CountryList = new List<CountryRegion>();
            StateList = new List<StateProvince>();
            RelationShipList = new List<LookUpDataEntity>();
        }
        public int EmployeeEmergencyContactDetailId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string EmployeeEmergencyContactDetailCode { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }
       
        [Display(Name = "Home Phone")]
        [Required(ErrorMessage = "Please enter home phone.")]
        public string HomePhone { get; set; }
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Display(Name = "Personal Email")]
        public string PersonalEmail { get; set; }
        [Display(Name = "Work Email")]
        public string WorkEmail { get; set; }
        [Display(Name = "Street1")]
        public string Street1 { get; set; }
        [Display(Name = "Street2")]
        public string Street2 { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Zip/Postal Code")]
        public string Zip { get; set; }
         [Display(Name = "Primary Contact")]
        public Boolean IsPrimaryContact { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "State")]
        public int StateId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        #region Dropdown Properties

        [Display(Name = "Country/Region")]
        public List<CountryRegion> CountryList { get; set; }

        [Display(Name = "State/Province")]
        public List<StateProvince> StateList { get; set; }

        public List<LookUpDataEntity> RelationShipList { get; set; }
        [Display(Name = "Relationship")]
        [Required(ErrorMessage = "Please enter relationship.")]
        public int Relationship { get; set; }
        public string RelationshipName { get; set; }

        #endregion
    }
}