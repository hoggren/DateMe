using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Models.Context;
using Models.Models;
using System.Linq.Expressions;
using DateMe.Functions;
using DateMe.ViewModels.Api;
using Microsoft.Ajax.Utilities;

namespace DateMe.Controllers.Api
{
    public class FriendsController : BaseApiController
    {
        private AppDbContext db = new AppDbContext();

        private static readonly Expression<Func<Friend, FriendDto>> AsFriendDto =
            friend => new FriendDto
            {
                Id = friend.AppUser.Id,
                Nickname = friend.AppUser.UserData.Nickname,
                Firstname = friend.AppUser.Profile.FirstName,
                Lastname = friend.AppUser.Profile.LastName,
                City = friend.AppUser.UserData.Location.City,
                Category = friend.Category
            };

        //GET /api/friends
        public IQueryable<FriendDto> GetFriends()
        {
            var friends = (from f in db.Users.Find(User.Identity.GetUserId()).Profile.Friends
                           where f.Confirmed == true && f.AppUser.Active == true
                           select f
                ).AsQueryable().Select(AsFriendDto);

            return friends;
        }

        //GET /api/friends/requests
        public IQueryable<FriendDto> GetUnconfirmedFriends(string id)
        {
            var friends = (from f in db.Users.Find(User.Identity.GetUserId()).Profile.Friends
                where f.Confirmed == false
                select f
                ).AsQueryable().Select(AsFriendDto);

            return friends;
        }

        // POST: api/Friends/5
        [ResponseType(typeof(Friend))]
        public IHttpActionResult PostRequest(String id)
        {
            if (id == User.Identity.GetUserId())
                return NotFound();

            var friendUser = db.Users.Find(id);

            if (friendUser != null)
            {
                var currentUser = db.Users.Find(User.Identity.GetUserId());

                foreach (var friend in currentUser.Profile.Friends)
                {
                    if(UserUtilities.AreFriends(id))
                        return NotFound();
                }

                friendUser.Profile.Friends.Add(new Friend
                {
                    AppUser = currentUser,
                    Confirmed = false,
                });

                db.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        public IHttpActionResult PutCategory(string id, string category)
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());
            var friendToChange = currentUser.Profile.Friends.FirstOrDefault(f => f.AppUser.Id == id);

            if (friendToChange != null)
            {
                friendToChange.Category = category;
            }

            db.SaveChanges();

            return Ok();
        }

        // PUT: api/Friends/99
        [ResponseType(typeof(Friend))]
        public IHttpActionResult PutRequest(string id)
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());
            var friendRequest = currentUser.Profile.Friends.First(f => f.AppUser.Id.Equals(id.ToString()));

            if (friendRequest != null)
            if (!friendRequest.Confirmed)
            {
                friendRequest.Confirmed = true;

                var newFriendUser = db.Users.Find(id);

                if (newFriendUser != null)
                {
                    newFriendUser.Profile.Friends.Add(new Friend
                    {
                        AppUser = currentUser,
                        Confirmed = true
                    });
                }
            }

            db.SaveChanges();
            return Ok();
        }

        // DELETE: api/Friends/5
        [ResponseType(typeof(Friend))]
        public IHttpActionResult DeleteFriend(string id)
        {
            var currentUserId = User.Identity.GetUserId();

            var recievedRequest = db.Users.Find(currentUserId)?.Profile.Friends.First(f => f.AppUser.Id == id);
            var senderRequest = db.Users.Find(id)?.Profile.Friends.FirstOrDefault(f => f.AppUser.Id == currentUserId);

            if (senderRequest != null)
            {
                db.Friends.Remove(senderRequest);
            }

            if (recievedRequest != null)
            {
                db.Friends.Remove(recievedRequest);
            }

            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FriendExists(Guid id)
        {
            return db.Friends.Count(e => e.Id == id) > 0;
        }
    }
}