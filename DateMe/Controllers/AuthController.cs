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
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
                return View();

            var user = await userManager.FindAsync(viewModel.Email, viewModel.Password);

            if (user != null)
            {
                await SignIn(user);
                return Redirect(GetRedirectedUrl(viewModel.ReturnUrl));
            }

            ModelState.AddModelError("", "Invalid email or password");

            return View(viewModel);
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
                return View(new RegisterViewModel());
            #region usercreation
            var user = new AppUser
            {
                UserName = model.Email
            };

            user.UserData = new UserData 
            {
                Nickname = model.Nickname,
                PhotoPath = "/Content/Images/example_sexy.png",
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam " +
                              "rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                              "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia " +
                              "consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui " +
                              "dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora " +
                              "incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum " +
                              "exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem " +
                              "vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui " +
                              "dolorem eum fugiat quo voluptas nulla pariatur?",
                DateOfBirth = new DateTime(1984, 3, 23),
                Gender = model.Gender,
                LookingFor = model.LookingFor
            };

            user.UserData.Location = new Location
            {
                Country = "Sweden",
                City = model.City
            };

            user.Profile = new Profile
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                
            };

            user.Profile.FriendsList = new FriendsList();
            user.UserData.Interests = new List<Interest>();
            user.Profile.Messages = new List<Message>();
            /*
            user.Profile.Messages.Add(new Message
            {
                Text = "hi there, i would love to make a date ASAP, u are so beautiful!!",
                From = user
            });
            user.Profile.Messages.Add(new Message
            {
                Text = "Thanks for last night!! ;) tihi",
                From = user
            });
            user.Profile.Messages.Add(new Message
            {
                Text = "Wow.. Is that really your snot hanging from the nose or is it slime from the toy store??",
                From = user
            });
            */
            #endregion usercreation

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
                //Visa i en Error-view!
                foreach (var x in e.EntityValidationErrors)
                {
                    Debug.WriteLine(x.Entry.Entity.GetType().Name);
                    Debug.WriteLine(x.ValidationErrors.First().ErrorMessage);
                }
            }

            return View(model);
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);

            Request.GetOwinContext().Authentication.SignIn(identity);
        }

        private string GetRedirectedUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}