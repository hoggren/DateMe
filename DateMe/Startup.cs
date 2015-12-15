using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Models;
using Models.Models;
using Owin;

namespace DateMe
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Auth/Login")
            });

            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<AppUser>(new UserStore<AppUser>(new AppDbContext()));

                usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false //CP SKIT
                };

                return usermanager;
            };
        }
    }
}