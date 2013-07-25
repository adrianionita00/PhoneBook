using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StefaniniPhoneBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Click 'Contacts' tab to view data... ";


            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
