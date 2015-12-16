using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Models.Models;

namespace Models.Context
{
    public class AppDbInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
 /*           context.Users.Add(new AppUser()
            {
                Email = "klas@tarnstrom.se",
                PasswordHash = new PasswordHasher().HashPassword("hejhej"),
                UserData = new UserData
                {
                    FirstName = "Klas", 
                    LastName = "Tärnström",
                    Nickname = "Klasse Kock"
                }
            });
            base.Seed(context);
            */
        }
    }
}