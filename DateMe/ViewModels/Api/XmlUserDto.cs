using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMe.ViewModels.Api
{
    public class XmlUserDto
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public String PhotoPath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string LookingFor { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Visible { get; set; }

        public List<String> Friends { get; set; }

        public XmlUserDto(AppUser user)
        {
            Id = user.Id;
            Nickname = user.UserData.Nickname;
            Description = user.UserData.Description;
            City = user.UserData.Location.City;
            PhotoPath = user.UserData.PhotoPath;
            DateOfBirth = user.UserData.DateOfBirth;
            Gender = user.UserData.Gender;
            LookingFor = user.UserData.LookingFor;

            FirstName = user.Profile.FirstName;
            LastName = user.Profile.LastName;
            Visible = user.Visible;

            Friends = new List<string>();

            foreach (var f in user.Profile.Friends)
            {
                Friends.Add(f.AppUser.UserData.Nickname);
            }
        }

        public XmlUserDto()
        {

        }
    }
}