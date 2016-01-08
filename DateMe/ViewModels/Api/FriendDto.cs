using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMe.ViewModels.Api
{
    public class FriendDto
    {
        public String Id { get; set; }
        public String Nickname { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String City { get; set; }
        public String Category { get; set; }

        public FriendDto()
        {
            
        }

    }
}