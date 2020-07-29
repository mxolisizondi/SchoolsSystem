using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class ApplicationStatus
    {
        public byte Id { get; set; }

        public string Status { get; set; }

        public static readonly byte Received = 5;
        public static readonly byte Reviewed = 1;
        public static readonly byte RequiredDocuments = 2;
        public static readonly byte Accepted = 3;
        public static readonly byte Declined = 4;
        public static readonly byte Withdrawed = 6;
    }
}