using DateMe.Functions;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMe.ViewModels
{
    public class SupermatchViewModel
    {
        public SupermatchViewModel(AppUser user)
        {
            Matches = UserUtilities.getSuperMatches();
            MyBirthDay = user.UserData.DateOfBirth;
        }

        public List<AppUser> Matches { get; set; }
        public DateTime MyBirthDay { get; set; }
    }
}