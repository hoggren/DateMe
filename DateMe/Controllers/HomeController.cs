using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateMe.ViewModels;
using Models.Context;
using Models.Models;
using System.Threading;
using System.Globalization;

namespace DateMe.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly AppDbContext _db = new AppDbContext();

        public ActionResult Index(string lang)
        {

            if (lang == "SV" || lang == "sv")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("sv-SE");
            }

            var exampleUsers = (from u in _db.Users
                                where u.Active == true
                                orderby u.Id descending 
                                select u).Take(5).ToList();

            return View(new HomeViewModel(exampleUsers));
        }

        public ActionResult About()
        {
            return View();
        }

    }
}