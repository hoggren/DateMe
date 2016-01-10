using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateMe.ViewModels;
using Microsoft.AspNet.Identity;
using Models.Context;
using Models.Models;
using System.IO;

using DateMe.Functions;
using System.Diagnostics;
using System.Xml;

namespace DateMe.Controllers
{
    public class ProfileController : BaseController
    {
        private AppDbContext db = new AppDbContext();

        // GET: Profile
        public ActionResult Index()
        {
            UserUtilities.ResetMessageCount();

            var currentUser = db.Users.Find(System.Web.HttpContext.Current.User.Identity.GetUserId());
            
            if (User.Identity.IsAuthenticated && currentUser != null)
            {
                return View(new ProfileViewModel(currentUser));
            }
            else
            {
                return RedirectToAction("Logout", "Auth");
            }
        }

        public ActionResult U(string id)
        {
            var currentUserId = User.Identity.GetUserId();

            var currentUser = (from u in db.Users
                               where u.Id == currentUserId
                               select u).SingleOrDefault();

            var requestedUser = (from u in db.Users
                                 where u.Id == id
                                 select u).SingleOrDefault();

            if (requestedUser != null)
            {
                if (requestedUser.Id != currentUser.Id)
                {
                    (requestedUser.Profile.Visitors as List<Visitor>).Insert(0, new Visitor { AppUser = currentUser });
                    db.SaveChanges();
                }
            }

            return View(new ProfileViewModel(requestedUser));
            
        }

        [HttpGet]
        public ActionResult Export()
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());
            return Content(UserUtilities.exportUser(currentUser), "text/xml");
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var currentUser = db.Users.Find(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var model = new ProfileEditViewModel
            {
                Nickname = currentUser.UserData.Nickname,
                Firstname = currentUser.Profile.FirstName,
                Lastname = currentUser.Profile.LastName,
                City = currentUser.UserData.Location.City,
                Gender = currentUser.UserData.Gender,
                LookingFor = currentUser.UserData.LookingFor,
                Description = currentUser.UserData.Description,
                Email = currentUser.UserName,
                Password = "NOPENOPENOPENOPE",
                Active = currentUser.Active,
                Visible = currentUser.Visible
            };

            return View(model);
        }

        public ActionResult Delete()
        {
            var user = db.Users.Find(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (user != null)
            {
                user.Active = false;
                var x = user.Profile.ProfileId;
                x = user.UserData.UserId;
            }

            db.SaveChanges();

            return RedirectToAction("Logout","Auth");
        }

        [HttpPost]
        public ActionResult Edit(ProfileEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var photoPath = "";

            if(model.ImageFile != null)
            {
                if (!(new string[] { "image/jpeg", "image/pjpeg" }.Contains(model.ImageFile.ContentType)))
                {
                    ModelState.AddModelError("ImageFile", "Wrong filetype. Allowed filetypes: jpg, jpeg");
                    return View(model);
                }
                else if (model.ImageFile.ContentLength > 1048576)
                {
                    ModelState.AddModelError("ImageFile", "Max file size: 1 Mb");
                    return View(model);
                }

                var filepath = "/Content/Uploads/";
                var filename = "";

                do
                {
                    filename = Path.GetRandomFileName() + ".jpg";
                } while (System.IO.File.Exists(Server.MapPath("~" + filepath) + filename));

                model.ImageFile.SaveAs(Server.MapPath("~" + filepath) + filename);
                photoPath = filepath + filename;
            }

            if (model.NewPassword != null)
            {
                if (model.NewPassword.Length < 8 || model.NewPassword.Length >= 50)
                {
                    ModelState.AddModelError("NewPassword", "Välj ett nytt lösenord, minst 8 bokstäver.");
                    return View(model);
                }
            }

            var currentUser = db.Users.Find(System.Web.HttpContext.Current.User.Identity.GetUserId());

            currentUser.UserData.Nickname = model.Nickname;
            currentUser.Profile.FirstName = model.Firstname;
            currentUser.Profile.LastName = model.Lastname;
            currentUser.UserData.Location = new Location { Country = "Sweden", City = model.City };
            currentUser.UserData.Gender = model.Gender;
            currentUser.UserData.LookingFor = model.LookingFor;
            currentUser.UserData.Description = model.Description;
            currentUser.UserName = model.Email;
            currentUser.Visible = model.Visible;
            currentUser.Active = model.Active;

            if (!photoPath.Equals(""))
                currentUser.UserData.PhotoPath = photoPath;

            if (model.NewPassword != null)
                currentUser.PasswordHash = Startup.UserManagerFactory.Invoke().PasswordHasher.HashPassword(model.NewPassword);

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}