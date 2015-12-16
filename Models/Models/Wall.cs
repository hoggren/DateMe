using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Wall : List<Message>
    {
        public Guid WallId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}