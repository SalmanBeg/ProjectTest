using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRMS.Web.ViewModels
{
    public class ChangePasswordFormModel
    {
        [Required(ErrorMessage="Enter Old Password")]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Enter New Password")]
        [DataType(DataType.Password)]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 40 characters.")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}