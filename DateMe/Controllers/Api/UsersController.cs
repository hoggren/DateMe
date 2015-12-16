using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Models.Context;
using Models.Models;

namespace DateMe.Controllers.Api
{
    public class UsersController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        public IHttpActionResult GetAppUser(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            AppUser user = null;

            switch (id)
            {
                case "current":
                case "Current":
                    user = db.Users.Find(HttpContext.Current.User.Identity.GetUserId());

                    var currentUser = new
                    {
                        Id = user.Id,
                        Nickname = user.UserData.Nickname
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
                    //Ge tillbaka minddre infoom ni inte är vänner
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