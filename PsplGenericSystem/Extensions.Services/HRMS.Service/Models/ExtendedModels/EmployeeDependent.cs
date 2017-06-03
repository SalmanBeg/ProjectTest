using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HRMS.Common.Enums;
using HRMS.Service;

namespace HRMS.Service.Models.EDM
{
    [MetadataType(typeof(EmployeeDependentMetaData))]
    public partial class EmployeeDependent
    {
        [Display(Name = "RelationShip")]
        public string RelationShipName { get; set; }
        
        [Display(Name="Imputed Income")]
        public bool IsImputedIncome
        {
            get
            {
                return ImputedIncome.GetValueOrDefault();
            }
            set
            {
                ImputedIncome = value;
            }
        }
        [Display(Name="Disabled")]
        public bool IsDisabled
        {
            get
            {
                return Disabled.GetValueOrDefault();
            }
            set
            {
                Disabled = value;
            }
        }
        [Display(Name="Smoker")]
        public bool IsSmoker
        {
            get
            {
                return Smoker.GetValueOrDefault();
            }
            set
            {
                Smoker = value;
            }
        }
        [Display(Name="Student")]
        public bool IsStudent
        {
            get
            {
                return Student.GetValueOrDefault();
            }
            set
            {
                Student = value;
            }
        }
       
    }
    public partial class EmployeeDependentMetaData
    {      
        public int EmployeeDependentId { set; get; }
        public int CompanyId { set; get; }
        public int UserId { set; get; }
        public string EmployeeDependentCode { set; get; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter first name.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter letters only please")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter last name.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter letters only please")]
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
        [RegularExpression(@"^[\w\._-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Please enter a valid email address")]      
        [Display(Name = "Home Email")]
        public string HomeEmail { get; set; }
        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }
        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }
        [Display(Name = "SSN")]
        public string SSN { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Please enter Birth Date.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[Range(typeof(DateTime), "1/1/1753", "1/1/2020", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? BirthDate { get; set; }       
        public bool ImputedIncome { get; set; }      
        public bool Disabled { get; set; }       
        public bool Smoker { get; set; }
        public bool Student { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
       

        //public string Age { get; set; }
        #region Dropdown Properties

        [Display(Name = "Relationship")]
        [Required(ErrorMessage = "Please select Relationship.")]
        public int RelationShip { get; set; }
        [Display(Name = "Suffix")]
        public int Suffix { get; set; }
        [Required(ErrorMessage = "Please select Salutation.")]
        [Display(Name = "Salutation")]
        public int Salutation { get; set; }
        [Display(Name = "Gender")   ]
        public int Gender { get; set; }
        #endregion    
    }
}
