using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Location
    {
        public Location()
        {
            UserDatas = new List<UserData>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LocationId { get; set; }
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual ICollection<UserData> UserDatas { get; set; }
    }
}