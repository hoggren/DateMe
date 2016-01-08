using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mail;
using DateMe.Functions;
using Models.Models;

namespace DateMe.ViewModels
{
    public class ProfileViewModel
    {
        private AppUser _user;

        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string LookingFor { get; set; }
        public string Nickname { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string PhotoPath { get; set; }
        public List<Message> Messages { get; set; }
        public List<AppUser> Visitors { get; set; }

        public ProfileViewModel(AppUser user)
        {
            this._user = user;
            var profile = user.Profile;
            var userData = user.UserData;

            Id = user.Id;
            Name = $"{profile.FirstName} {profile.LastName}";

            if (userData.Gender.Equals("Male")) Gender = "Man";
            else if (userData.Gender.Equals("Female")) Gender = "Woman";
            if (userData.LookingFor.Equals("Male")) LookingFor = "men";
            else if (userData.LookingFor.Equals("Female")) LookingFor = "women";
            else LookingFor = "other";

            Nickname = userData.Nickname;
            Location = userData.Location;
            Description = userData.Description;
            Age = UserUtilities.DateToAge(userData.DateOfBirth);
            PhotoPath = userData.PhotoPath;
            Messages = profile.Messages as List<Message>;
            Visitors = profile.Visitors.ToList();
        }
    }



}