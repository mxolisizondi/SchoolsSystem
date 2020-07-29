using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class School
    {
        public int Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string TelephoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public AcceptApplication AcceptApplication { get; set; }

        [Display(Name = "Application Status")]
        public byte AcceptApplicationId { get; set; }

        //Opening of application and closing date
        [Display(Name = "Open/Next Open Date")]
        public DateTime? OpenDate { get; set; }

        [Display(Name = "Closing Date")]
        public DateTime? ClosingDate { get; set; }

        //Grade details
        public byte StartingGrade { get; set; }

        public byte LastGrade { get; set; }
    }
}