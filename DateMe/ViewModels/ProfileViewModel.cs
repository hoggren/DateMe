using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Models;

namespace DateMe.ViewModels
{
    public class ProfileViewModel
    {
        private AppUser _user;

        public string Name { get; set; }
        public string Gender { get; set; }
        public string LookingFor { get; set; }
        public string Nickname { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public Wall Wall { get; set; } 

        public ProfileViewModel(AppUser user)
        {
            this._user = user;
            var profile = user.Profile;
            var userData = user.UserData;

            Name = $"{profile.FirstName} {profile.LastName}";
            Gender = userData.Gender;
            LookingFor = userData.LookingFor;
            Nickname = userData.Nickname;
            Location = userData.Location;
            Description = userData.Description;
            Age = DateTime.Today.Year - userData.DateOfBirth.Year;

            Wall = profile.Wall;
        }
    }



}