using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MessageId { get; set; }
        public virtual Profile Profile { get; set; }
        [Required]
        [StringLength(512, MinimumLength = 2)]
        public string Text { get; set; }
        public DateTime Sent { get; set; }
        public bool Read { get; set; }
        public virtual AppUser From { get;set; }
    }
}