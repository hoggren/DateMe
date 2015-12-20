using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateMe.ViewModels.Api
{
    public class MessageDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string FromId { get; set; }

        public MessageDto() { }

    }
}