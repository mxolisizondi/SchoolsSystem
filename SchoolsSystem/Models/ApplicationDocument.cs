using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolsSystem.Models
{
    public class ApplicationDocument
    {
        //Tell the user to name the files as per given example so that you can tell which document was not attached and
        //give checkbox list to tick for attached documents add Class for Names of document like Rolename to verify attached documtents
        public int Id { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }

        public Learner Learner { get; set; }

        public string LearnerUseId { get; set; }

        public Application Application { get; set; }

        public int ApplicationId { get; set; }

        //public string LearnerIdCopy { get; set; }

        //public string ParentIdCopy { get; set; }

        //public string SchoolReport { get; set; }

        //public string TransferLetter { get; set; }
    }
}