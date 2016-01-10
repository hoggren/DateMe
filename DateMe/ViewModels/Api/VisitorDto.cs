using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Models;

namespace DateMe.ViewModels.Api
{
    public class VisitorDto
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public DateTime TimeOfVisit { get; set; }

        public VisitorDto(Visitor visitor)
        {
            Id = visitor.AppUser.Id;
            Nickname = visitor.AppUser.UserData.Nickname;
            TimeOfVisit = visitor.TimeOfVisit;
        }

        public VisitorDto()
        {
            
        }
    }
}