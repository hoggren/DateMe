using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Visitor
    {
        public Visitor()
        {
            TimeOfVisit = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VisitorId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual DateTime TimeOfVisit { get;set; }
    }
}