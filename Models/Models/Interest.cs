using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InterestId { get; set; }
        public ICollection<UserData> Interested { get; set; }

        public string Title { get; set; }
    }
}