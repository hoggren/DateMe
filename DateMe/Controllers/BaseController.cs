using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Models.Models;

namespace DateMe.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<AppUser> userManager;

        public BaseController() : this(Startup.UserManagerFactory.Invoke())
        {
            
        }

        public BaseController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            Exception e = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(e)
            };
        }
    }
}