using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Models;

namespace DateMe.ViewModels
{
    public class MessagesViewModel
    {
        public List<Message> Messages { get; set; }

        public MessagesViewModel(List<Message> messages)
        {
            Messages = messages;
        }
    }
}