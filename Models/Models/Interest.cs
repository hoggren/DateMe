using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Interest
    {
        public Interest()
        {
            Interested = new HashSet<UserData>();
        }

        public int Id { get; set; }
        public ICollection<UserData> Interested { get; set; }
    }
}