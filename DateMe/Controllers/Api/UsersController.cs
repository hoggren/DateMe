using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Models.Context;
using Models.Models;
using System.Linq;
using System.Collections.Generic;

using DateMe.ViewModels.Api;
using System.Web.Http.Description;
using System.Linq.Expressions;
using System;
using System.Data.Entity;
using System.Web.Mvc.Html;

namespace DateMe.Controllers.Api
{
    public class UsersController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        private static readonly Expression<Func<AppUser, UserDto>> AsUserDto =
            user => new UserDto
            {
                Id = user.Id,
                Nickname = user.UserData.Nickname,
                Description = user.UserData.Description,
                City = user.UserData.Location.City,
                PhotoPath = user.UserData.PhotoPath,
                DateOfBirth = user.UserData.DateOfBirth,
                Gender = user.UserData.Gender,
                LookingFor = user.UserData.LookingFor
            };

        public IQueryable<UserDto> GetAppusers(string query)
        {
            return (from u in db.Users
                where u.UserData.Nickname.Contains(query)
                      && u.Visible == true && u.Active == true
                select u).Select(AsUserDto);
        }

        [ResponseType(typeof(UserDto))]
        public IHttpActionResult GetAppUser(string id)
        {
            AppUser user = null;

            switch (id)
            {
                case "current":
                case "Current":
                    user = db.Users.Find(HttpContext.Current.User.Identity.GetUserId());

                    var currentUser = new UserDto(user);
                    return Ok(currentUser);

                default:
                    user = Startup.UserManagerFactory.Invoke().FindById(id);

                    if (user == null)
                    if (user.Active && user.Visible)
                    {
                        return NotFound();
                    }

                    var unfriendlyUser = new UserDto(user);
                    return Ok(unfriendlyUser);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}