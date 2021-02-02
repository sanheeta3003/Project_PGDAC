using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
namespace RationTruckTrackMVC.Controllers
{
    public class DistributorsController : Controller
    {
        // GET: Distributors
        [HttpGet]
        public ActionResult Index()
        {
            List<Distributors> distributorsList = DistributorsBM.GetAllDistributors();
            ViewData["Dlist"] = distributorsList;
            return View();
        }
        [HttpGet]
        public ActionResult Form()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult Login(String uname, long contactNum)
        {
            Distributors dist= DistributorsBM.GetDistributorByLogin(uname, contactNum);
            ViewData["distributor"] = dist;
            return View();
        }
        [HttpGet]
        public ActionResult Regform()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Insert(string name,string address,long mobno)
        {
            DistributorsBM.InsertDistributor(name,address,mobno) ;
            ViewData["msg"] = "Congratulation,Now You are Distributor";
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            List<Ration> RationList = RationBM.GetAllRation();
            ViewData["Rlist"] = RationList;
            return View();
        }
    }
}