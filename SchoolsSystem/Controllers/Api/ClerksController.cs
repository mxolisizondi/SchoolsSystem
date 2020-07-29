using SchoolsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolsSystem.Controllers.Api
{
    public class ClerksController : ApiController
    {
        private ApplicationDbContext _context;

        public ClerksController()
        {
            _context = new ApplicationDbContext();
        }
        //GET api/clerks
        public IEnumerable<Clerk> GetClerks()
        {
            return _context.Clerks.ToList();
        }

        //GET api/clerks/1
        //public Clerk Clerk(string id)
        //{
        //    var clerk = _context.Clerks.SingleOrDefault(c => c.userId == id);

        //}

        public void DeleteClerk(string id)
        {

        }


    }
}
