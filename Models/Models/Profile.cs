using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Profile
    {
        public Profile()
        {
            Messages = new List<Message>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProfileId { get; set; }

        public virtual AppUser AppUser { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual FriendsList FriendsList { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}