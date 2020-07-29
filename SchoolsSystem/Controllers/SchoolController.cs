using SchoolsSystem.Models;
using SchoolsSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SchoolsSystem.Controllers
{
    public class SchoolController : Controller
    {
        private ApplicationDbContext _context;

        public SchoolController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: School
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult RegisteredSchools(string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.message = message;

            var schools = _context.Schools.ToList();
            return View(schools);
        }

        //GET: Add School
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult AddSchool()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult AddSchool(School school)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new SchoolViewModel
                {
                    School = school
                    //AcceptApplications = _context.AcceptApplications.ToList()
                };
                return View(viewModel);
            }
            school.AcceptApplicationId = AcceptApplication.Closed; // Only clerk can change status 
            _context.Schools.Add(school);
            _context.SaveChanges();
            return RedirectToAction("RegisteredSchools", "School", new { message = "Added" });// Show the list of school and add toast that show that the school was added
        }

        //GET: Delete School
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DeleteSchool()
        {
            var schools = _context.Schools.ToList();
            return View(schools);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult DeleteSchool(int? schoolId)
        {
            var school = _context.Schools.SingleOrDefault(s => s.Id == schoolId);

            if (school == null)
                return HttpNotFound(); // Toast that the school was not deleted because was found

            _context.Schools.Remove(school);
            _context.SaveChanges();

            return RedirectToAction("RegisteredSchools", "School", new { message = "Deleted" }); // Put a toast that the school is delete then redirect back to the remove list
        }

        [Authorize(Roles = RoleName.Learner)]
        public ActionResult OpenApplications()
        {
            var schools = _context.Schools.Where(s => s.AcceptApplicationId == AcceptApplication.Accept);
            return View(schools);
        }

        //Get: Closed Applications
        public ActionResult ClosedApplications()
        {
            var closedApplication = _context.Schools.Include(s => s.AcceptApplication)
                                                    .Where(s => s.AcceptApplicationId == AcceptApplication.Closed)
                                                    .ToList();

            return View(closedApplication);
        }
    }
}