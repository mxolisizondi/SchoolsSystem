using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class NotificationStatus
    {
        public byte Id { get; set; }
        public string Status { get; set; }

        public static readonly byte Unread = 2;
        public static readonly byte Read = 1;
    }
}