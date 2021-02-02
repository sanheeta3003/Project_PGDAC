using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace RationTruckTrackMVC.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        [HttpGet]
        public ActionResult Index()
        {
            List<TrackingDetails> trackDetails = TrackingBM.GetAllTrackingDetails();
            ViewData["trackDetails"] = trackDetails;
            return View();
        }
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(string tnum,string msg,string dcity,string dd ,string ed,string scity,string stat)
        {
            TrackingBM.InsertTrackingDetails(tnum, msg, dcity, dd, ed, scity, stat);

            return View();
        }
        public ActionResult Uform(int id)
        {
             TrackingDetails td= TrackingBM.GetTrackById(id);
            ViewData["track"] = td;
            return View();
        }
        [HttpPost]
        public ActionResult Update(string msg, string date1, string date2, string stat, int id)
        {
            TrackingBM.UpdateTrackingDetails(msg, date1,date2, stat,id);
            return View();
        }
        public ActionResult Delete(int id)
        {
            TrackingBM.DeleteTrack(id);
            return View();
        }
        public ActionResult Findcity()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult TrackByCity(string city)
        {
           TrackingDetails track= TrackingBM.GetTrackByCity(city);
            ViewData["track"] = track;
            return View();
        }

    }
}