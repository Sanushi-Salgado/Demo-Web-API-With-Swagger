using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebAPIWithSwagger.Controllers
{
    #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
