using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class AcceptApplication
    {
        //Change the name of this class it doesnot make sense
        public byte Id { get; set; }

        public string Status { get; set; }

        public static readonly byte Accept = 1;
        public static readonly byte Closed = 2;

    }
}