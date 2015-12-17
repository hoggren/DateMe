using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Models.Context;
using Models.Models;
using System.Linq;
using System.Collections.Generic;

namespace DateMe.Controllers.Api
{
    public class UsersController : ApiController
    {
        //private AppDbContext db;

        public List<AppUser> GetAppusers(string query)
        {
            List<AppUser> result;

            using (var db = new AppDbContext())
            {
                result = (from u in db.Users
                          where u.UserData.Nickname.Contains(query)
                          select u).ToList();

                return result;
            }
        }
        public IHttpActionResult GetAppUser(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            using(var db = new AppDbContext())
            {
                AppUser user = null;

                switch (id)
                {
                    case "current":
                    case "Current":
                        user = db.Users.Find(HttpContext.Current.User.Identity.GetUserId());
                        
                        var currentUser = new
                        {
                            Id = user.Id,
                            Nickname = user.UserData.Nickname,
                            Description = user.UserData.Description,
                            Interest = user.UserData.Interests,
                            Location = user.UserData.Location.City,
                            PhotoPath = user.UserData.PhotoPath,
                            Gender = user.UserData.Gender,
                            LookingFor = user.UserData.LookingFor
                            //NewMessageCount
                            //messageCount
                            //NewFriendRequests
                        };

                        return Ok(currentUser);

                    default:
                        user = Startup.UserManagerFactory.Invoke().FindById(id);

                        if (user == null)
                        {
                            return NotFound();
                        }

                        var friendlyUser = new
                        {
                            Id = user.Id,
                            Nickname = user.UserData.Nickname
                        };

                        return Ok(friendlyUser);

                        var unfriendlyUser = new
                        {
                            Id = user.Id,
                            Nickname = user.UserData.Nickname
                        };

                        break;
                }
            }
        }
    }
}