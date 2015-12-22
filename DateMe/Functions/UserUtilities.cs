using Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMe.Functions
{
    public class UserUtilities
    {
        public static bool UniqueNickName(string nickname)
        {
            var db = new AppDbContext();
            var user = (from u in db.Users
                        where u.UserData.Nickname == nickname
                        select u);

            if (user.Count() == 0)
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

            if (user.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}