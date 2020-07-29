using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class Learner
    {
        [Key, ForeignKey("ApplicationUser")]
        public string UseId { get; set; }

        [Display(Name = "Full Names")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        public string Surname { get; set; }

        [Display(Name = "SA ID/ Passport Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Contact Number")]
        public string CellNumber { get; set; }

        [Display(Name = "Age in years")]
        public byte? Age { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}