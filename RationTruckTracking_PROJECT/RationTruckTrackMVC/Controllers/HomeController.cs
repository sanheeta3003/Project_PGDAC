using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RationTruckTrackMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult help()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult image()
        {
            ViewBag.Message = "Your image page.";

            return View();
        }
        public ActionResult check()
        {
            ViewBag.Message = "Your checkpost.";

            return View();
        }
        public ActionResult map()
        {
            ViewBag.Message = "Your mahamap.";

            return View();
        }
    }
}