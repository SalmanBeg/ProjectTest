using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class ChangeUserNameFormModel
    {

        [Required(ErrorMessage = "Please Enter the Username")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 30 characters.")]
        [RegularExpression("^[a-zA-Z0-9._-]+$", ErrorMessage = "Special Characters are not allowed except -._")]
        [Display(Name = "New Username")]
        public string Username { get; set; }
        
    }
}