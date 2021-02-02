using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace RationTruckTrackMVC.Controllers
{
    public class RationController : Controller
    {
        // GET: Ration
        [HttpGet]
        public ActionResult Index()
        {
            List<Ration> RationList = RationBM.GetAllRation();
            ViewData["Rlist"] = RationList;
            return View();
        }
        [HttpGet]
        public ActionResult Form()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Insert(string gname,int cost,int qtn)
        {
            RationBM.InsertRation(gname,cost,qtn);
            return View();
        }
        [HttpGet]
        public ActionResult ById(int id)
        {
           Ration goods= RationBM.GetGoodsById(id);
            ViewData["goods"] = goods;
            return View();
        }
        [HttpGet]
        public ActionResult Update( int cost, int qtn,int id)
        {
            RationBM.UpdateRation(cost, qtn,id);
            return View();
        }
        public ActionResult Delete(int id)
        {
            RationBM.DeleteRation(id);
            return View();
        }

    }
}