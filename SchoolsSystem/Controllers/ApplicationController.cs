using Microsoft.AspNet.Identity;
using SchoolsSystem.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SchoolsSystem.Controllers
{
    //[Authorize(Roles = ""+RoleName.Admin+","+RoleName.Clerk)]
    public class ApplicationController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicationController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Application
        public ActionResult Index()
        {
            return View();
        }

        //GET: View Application
        public ActionResult ViewApplication(int id)//
        {
            var userId = User.Identity.GetUserId();
            var clerk = _context.Clerks.Single(c => c.userId == userId);

            var application = _context.Applications.Include(l => l.Learner)
                                                   .Include(p => p.ParentDetail)
                                                   .Include(s => s.School)
                                                   .Include(d => d.ApplicationDocuments)
                                                   .SingleOrDefault(a => a.Id == id);

            if (clerk.SchoolId != application.SchoolId) // Only clerk assigned to this school can view
                return HttpNotFound();

            return View(application);
        }

        [HttpPost]
        public FileResult DownloadFile(int? fileId)
        {
            ApplicationDocument file = _context.ApplicationDocuments.ToList().Find(p => p.Id == fileId);
            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = file.FileName,
                Inline = false
            };
            Response.Headers.Add("Content-Disposition", cd.ToString());
            return File(file.Data, file.ContentType);
        }

        //Post: Approve form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveApplication(int id, string comment)
        {
            var form = _context.Applications.SingleOrDefault(f => f.Id == id);

            if (form == null)
                return HttpNotFound();
            form.ApplicationStatusId = ApplicationStatus.Accepted;
            form.Comment = comment;
            _context.SaveChanges();

            return RedirectToAction("PendingApplications","Clerk");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RejectApplication(int id, string comment)
        {
            var applicationDetails = _context.Applications.Single(f => f.Id == id);
            if (applicationDetails == null)
                return HttpNotFound();
            applicationDetails.ApplicationStatusId = ApplicationStatus.Declined;
            applicationDetails.Comment = comment;
            _context.SaveChanges();

            return RedirectToAction("PendingApplications", "Clerk");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RequiredDocuments(int id, string comment)
        {
            var applicationDetails = _context.Applications.Single(f => f.Id == id);
            if (applicationDetails == null)
                return HttpNotFound();
            applicationDetails.ApplicationStatusId = ApplicationStatus.RequiredDocuments;
            applicationDetails.Comment = comment;
            _context.SaveChanges();

            return RedirectToAction("PendingApplications", "Clerk");
        }

        public JsonResult GetNotifications()
        {
            var applicationDetails = _context.Applications;
            return Json(applicationDetails, JsonRequestBehavior.AllowGet);
        }




    }
}