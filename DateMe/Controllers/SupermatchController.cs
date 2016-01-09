using Microsoft.AspNet.Identity;
using Models.Context;
using System.Web.Mvc;
using DateMe.ViewModels;

namespace DateMe.Controllers
{
    public class SupermatchController : Controller
    {
        // GET: Supermatch
        public ActionResult Index()
        {
            using (var db = new AppDbContext())
            {
                var currentUser = db.Users.Find(User.Identity.GetUserId());
                var model = new SupermatchViewModel(currentUser);

                return View(model);
            }

        }
    }
}