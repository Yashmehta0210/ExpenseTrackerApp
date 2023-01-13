using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker1.Controllers
{
   /* [Authorize]*/
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                return View();
            }
            else 
            { 
                return RedirectToAction("Login", "User");
            }
            
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
    }
}