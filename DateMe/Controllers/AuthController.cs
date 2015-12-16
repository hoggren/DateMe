using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DateMe.ViewModels;
using Microsoft.AspNet.Identity;
using Models.Models;

namespace DateMe.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
             
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindAsync(viewModel.Email, viewModel.Password);

            if (user != null)
            {
                await SignIn(user);
                return Redirect(GetRedirectedUrl(viewModel.ReturnUrl));
            }

            ModelState.AddModelError("", "Invalid email or password");

            return View(viewModel);
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            Request.GetOwinContext().Authentication.SignIn(identity);
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();  
            }
            /*
           var user = new AppUser
           {
               UserName = model.Email,
               UserData = new UserData
               {
                   Nickname = model.Nickname,
                   PhotoPath = "",
                   Description = "",
                   DateOfBirth = DateTime.Now,
                   Location = new Location {Country = "Sweden", City = "Uppsala"},
                   Interests = new List<Interest>()
               },
              Profile = new Profile
               {
                   FirstName = model.Firstname,
                   LastName = model.Lastname,
                   FriendsList = new FriendsList(),
                   Wall = new Wall()
               }
               
        };
        */
            var user = new AppUser
            {
                UserName = model.Email
            };
            user.UserData = new UserData 
            {
                Nickname = model.Nickname,
                PhotoPath = "",
                Description = "",
                DateOfBirth = DateTime.Now
            };
            user.UserData.Location = new Location {Country = "Sweden", City = "Uppsala"};
            user.UserData.Interests = new List<Interest>();

            user.Profile = new Profile
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                //FriendsList = new FriendsList(),
                //Wall = new Wall()
            };
            try
            {
                var result = await userManager.CreateAsync(user, model.Password);
            


            if (result.Succeeded)
            {
                await SignIn(user);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var x in e.EntityValidationErrors)
                {
                    Debug.WriteLine(x.Entry.Entity.GetType().Name);
                    Debug.WriteLine(x.ValidationErrors.First().ErrorMessage);
                }
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }


        private string GetRedirectedUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

    }
}