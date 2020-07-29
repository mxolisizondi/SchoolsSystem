using SchoolsSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using SchoolsSystem.ViewModels;

namespace SchoolsSystem.Controllers
{
    [Authorize(Roles = ""+RoleName.Clerk+","+RoleName.Admin)]
    public class ClerkController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public ClerkController()
        {
            _context = new ApplicationDbContext();
        }

        public ClerkController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: Clerk
        [Authorize(Roles = RoleName.Clerk)]
        public ActionResult Home(string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.message = message;

            return View();
        }

        public ActionResult RegisteredClerks(string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.message = message;

            var clerks = _context.Clerks.Include(s => s.School).ToList();
            return View(clerks);
        }

        //DELETE
        public ActionResult DeleteClerk(string message)
        {
            if (!string.IsNullOrEmpty(message))
                ViewBag.message = message;

            var clerks = _context.Clerks.Include(s => s.School).ToList();

            return View(clerks);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteClerk")]
        public async Task<ActionResult> DeleteClerkPost(string userId)
        {
            if(ModelState.IsValid)
            {
                if (userId == null)
                    return HttpNotFound();

                var user = await UserManager.FindByIdAsync(userId);
                var logins = user.Logins;
                var userRole = await UserManager.GetRolesAsync(userId);
                var clerk = _context.Clerks.SingleOrDefault(c => c.userId.Equals(userId));

                if(clerk != null)
                {
                    _context.Clerks.Remove(clerk);
                    _context.SaveChanges();
                }

                using (var transaction = _context.Database.BeginTransaction())
                {
                    foreach(var login in logins.ToList())
                    {
                        await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
                    }

                    if(userRole.Count() > 0)
                    {
                        foreach(var roleClerk in userRole.ToList())
                        {
                            var result = await UserManager.RemoveFromRoleAsync(user.Id, roleClerk);
                        }
                    }
                    await UserManager.DeleteAsync(user);
                    transaction.Commit();
                }
                return RedirectToAction("DeleteClerk", "Clerk", new { message = "Deleted" });
            }
            return RedirectToAction("DeleteClerk","Clerk", new { message = "Error"});// Return to view this mean they was an error cant delete
        }


        //GET: All Pending applications
        public ActionResult PendingApplications()
        {
            var userId = User.Identity.GetUserId();
            var clerk = _context.Clerks.Single(c => c.userId == userId);
            if(clerk == null)
            {
                HttpNotFound();
            }
            var pendingApplications = _context.Applications.Include(d => d.ApplicationDocuments)
                                                    .Include(l => l.Learner)
                                                    .Include(s => s.ApplicationStatus)
                                                    .Where(u => u.SchoolId == clerk.SchoolId &&
                                                            u.ApplicationStatus.Id != ApplicationStatus.Accepted && u.ApplicationStatusId != ApplicationStatus.Declined)
                                                            .ToList();

            return View(pendingApplications);
        }

        //GET: Change Status- Close or Open Applications
        public ActionResult ChangeSchoolStatus()
        {
            var userId = User.Identity.GetUserId();
            var acceptApplicationStatus = _context.AcceptApplications.ToList();
            var clerkDetails = _context.Clerks.Include(s => s.School).SingleOrDefault(c => c.userId == userId);

            var viewModel = new SchoolViewModel
            {
                School = clerkDetails.School,
                AcceptApplications = acceptApplicationStatus
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeSchoolStatus(School school)
        {
            var schoolInDb = _context.Schools.Single(s => s.Id == school.Id);

            if(schoolInDb == null)
            {
                return HttpNotFound();
            }
            // Use library like AutoMapper to do this for you instead of doing it manual
            schoolInDb.OpenDate = school.OpenDate;
            schoolInDb.ClosingDate = school.ClosingDate;
            schoolInDb.AcceptApplicationId = school.AcceptApplicationId;

            _context.SaveChanges();

            return RedirectToAction("Home", new { message = "Change"}); // Toast Status succeful changes and redirect to pending applications
        }

        //GET: All aprove applications Clerk
        public ActionResult ApprovedApplications()
        {
            var userId = User.Identity.GetUserId();
            var clerk = _context.Clerks.Single(c => c.userId == userId);
            var approvedApplications = _context.Applications.Include(d => d.ApplicationDocuments)
                                                    .Include(s => s.School)
                                                    .Include(l => l.Learner)
                                                    .Include(s => s.ApplicationStatus)
                                                    .Where(u => u.SchoolId == clerk.SchoolId &&
                                                           u.ApplicationStatus.Id == ApplicationStatus.Accepted)
                                                           .ToList();

            return View(approvedApplications);
        }

        //GET: All Rejectect Applications
        public ActionResult RejectedApplications()
        {
            var userId = User.Identity.GetUserId();
            var clerk = _context.Clerks.Single(c => c.userId == userId);
            var apprvedApplications = _context.Applications.Include(d => d.ApplicationDocuments)
                                                    .Include(s => s.School)
                                                    .Include(l => l.Learner)
                                                    .Include(s => s.ApplicationStatus)
                                                    .Where(u => u.School.Id == clerk.SchoolId &&
                                                           u.ApplicationStatus.Id == ApplicationStatus.Declined)
                                                           .ToList();

            return View(apprvedApplications);
        }

        public ActionResult WithdrawedApplications()
        {
            var userId = User.Identity.GetUserId();
            var clerk = _context.Clerks.Single(c => c.userId == userId);
            var withdrawedApplications = _context.Applications.Include(d => d.ApplicationDocuments)
                                                    .Include(s => s.School)
                                                    .Include(s => s.Learner)
                                                    .Include(s => s.ApplicationStatus)
                                                    .Where(u => u.ApplicationStatus.Id == ApplicationStatus.Withdrawed &&
                                                           u.SchoolId == clerk.SchoolId)
                                                           .ToList();
            return View(withdrawedApplications);
        }

    }
}