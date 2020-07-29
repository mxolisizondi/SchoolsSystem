using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Enum
{
    public static class ApplicationStatus
    {
        public const int Received = 5;
        public const int Reviewed = 1;
        public const int RequiredDocuments = 2;
        public const int Accepted = 3;
        public const int Declined = 4;
    }
}