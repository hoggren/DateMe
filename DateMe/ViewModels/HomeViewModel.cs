using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Models;

namespace DateMe.ViewModels
{
    public class HomeViewModel
    {
        public List<AppUser> ExampleUsers { get; set; }

        public HomeViewModel(List<AppUser> exampleUsers)
        {
            ExampleUsers = exampleUsers;
        }
    }
}