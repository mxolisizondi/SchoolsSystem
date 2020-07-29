using SchoolsSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolsSystem.ViewModels.Account
{
    public class RegisterClerkViewModel
    {
        [Required]
        [Display(Name = "Firstname")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Cellphone")]
        public string CelphoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please provide the school the clerk work for")]
        [Display(Name = "School Name")]
        public int SchoolId { get; set; }

        public IEnumerable<School> Schools { get; set; }
    }
}