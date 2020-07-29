using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class Clerk
    {
        [Key,ForeignKey("ApplicationUser")]
        public string userId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdNumber { get; set; }

        public string EmailAddress { get; set; }

        public string CellNumber { get; set; }

        public School School { get; set; }

        public int SchoolId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}