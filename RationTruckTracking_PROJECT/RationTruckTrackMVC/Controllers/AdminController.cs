using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace RationTruckTrackMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Form()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Admin> adminList = AdminBM.GetAllAdmin();
            ViewData["Alist"] = adminList;
            return View();
        }
        [HttpGet]
        public ActionResult Login(String email, string empId)
        {
            Admin adm = AdminBM.GetAdminByLogin(email, empId);
            ViewData["admin"] = adm;
            return View();
        }
        public ActionResult Regform()
        {

            return View();
        
        }
        [HttpPost]
        public ActionResult Insert(string mail, string aname, string empid)
        {
            AdminBM.InsertAdmin(  mail, aname, empid);
            ViewData["adminInsert"] = "Congratulations,Now Your are Admin." ;
            return View();
        }
        public ActionResult Delete(int adminId)
        {
            AdminBM.DeleteAdmin(adminId);
            ViewData["adminInsert"] = "Account is deleted.";
            return View();
        }
    }
}