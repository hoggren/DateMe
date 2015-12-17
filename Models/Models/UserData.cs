using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Web;

using Models.Models.Types;

namespace Models.Models
{
    public class UserData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual Location Location { get; set; }

        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string LookingFor { get; set; }
        public string PhotoPath { get; set; }
        public string Description { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }

    }
}