using SchoolsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;

namespace SchoolsSystem.Controllers
{
    [Authorize(Roles = RoleName.Learner)]
    public class LearnerController : Controller
    {
        private ApplicationDbContext _context;

        public LearnerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Learner
        public ActionResult Home()
        {
            return View();
        }

        //GET: Submit Application
        public ActionResult SubmitApplication(int id)
        {
            var userId = User.Identity.GetUserId();
            var learner = _context.Learners.SingleOrDefault(u => u.UseId == userId);
            var school = _context.Schools.SingleOrDefault(s => s.Id == id);
            var checkPendingApplication = _context.Applications.SingleOrDefault(f => f.SchoolId == id && 
                                                                           f.LearnerUseId == userId && 
                                                                           f.ApplicationStatusId != ApplicationStatus.Declined);

            if (checkPendingApplication != null)
            {
                if(checkPendingApplication.ApplicationStatusId == ApplicationStatus.Accepted)
                    return RedirectToAction("ApprovedApplications", "Learner", new { message = "Accepted" });

                return RedirectToAction("PendingApplications","Learner", new { message = "Active"});
            }

            var veiwModel = new Application
            {
                Learner = learner,
                School = school
            };
            return View(veiwModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitApplication(Application model)
        {
            //Get learner details and update the id or any changes to profile details
            var learnerInDb = _context.Learners.SingleOrDefault(u => u.UseId == model.Learner.UseId);
            var school = _context.Schools.SingleOrDefault(s => s.Id == model.School.Id);

            if (school.AcceptApplicationId == AcceptApplication.Closed)
                return HttpNotFound();

            if (learnerInDb == null)
                return HttpNotFound();

            if(learnerInDb.IdNumber == null)
                learnerInDb.IdNumber = model.Learner.IdNumber;

            if(learnerInDb.Age == null)
                learnerInDb.Age = model.Learner.Age;

            if (learnerInDb.DateOfBirth == null)
                learnerInDb.DateOfBirth = model.Learner.DateOfBirth;

            _context.SaveChanges();

            List<ApplicationDocument> applicationDocuments = new List<ApplicationDocument>();
            var parentDetails = model.ParentDetail;
            _context.ParentDetails.Add(parentDetails);
            _context.SaveChanges();
            var parentId = parentDetails.Id;
            _context = new ApplicationDbContext();

            var application = new Application
            {
                LearnerUseId = model.Learner.UseId,
                ParentDetailId = parentId,
                SchoolId = model.School.Id,
                ApplicationStatusId = ApplicationStatus.Received,
                ApplyingGrade = model.ApplyingGrade,
                PreviousGrade = model.PreviousGrade,
                DateSubmitted = DateTime.Now

            };
            _context.Applications.Add(application);
            _context.SaveChanges();
            var applicationId = application.Id;
            _context = new ApplicationDbContext();

            //upload files
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
                byte[] bytes;
                BinaryReader br = new BinaryReader(file.InputStream);

                bytes = br.ReadBytes(file.ContentLength);

                if (file != null && file.ContentLength > 0)
                {
                    var fileData = new ApplicationDocument
                    {
                        FileName = Path.GetFileName(file.FileName),
                        ContentType = file.ContentType,
                        Data = bytes,
                        LearnerUseId = model.Learner.UseId,
                        ApplicationId = applicationId

                    };
                    applicationDocuments.Add(fileData);
                }

            }
            foreach (var file in applicationDocuments)
            {
                file.ApplicationId = applicationId;
                _context.ApplicationDocuments.Add(file);
                _context.SaveChanges();
            }

            //A message you application is submitted we will let you know 
            return RedirectToAction("PendingApplications","Learner", new { message = "Submitted"});
        }

        //GET: All Pending applications
        public ActionResult PendingApplications(string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.message = message;

            var userId = User.Identity.GetUserId();
            var pendingApplications = _context.Applications.Include(d => d.ApplicationDocuments)
                                                    .Include(s => s.School)
                                                    .Include(s => s.ApplicationStatus)
                                                    .Where(u => u.LearnerUseId == userId &&
                                                           u.ApplicationStatus.Id != ApplicationStatus.Accepted &&
                                                           u.ApplicationStatusId != ApplicationStatus.Declined &&
                                                           u.ApplicationStatusId != ApplicationStatus.Withdrawed)
                                                           .ToList();

            return View(pendingApplications);
        }

        //GET: All my approved application
        public ActionResult ApprovedApplications(string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.message = message;

            var userId = User.Identity.GetUserId();
            var approvedApplications = _context.Applications.Include(d => d.ApplicationDocuments)
                                                    .Include(s => s.School)
                                                    .Include(s => s.ApplicationStatus)
                                                    .Where(u => u.LearnerUseId == userId &&
                                                           u.ApplicationStatus.Id == ApplicationStatus.Accepted)
                                                           .ToList();

            return View(approvedApplications);
        }

        //GET: All Rejectect Applications
        public ActionResult RejectedApplications()
        {
            var userId = User.Identity.GetUserId();
            var approvedApplications = _context.Applications.Include(d => d.ApplicationDocuments)
                                                    .Include(s => s.School)
                                                    .Include(s => s.ApplicationStatus)
                                                    .Where(u => u.LearnerUseId == userId &&
                                                           u.ApplicationStatus.Id == ApplicationStatus.Declined)
                                                           .ToList();

            return View(approvedApplications);
        }

        //GET: All withdrawed applicationd
        public ActionResult WithdrawedApplications(string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.message = message;

            var userId = User.Identity.GetUserId();
            var withdrawedApplications = _context.Applications.Include(d => d.ApplicationDocuments)
                                                    .Include(s => s.School)
                                                    .Include(s => s.ApplicationStatus)
                                                    .Where(u => u.LearnerUseId == userId &&
                                                           u.ApplicationStatus.Id == ApplicationStatus.Withdrawed)
                                                           .ToList();
            return View(withdrawedApplications);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WithdrawApplication(int? formId)
        {
            var application = _context.Applications.SingleOrDefault(fId => fId.Id == formId);
            if (application == null)
                return HttpNotFound();
            if (application.ApplicationStatusId != ApplicationStatus.Withdrawed)
            {
                application.ApplicationStatusId = ApplicationStatus.Withdrawed;
                _context.SaveChanges();
            }

            return RedirectToAction("WithdrawedApplications",new { message = "Withdrawed" });
        }
    }
}