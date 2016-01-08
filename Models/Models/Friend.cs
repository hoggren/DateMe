using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Friend
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual AppUser AppUser { get; set; }
        public String Category { get; set; }
        public bool Confirmed { get; set; }
    }
}