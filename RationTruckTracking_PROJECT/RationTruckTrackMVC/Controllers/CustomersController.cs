using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
namespace RationTruckTrackMVC.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Form()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult Login(string uname, string rationNo)
        {
            Response.Write(uname);
            Response.Write(rationNo);
            Customers customer = CustomerBM.GetCustomerByLogin(uname, rationNo);
             ViewData["customer"] = customer;

            Response.Write(customer.customerContactNumber);

            return View();
        }
    }
}