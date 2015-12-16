using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Models
{
    public class Message : IModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}