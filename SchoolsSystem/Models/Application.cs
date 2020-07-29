using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class Application
    {
        public int Id { get; set; }

        //Learner details
        public Learner Learner { get; set; }
        public string LearnerUseId { get; set; }

        //Parent Details
        public ParentDetail ParentDetail { get; set; }
        public int ParentDetailId { get; set; }

        //Attach Files Make it a list
        public ICollection<ApplicationDocument> ApplicationDocuments { get; set; }
        //public int ApplicationdDocumentId { get; set; }


        //Application Status
        public ApplicationStatus ApplicationStatus { get; set; }
        public byte ApplicationStatusId { get; set; }

        [Display(Name = "Previous School")]
        public string PreviousSchool { get; set; }

        public School School { get; set; }
        public int SchoolId { get; set; }

        [Display(Name = "Previous Grade")]
        public byte PreviousGrade { get; set; }

        [Display(Name = "Applying For Grade")]
        public byte ApplyingGrade { get; set; }

        public DateTime DateSubmitted { get; set; }

        [Display(Name = "Comment on Status")]
        public string Comment { get; set; }

    }
}