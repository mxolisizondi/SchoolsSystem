using SchoolsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsSystem.ViewModels
{
    public class SchoolViewModel
    {
        public School School { get; set; }

        public IEnumerable<AcceptApplication> AcceptApplications { get; set; }
    }
}