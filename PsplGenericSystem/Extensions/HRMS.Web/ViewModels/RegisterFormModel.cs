using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using HRMS.BusinessLayer;
using System.Web.Mvc;
using HRMS.Common.Enums;
using HRMS.Service.Models.EDM;

namespace HRMS.Web.ViewModels
{
    public class RegisterFormModel
    {
        public RegisterFormModel()
        {
            Country = new List<CountryRegion>();
            State = new List<StateProvince>();
        }

        public RegisterFormModel(int countryId, int stateId)
        {
            StateId = stateId;
            CountryId = countryId;          
            Country = new List<CountryRegion>();
            State = new List<StateProvince>();
        }  
        [Required(ErrorMessage = "Please enter the company name.")]
        [RegularExpression("^[a-zA-Z0-9._ -']*$", ErrorMessage = "Special Characters are not allowed.")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter address.")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required(ErrorMessage = "Please enter city.")]
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter zip")]
        public string ZIP { get; set; }
        [Required(ErrorMessage = "Please enter phoneno.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "PhoneNo should be minimum of 10 digits.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter the first name.")]
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the last name.")]
        [RegularExpression("^[a-zA-Z0-9._ -]*$", ErrorMessage = "Special Characters are not allowed.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter an emailaddress.")]
        //[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"^[\w\._-]+@[\w\.-]+\.[\w]{2,3}$", ErrorMessage = "Please enter a valid email address")]
        [Remote("CheckForDuplication", "Account", HttpMethod = "POST", ErrorMessage = "Email is registerd with us, please try using other email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a UserName.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 30 characters.")]
        [RegularExpression("^[a-zA-Z0-9._-]+$", ErrorMessage = "Special Characters are not allowed except .-_")]
        [Remote("ValidateUserName", "Account",  HttpMethod = "POST", ErrorMessage = "UserName is registerd with us, please try using other UserName.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 40 characters.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter the confirm password.")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool IsApproved { get; set; }
        public List<CountryRegion> Country { get; set; }
        public List<StateProvince> State { get; set; }
        [Required(ErrorMessage = "Please Select the Country.")]
        public int  CountryId { get; set; }
        [Required(ErrorMessage = "The State Field is Required.")]
        public int StateId { get; set; }

    }
}