using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DateMe.ViewModels.Api;
using Microsoft.AspNet.Identity;
using Models.Context;
using Models.Models;

namespace DateMe.Controllers.Api
{
    public class VisitorsController : ApiController
    {
        private readonly AppDbContext _db = new AppDbContext();

        private static readonly Expression<Func<Visitor, VisitorDto>> AsVisitorDto =
            visitor => new VisitorDto
            {
                Id = visitor.AppUser.Id,
                Nickname = visitor.AppUser.UserData.Nickname,
                TimeOfVisit = visitor.TimeOfVisit
            };


        [ResponseType(typeof(VisitorDto))]
        public IQueryable<VisitorDto> GetVisitors()
        {
            var currentUserId = User.Identity.GetUserId();

            if (currentUserId == null)
            {
                return (_db.Users.Find(new Guid()).Profile.Visitors).AsQueryable().Select(AsVisitorDto).Take(5);
            }

            return (_db.Users.Find(currentUserId).Profile.Visitors).AsQueryable().Select(AsVisitorDto).Take(5).Reverse();
        }
       


    }
}