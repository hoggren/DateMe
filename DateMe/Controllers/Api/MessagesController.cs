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
                FromId = message.From.Id
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

        // GET: api/Messages/{id}
        [ResponseType(typeof(Message))]
        public IQueryable<Message> GetMessages(string id)
        {
            var user = db.Users.Find(id);

            if (user == null)
            {
                return db.Messages.Where(m => m.MessageId == new Guid());
            }

            var messages = db.Messages.Where(m => m.Profile.ProfileId == user.Profile.ProfileId);

            return messages;
        }

        // POST: api/Messages
        [ResponseType(typeof(Message))]
        public IHttpActionResult PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Messages.Add(message);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = message.Profile.ProfileId }, message);
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