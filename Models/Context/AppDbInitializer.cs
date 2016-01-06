using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.Models;

namespace Models.Context
{
    public class AppDbInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            IList<Interest> defaultInterests = new List<Interest>();
            #region interestCreation

            defaultInterests.Add(new Interest { Title = "Toothpaste" });
            defaultInterests.Add(new Interest { Title = "Doing taxes" });
            defaultInterests.Add(new Interest { Title = "Moonshine" });
            defaultInterests.Add(new Interest { Title = "Greed" });
            defaultInterests.Add(new Interest { Title = "Hate" });
            defaultInterests.Add(new Interest { Title = "Short circuits" });
            defaultInterests.Add(new Interest { Title = "Pandemic" });
            defaultInterests.Add(new Interest { Title = "Poison" });
            defaultInterests.Add(new Interest { Title = "Prison" });
            defaultInterests.Add(new Interest { Title = "Random interests" });
            defaultInterests.Add(new Interest { Title = "Road rage" });
            defaultInterests.Add(new Interest { Title = "Pornography" });
            defaultInterests.Add(new Interest { Title = "Torture" });
            defaultInterests.Add(new Interest { Title = "Flowers" });
            defaultInterests.Add(new Interest { Title = "Disease" });
            defaultInterests.Add(new Interest { Title = "Happiness" });
            defaultInterests.Add(new Interest { Title = "Working hard" });
            defaultInterests.Add(new Interest { Title = "Slavery" });
            defaultInterests.Add(new Interest { Title = "Hitting too hard" });
            defaultInterests.Add(new Interest { Title = "Cigarettes" });

            #endregion

            foreach (var i in defaultInterests)
                context.Interests.Add(i);

            IList<AppUser> defaultUsers = new List<AppUser>();
            #region usercreation
            defaultUsers.Add(new AppUser
            {
                Active = true,
                UserName = "klas@tarnstrom.se",
                PasswordHash = new PasswordHasher().HashPassword("hejhejhej"),

                UserData = new UserData
                {
                    Location = new Location { Country = "Sweden", City = "Uppsala" },
                    Nickname = "Klasse",
                    Gender = "Male",
                    LookingFor = "Female",
                    PhotoPath = "/Content/Images/default_users/klasse.jpg",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                                  "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis " +
                                  "nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                                  "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                                  "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia " +
                                  "deserunt mollit anim id est laborum.",
                    DateOfBirth = new DateTime(1987, 5, 23),                  
                    Interests = new List<Interest>()
                },

                Profile = new Profile
                {
                    FirstName = "Klas",
                    LastName = "Tärnström",
                    FriendsList = new FriendsList(),
                    Messages = new List<Message>()
                }

            });

            defaultUsers.Add(new AppUser
            {
                Active = true,
                UserName = "carljan@grythyttan.se",
                PasswordHash = new PasswordHasher().HashPassword("hejhejhej"),

                UserData = new UserData
                {
                    Location = new Location { Country = "Sweden", City = "Örebro" },
                    Nickname = "C-jan",
                    Gender = "Male",
                    LookingFor = "Male",
                    PhotoPath = "/Content/Images/default_users/carljan.jpg",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                      "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis " +
                      "nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                      "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                      "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia " +
                      "deserunt mollit anim id est laborum.",
                    DateOfBirth = new DateTime(1946, 3, 22),
                    Interests = new List<Interest>()
                },

                Profile = new Profile
                {
                    FirstName = "Carl Jan",
                    LastName = "Granqvist",
                    FriendsList = new FriendsList(),
                    Messages = new List<Message>()
                }

            });

            defaultUsers.Add(new AppUser
            {
                Active = true,
                UserName = "tommy@pippi.com",
                PasswordHash = new PasswordHasher().HashPassword("hejhejhej"),

                UserData = new UserData
                {
                    Location = new Location { Country = "Sweden", City = "Visby" },
                    Nickname = "TommyFromPippi57",
                    Gender = "Male",
                    LookingFor = "Other",
                    PhotoPath = "/Content/Images/default_users/tommy.jpg",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                      "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis " +
                      "nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                      "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                      "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia " +
                      "deserunt mollit anim id est laborum.",
                    DateOfBirth = new DateTime(1957, 10, 22),
                    Interests = new List<Interest>()
                },

                Profile = new Profile
                {
                    FirstName = "Tommy",
                    LastName = "Enigma",
                    FriendsList = new FriendsList(),
                    Messages = new List<Message>()
                }

            });

            defaultUsers.Add(new AppUser
            {
                Active = true,
                UserName = "carlxvigustaf@kungahuset.gov",
                PasswordHash = new PasswordHasher().HashPassword("hejhejhej"),

                UserData = new UserData
                {
                    Location = new Location { Country = "Sweden", City = "Stockholm" },
                    Nickname = "XVI",
                    Gender = "Male",
                    LookingFor = "Female",
                    PhotoPath = "/Content/Images/default_users/knugen.jpg",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                      "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis " +
                      "nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                      "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                      "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia " +
                      "deserunt mollit anim id est laborum.",
                    DateOfBirth = new DateTime(1946, 4, 30),
                    Interests = new List<Interest>()
                },

                Profile = new Profile
                {
                    FirstName = "Carl Gustaf",
                    LastName = "Bernadotte",
                    FriendsList = new FriendsList(),
                    Messages = new List<Message>()
                }

            });

            defaultUsers.Add(new AppUser
            {
                Active = true,
                UserName = "narcotraficante49@hotmail.com",
                PasswordHash = new PasswordHasher().HashPassword("hejhejhej"),

                UserData = new UserData
                {
                    Location = new Location { Country = "Colombia", City = "Medellin" },
                    Nickname = "NarcotráficoParaSiempre",
                    Gender = "Male",
                    LookingFor = "Female",
                    PhotoPath = "/Content/Images/default_users/pablo.jpg",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                      "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis " +
                      "nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " +
                      "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat " +
                      "nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia " +
                      "deserunt mollit anim id est laborum.",
                    DateOfBirth = new DateTime(1949, 12, 1),
                    Interests = new List<Interest>()
                },

                Profile = new Profile
                {
                    FirstName = "Pablo",
                    LastName = "Escobar",
                    FriendsList = new FriendsList(),
                    Messages = new List<Message>()
                }

            });

            using (var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context)))
            {
                foreach (var u in defaultUsers)
                {
                    context.Users.Add(u);
                    userManager.Create(u);
                }
            }

            #endregion




            base.Seed(context);
            
        }
    }
}
