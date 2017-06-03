using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Web.ViewModels
{
    public class LoginFormModel
    {
        [Required(ErrorMessage="Please enter email")]
        //[EmailAddress(ErrorMessage="Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage="Please enter password.")]
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}