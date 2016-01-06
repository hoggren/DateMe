using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateMe.ViewModels;
using Models.Context;
using Models.Models;

namespace DateMe.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly AppDbContext _db = new AppDbContext();

        public ActionResult Index()
        {
            var exampleUsers = (from u in _db.Users
                                where u.Active == true
                                select u).Take(5).ToList();

            return View(new HomeViewModel(exampleUsers));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}