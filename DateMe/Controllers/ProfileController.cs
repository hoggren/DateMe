using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateMe.ViewModels;
using Microsoft.AspNet.Identity;
using Models.Context;
using Models.Models;

namespace DateMe.Controllers
{
    public class ProfileController : BaseController
    {
        private AppDbContext db = new AppDbContext();

        // GET: Profile
        public ActionResult Index()
        {
            var currentUser = db.Users.Find(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (User.Identity.IsAuthenticated)
            {
                return View(new ProfileViewModel(currentUser));
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        public ActionResult Specific(string id)
        {
            var requestedUser = db.Users.Find(id);
            return View(new ProfileViewModel(requestedUser));
        }
    }
}