using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMe.ViewModels.Api
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public String PhotoPath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string LookingFor { get; set; }

        public UserDto(AppUser user)
        {
            Id = user.UserData.UserId;
            Nickname = user.UserData.Nickname;
            Description = user.UserData.Description;
            City = user.UserData.Location.City;
            PhotoPath = user.UserData.PhotoPath;
            DateOfBirth = user.UserData.DateOfBirth;
            Gender = user.UserData.Gender;
            LookingFor = user.UserData.LookingFor;
        }

        public UserDto()
        {

        }
    }
}