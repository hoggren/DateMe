using Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Security;

namespace DateMe.Functions
{
    public class UserUtilities
    {
        public static bool AreFriends(string friendId)
        {
            var db = new AppDbContext();

            var currentUser = db.Users.Find(HttpContext.Current.User.Identity.GetUserId());
            var friend = db.Users.Find(friendId);

            if (friend != null)
            {
                foreach (var f in friend.Profile.Friends)
                {
                    if (f.AppUser.Id == currentUser.Id)
                    {
                        return true;
                    }
                }

                foreach (var f in currentUser.Profile.Friends)
                {
                    if (f.AppUser.Id == friend.Id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool UniqueNickName(string nickname)
        {
            var db = new AppDbContext();
            var user = (from u in db.Users
                        where u.UserData.Nickname == nickname
                        select u);

            if (!user.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UniqueEmail(string email)
        {
            var db = new AppDbContext();
            var user = (from u in db.Users
                        where u.UserName == email
                        select u);

            if (!user.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int NewMessageCount()
        {

            var db = new AppDbContext();
            var userId = HttpContext.Current.User.Identity.GetUserId();

            var unreadMessages = (from u in db.Users
                                  where u.Id == userId
                                  join m in db.Messages on u.Profile.ProfileId equals m.Profile.ProfileId
                                  where m.Read == false
                                  select m);

            if (unreadMessages == null)
            {
                return 0;
            }
            else
            {
                return unreadMessages.Count();
            }
        }

        public static void ResetMessageCount()
        {
            var db = new AppDbContext();
            var userId = HttpContext.Current.User.Identity.GetUserId();

            var messages = (from u in db.Users
                            where u.Id == userId
                            join m in db.Messages on u.Profile.ProfileId equals m.Profile.ProfileId
                            select m);

            foreach(var m in messages)
            {
                m.Read = true;
            }

            db.SaveChanges();
        }
        
        public static int UnconfirmedRequestCount()
        {
            var db = new AppDbContext();
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var currentUser = db.Users.Find(userId);

            if (currentUser == null)
                return 0;

            var unconfirmedRequests = currentUser.Profile.Friends.Count(f => f.Confirmed == false);

            return unconfirmedRequests;
        }

        public static int DateToAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;

            return age;
        }
    }
}