using Microsoft.AspNet.Identity;
using SchoolsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SchoolsSystem.Controllers
{
    public class NotificationController : Controller
    {
        // move all this code to api and receive id for user

        private ApplicationDbContext _context;

        public NotificationController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Approved Notification
        public JsonResult GetApprovedApplicationNotifications()
        {
            var userId = User.Identity.GetUserId();
            var approvedApplications = _context.Applications.Where(u => u.LearnerUseId == userId &&
                                                                   u.ApplicationStatus.Id == ApplicationStatus.Accepted &&
                                                                   u.NotificationStatusId == NotificationStatus.Unread)
                                                                   .ToList();

            return Json(approvedApplications,JsonRequestBehavior.AllowGet);
        }

        // GET: Rejected Notification
        public JsonResult GetRejectedApplicationNotifications()
        {
            var userId = User.Identity.GetUserId();
            var rejectedApplications = _context.Applications.Where(u => u.LearnerUseId == userId &&
                                                                   u.ApplicationStatus.Id == ApplicationStatus.Declined &&
                                                                   u.NotificationStatusId == NotificationStatus.Unread)
                                                                   .ToList();

            return Json(rejectedApplications, JsonRequestBehavior.AllowGet);
        }

        // GET: Pending Notification
        public JsonResult GetPendingApplicationNotifications()
        {
            var userId = User.Identity.GetUserId();
            var pendingApplications = _context.Applications.Where(u => u.LearnerUseId == userId &&
                                                                   u.ApplicationStatus.Id != ApplicationStatus.Accepted &&
                                                                   u.ApplicationStatusId != ApplicationStatus.Declined &&
                                                                   u.ApplicationStatusId != ApplicationStatus.Withdrawed &&
                                                                   u.NotificationStatusId == NotificationStatus.Unread)
                                                                   .ToList();

            return Json(pendingApplications,JsonRequestBehavior.AllowGet);
        }

        // GET: Get all new Notification
        public JsonResult GetNewNotifications(string id)
        {
            var applicationDetails = _context.Applications.Where(f => f.LearnerUseId == id &&
                                                                 f.NotificationStatusId == NotificationStatus.Unread).ToList();
            return Json(applicationDetails, JsonRequestBehavior.AllowGet);
        }
    }
}