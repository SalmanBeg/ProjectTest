using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;


namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeEmergencyContactMetaData))]
    public partial class EmployeeEmergencyContact
    {
        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }
        public List<CountryRegion> RelationshipList { get; set; }
        [Display(Name = "RelationShip")]
        public string RelationshipName { get; set; }
       
    }

    public partial class EmployeeEmergencyContactMetaData
    {       
       
        public int EmployeeEmergencyContactId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string EmployeeEmergencyContactCode { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter name.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter letters only please")]
        public string Name { get; set; }
         [RegularExpression("^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$", ErrorMessage = "You must provide a proper phone number.")]
        [Display(Name = "Home Phone")]
        [Required(ErrorMessage = "Please enter home phone.")]
        public string HomePhone { get; set; }
         [RegularExpression("^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$", ErrorMessage = "You must provide a proper phone number.")]
        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
         [RegularExpression("^\\D?(\\d{3})\\D?\\D?(\\d{3})\\D?(\\d{4})$", ErrorMessage = "You must provide a proper phone number.")]
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Display(Name = "Personal Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string PersonalEmail { get; set; }
        [Display(Name = "Work Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string WorkEmail { get; set; }
        [Display(Name = "Street1")]
        public string Street1 { get; set; }
        [Display(Name = "Street2")]
        public string Street2 { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        [Display(Name = "Zip/Postal Code")]
        public string Zip { get; set; }
        [Display(Name = "Primary Contact")]
        public Boolean? IsPrimaryContact { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please enter a country.")]
        public int CountryId { get; set; }
         [Required(ErrorMessage = "Please enter a state.")]
        [Display(Name = "State")]
        public int StateId { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }


     

        #region Dropdown Properties

        [Required(ErrorMessage = "Please enter relationship.")]
        public int Relationship { get; set; }
        public List<CountryRegion> CountryList { get; set; }
        public List<StateProvince> StateList { get; set; }
        public List<CountryRegion> RelationshipList { get; set; }

        #endregion
        
        }
}
