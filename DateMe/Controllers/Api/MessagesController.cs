using System;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Models.Context;
using Models.Models;
using Microsoft.AspNet.Identity;
using System.Linq.Expressions;

using DateMe.ViewModels.Api;

namespace DateMe.Controllers.Api
{
    public class MessagesController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        private static readonly Expression<Func<Message, MessageDto>> AsMessageDto =
            message => new MessageDto
            {
                Id = message.MessageId.ToString(),
                Text = message.Text,
                FromId = message.From.Id,
                FromNickName = message.From.UserData.Nickname,
                Sent = message.Sent
            };

        // GET: api/Messages
        [ResponseType(typeof(MessageDto))]
        public IQueryable<MessageDto> GetMessages()
        {
            var id = User.Identity.GetUserId();
            var user = db.Users.Find(id);

            if (user == null)
            {
                return db.Messages.Where(m => m.MessageId == new Guid()).Select(AsMessageDto);
            }

            var messages = db.Messages.Where(m => m.Profile.ProfileId == user.Profile.ProfileId).Select(AsMessageDto);

            return messages;
        }

        // POST: api/Messages/{toUserId}
        [ResponseType(typeof(Message))]
        public IHttpActionResult PostMessage(Message message, string toUserId)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            var toUser = db.Users.Find(toUserId);

            if (toUser == null || message == null)
            {
                return NotFound();
            }

            message.From = db.Users.Find(User.Identity.GetUserId());
            message.Profile = toUser.Profile;
            message.Sent = DateTime.Now;
            message.Read = false;

            db.Messages.Add(message);
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Message))]
        public IHttpActionResult DeleteMessage(Guid id)
        {
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }

            db.Messages.Remove(message);
            db.SaveChanges();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}