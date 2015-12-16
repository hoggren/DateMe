using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Location : IModel
    {
        public Location()
        {
            UserDatas = new List<UserData>();
        }

        public int Id { get; set; }
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual ICollection<UserData> UserDatas { get; set; }
    }
}