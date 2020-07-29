using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class ParentDetail
    {
        public int Id { get; set; }

        [Display(Name = "Parent/Guardian Full Names")]
        public string Name { get; set; }

        [Display(Name = "Parent/Guardian Last Name")]
        public string Surname { get; set; }

        [Display(Name = "Parent/Guardian SA ID/Passport Number")]
        public string IdNumber { get; set; }

        [Display(Name = "Parent/Guardian Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Parent/Guardian Cell No")]
        public string CellNumber { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }
    }
}