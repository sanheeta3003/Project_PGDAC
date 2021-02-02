using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace RationTruckTrackMVC.Controllers
{
    public class TruckController : Controller
    {
        // GET: Truck
        public ActionResult Index()
        {
            List<TruckDriverDetails> driverDetails = TruckDriverDetailsBM.GetAllTruckDriverDetails();
            ViewData["truck"] = driverDetails;
            return View();
        }
        public ActionResult Form()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Insert(string dname, string regNo,long mobNo)
        {
            TruckDriverDetailsBM.InsertTruckDriverDetails(dname, regNo,mobNo);

            return View();
        }
    }
}