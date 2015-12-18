using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Models;

namespace DateMe.ViewModels
{
    public class WallViewModel
    {
        public List<Message> Messages { get; set; }

        public WallViewModel(Wall wall)
        {
            Messages = wall;
        }
    }
}